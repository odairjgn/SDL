using SDL.Models.Enum;
using SDL.Services.Configuration;
using SDL.Services.Ffmpeg;
using SDL.Services.Log;
using SDL.Services.Utils;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Services;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace SDL.Services.Tasks
{
    public class TrackDownloadTask : DownloadTask
    {
        private readonly Track _track;
        private readonly FileInfo _file;

        public string TrackId => _track.Id;

        public override string OutputFile => _file.FullName;

        public TrackDownloadTask(Track track)
        {
            _track = track;
            _file = GenerateName();
        }

        public TrackDownloadTask(Track track, string playListName)
        {
            _track = track;
            _file = GenerateName(playListName);
        }

        private FileInfo GenerateName(string playListName)
        {
            var builder = new FileNameBuider();
            builder.Track = _track;
            builder.Playlist = playListName;
            return builder.Buid();
        }

        private FileInfo GenerateName()
        {
            var builder = new FileNameBuider();
            builder.Track = _track;
            return builder.Buid();
        }

        private void SetupDirectory()
        {
            if (!_file.Directory?.Exists == true)
            {
                _file.Directory!.Create();
            }
        }

        public async override Task Download()
        {
            if (Status == DownloadTaskStatus.Finished)
            {
                return;
            }

            try
            {
                Status = DownloadTaskStatus.Running;
                await FfmpegService.Instance.DownloadFfmpegAsync();
                FfmpegService.Instance.ConfigureFfmpeg();

                var clientSpotify = new SpotifyServices();
                var clientYoutube = new YoutubeClient();
                var youtubeId = await clientSpotify.Track.GetYoutubeIdAsync(_track.Id);
                var youtubeUrl = $"https://youtube.com/watch?v={youtubeId}";
                var streamManifest = await clientYoutube.Videos.Streams.GetManifestAsync(youtubeId);
                var streamUrl = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate().Url;
                SetupDirectory();
                var ok = await FfmpegService.Instance.StreamConvert(streamUrl, _file.FullName);

                if (ok)
                {
                    await AddMetadataAsync();
                    await AddCoverAsync();
                }

                Status = ok ? DownloadTaskStatus.Finished : DownloadTaskStatus.Error;
            }
            catch (Exception ex)
            {
                if (_file.Exists)
                    _file.Delete();

                Status = DownloadTaskStatus.Error;
                LogService.Instance.WriteException(ex);
            }
        }

        private async Task AddMetadataAsync()
        {
            try
            {
                if (!ConfigurationService.ConfigFile.CreateSongMetadata)
                    return;

                var file = TagLib.File.Create(_file.FullName);
                file.Tag.Title = _track.Title;
                file.Tag.Performers = _track.Artists.Select(x => x.Name).ToArray();
                file.Tag.Album = _track.Album?.Name??string.Empty;
                file.Tag.Track = (uint)_track.TrackNumber;
                file.Tag.DateTagged = DateTime.UtcNow;
                file.Tag.Disc = (uint)_track.DiscNumber;
                file.Tag.Genres = _track.Album?.Genres?.ToArray() ?? Array.Empty<string>();
                file.Save();
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        private async Task AddCoverAsync()
        {
            try
            {
                if (!ConfigurationService.ConfigFile.DownloadCovers)
                    return;

                var url = _track.Album?.Images?.FirstOrDefault()?.Url;

                if (string.IsNullOrEmpty(url))
                    return;

                var clientHttp = new HttpClient();
                var imgdata = await clientHttp.GetByteArrayAsync(url);

                TagLib.Picture pic = new TagLib.Picture
                {
                    Type = TagLib.PictureType.FrontCover,
                    Description = "Cover",
                    MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg
                };

                var file = TagLib.File.Create(_file.FullName);
                using var ms = new MemoryStream();
                using var buffer = new MemoryStream(imgdata);
                using var image = Image.FromStream(buffer);
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                pic.Data = TagLib.ByteVector.FromStream(ms);
                file.Tag.Pictures = [pic];
                file.Save();
                ms.Close();
                buffer.Close();
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public override string ToString()
        {
            return $"{_track.Title} - {_track.Artists.FirstOrDefault()?.Name}";
        }
    }
}
