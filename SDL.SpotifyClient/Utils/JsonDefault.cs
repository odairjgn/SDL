using System.Text.Json;
using System.Text.Json.Serialization;

namespace SDL.SpotifyClient.Utils
{
    public class JsonDefault
    {
        public static JsonSerializerOptions Options => GetOptions();

        private static JsonSerializerOptions GetOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}
