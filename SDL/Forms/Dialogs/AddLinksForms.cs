using SDL.Services.Log;
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


            }
            catch (Exception ex)
            {
                LogService.Instance.WriteException(ex);
            }
        }
    }
}
