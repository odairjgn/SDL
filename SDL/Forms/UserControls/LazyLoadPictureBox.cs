using SDL.Assets;
using SDL.Services.Cache;
using SDL.Services.Log;

namespace SDL.Forms.UserControls
{
    public class LazyLoadPictureBox : PictureBox
    {
        private Uri? _uri;
        public Uri? Uri
        {
            get
            {
                return _uri;
            }
            set
            {
                _uri = value;
                LoadImage();
            }
        }

        private async void LoadImage()
        {
            if (_uri == null)
            {
                Image = null;
                return;
            }

            if (InvokeRequired)
            {
                Invoke(() => Image = ImagesResources.Loading);
            }
            else
            {
                Image = ImagesResources.Loading;
            }

            try
            {
                using var client = new HttpClient();
                using var imgStrm = new MemoryStream();
                using var imgStrmWeb = await client.GetStreamAsync(Uri);
                imgStrmWeb.CopyTo(imgStrm);
                var img = Image.FromStream(imgStrm);                

                if (InvokeRequired)
                {
                    Invoke(() => Image = img);
                }
                else
                {
                    Image = img;
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke(() => Image = ImagesResources.ErrorImage);
                }
                else
                {
                    Image = ImagesResources.ErrorImage;
                }
            }
        }
    }
}
