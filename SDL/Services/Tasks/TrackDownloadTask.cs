using SDL.Models.Enum;
using SDL.Services.Ffmpeg;
using SDL.Services.Log;
using SDL.Services.Utils;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Services;
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

        public override string ToString()
        {
            return $"{_track.Title} - {_track.Artists.FirstOrDefault()?.Name}";
        }
    }
}
