using SDL.Services.Log;
using SDL.Services.Tasks;
using SDL.SpotifyClient.Models.Album;
using SDL.SpotifyClient.Models.Artist;
using SDL.SpotifyClient.Models.Playlist;
using SDL.SpotifyClient.Models.Tracks;
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
    public partial class AddLinksForms : Form
    {
        public AddLinksForms()
        {
            InitializeComponent();
        }

        private async void btOk_Click(object sender, EventArgs e)
        {
            btOk.Enabled = false;
            await AddLinks();
            Close();
        }

        private async Task AddLinks()
        {
            try
            {
                foreach(var line in txtLinks.Lines)
                {
                    await AddLine(line);
                }
            }
            catch (Exception ex) 
            { 
                LogService.Instance.WriteException(ex);
            }
        }

        private async Task AddLine(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return;
                }

                var trackId = TrackId.TryParse(url);
                var playListId = PlaylistId.TryParse(url);
                var albumId = AlbumId.TryParse(url);
                var artistId = ArtistId.TryParse(url);

                if (trackId != null)
                {
                    await DownloadList.AddIdAsync(trackId.Value);
                    return;
                }

                if (playListId != null)
                {
                    await DownloadList.AddIdAsync(playListId.Value);
                    return;
                }

                if (albumId != null)
                {
                    await DownloadList.AddIdAsync(albumId.Value);
                    return;
                }

                if (artistId != null)
                {
                    await DownloadList.AddIdAsync(artistId.Value);
                    return;
                }
            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }
    }
}
