using SDL.Forms.Dialogs;
using SDL.Forms.UserControls;
using SDL.Services.Tasks;

namespace SDL.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DownloadList.Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;

            foreach (DownloadTask item in e.NewItems)
            {
                flpItensDownload.Controls.Add(new DownloadItem(item));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            searchForm.ShowDialog();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            DownloadList.Tasks.Clear();
            flpItensDownload.Controls.Clear();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            pnTools.Enabled = btnDownload.Enabled = false;
            await RunDownloads();
            pnTools.Enabled = btnDownload.Enabled = true;
        }

        private async Task RunDownloads()
        {
            foreach (var item in DownloadList.Tasks)
            {
                await item.Download();
            }
        }
    }
}
