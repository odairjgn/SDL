using System.Collections.ObjectModel;

namespace SDL.Services.Tasks
{
    public static class DownloadList
    {
        static DownloadList()
        {
            Tasks = new ObservableCollection<DownloadTask>();
        }

        public static ObservableCollection<DownloadTask> Tasks { get; private set; }
    }
}
