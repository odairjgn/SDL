using SDL.Services.Configuration;
using SDL.Services.Utils;
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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            config.SelectedObject = ConfigurationService.ConfigFile;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var msg = FileNameBuider.GetHelpText();
            MessageBox.Show(msg);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            ConfigurationService.Save();
            Close();
        }
    }
}
