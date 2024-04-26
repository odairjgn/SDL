using SDL.SpotifyClient.Utils;
using System.Text.RegularExpressions;

namespace SDL.SpotifyClient.Models.Artist
{
    public readonly struct ArtistId : IEquatable<ArtistId>
    {
        public string Value { get; }

        private ArtistId(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsValid(string artistId)
        {
            if (artistId.Length != 22)
            {
                return false;
            }

            return !Regex.IsMatch(artistId, "[^0-9a-zA-Z_\\-]");
        }

        private static string? TryNormalize(string? artistIdOrUrl)
        {
            if (string.IsNullOrWhiteSpace(artistIdOrUrl))
            {
                return null;
            }

            if (IsValid(artistIdOrUrl))
            {
                return artistIdOrUrl;
            }

            string value = Regex.Match(artistIdOrUrl, "spotify\\..+?\\/artist\\/([a-zA-Z0-9]+)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(value) && IsValid(value))
            {
                return value;
            }

            return null;
        }

        public static ArtistId? TryParse(string? artistIdOrUrl)
        {
            return TryNormalize(artistIdOrUrl)?.Pipe((string id) => new ArtistId(id));
        }

        public static ArtistId Parse(string artistIdOrUrl)
        {
            return TryParse(artistIdOrUrl) ?? throw new ArgumentException("Invalid Spotify track ID or URL '" + artistIdOrUrl + "'.");
        }

        public static implicit operator ArtistId(string artistIdOrUrl)
        {
            return Parse(artistIdOrUrl);
        }

        public static implicit operator string(ArtistId artistId)
        {
            return artistId.ToString();
        }

        public bool Equals(ArtistId other)
        {
            return StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is ArtistId other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public static bool operator ==(ArtistId left, ArtistId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ArtistId left, ArtistId right)
        {
            return !(left == right);
        }
    }
}
