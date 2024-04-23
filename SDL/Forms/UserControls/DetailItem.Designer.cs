namespace SDL.Forms.UserControls
{
    partial class DetailItem
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
            lbTitle = new Label();
            lbInfo = new Label();
            btnSpotify = new Button();
            btnYoutube = new Button();
            btnPreview = new Button();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(489, 18);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "...";
            // 
            // lbInfo
            // 
            lbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbInfo.Location = new Point(0, 18);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(489, 18);
            lbInfo.TabIndex = 1;
            lbInfo.Text = "...";
            // 
            // btnSpotify
            // 
            btnSpotify.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSpotify.BackgroundImage = Assets.ImagesResources.spotify;
            btnSpotify.BackgroundImageLayout = ImageLayout.Zoom;
            btnSpotify.FlatAppearance.BorderSize = 0;
            btnSpotify.Location = new Point(495, 3);
            btnSpotify.Name = "btnSpotify";
            btnSpotify.Size = new Size(31, 31);
            btnSpotify.TabIndex = 2;
            btnSpotify.UseVisualStyleBackColor = true;
            btnSpotify.Click += btnSpotify_Click;
            // 
            // btnYoutube
            // 
            btnYoutube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYoutube.BackgroundImage = Assets.ImagesResources.yt;
            btnYoutube.BackgroundImageLayout = ImageLayout.Zoom;
            btnYoutube.FlatAppearance.BorderSize = 0;
            btnYoutube.Location = new Point(532, 3);
            btnYoutube.Name = "btnYoutube";
            btnYoutube.Size = new Size(31, 31);
            btnYoutube.TabIndex = 3;
            btnYoutube.UseVisualStyleBackColor = true;
            btnYoutube.Click += btnYoutube_Click;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPreview.BackgroundImage = Assets.ImagesResources.play_icon;
            btnPreview.BackgroundImageLayout = ImageLayout.Zoom;
            btnPreview.FlatAppearance.BorderSize = 0;
            btnPreview.Location = new Point(569, 3);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(31, 31);
            btnPreview.TabIndex = 4;
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // DetailItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPreview);
            Controls.Add(btnYoutube);
            Controls.Add(btnSpotify);
            Controls.Add(lbInfo);
            Controls.Add(lbTitle);
            Name = "DetailItem";
            Size = new Size(605, 37);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label lbInfo;
        private Button btnSpotify;
        private Button btnYoutube;
        private Button btnPreview;
    }
}
