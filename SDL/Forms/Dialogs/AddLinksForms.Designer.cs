namespace SDL.Forms.Dialogs
{
    partial class AddLinksForms
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
            txtLinks = new TextBox();
            btOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 15);
            label1.TabIndex = 0;
            label1.Text = "Spotify Links: (one per line)";
            // 
            // txtLinks
            // 
            txtLinks.Location = new Point(12, 27);
            txtLinks.Multiline = true;
            txtLinks.Name = "txtLinks";
            txtLinks.ScrollBars = ScrollBars.Both;
            txtLinks.Size = new Size(661, 267);
            txtLinks.TabIndex = 1;
            // 
            // btOk
            // 
            btOk.Location = new Point(598, 307);
            btOk.Name = "btOk";
            btOk.Size = new Size(75, 23);
            btOk.TabIndex = 2;
            btOk.Text = "OK";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            // 
            // AddLinksForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 342);
            Controls.Add(btOk);
            Controls.Add(txtLinks);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddLinksForms";
            Text = "Add Links";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLinks;
        private Button btOk;
    }
}