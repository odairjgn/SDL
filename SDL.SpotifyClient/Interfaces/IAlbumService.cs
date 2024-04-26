using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface IAlbumService
    {
        Task<Album> GetAsync(AlbumId albumId, CancellationToken cancellationToken = default);

        Task<List<Track>> GetTracksAsync(AlbumId albumId, int offSet = 0, int limit = 50, CancellationToken cancellationToken = default);

        Task<List<Track>> GetAllTracksAsync(AlbumId albumId, CancellationToken cancellationToken = default);
    }
}
