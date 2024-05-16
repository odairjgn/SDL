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
                tracks.ForEach(x => AddTrack(x));
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
                tracks.ForEach(x => AddTrack(x, list.Name));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        public static async Task AddTrack(Track track, string? playList = null)
        {
            var dlTask = playList == null
                ? new TrackDownloadTask(track)
                : new TrackDownloadTask(track, playList);

            if (Tasks.Any(x => x.OutputFile == dlTask.OutputFile))
                return;

            Tasks.Add(dlTask);
            await Task.CompletedTask;
        }
    }
}
