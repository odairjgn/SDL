using SDL.SpotifyClient.Models.Tracks;

namespace SDL.SpotifyClient.Interfaces
{
    public interface ITrackService
    {
        Task<Track> GetAsync(TrackId trackId, CancellationToken cancellationToken = default);

        Task<string?> GetYoutubeIdAsync(TrackId trackId, CancellationToken cancellationToken = default);

        Task<string?> GetDownloadUrlAsync(TrackId trackId, CancellationToken cancellationToken = default);

        Task<string?> GetSpotifymateUrlAsync(TrackId trackId, CancellationToken cancellationToken = default);

        Task<string?> GetSpotifyDownloaderUrlAsync(TrackId trackId, CancellationToken cancellationToken = default);
    }
}
