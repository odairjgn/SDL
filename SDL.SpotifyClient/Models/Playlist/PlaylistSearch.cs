using SDL.SpotifyClient.Interfaces;

namespace SDL.SpotifyClient.Models.Playlist
{
    public class PlaylistSearch : Playlist, ISearchBase
    {
        public string? Url => Id;

        public string? Title => Name;
    }
}
