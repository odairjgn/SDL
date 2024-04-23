using SDL.Forms.UserControls;
using SDL.Services.Log;
using SDL.SpotifyClient.Enums;
using SDL.SpotifyClient.Interfaces;
using SDL.SpotifyClient.Services;

namespace SDL.Forms.Dialogs
{
    public partial class SearchForm : Form
    {
        private readonly ISpotifyServices _spotifyServices;

        public SearchForm()
        {
            InitializeComponent();
            _spotifyServices = new SpotifyServices();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                return;
            }

            Go();
        }

        private async void Go()
        {
            try
            {
                Invoke(() => btnGo.Enabled = false);
                Invoke(flpItens.Controls.Clear);
                Invoke(delegate
                {
                    var labelLoad = new Label() { Text = "Loading..." };
                    flpItens.Controls.Add(labelLoad);
                });

                var results = await Search();
                Invoke(flpItens.Controls.Clear);

                foreach (var result in results)
                {
                    Invoke(delegate
                    {
                        var searchItem = new SearchItem()
                        {
                            Result = result
                        };
                        flpItens.Controls.Add(searchItem);
                    });
                }
            }
            catch (Exception ex)
            {
                Invoke(flpItens.Controls.Clear);
                LogService.Instance.WriteException(ex);
                Invoke(() => MessageBox.Show(ex.Message, "Error"));
            }
            finally
            {
                Invoke(() => btnGo.Enabled = true);
            }
        }

        private async Task<IEnumerable<ISearchBase>> Search()
        {
            if (rbAll.Checked)
            {
                return await _spotifyServices.Search.GetAllTypesAsync(txtSearch.Text);
            }

            if (rbTracks.Checked)
            {
                return await _spotifyServices.Search.GetFilteredRecordsAsync(txtSearch.Text, types: TypeSearch.Track);
            }

            if (rbPlayList.Checked)
            {
                return await _spotifyServices.Search.GetFilteredRecordsAsync(txtSearch.Text, types: TypeSearch.Playlist);
            }

            if (rbArtist.Checked)
            {
                return await _spotifyServices.Search.GetFilteredRecordsAsync(txtSearch.Text, types: TypeSearch.Artist);
            }

            if (rbAlbum.Checked)
            {
                return await _spotifyServices.Search.GetFilteredRecordsAsync(txtSearch.Text, types: TypeSearch.Album);
            }

            return [];
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnGo.PerformClick();
            }
        }
    }
}
