using SDL.SpotifyClient.Enums;
using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Utils;
using System.ComponentModel.DataAnnotations;
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

        public async Task<List<ISearchBase>> GetFilteredRecordsAsync(
            string query,
            CancellationToken cancellationToken = default,
            params TypeSearch[] types)
        {
            ArgumentException.ThrowIfNullOrEmpty(query, nameof(query));

            if (types.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(types));

            var result = new List<ISearchBase>();

            var listType = string.Join(',', types.Select(x => x.ToString().ToLowerInvariant()));

            const decimal MaxLimit = 50;
            var limit = Math.Round(MaxLimit / types.Length);

            var response = await _spotifyHttp.GetAsync(
                $"https://api.spotify.com/v1/search?q={NormalizeSearch(query)}&type={listType}&market=us&limit={limit}&offset=0",
                cancellationToken);

            if (types.Contains(TypeSearch.Album))
            {
                var albums = JsonNode.Parse(response)![$"albums"]!["items"]!.ToString();
                result.AddRange(JsonSerializer.Deserialize<List<AlbumSearch>>(albums, JsonDefault.Options) ?? Enumerable.Empty<ISearchBase>());
            }

            if (types.Contains(TypeSearch.Artist))
            {
                var artists = JsonNode.Parse(response)![$"artists"]!["items"]!.ToString();
                result.AddRange(JsonSerializer.Deserialize<List<ArtistSearch>>(artists, JsonDefault.Options) ?? Enumerable.Empty<ISearchBase>());
            }

            if (types.Contains(TypeSearch.Playlist))
            {
                var playlists = JsonNode.Parse(response)![$"playlists"]!["items"]!.ToString();
                result.AddRange(JsonSerializer.Deserialize<List<PlaylistSearch>>(playlists, JsonDefault.Options) ?? Enumerable.Empty<ISearchBase>());
            }

            if (types.Contains(TypeSearch.Track))
            {
                var tracks = JsonNode.Parse(response)![$"tracks"]!["items"]!.ToString();
                result.AddRange(JsonSerializer.Deserialize<List<TrackSearch>>(tracks, JsonDefault.Options) ?? Enumerable.Empty<ISearchBase>());
            }

            return result;
        }

        public async Task<List<ISearchBase>> GetAllTypesAsync(string query, CancellationToken cancellationToken = default)
        {
            return await GetFilteredRecordsAsync(query, cancellationToken, Enum.GetValues<TypeSearch>());
        }

        private string NormalizeSearch(string search) => Uri.EscapeDataString(search);
    }
}
