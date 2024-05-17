using System.ComponentModel;

namespace SDL.Models.Configuration
{
    public class ConfigFile
    {
        [Category("Directory")]
        [Description("Download folder")]
        [DisplayName("Download folder")]
        public string DownloadFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        [Category("Directory")]
        [Description("Temp folder")]
        [DisplayName("Temp folder")]
        public string TempFolder { get; set; }
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SDL_temp");

        [Category("Directory")]
        [Description("FFMPEG folder")]
        [DisplayName("FFMPEG folder")]
        public string FfmpegFolder { get; set; }
            = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg");

        [Category("Download")]
        [Description("Save playlists on own folder")]
        [DisplayName("Save playlists on own folder")]
        public bool SavePlaylistOnOwnFolder { get; set; } = true;

        [Category("Download")]
        [Description("Download album cover")]
        [DisplayName("Download album cover")]
        public bool DownloadCovers { get; set; } = true;

        [Category("Download")]
        [Description("Download song metadata")]
        [DisplayName("Download song metadata")]
        public bool CreateSongMetadata { get; set; } = true;

        [Category("Download")]
        [Description("File name pattern")]
        [DisplayName("File name pattern")]
        public string FileNameTemplate { get; set; } = @"{1}\{2}\{0}";
    }
}
