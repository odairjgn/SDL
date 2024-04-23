namespace SDL.Forms.Dialogs
{
    partial class DetailForm
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
            flpItens = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpItens
            // 
            flpItens.AutoScroll = true;
            flpItens.Dock = DockStyle.Fill;
            flpItens.Location = new Point(0, 0);
            flpItens.Name = "flpItens";
            flpItens.Size = new Size(586, 335);
            flpItens.TabIndex = 5;
            // 
            // DetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 335);
            Controls.Add(flpItens);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DetailForm";
            Text = "DetailForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpItens;
    }
}