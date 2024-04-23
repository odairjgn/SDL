using System.Runtime.Serialization;

namespace SDL.SpotifyClient.Models.Album
{
    public enum AlbumType
    {
        [EnumMember(Value = "album")]
        Album,

        [EnumMember(Value = "single")]
        Single,

        [EnumMember(Value = "compilation")]
        Compilation
    }
}
