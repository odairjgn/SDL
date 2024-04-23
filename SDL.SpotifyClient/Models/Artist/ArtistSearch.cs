using SDL.SpotifyClient.Interfaces;

namespace SDL.SpotifyClient.Models.Artist
{
    public class ArtistSearch : Artist, ISearchBase
    {
        public string? Url => Id;

        public string? Title => Name;
    }
}
