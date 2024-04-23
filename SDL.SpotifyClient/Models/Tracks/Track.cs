using SDL.SpotifyClient.Models.Common;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Tracks
{
    public class Track : SpotifyEntity
    {
        [JsonPropertyName("name")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("available_markets")]
        public List<string> AvailableMarkets { get; set; } = default!;

        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }

        [JsonPropertyName("duration_ms")]
        public long DurationMs { get; set; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }

        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; } = default!;

        [JsonPropertyName("album")]
        public Album.Album Album { get; set; } = default!;

        [JsonPropertyName("artists")]
        public List<Artist.Artist> Artists { get; set; } = default!;

        public override string Url => $"https://open.spotify.com/track/{Id}";
    }
}
