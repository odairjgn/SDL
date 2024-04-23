using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IPlaylistService
    {
        Task<Playlist> GetAsync(string playlistId, CancellationToken cancellationToken = default);

        Task<List<Item>> GetItemsAsync(string playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Item>> GetAllItemsAsync(string playlistId, CancellationToken cancellationToken = default);

        Task<List<Track>> GetTracksAsync(string playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Track>> GetAllTracksAsync(string playlistId, CancellationToken cancellationToken = default);
    }
}
