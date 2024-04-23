namespace SDL.SpotifyClient.Interfaces
{
    public interface ISpotifyServices
    {
        ISearchService Search { get; }

        IAlbumService Album { get; }

        IArtistService Artist { get; }

        ITrackService Track { get; }

        IPlaylistService Playlist { get; }
    }
}
