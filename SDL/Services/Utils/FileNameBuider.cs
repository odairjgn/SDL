using SDL.Services.Configuration;
using SDL.SpotifyClient.Models.Tracks;
using System.Text;

namespace SDL.Services.Utils
{
    public class FileNameBuider
    {
        public DirectoryInfo Root { get; set; }
            = new DirectoryInfo(ConfigurationService.ConfigFile.DownloadFolder);

        public Track Track { get; set; }

        public string Pattern { get; set; } = @"{1}\{2}\{0}";

        public string Extension { get; set; } = ".mp3";

        public string Playlist { get; set; }

        public FileInfo Buid()
        {
            if (Playlist != null)
            {
                var filepl = Path.Combine(
                    Root.FullName,
                    Playlist.ToSafeFilePath(),
                    $"{Track.Title.ToSafeFilePath()}{Extension}");

                return new FileInfo(filepl);
            }

            var fragment = string.Format(Pattern,
                Track.Title,
                Track.Artists.First().Name,
                Track.Album?.Name,
                Track.Album?.Genres.FirstOrDefault(),
                Track.TrackNumber,
                Track.DiscNumber,
                Track.Popularity,
                DateTime.Now);

            var file = Path.Combine(Root.FullName, $"{fragment.ToSafeFilePath()}{Extension}");
            return new FileInfo(file);
        }

        public static string GetHelpText()
        {
            var sb = new StringBuilder();

            //Track.Title
            sb.AppendLine("0: Track name");

            //Track.Artists[0].Name
            sb.AppendLine("1: Artist");

            //Track.Album.Name
            sb.AppendLine("2: Album");

            //Track.Album.Genres[0]
            sb.AppendLine("3: Genre");

            //Track.TrackNumber
            sb.AppendLine("4: Track Number");

            //Track.DiskNumber
            sb.AppendLine("5: Disk Number");

            //Track.Popularity
            sb.AppendLine("6: Popularity");

            //DateTime.Now
            sb.AppendLine("7: Current DateTime");

            return sb.ToString();
        }
    }
}
