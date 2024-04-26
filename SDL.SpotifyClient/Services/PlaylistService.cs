using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Models.User;
using SDL.SpotifyClient.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly SpotifyAuthenticatedClient _client;

        public PlaylistService(HttpClient httpClient)
        {
            _client = new SpotifyAuthenticatedClient(httpClient);
        }

        public async Task<List<Item>> GetAllItemsAsync(PlaylistId playlistId, CancellationToken cancellationToken = default)
        {
            var playlistItems = new List<Item>();

            var offset = 0;

            while (true)
            {
                var tracks = await GetItemsAsync(
                    playlistId,
                    offset,
                    limit: 50,
                    cancellationToken
                );

                playlistItems.AddRange(tracks);

                if (tracks.Count < 4)
                    break;

                offset += tracks.Count;
            }

            return playlistItems;
        }

        public async Task<List<Track>> GetAllTracksAsync(PlaylistId playlistId, CancellationToken cancellationToken = default)
        {
            return (await GetAllItemsAsync(playlistId, cancellationToken)).ConvertAll(x => x.Track);

        }

        public async Task<Playlist> GetAsync(PlaylistId playlistId, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/playlists/{playlistId}",
                cancellationToken
            );

            var playlistJObj = JsonNode.Parse(response);
            var tracksItems = playlistJObj!["tracks"]?["items"]?.ToString() ?? playlistJObj["items"]!.ToString();

            var palylist = JsonSerializer.Deserialize<Playlist>(response, JsonDefault.Options)!;
            palylist.Items = JsonSerializer.Deserialize<List<Item>>(tracksItems, JsonDefault.Options)!;

            return palylist;
        }

        public async Task<List<Item>> GetItemsAsync(PlaylistId playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/playlists/{playlistId}/tracks?offset={offset}&limit={limit}",
                cancellationToken
            );

            var playlistJObj = JsonNode.Parse(response);

            var tracksItems = playlistJObj!["tracks"]?["items"]?.ToString()
                ?? playlistJObj["items"]?.ToString();

            var list = new List<Item>();

            if (string.IsNullOrEmpty(tracksItems))
                return list;

            foreach (var token in JsonNode.Parse(tracksItems!)!.AsArray())
            {
                var item = JsonSerializer.Deserialize<Item>(token!.ToString(), JsonDefault.Options)!;

                var userId = token["added_by"]?["id"]?.ToString();
                if (!string.IsNullOrEmpty(userId))
                {
                    item.AddedBy = JsonSerializer.Deserialize<User>(
                        token["added_by"]!.ToString(), JsonDefault.Options)!;
                }

                list.Add(item);
            }

            return list;
        }

        public async Task<List<Track>> GetTracksAsync(PlaylistId playlistId, int offset = 0, int limit = 50, CancellationToken cancellationToken = default)
        {
            return (await GetItemsAsync(playlistId, offset, limit, cancellationToken)).ConvertAll(x => x.Track);
        }
    }
}
