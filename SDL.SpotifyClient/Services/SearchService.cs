using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient.Services
{
    public class SearchService : ISearchService
    {
        private readonly SpotifyAuthenticatedClient _spotifyHttp;

        public SearchService(HttpClient httpClient)
        {
            _spotifyHttp = new SpotifyAuthenticatedClient(httpClient);
        }

        public async Task<List<ISearchBase>> GetAlbumsAsync(string search, CancellationToken cancellationToken = default)
        {
            return await GetSearchInternalAsync<AlbumSearch>(search, "album", cancellationToken: cancellationToken);
        }

        public async Task<List<ISearchBase>> GetArtistsAsync(string search, CancellationToken cancellationToken = default)
        {
            return await GetSearchInternalAsync<ArtistSearch>(search, "artist", cancellationToken: cancellationToken);
        }

        public async Task<List<ISearchBase>> GetPlaylistsAsync(string search, CancellationToken cancellationToken = default)
        {
            return await GetSearchInternalAsync<PlaylistSearch>(search, "playlist", cancellationToken: cancellationToken);
        }

        public async Task<List<ISearchBase>> GetTracksAsync(string search, CancellationToken cancellationToken = default)
        {
            return await GetSearchInternalAsync<TrackSearch>(search, "track", cancellationToken: cancellationToken);
        }

        private async Task<List<ISearchBase>> GetSearchInternalAsync<TModelResult>(
            string search,
            string type,
            int limit = 50,
            int offSet = 0,
            CancellationToken cancellationToken = default)
            where TModelResult : class, ISearchBase
        {
            var response = await _spotifyHttp.GetAsync(
                $"https://api.spotify.com/v1/search?q={NormalizeSearch(search)}&type={type}&market=us&limit={limit}&offset={offSet}",
                cancellationToken);

            var result = new List<ISearchBase>();

            var playlists = JsonNode.Parse(response)![$"{type}s"]!["items"]!.ToString();
            result.AddRange(JsonSerializer.Deserialize<List<TModelResult>>(playlists, JsonDefault.Options) ?? Enumerable.Empty<ISearchBase>());

            return result;
        }

        private string NormalizeSearch(string search) => Uri.EscapeDataString(search);
    }
}
