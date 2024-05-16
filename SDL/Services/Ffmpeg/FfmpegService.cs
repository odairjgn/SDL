using FFMpegCore;
using GithubReleaseDownloader;
using GithubReleaseDownloader.Entities;
using SDL.Services.Configuration;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.IO.Compression;

namespace SDL.Services.Ffmpeg
{
    public class FfmpegService
    {
        private static FfmpegService _instance;
        public static FfmpegService Instance => _instance ??= new FfmpegService();

        private bool _configured;

        private FfmpegService() { }

        public async Task<bool> StreamConvert(string url, string fileName)
        {
            return await FFMpegArguments
                .FromUrlInput(new Uri(url))
                .OutputToFile(fileName)
                .ProcessAsynchronously();
        }

        public void ConfigureFfmpeg()
        {
            if(_configured) 
                return;

            GlobalFFOptions.Configure(new FFOptions
            {
                BinaryFolder = ConfigurationService.ConfigFile.FfmpegFolder + "\\",
                TemporaryFilesFolder = ConfigurationService.ConfigFile.TempFolder + "\\",
            });

            _configured = true;
        }

        public async Task<bool> DownloadFfmpegAsync()
        {
            if (new DirectoryInfo(ConfigurationService.ConfigFile.FfmpegFolder).EnumerateFiles()
                    .Count() >= 3)
            {
                return true;
            }

            var release = await ReleaseManager.Instance.GetLatestAsync("Tyrrrz", "FFmpegBin");
            if (release is null || !release.Assets.Any()) return false;

            var releaseAsset = new ReleaseAsset();

            if (OperatingSystem.IsWindows())
            {
                releaseAsset = release.Assets.First(asset => asset.Name.EndsWith("windows-x64.zip"));
            }

            if (OperatingSystem.IsLinux())
            {
                releaseAsset = release.Assets.First(asset => asset.Name.EndsWith("linux-x64.zip"));
            }

            if (OperatingSystem.IsMacOS())
            {
                releaseAsset = release.Assets.First(asset => asset.Name.EndsWith("osx-x64.zip"));
            }

            if (OperatingSystem.IsMacCatalyst())
            {
                releaseAsset = release.Assets.First(asset => asset.Name.EndsWith("osx-arm64.zip"));
            }

            var downloadInfo = await AssetDownloader.Instance.DownloadAssetAsync(releaseAsset, ConfigurationService.ConfigFile.FfmpegFolder + "\\");

            using var stream = File.OpenRead(downloadInfo.Path);
            ZipFile.ExtractToDirectory(stream, ConfigurationService.ConfigFile.FfmpegFolder, true);
            stream.Close();
            File.Delete(downloadInfo.Path);

            return true;
        }
    }
}
