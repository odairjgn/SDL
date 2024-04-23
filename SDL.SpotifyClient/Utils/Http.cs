namespace SDL.SpotifyClient.Utils
{
    internal class Http
    {
        private static readonly Lazy<HttpClient> _httpClientLazy = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Client => _httpClientLazy.Value;
    }
}
