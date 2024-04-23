using SDL.Models.Configuration;
using System.Text.Json;

namespace SDL.Services.Configuration
{
    public class ConfigurationService
    {
        private static string ConfigFileName = Path.Combine(Directory.GetCurrentDirectory(), "config.json");

        static ConfigurationService()
        {
            try
            {
                Load();
            }
            catch
            {
                Reset();
                Load();
            }
        }

        public static ConfigFile ConfigFile { get; private set; }

        public static void Save()
        {
            var json = JsonSerializer.Serialize(ConfigFile);
            File.WriteAllText(ConfigFileName, json);
        }

        public static void Load()
        {
            var json = File.ReadAllText(ConfigFileName);
            ConfigFile = JsonSerializer.Deserialize<ConfigFile>(json);

            if(!Directory.Exists(ConfigFile.FfmpegFolder))
            {
                Directory.CreateDirectory(ConfigFile.FfmpegFolder);
            }

            if (!Directory.Exists(ConfigFile.TempFolder))
            {
                Directory.CreateDirectory(ConfigFile.TempFolder);
            }
        }

        public static void Reset()
        {
            ConfigFile = new ConfigFile();
            Save();
        }
    }
}
