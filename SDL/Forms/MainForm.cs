using SDL.Forms.Dialogs;
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
            foreach (DownloadTask item in e.NewItems)
            {
                flpItensDownload.Controls.Add(new Label() { Text = item.ToString() });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
    }
}
