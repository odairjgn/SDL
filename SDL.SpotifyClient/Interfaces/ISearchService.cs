namespace SDL.SpotifyClient.Interfaces
{
    public interface ISearchService
    {
        Task<List<ISearchBase>> GetPlaylistsAsync(string search, CancellationToken cancellationToken = default);

        Task<List<ISearchBase>> GetAlbumsAsync(string search, CancellationToken cancellationToken = default);

        Task<List<ISearchBase>> GetArtistsAsync(string search, CancellationToken cancellationToken = default);

        Task<List<ISearchBase>> GetTracksAsync(string search, CancellationToken cancellationToken = default);
    }
}
