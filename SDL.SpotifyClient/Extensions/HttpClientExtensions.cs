namespace SDL.SpotifyClient.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<string> ExecuteAsync(this HttpClient client, HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            if (!request.Headers.Contains("User-Agent"))
            {
                request.Headers.Add("User-Agent", "Other");
            }

            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return string.Empty;

            var teste = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {(int)response.StatusCode}, Request: {request}");

            return await response.Content.ReadAsStringAsync();
        }

        public static async ValueTask<string> ExecuteAsync(
            this HttpClient http,
            string url,
            IDictionary<string, string> headers,
            CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            for (var j = 0; j < headers.Count; j++)
                request.Headers.TryAddWithoutValidation(headers.ElementAt(j).Key, headers.ElementAt(j).Value);

            return await http.ExecuteAsync(request, cancellationToken);
        }

        public static async ValueTask<string> PostAsync(
            this HttpClient http,
            string url,
            IDictionary<string, string>? headers,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            for (var j = 0; j < headers?.Count; j++)
                request.Headers.TryAddWithoutValidation(headers.ElementAt(j).Key, headers.ElementAt(j).Value);

            request.Content = content;

            return await http.ExecuteAsync(request, cancellationToken);
        }
    }
}
