using SDL.SpotifyClient.Utils;
using System.Text.RegularExpressions;

namespace SDL.SpotifyClient.Models.Playlist
{
    public readonly struct PlaylistId : IEquatable<PlaylistId>
    {
        public string Value { get; }

        private PlaylistId(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsValid(string playlistId)
        {
            if (playlistId.Length != 22)
            {
                return false;
            }

            return !Regex.IsMatch(playlistId, "[^0-9a-zA-Z_\\-]");
        }

        private static string? TryNormalize(string? playlistIdOrUrl)
        {
            if (string.IsNullOrWhiteSpace(playlistIdOrUrl))
            {
                return null;
            }

            if (IsValid(playlistIdOrUrl))
            {
                return playlistIdOrUrl;
            }

            string value = Regex.Match(playlistIdOrUrl, "spotify\\..+?\\/playlist\\/([a-zA-Z0-9]+)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(value) && IsValid(value))
            {
                return value;
            }

            string value2 = Regex.Match(playlistIdOrUrl, "spotify\\..+?\\/v1\\/playlists\\/([a-zA-Z0-9]+)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(value2) && IsValid(value2))
            {
                return value2;
            }

            return null;
        }

        public static PlaylistId? TryParse(string? playlistIdOrUrl)
        {
            return TryNormalize(playlistIdOrUrl)?.Pipe((string id) => new PlaylistId(id));
        }

        public static PlaylistId Parse(string playlistIdOrUrl)
        {
            return TryParse(playlistIdOrUrl) ?? throw new ArgumentException("Invalid Spotify track ID or URL '" + playlistIdOrUrl + "'.");
        }

        public static implicit operator PlaylistId(string playlistIdOrUrl)
        {
            return Parse(playlistIdOrUrl);
        }

        public static implicit operator string(PlaylistId playlistId)
        {
            return playlistId.ToString();
        }

        public bool Equals(PlaylistId other)
        {
            return StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is PlaylistId other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public static bool operator ==(PlaylistId left, PlaylistId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlaylistId left, PlaylistId right)
        {
            return !(left == right);
        }
    }
}
