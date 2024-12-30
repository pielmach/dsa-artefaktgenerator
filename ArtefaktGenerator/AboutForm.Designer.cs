namespace ArtefaktGenerator
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            labelAbout = new Label();
            linkLabelGitHub = new LinkLabel();
            SuspendLayout();
            // 
            // labelAbout
            // 
            labelAbout.AutoSize = true;
            labelAbout.Location = new Point(40, 37);
            labelAbout.MaximumSize = new Size(730, 0);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(722, 375);
            labelAbout.TabIndex = 0;
            labelAbout.Text = resources.GetString("labelAbout.Text");
            // 
            // linkLabelGitHub
            // 
            linkLabelGitHub.AutoSize = true;
            linkLabelGitHub.LinkArea = new LinkArea(40, 89);
            linkLabelGitHub.Location = new Point(40, 429);
            linkLabelGitHub.MaximumSize = new Size(780, 30);
            linkLabelGitHub.Name = "linkLabelGitHub";
            linkLabelGitHub.Size = new Size(757, 30);
            linkLabelGitHub.TabIndex = 1;
            linkLabelGitHub.TabStop = true;
            linkLabelGitHub.Text = "Alle weiteren Informationen auf GitHub: https://github.com/pielmach/dsa-artefaktgenerator";
            linkLabelGitHub.UseCompatibleTextRendering = true;
            linkLabelGitHub.LinkClicked += linkLabelGitHub_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(linkLabelGitHub);
            Controls.Add(labelAbout);
            Name = "AboutForm";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
    }
}