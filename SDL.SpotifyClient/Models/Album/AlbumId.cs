using SDL.SpotifyClient.Utils;
using System.Text.RegularExpressions;

namespace SDL.SpotifyClient.Models.Album
{
    public readonly struct AlbumId : IEquatable<AlbumId>
    {
        public string Value { get; }

        private AlbumId(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsValid(string albumId)
        {
            if (albumId.Length != 22)
            {
                return false;
            }

            return !Regex.IsMatch(albumId, "[^0-9a-zA-Z_\\-]");
        }

        private static string? TryNormalize(string? albumIdOrUrl)
        {
            if (string.IsNullOrWhiteSpace(albumIdOrUrl))
            {
                return null;
            }

            if (IsValid(albumIdOrUrl))
            {
                return albumIdOrUrl;
            }

            string value = Regex.Match(albumIdOrUrl, "spotify\\..+?\\/album\\/([a-zA-Z0-9]+)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(value) && IsValid(value))
            {
                return value;
            }

            return null;
        }

        public static AlbumId? TryParse(string? albumIdOrUrl)
        {
            return TryNormalize(albumIdOrUrl)?.Pipe((string id) => new AlbumId(id));
        }

        public static AlbumId Parse(string albumIdOrUrl)
        {
            return TryParse(albumIdOrUrl) ?? throw new ArgumentException("Invalid Spotify track ID or URL '" + albumIdOrUrl + "'.");
        }

        public static implicit operator AlbumId(string albumIdOrUrl)
        {
            return Parse(albumIdOrUrl);
        }

        public static implicit operator string(AlbumId albumId)
        {
            return albumId.ToString();
        }

        public bool Equals(AlbumId other)
        {
            return StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is AlbumId other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public static bool operator ==(AlbumId left, AlbumId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AlbumId left, AlbumId right)
        {
            return !(left == right);
        }
    }
}
