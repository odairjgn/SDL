using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IArtistService
    {
        Task<Artist> GetAsync(ArtistId artistId, CancellationToken cancellationToken = default);

        Task<List<Album>> GetAlbumsAsync(ArtistId artistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Album>> GetAllAlbumsAsync(ArtistId artistId, CancellationToken cancellationToken = default);
    }
}
