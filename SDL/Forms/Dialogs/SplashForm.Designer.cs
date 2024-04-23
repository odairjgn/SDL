namespace SDL.Forms.Dialogs
{
    partial class SplashForm
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
            mainLayout = new TableLayoutPanel();
            pnLoading = new Panel();
            lbLoading = new Label();
            pbLoading = new ProgressBar();
            pbLogo = new PictureBox();
            mainLayout.SuspendLayout();
            pnLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainLayout.Controls.Add(pnLoading, 0, 1);
            mainLayout.Controls.Add(pbLogo, 0, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 75.5208359F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 24.479166F));
            mainLayout.Size = new Size(370, 192);
            mainLayout.TabIndex = 0;
            // 
            // pnLoading
            // 
            pnLoading.Controls.Add(pbLoading);
            pnLoading.Controls.Add(lbLoading);
            pnLoading.Dock = DockStyle.Fill;
            pnLoading.Location = new Point(3, 148);
            pnLoading.Name = "pnLoading";
            pnLoading.Size = new Size(364, 41);
            pnLoading.TabIndex = 0;
            // 
            // lbLoading
            // 
            lbLoading.AutoSize = true;
            lbLoading.Location = new Point(0, 0);
            lbLoading.Name = "lbLoading";
            lbLoading.Size = new Size(59, 15);
            lbLoading.TabIndex = 0;
            lbLoading.Text = "Loading...";
            // 
            // pbLoading
            // 
            pbLoading.Location = new Point(4, 20);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(356, 13);
            pbLoading.Style = ProgressBarStyle.Marquee;
            pbLoading.TabIndex = 1;
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Fill;
            pbLogo.Location = new Point(3, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(364, 139);
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 192);
            Controls.Add(mainLayout);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashForm";
            Load += SplashForm_Load;
            mainLayout.ResumeLayout(false);
            pnLoading.ResumeLayout(false);
            pnLoading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Panel pnLoading;
        private ProgressBar pbLoading;
        private Label lbLoading;
        private PictureBox pbLogo;
    }
}