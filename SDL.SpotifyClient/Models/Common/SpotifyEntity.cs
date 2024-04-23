using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Common
{
    public abstract class SpotifyEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public abstract string Url { get; }
    }
}
