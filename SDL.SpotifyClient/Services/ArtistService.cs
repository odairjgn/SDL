using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient.Services
{
    public class ArtistService : IArtistService
    {
        private readonly SpotifyAuthenticatedClient _client;

        public ArtistService(HttpClient httpClient)
        {
            _client = new SpotifyAuthenticatedClient(httpClient);
        }

        public async Task<List<Album>> GetAlbumsAsync(string artistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/artists/{artistId}/albums?offset={offset}&limit={limit}",
                cancellationToken
            );

            var artistAlbums = JsonNode.Parse(response)!["items"]!.ToString();

            return JsonSerializer.Deserialize<List<Album>>(artistAlbums, JsonDefault.Options);
        }

        public async Task<List<Album>> GetAllAlbumsAsync(string artistId, CancellationToken cancellationToken = default)
        {
            var artistAlbums = new List<Album>();

            var offset = 0;

            while (true)
            {
                var albums = await GetAlbumsAsync(
                    artistId,
                    offset,
                    limit: 50,
                    cancellationToken
                );

                artistAlbums.AddRange(albums);

                if (albums.Count < 4)
                    break;

                offset += albums.Count;
            }

            return artistAlbums;
        }

        public async Task<Artist> GetAsync(string artistId, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/artists/{artistId}",
                cancellationToken
            );

            return JsonSerializer.Deserialize<Artist>(response, JsonDefault.Options);
        }
    }
}
