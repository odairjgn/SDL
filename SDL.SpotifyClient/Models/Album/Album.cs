using SDL.SpotifyClient.Models.Common;
using SDL.SpotifyClient.Models.Tracks;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Album
{
    public class Album : SpotifyEntity
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("album_type")]
        public AlbumType AlbumType { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonPropertyName("available_markets")]
        public List<string> AvailableMarkets { get; set; } = default!;

        [JsonIgnore]
        public List<Track> Tracks { get; set; } = default!;

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; } = default!;

        [JsonPropertyName("artists")]
        public List<Artist.Artist> Artists { get; set; } = default!;

        [JsonPropertyName("images")]
        public List<Image.Image> Images { get; set; } = default!;

        public override string Url => $"https://open.spotify.com/album/{Id}";
    }
}
