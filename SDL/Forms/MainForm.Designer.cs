namespace SDL.Forms
{
    partial class MainForm
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
            pnTools = new Panel();
            btnClearList = new Button();
            button1 = new Button();
            btnConfig = new Button();
            btnFromUrl = new Button();
            btnSearch = new Button();
            pnActions = new Panel();
            btnDownload = new Button();
            flpItensDownload = new FlowLayoutPanel();
            mainLayout.SuspendLayout();
            pnTools.SuspendLayout();
            pnActions.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(pnTools, 0, 0);
            mainLayout.Controls.Add(pnActions, 1, 1);
            mainLayout.Controls.Add(flpItensDownload, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.Size = new Size(878, 532);
            mainLayout.TabIndex = 0;
            // 
            // pnTools
            // 
            pnTools.Controls.Add(btnClearList);
            pnTools.Controls.Add(button1);
            pnTools.Controls.Add(btnConfig);
            pnTools.Controls.Add(btnFromUrl);
            pnTools.Controls.Add(btnSearch);
            pnTools.Dock = DockStyle.Fill;
            pnTools.Location = new Point(3, 3);
            pnTools.Name = "pnTools";
            mainLayout.SetRowSpan(pnTools, 2);
            pnTools.Size = new Size(134, 526);
            pnTools.TabIndex = 0;
            // 
            // btnClearList
            // 
            btnClearList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnClearList.Location = new Point(9, 67);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(115, 23);
            btnClearList.TabIndex = 4;
            btnClearList.Text = "Clear list";
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(9, 500);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 3;
            button1.Text = "About...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnConfig
            // 
            btnConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfig.Location = new Point(9, 471);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(115, 23);
            btnConfig.TabIndex = 2;
            btnConfig.Text = "Configuration";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnFromUrl
            // 
            btnFromUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnFromUrl.Location = new Point(9, 38);
            btnFromUrl.Name = "btnFromUrl";
            btnFromUrl.Size = new Size(115, 23);
            btnFromUrl.TabIndex = 1;
            btnFromUrl.Text = "From URL";
            btnFromUrl.UseVisualStyleBackColor = true;
            btnFromUrl.Click += btnFromUrl_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.Location = new Point(9, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnActions
            // 
            pnActions.Controls.Add(btnDownload);
            pnActions.Dock = DockStyle.Fill;
            pnActions.Location = new Point(143, 495);
            pnActions.Name = "pnActions";
            pnActions.Size = new Size(732, 34);
            pnActions.TabIndex = 2;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownload.Location = new Point(593, 1);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(136, 30);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // flpItensDownload
            // 
            flpItensDownload.AutoScroll = true;
            flpItensDownload.Dock = DockStyle.Fill;
            flpItensDownload.Location = new Point(143, 3);
            flpItensDownload.Name = "flpItensDownload";
            flpItensDownload.Size = new Size(732, 486);
            flpItensDownload.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 532);
            Controls.Add(mainLayout);
            MinimumSize = new Size(816, 571);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            mainLayout.ResumeLayout(false);
            pnTools.ResumeLayout(false);
            pnActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Panel pnTools;
        private Button btnFromUrl;
        private Button btnSearch;
        private Button btnConfig;
        private Panel pnActions;
        private Button btnClearList;
        private Button button1;
        private Button btnDownload;
        private FlowLayoutPanel flpItensDownload;
    }
}