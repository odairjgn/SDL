namespace SDL.Forms.Dialogs
{
    partial class ConfigForm
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
            config = new PropertyGrid();
            btSave = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // config
            // 
            config.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            config.Location = new Point(12, 12);
            config.Name = "config";
            config.Size = new Size(365, 426);
            config.TabIndex = 0;
            // 
            // btSave
            // 
            btSave.Location = new Point(302, 460);
            btSave.Name = "btSave";
            btSave.Size = new Size(75, 23);
            btSave.TabIndex = 1;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(12, 468);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(159, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "help about filename patterns";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 495);
            Controls.Add(linkLabel1);
            Controls.Add(btSave);
            Controls.Add(config);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigForm";
            Text = "Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PropertyGrid config;
        private Button btSave;
        private LinkLabel linkLabel1;
    }
}