namespace SDL.Models.Configuration
{
    public class ConfigFile
    {
        public string DownloadFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        public string TempFolder { get; set; }
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SDL_temp");

        public string FfmpegFolder { get; set; }
            = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg");

        public bool SavePlaylistOnOwnFolder { get; set; } = true;

        public bool DownloadCovers { get; set; } = true;

        public bool CreateSongMetadata { get; set; } = true;

        public string FileNameTemplate { get; set; }
    }
}
