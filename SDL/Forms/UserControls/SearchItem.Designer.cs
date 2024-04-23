namespace SDL.Forms.UserControls
{
    partial class SearchItem
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
            pbCover = new LazyLoadPictureBox();
            lbTitle = new Label();
            lbInfo1 = new Label();
            btDownload = new Button();
            btPreview = new Button();
            lkOpenOnSpotify = new LinkLabel();
            lbInfo2 = new Label();
            lbType = new Label();
            lkYoutube = new LinkLabel();
            lkDetails = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
            SuspendLayout();
            // 
            // pbCover
            // 
            pbCover.Location = new Point(4, 3);
            pbCover.Name = "pbCover";
            pbCover.Size = new Size(77, 77);
            pbCover.SizeMode = PictureBoxSizeMode.Zoom;
            pbCover.TabIndex = 0;
            pbCover.TabStop = false;
            pbCover.Uri = null;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTitle.Location = new Point(87, 3);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(578, 18);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "Title";
            // 
            // lbInfo1
            // 
            lbInfo1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbInfo1.Location = new Point(87, 21);
            lbInfo1.Name = "lbInfo1";
            lbInfo1.Size = new Size(578, 18);
            lbInfo1.TabIndex = 2;
            lbInfo1.Text = "Info 1";
            // 
            // btDownload
            // 
            btDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btDownload.BackgroundImage = Assets.ImagesResources.download_icon;
            btDownload.BackgroundImageLayout = ImageLayout.Zoom;
            btDownload.FlatAppearance.BorderColor = Color.Silver;
            btDownload.FlatAppearance.BorderSize = 0;
            btDownload.FlatStyle = FlatStyle.Flat;
            btDownload.Location = new Point(678, 44);
            btDownload.Name = "btDownload";
            btDownload.Size = new Size(40, 36);
            btDownload.TabIndex = 3;
            btDownload.UseVisualStyleBackColor = true;
            btDownload.Click += btDownload_Click;
            // 
            // btPreview
            // 
            btPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btPreview.BackgroundImage = Assets.ImagesResources.play_icon;
            btPreview.BackgroundImageLayout = ImageLayout.Zoom;
            btPreview.FlatAppearance.BorderColor = Color.Silver;
            btPreview.FlatAppearance.BorderSize = 0;
            btPreview.FlatStyle = FlatStyle.Flat;
            btPreview.Location = new Point(678, 3);
            btPreview.Name = "btPreview";
            btPreview.Size = new Size(40, 36);
            btPreview.TabIndex = 4;
            btPreview.UseVisualStyleBackColor = true;
            btPreview.Click += btPreview_Click;
            // 
            // lkOpenOnSpotify
            // 
            lkOpenOnSpotify.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lkOpenOnSpotify.AutoSize = true;
            lkOpenOnSpotify.Location = new Point(583, 65);
            lkOpenOnSpotify.Name = "lkOpenOnSpotify";
            lkOpenOnSpotify.Size = new Size(93, 15);
            lkOpenOnSpotify.TabIndex = 5;
            lkOpenOnSpotify.TabStop = true;
            lkOpenOnSpotify.Text = "Open on Spotify";
            lkOpenOnSpotify.LinkClicked += lkOpenOnSpotify_LinkClicked;
            // 
            // lbInfo2
            // 
            lbInfo2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbInfo2.ForeColor = SystemColors.GrayText;
            lbInfo2.Location = new Point(87, 39);
            lbInfo2.Name = "lbInfo2";
            lbInfo2.Size = new Size(578, 18);
            lbInfo2.TabIndex = 6;
            lbInfo2.Text = "Info 2";
            // 
            // lbType
            // 
            lbType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbType.AutoSize = true;
            lbType.BackColor = SystemColors.ButtonShadow;
            lbType.Location = new Point(87, 61);
            lbType.Name = "lbType";
            lbType.Padding = new Padding(2);
            lbType.Size = new Size(35, 19);
            lbType.TabIndex = 7;
            lbType.Text = "Type";
            // 
            // lkYoutube
            // 
            lkYoutube.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lkYoutube.AutoSize = true;
            lkYoutube.Location = new Point(480, 65);
            lkYoutube.Name = "lkYoutube";
            lkYoutube.Size = new Size(100, 15);
            lkYoutube.TabIndex = 9;
            lkYoutube.TabStop = true;
            lkYoutube.Text = "Open on Youtube";
            lkYoutube.LinkClicked += lkYoutube_LinkClicked;
            // 
            // lkDetails
            // 
            lkDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lkDetails.AutoSize = true;
            lkDetails.Location = new Point(432, 65);
            lkDetails.Name = "lkDetails";
            lkDetails.Size = new Size(42, 15);
            lkDetails.TabIndex = 10;
            lkDetails.TabStop = true;
            lkDetails.Text = "Details";
            lkDetails.LinkClicked += lkDetails_LinkClicked;
            // 
            // SearchItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lkDetails);
            Controls.Add(lkYoutube);
            Controls.Add(lbType);
            Controls.Add(lbInfo2);
            Controls.Add(lkOpenOnSpotify);
            Controls.Add(btPreview);
            Controls.Add(btDownload);
            Controls.Add(lbInfo1);
            Controls.Add(lbTitle);
            Controls.Add(pbCover);
            Name = "SearchItem";
            Size = new Size(721, 83);
            ((System.ComponentModel.ISupportInitialize)pbCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LazyLoadPictureBox pbCover;
        private Label lbTitle;
        private Label lbInfo1;
        private Button btDownload;
        private Button btPreview;
        private LinkLabel lkOpenOnSpotify;
        private Label lbInfo2;
        private Label lbType;
        private LinkLabel lkYoutube;
        private LinkLabel lkDetails;
    }
}
