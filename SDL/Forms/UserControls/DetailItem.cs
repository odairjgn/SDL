using SDL.Assets;
using SDL.Services.Log;
using SDL.Services.Player;
using SDL.Services.Utils;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Services;
using System.Data;
using System.Diagnostics;

namespace SDL.Forms.UserControls
{
    public partial class DetailItem : UserControl
    {
        private SpotifyServices _spotify;
        private Track _track;
        private Form? _form;

        public DetailItem()
        {
            InitializeComponent();
        }

        public DetailItem(Track track)
        {
            InitializeComponent();
            _spotify = new SpotifyServices();
            _track = track;
            LoadInfo();
        }

        private async void LoadInfo()
        {
            try
            {
                btnPreview.Enabled = btnSpotify.Enabled = btnYoutube.Enabled = false;
                _track = await _spotify.Track.GetAsync(_track.Id);
                lbTitle.Text = _track.Title;
                lbInfo.Text = string.Join(", ", _track.Artists.Select(x => x.Name));
                btnPreview.Enabled = btnSpotify.Enabled = btnYoutube.Enabled = true;
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
                lbInfo.Text = ex.Message;
                lbTitle.Text = "(Error)";
            }
        }

        private bool _playing = false;
        public bool Playing
        {
            get
            {
                return _playing;
            }
            set
            {
                _playing = value;
                btnPreview.BackgroundImage = value ? ImagesResources.stop_icon : ImagesResources.play_icon;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _form = FormsUtils.FindForm(this);
            _form.Resize += _form_Resize;
            _form_Resize(this, EventArgs.Empty);
        }

        private void _form_Resize(object? sender, EventArgs e)
        {
            FormsUtils.ResponsiveItemResize(this);
        }

        private async void btnPreview_Click(object sender, EventArgs e)
        {
            if (Playing)
            {
                await PreviewPlayer.Player.StopAsync();
            }
            else
            {
                await PreviewPlayer.Player.PlayAsync(_track.PreviewUrl);
                PreviewPlayer.Player.Stoped += Player_Stoped;
            }

            Playing = !Playing;
        }

        private void Player_Stoped(object? sender, EventArgs e)
        {
            Playing = false;
        }

        private async void btnYoutube_Click(object sender, EventArgs e)
        {
            try
            {
                var ytId = await _spotify.Track.GetYoutubeIdAsync(_track.Id);
                Process.Start(new ProcessStartInfo($"https://www.youtube.com/watch?v={ytId}") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSpotify_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(_track.Url) { UseShellExecute = true });
        }
    }
}
