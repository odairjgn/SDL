using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Image
{
    public class Image
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }
    }
}
