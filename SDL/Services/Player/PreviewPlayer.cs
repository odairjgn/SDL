using NAudio.Wave;
using SDL.Services.Log;

namespace SDL.Services.Player
{
    public class PreviewPlayer
    {
        private static PreviewPlayer _player;
        private MemoryStream _stream;
        private Mp3FileReader _mp3;
        private WaveOut _output;

        public static PreviewPlayer Player => (_player ??= new PreviewPlayer());

        private PreviewPlayer()
        {
            
        }

        public event EventHandler Stoped;

        public async Task PlayAsync(string url)
        {
            try
            {
                await StopAsync();
                var client = new HttpClient();
                var downloadData = await client.GetByteArrayAsync(url);
                _stream = new MemoryStream(downloadData);
                _mp3 = new Mp3FileReader(_stream);
                _output = new WaveOut();
                _output.Init(_mp3);
                _output.PlaybackStopped += _output_PlaybackStopped;
                _output.Play();
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        private void _output_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            Stoped?.Invoke(sender, e);
        }

        public async Task StopAsync()
        {
            try
            {
                _output?.Stop();
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }

            await Task.CompletedTask;
        }
    }
}
