using SDL.Forms.UserControls;
using SDL.SpotifyClient.Models.Tracks;

namespace SDL.Forms.Dialogs
{
    public partial class DetailForm : Form
    {
        private readonly Task<List<Track>> _taskListTracks;

        public DetailForm(Task<List<Track>> taskListTracks)
        {
            InitializeComponent();
            _taskListTracks = taskListTracks;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadItemsUi(_taskListTracks);
        }

        private async void LoadItemsUi(Task<List<Track>> itemsTask)
        {
            Invoke(delegate
            {
                var noItem = new Label() { Text = "Loading..." };
                flpItens.Controls.Add(noItem);
            });

            var results = await itemsTask;

            Invoke(flpItens.Controls.Clear);

            Invoke(delegate
            {
                foreach (var d in results)
                {
                    var item = new DetailItem(d);
                    flpItens.Controls.Add(item);
                }

                if (results.Count == 0)
                {
                    var noItem = new Label() { Text = "(Empty)" };
                    flpItens.Controls.Add(noItem);
                }
            });            
        }
    }
}
