using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly SpotifyAuthenticatedClient _client;

        public AlbumService(HttpClient httpClient)
        {
            _client = new SpotifyAuthenticatedClient(httpClient);
        }

        public async Task<List<Track>> GetAllTracksAsync(AlbumId albumId, CancellationToken cancellationToken = default)
        {
            var tracks = new List<Track>();

            var offset = 0;

            while (true)
            {
                var temp = await GetTracksAsync(
                    albumId,
                    offset,
                    limit: 50,
                    cancellationToken
                );

                tracks.AddRange(temp);

                if (temp.Count < 4)
                    break;

                offset += tracks.Count;
            }

            return tracks;
        }

        public async Task<Album> GetAsync(AlbumId albumId, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/albums/{albumId}",
                cancellationToken
            );

            var album = JsonSerializer.Deserialize<Album>(response, JsonDefault.Options);

            var items = JsonNode.Parse(response)!["tracks"]?["items"]?.ToString();
            if (!string.IsNullOrEmpty(items))
            {
                var albumTracks = JsonSerializer.Deserialize<List<Track>>(items, JsonDefault.Options) ?? Enumerable.Empty<Track>().ToList();
                albumTracks.ForEach(track => track.Album = album);
                album.Tracks = albumTracks;
            }

            return album;
        }

        public async Task<List<Track>> GetTracksAsync(AlbumId albumId, int offSet = 0, int limit = 50, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/albums/{albumId}/tracks?offset={offSet}&limit={limit}",
                cancellationToken
            );

            var albumTracks = JsonNode.Parse(response)!["items"]!.ToString();

            return JsonSerializer.Deserialize<List<Track>>(albumTracks, JsonDefault.Options);
        }
    }
}
