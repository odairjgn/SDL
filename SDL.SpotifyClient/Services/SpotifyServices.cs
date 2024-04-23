using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Utils;

namespace SDL.SpotifyClient.Services
{
    public class SpotifyServices : ISpotifyServices
    {
        private readonly HttpClient _httpClient;

        public SpotifyServices()
        {
            _httpClient = Http.Client;
        }

        public ISearchService Search => new SearchService(_httpClient);

        public IAlbumService Album => new AlbumService(_httpClient);

        public IArtistService Artist => new ArtistService(_httpClient);

        public ITrackService Track => new TrackService(_httpClient);

        public IPlaylistService Playlist => new PlaylistService(_httpClient);
    }
}
