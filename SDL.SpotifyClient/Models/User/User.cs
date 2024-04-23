using SDL.SpotifyClient.Models.Common;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.User
{
    public class User : SpotifyEntity
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = default!;

        [JsonPropertyName("images")]
        public List<Image.Image> Images { get; set; } = default!;

        public override string Url => $"https://open.spotify.com/user/{Id}";
    }
}
