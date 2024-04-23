using SDL.SpotifyClient.Enums;

namespace SDL.SpotifyClient.Interfaces
{
    public interface ISearchService
    {
        Task<List<ISearchBase>> GetFilteredRecordsAsync(string query, CancellationToken cancellationToken = default, params TypeSearch[] types);

        Task<List<ISearchBase>> GetAllTypesAsync(string query, CancellationToken cancellationToken = default);
    }
}
