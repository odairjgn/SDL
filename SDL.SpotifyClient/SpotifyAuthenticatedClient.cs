using SDL.SpotifyClient.Extensions;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace SDL.SpotifyClient
{
    public class SpotifyAuthenticatedClient
    {
        private readonly HttpClient _httpClient;

        public SpotifyAuthenticatedClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<string> GetAsync(string url, CancellationToken cancellationToken = default)
        {
            var bearerToken = await GetBearerTokenAsync(cancellationToken);

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            
            return await _httpClient.ExecuteAsync(request, cancellationToken);
        }

        private async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://open.spotify.com/get_access_token?reason=transport&productType=web_player"
            );

            var response = await _httpClient.ExecuteAsync(request, cancellationToken);

            var responseJson = JsonNode.Parse(response);

            return responseJson["accessToken"]?.ToString();
        }
    }
}
