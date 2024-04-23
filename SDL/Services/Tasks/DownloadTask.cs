using SDL.Models.Enum;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SDL.Services.Tasks
{
    public abstract class DownloadTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler Remove;

        protected void OnPropertyChanged([CallerMemberName]string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected void OnRemove()
        {
            Remove?.Invoke(this, EventArgs.Empty);
        }

        private DownloadTaskStatus _status;
        public DownloadTaskStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public abstract Task Download();
    }
}
