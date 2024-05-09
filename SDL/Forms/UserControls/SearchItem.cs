using SDL.Assets;
using SDL.Forms.Dialogs;
using SDL.Services.Log;
using SDL.Services.Player;
using SDL.Services.Tasks;
using SDL.Services.Utils;
using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
using SDL.SpotifyClient.Services;
using System.Data;
using System.Diagnostics;
using System.Security.Policy;

namespace SDL.Forms.UserControls
{
    public partial class SearchItem : UserControl
    {
        private Form? _form;
        private ISearchBase _result;

        public SearchItem()
        {
            InitializeComponent();
        }

        public ISearchBase Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                LoadInfo();
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
                btPreview.BackgroundImage = value ? ImagesResources.stop_icon : ImagesResources.play_icon;
            }
        }

        private void LoadInfo()
        {
            if (_result == null)
            {
                return;
            }

            lbTitle.Text = _result.Title;

            switch (_result)
            {
                case Track track:
                    lbInfo1.Text = string.Join(", ", track.Artists.Select(x => x.Name));
                    lbInfo2.Text = track.Album.Name;

                    var imgT = track.Album.Images.FirstOrDefault();
                    pbCover.Uri = imgT == null ? null : new Uri(imgT.Url);

                    lbType.Text = "Track";
                    lbType.ForeColor = Color.White;
                    lbType.BackColor = Color.Green;
                    lkDetails.Visible = false;
                    break;

                case Artist artist:
                    lbInfo1.Text = string.Join(", ", artist.Genres);
                    lbInfo2.Text = string.Empty;

                    var imgA = artist.Images.FirstOrDefault();
                    pbCover.Uri = imgA == null ? null : new Uri(imgA.Url);

                    lbType.Text = "Artist";
                    lbType.ForeColor = Color.White;
                    lbType.BackColor = Color.Blue;

                    lkYoutube.Visible = false;
                    btPreview.Visible = false;

                    lkDetails.Visible = true;
                    break;

                case Album album:
                    lbInfo1.Text = string.Join(", ", album.Artists.Select(a => a.Name));
                    lbInfo2.Text = album.AlbumType.ToString();

                    var imgB = album.Images.FirstOrDefault();
                    pbCover.Uri = imgB == null ? null : new Uri(imgB.Url);

                    lbType.Text = "Album";
                    lbType.ForeColor = Color.White;
                    lbType.BackColor = Color.Red;
                    lkYoutube.Visible = false;
                    btPreview.Visible = false;
                    lkDetails.Visible = true;
                    break;

                case Playlist playlist:
                    lbInfo1.Text = playlist.Owner.DisplayName;
                    lbInfo2.Text = playlist.Description;

                    pbCover.Image = ImagesResources.Playlist;

                    lbType.Text = "Playlist";
                    lbType.ForeColor = Color.White;
                    lbType.BackColor = Color.DeepPink;
                    lkYoutube.Visible = false;
                    btPreview.Visible = false;
                    lkDetails.Visible = true;
                    break;
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

        private async void lkOpenOnSpotify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_result?.Url != null)
            {
                var url = _result switch
                {
                    Artist _ => $"https://open.spotify.com/artist/{_result.Url}",
                    Album _ => $"https://open.spotify.com/album/{_result.Url}",
                    Playlist _ => $"https://open.spotify.com/playlist/{_result.Url}",
                    _ => _result.Url
                };

                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        private async void lkYoutube_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var musica = _result as Track;
                var spotify = new SpotifyServices();
                var ytId = await spotify.Track.GetYoutubeIdAsync(musica.Id);
                Process.Start(new ProcessStartInfo($"https://www.youtube.com/watch?v={ytId}") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void btPreview_Click(object sender, EventArgs e)
        {
            if (Playing)
            {
                await PreviewPlayer.Player.StopAsync();
            }
            else
            {
                var song = _result as Track;
                await PreviewPlayer.Player.PlayAsync(song.PreviewUrl);
                PreviewPlayer.Player.Stoped += Player_Stoped;
            }

            Playing = !Playing;
        }

        private void Player_Stoped(object? sender, EventArgs e)
        {
            Playing = false;
        }

        private async void lkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_result != null)
            {
                var spot = new SpotifyServices();

                var tracks = new List<Track>();

                switch (_result)
                {
                    case Album album:
                        tracks = await spot.Album.GetAllTracksAsync(album.Id);
                        break;

                    case Playlist playlist:
                        tracks = await spot.Playlist.GetAllTracksAsync(playlist.Id);
                        break;

                    case Artist artist:

                        var albuns = await spot.Artist.GetAllAlbumsAsync(artist.Id);
                        foreach (var a in albuns)
                        {
                            var tr = await spot.Album.GetAllTracksAsync(a.Id);

                            foreach (var t in tr)
                            {
                                if (tracks.Any(x => x.Id == t.Id))
                                    continue;

                                tracks.Add(t);
                            }
                        }
                        break;
                }

                var detForm = new DetailForm(tracks);
                detForm.ShowDialog();
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            DownloadList.Tasks.Add(new TrackDownloadTask(_result as Track));
        }
    }
}
