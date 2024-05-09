using SDL.SpotifyClient.Models.Tracks;

namespace SDL.Services.Tasks
{
    public class TrackDownloadTask : DownloadTask
    {
        private readonly Track _track;
        private readonly FileInfo _file;

        public TrackDownloadTask(Track track)
        {
            _track = track;
            _file = GenerateName();
        }

        public TrackDownloadTask(Track track, string playListName)
        {
            _track = track;
            _file = GenerateName(playListName);
        }

        private FileInfo GenerateName(string playListName)
        {
            throw new NotImplementedException();
        }

        private FileInfo GenerateName()
        {
            return new FileInfo("C:/didi.txt");
        }

        public override Task Download()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{_track.Title} - {_track.Artists.FirstOrDefault()?.Name}";
        }
    }
}
