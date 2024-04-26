using SDL.SpotifyClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SDL.SpotifyClient.Models.Tracks
{
    public readonly struct TrackId : IEquatable<TrackId>
    {
        public string Value { get; }

        private TrackId(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsValid(string trackId)
        {
            if (trackId.Length != 22)
            {
                return false;
            }

            return !Regex.IsMatch(trackId, "[^0-9a-zA-Z_\\-]");
        }

        private static string? TryNormalize(string? trackIdOrUrl)
        {
            if (string.IsNullOrWhiteSpace(trackIdOrUrl))
            {
                return null;
            }

            if (IsValid(trackIdOrUrl))
            {
                return trackIdOrUrl;
            }

            string value = Regex.Match(trackIdOrUrl, "spotify\\..+?\\/track\\/([a-zA-Z0-9]+)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(value) && IsValid(value))
            {
                return value;
            }

            return null;
        }

        public static TrackId? TryParse(string? trackIdOrUrl)
        {
            return TryNormalize(trackIdOrUrl)?.Pipe((string id) => new TrackId(id));
        }

        public static TrackId Parse(string trackIdOrUrl)
        {
            return TryParse(trackIdOrUrl) ?? throw new ArgumentException("Invalid Spotify track ID or URL '" + trackIdOrUrl + "'.");
        }

        public static implicit operator TrackId(string trackIdOrUrl)
        {
            return Parse(trackIdOrUrl);
        }

        public static implicit operator string(TrackId trackId)
        {
            return trackId.ToString();
        }

        public bool Equals(TrackId other)
        {
            return StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is TrackId other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public static bool operator ==(TrackId left, TrackId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TrackId left, TrackId right)
        {
            return !(left == right);
        }
    }
}
