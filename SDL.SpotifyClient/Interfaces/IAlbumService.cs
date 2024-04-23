using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IAlbumService
    {
        Task<Album> GetAsync(string albumId, CancellationToken cancellationToken = default);

        Task<List<Track>> GetTracksAsync(string albumId, int offSet = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Track>> GetAllTracksAsync(string albumId, CancellationToken cancellationToken = default);
    }
}
