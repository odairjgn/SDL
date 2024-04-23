using SDL.SpotifyClient.Models.Common;
using SDL.SpotifyClient.Models.Tracks;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Models.Playlist
{
    public class Playlist : SpotifyEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; } = default!;

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonIgnore]
        public List<Track> Tracks => Items.ConvertAll(x => x.Track);

        [JsonPropertyName("owner")]
        public User.User Owner { get; set; } = default!;

        public override string Url => $"https://open.spotify.com/playlist/{Id}";
    }
}
