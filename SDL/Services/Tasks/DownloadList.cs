using SDL.Services.Log;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Services;
using System.Collections.ObjectModel;

namespace SDL.Services.Tasks
{
    public static class DownloadList
    {
        static DownloadList()
        {
            Tasks = new ObservableCollection<DownloadTask>();
        }

        public static ObservableCollection<DownloadTask> Tasks { get; private set; }

        public static async Task AddArtistAsync(Artist artist)
        {
            try
            {
                var client = new SpotifyServices();
                var albuns = await client.Artist.GetAllAlbumsAsync(artist.Id);
                albuns.ForEach(async x => await AddAlbumAsync(x));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddAlbumAsync(Album album)
        {
            try
            {
                var client = new SpotifyServices();
                var tracks = await client.Album.GetTracksAsync(album.Id);
                tracks.ForEach(async x => await AddTrackAsync(x));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddPlaylistAsync(Playlist list)
        {
            try
            {
                var client = new SpotifyServices();
                var tracks = await client.Playlist.GetTracksAsync(list.Id);
                tracks.ForEach(async x => await AddTrackAsync(x, list.Name));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddTrackAsync(Track track, string? playList = null)
        {
            var dlTask = playList == null
                ? new TrackDownloadTask(track)
                : new TrackDownloadTask(track, playList);

            if (Tasks.Any(x => x.OutputFile == dlTask.OutputFile))
                return;

            Tasks.Add(dlTask);
            await Task.CompletedTask;
        }

        public static async Task AddIdAsync(TrackId trackId)
        {
            try
            {
                var client = new SpotifyServices();
                var track = await client.Track.GetAsync(trackId);
                await AddTrackAsync(track);
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddIdAsync(PlaylistId playListId)
        {
            try
            {
                var client = new SpotifyServices();
                var playlist = await client.Playlist.GetAsync(playListId);
                await AddPlaylistAsync(playlist);
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddIdAsync(AlbumId albumId)
        {
            try
            {
                var client = new SpotifyServices();
                var album = await client.Album.GetAsync(albumId);
                await AddAlbumAsync(album);
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddIdAsync(ArtistId artistId)
        {
            try
            {
                var client = new SpotifyServices();
                var artist = await client.Artist.GetAsync(artistId);
                await AddArtistAsync(artist);
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }
    }
}
