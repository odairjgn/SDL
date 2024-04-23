using SDL.SpotifyClient.Interfaces;

namespace SDL.SpotifyClient.Models.Album
{
    public class AlbumSearch : Album, ISearchBase
    {
        public string? Title => Name;
    }
}
