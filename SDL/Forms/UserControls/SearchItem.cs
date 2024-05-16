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

                Task<List<Track>> taskDetails = Task.FromResult(new List<Track>());

                switch (_result)
                {
                    case Album album:
                        taskDetails = spot.Album.GetAllTracksAsync(album.Id);
                        break;

                    case Playlist playlist:
                        taskDetails = spot.Playlist.GetAllTracksAsync(playlist.Id);
                        break;

                    case Artist artist:

                        taskDetails = GetTaskFindAllTracksArtist(spot, artist.Id);
                        break;
                }

                var detForm = new DetailForm(taskDetails);
                detForm.ShowDialog();
            }
        }

        private async void btDownload_Click(object sender, EventArgs e)
        {
            btDownload.Enabled = false;
            switch (_result)
            {
                case Track track:
                    AddTrack(track);
                    break;

                case Playlist list:
                    await AddPlaylistAsync(list);
                    break;

                case Album album:
                    await AddAlbumAsync(album);
                    break;

                case Artist artist:
                    await AddArtistAsync(artist);
                    break;
            }
            btDownload.Enabled = true;
        }

        private async Task AddArtistAsync(Artist artist)
        {
            try
            {
                var client = new SpotifyServices();
                var albuns = await client.Artist.GetAllAlbumsAsync(artist.Id);
                albuns.ForEach(async x => await AddAlbumAsync(x));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        private async Task AddAlbumAsync(Album album)
        {
            try
            {
                var client = new SpotifyServices();
                var tracks = await client.Album.GetTracksAsync(album.Id);
                tracks.ForEach(x => AddTrack(x));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        private async Task AddPlaylistAsync(Playlist list)
        {
            try
            {
                var client = new SpotifyServices();
                var tracks = await client.Playlist.GetTracksAsync(list.Id);
                tracks.ForEach(x => AddTrack(x, list.Name));
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }

        private void AddTrack(Track track, string? playList = null)
        {
            var dlTask = playList == null 
                ? new TrackDownloadTask(track) 
                : new TrackDownloadTask(track, playList);

            if (DownloadList.Tasks.Any(x => x.OutputFile == dlTask.OutputFile))
                return;

            DownloadList.Tasks.Add(dlTask);
        }

        private async Task<List<Track>> GetTaskFindAllTracksArtist(SpotifyServices spot, string artistId)
        {
            var tracks = new List<Track>();

            var albuns = await spot.Artist.GetAllAlbumsAsync(artistId);

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

            return tracks;
        }
    }
}
