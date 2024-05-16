namespace SDL.Forms.UserControls
{
    partial class DownloadItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadItem));
            lbStatus = new PictureBox();
            lbInfo = new Label();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)lbStatus).BeginInit();
            SuspendLayout();
            // 
            // lbStatus
            // 
            lbStatus.Location = new Point(5, 3);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(37, 37);
            lbStatus.SizeMode = PictureBoxSizeMode.Zoom;
            lbStatus.TabIndex = 0;
            lbStatus.TabStop = false;
            // 
            // lbInfo
            // 
            lbInfo.Location = new Point(50, 3);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(172, 37);
            lbInfo.TabIndex = 1;
            lbInfo.Text = "label1";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "icons8-ampulheta-64.png");
            imageList1.Images.SetKeyName(1, "icons8-baixar-48.png");
            imageList1.Images.SetKeyName(2, "icons8-marca-de-seleção-emoji-48.png");
            imageList1.Images.SetKeyName(3, "icons8-erro-48.png");
            // 
            // DownloadItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbInfo);
            Controls.Add(lbStatus);
            Name = "DownloadItem";
            Size = new Size(225, 43);
            ((System.ComponentModel.ISupportInitialize)lbStatus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox lbStatus;
        private Label lbInfo;
        private ImageList imageList1;
    }
}
