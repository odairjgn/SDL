using SDL.Forms.UserControls;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.Forms.Dialogs
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        public DetailForm(List<Track> det)
        {
            InitializeComponent();

            foreach(var d in det)
            {
                var item = new DetailItem(d);
                flpItens.Controls.Add(item);
            }

            if (det.Count == 0)
            {
                var noItem = new Label() { Text = "(Empty)" };
                flpItens.Controls.Add(noItem);
            }
        }

    }
}
