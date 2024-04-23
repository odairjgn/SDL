using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface ITrackService
    {
        Task<Track> GetAsync(string trackId, CancellationToken cancellationToken = default);

        Task<string?> GetYoutubeIdAsync(string trackId, CancellationToken cancellationToken = default);

        Task<string?> GetDownloadUrlAsync(string trackId, CancellationToken cancellationToken = default);

        Task<string?> GetSpotifymateUrlAsync(string trackId, CancellationToken cancellationToken = default);

        Task<string?> GetSpotifyDownloaderUrlAsync(string trackId, CancellationToken cancellationToken = default);
    }
}
