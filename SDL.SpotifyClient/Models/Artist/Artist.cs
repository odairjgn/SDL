using SDL.SpotifyClient.Models.Common;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Artist
{
    public class Artist : SpotifyEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; } = default!;

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("images")]
        public List<Image.Image> Images { get; set; } = default!;

        public override string Url => $"https://open.spotify.com/artist/{Id}";
    }
}
