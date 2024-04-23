using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IArtistService
    {
        Task<Artist> GetAsync(string artistId, CancellationToken cancellationToken = default);

        Task<List<Album>> GetAlbumsAsync(string artistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Album>> GetAllAlbumsAsync(string artistId, CancellationToken cancellationToken = default);
    }
}
