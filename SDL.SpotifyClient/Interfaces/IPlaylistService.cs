using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IPlaylistService
    {
        Task<Playlist> GetAsync(PlaylistId playlistId, CancellationToken cancellationToken = default);

        Task<List<Item>> GetItemsAsync(PlaylistId playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Item>> GetAllItemsAsync(PlaylistId playlistId, CancellationToken cancellationToken = default);

        Task<List<Track>> GetTracksAsync(PlaylistId playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Track>> GetAllTracksAsync(PlaylistId playlistId, CancellationToken cancellationToken = default);
    }
}
