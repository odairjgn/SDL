using SDL.Services.Tasks;
using System.ComponentModel;

namespace SDL.Forms.UserControls
{
    public partial class DownloadItem : UserControl
    {
        private readonly DownloadTask _task;

        public DownloadItem(DownloadTask task)
        {
            InitializeComponent();
            _task = task;
            _task.PropertyChanged += _task_PropertyChanged;
            lbInfo.Text = _task.ToString();
            lbStatus.Image = imageList1.Images[(int)_task.Status];
        }

        private void _task_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DownloadTask.Status))
            {
                lbStatus.Image = imageList1.Images[(int)_task.Status];
            }
        }
    }
}
