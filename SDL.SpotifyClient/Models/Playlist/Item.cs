using SDL.SpotifyClient.Models.Tracks;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Playlist
{
    public class Item
    {
        [JsonPropertyName("added_at")]
        public DateTime AddedAt { get; set; }

        public User.User? AddedBy { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; } = default!;
    }
}
