namespace SDL.Forms.Dialogs
{
    partial class SearchForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            btnGo = new Button();
            pnOptions = new Panel();
            rbAlbum = new RadioButton();
            rbArtist = new RadioButton();
            rbPlayList = new RadioButton();
            rbTracks = new RadioButton();
            rbAll = new RadioButton();
            flpItens = new FlowLayoutPanel();
            pnOptions.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(65, 7);
            txtSearch.MaxLength = 128;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(406, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGo.Location = new Point(477, 6);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 23);
            btnGo.TabIndex = 2;
            btnGo.Text = "Go";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // pnOptions
            // 
            pnOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnOptions.Controls.Add(rbAlbum);
            pnOptions.Controls.Add(rbArtist);
            pnOptions.Controls.Add(rbPlayList);
            pnOptions.Controls.Add(rbTracks);
            pnOptions.Controls.Add(rbAll);
            pnOptions.Location = new Point(12, 36);
            pnOptions.Name = "pnOptions";
            pnOptions.Size = new Size(540, 26);
            pnOptions.TabIndex = 3;
            // 
            // rbAlbum
            // 
            rbAlbum.AutoSize = true;
            rbAlbum.Location = new Point(248, 3);
            rbAlbum.Name = "rbAlbum";
            rbAlbum.Size = new Size(62, 19);
            rbAlbum.TabIndex = 4;
            rbAlbum.Text = "Albuns";
            rbAlbum.UseVisualStyleBackColor = true;
            // 
            // rbArtist
            // 
            rbArtist.AutoSize = true;
            rbArtist.Location = new Point(184, 3);
            rbArtist.Name = "rbArtist";
            rbArtist.Size = new Size(58, 19);
            rbArtist.TabIndex = 3;
            rbArtist.Text = "Artists";
            rbArtist.UseVisualStyleBackColor = true;
            // 
            // rbPlayList
            // 
            rbPlayList.AutoSize = true;
            rbPlayList.Location = new Point(111, 3);
            rbPlayList.Name = "rbPlayList";
            rbPlayList.Size = new Size(67, 19);
            rbPlayList.TabIndex = 2;
            rbPlayList.Text = "Playlists";
            rbPlayList.UseVisualStyleBackColor = true;
            // 
            // rbTracks
            // 
            rbTracks.AutoSize = true;
            rbTracks.Location = new Point(48, 3);
            rbTracks.Name = "rbTracks";
            rbTracks.Size = new Size(57, 19);
            rbTracks.TabIndex = 1;
            rbTracks.Text = "Tracks";
            rbTracks.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Checked = true;
            rbAll.Location = new Point(3, 3);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(39, 19);
            rbAll.TabIndex = 0;
            rbAll.TabStop = true;
            rbAll.Text = "All";
            rbAll.UseVisualStyleBackColor = true;
            // 
            // flpItens
            // 
            flpItens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpItens.AutoScroll = true;
            flpItens.Location = new Point(12, 68);
            flpItens.Name = "flpItens";
            flpItens.Size = new Size(540, 390);
            flpItens.TabIndex = 4;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 470);
            Controls.Add(flpItens);
            Controls.Add(pnOptions);
            Controls.Add(btnGo);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchForm";
            pnOptions.ResumeLayout(false);
            pnOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnGo;
        private Panel pnOptions;
        private RadioButton rbTracks;
        private RadioButton rbAll;
        private RadioButton rbAlbum;
        private RadioButton rbArtist;
        private RadioButton rbPlayList;
        private FlowLayoutPanel flpItens;
    }
}