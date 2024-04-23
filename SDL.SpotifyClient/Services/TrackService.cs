using HtmlAgilityPack;
using SDL.SpotifyClient.Extensions;
using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient.Services
{
    public class TrackService : ITrackService
    {
        private readonly SpotifyAuthenticatedClient _client;
        private readonly HttpClient _httpClient;

        public TrackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _client = new SpotifyAuthenticatedClient(httpClient);
        }

        public async Task<Track> GetAsync(string trackId, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync(
                $"https://api.spotify.com/v1/tracks/{trackId}",
                cancellationToken
            );

            return JsonSerializer.Deserialize<Track>(response, JsonDefault.Options)!;
        }

        public async Task<string?> GetDownloadUrlAsync(string trackId, CancellationToken cancellationToken = default)
        {
            var url = "";

            try
            {
                url = await GetSpotifyDownloaderUrlAsync(trackId, cancellationToken);
            }
            catch { }

            
            if (string.IsNullOrEmpty(url))
                url = await GetSpotifymateUrlAsync(trackId, cancellationToken);

            return url;
        }

        public async Task<string?> GetSpotifyDownloaderUrlAsync(string trackId, CancellationToken cancellationToken = default)
        {
            var formContent = new FormUrlEncodedContent(
            [
                new("link", $"https://open.spotify.com/track/{trackId}")
            ]);

            var response = await _httpClient.PostAsync(
                "https://api.spotify-downloader.com/",
                null,
                formContent,
                cancellationToken
            );

            return JsonNode.Parse(response)!["audio"]?["url"]?.ToString();
        }

        public async Task<string?> GetSpotifymateUrlAsync(string trackId, CancellationToken cancellationToken = default)
        {
            var formContent = new FormUrlEncodedContent(
            [
                new("url", $"https://open.spotify.com/track/{trackId}"),
                await GetSpotifymateToken(cancellationToken)
            ]);

            var response = await _httpClient.PostAsync(
                "https://spotifymate.com/action",
                null,
                formContent,
                cancellationToken
            );

            if (string.IsNullOrEmpty(response))
                return null;

            var document = new HtmlDocument();
            document.LoadHtml(response);

            return document.GetElementbyId("download-block")?
                .SelectSingleNode(".//a")?.Attributes["href"]?.Value;
        }

        public async Task<string?> GetYoutubeIdAsync(string trackId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.ExecuteAsync(
                $"https://api.spotifydown.com/getId/{trackId}",
                new Dictionary<string, string>()
                {
                    { "referer", "https://spotifydown.com/" },
                    { "origin", "https://spotifydown.com" }
                },
                cancellationToken
            );

            if (string.IsNullOrEmpty(response))
                return null;

            var data = JsonNode.Parse(response)!;

            _ = bool.TryParse(data["success"]?.ToString(), out var success);

            if (!success)
                throw new Exception(data["message"]!.ToString());

            return JsonNode.Parse(response)?["id"]!.ToString();
        }

        private async Task<KeyValuePair<string?, string?>> GetSpotifymateToken(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://spotifymate.com/");

            var html = await _httpClient.ExecuteAsync(
                request,
                cancellationToken
            );

            var document = new HtmlDocument();
            document.LoadHtml(html);

            var hiddenInput = document.GetElementbyId("get_video")?.SelectSingleNode("//input[@type=\"hidden\"]")?.Attributes;

            return new KeyValuePair<string?, string?>(hiddenInput?["name"]?.Value, hiddenInput?["value"]?.Value);
        }
    }
}
