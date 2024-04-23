using SDL.Services.Ffmpeg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDL.Forms.Dialogs
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private async void SplashForm_Load(object sender, EventArgs e)
        {
            await LoadResources();
            Invoke(Close);
        }

        private async Task LoadResources()
        {
            await FfmpegService.Instance.DownloadFfmpeg();
        }
    }
}
