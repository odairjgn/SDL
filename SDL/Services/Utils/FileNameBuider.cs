using SDL.SpotifyClient.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Services.Utils
{
    public class FileNameBuider
    {
        public DirectoryInfo Root { get; set; } = new DirectoryInfo(Directory.GetCurrentDirectory());

        public Track Track { get; set; }

        public string Pattern { get; set; } = @"{1}\{2}\{0}";

        public string Extension { get; set; } = ".mp3";

        public FileInfo Buid()
        {
            var fragment = string.Format(Pattern, 
                Track.Title.ToSafeFilePath(),
                Track.Artists.First().Name.ToSafeFilePath(),
                Track.Album?.Name?.ToSafeFilePath());
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
            sb.AppendLine("5: Track Number");

            //Track.Popularity
            sb.AppendLine("6: Popularity");

            //DateTime.Now
            sb.AppendLine("7: Current DateTime");

            return sb.ToString();
        }
    }
}
