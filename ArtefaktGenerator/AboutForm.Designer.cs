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
            this.labelAbout = new System.Windows.Forms.Label();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(40, 37);
            this.labelAbout.MaximumSize = new System.Drawing.Size(730, 0);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(716, 250);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = resources.GetString("labelAbout.Text");
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.LinkArea = new System.Windows.Forms.LinkArea(40, 89);
            this.linkLabelGitHub.Location = new System.Drawing.Point(40, 309);
            this.linkLabelGitHub.MaximumSize = new System.Drawing.Size(780, 30);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(757, 30);
            this.linkLabelGitHub.TabIndex = 1;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "Alle weiteren Informationen auf GitHub: https://github.com/pielmach/dsa-artefaktg" +
    "enerator";
            this.linkLabelGitHub.UseCompatibleTextRendering = true;
            this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 387);
            this.Controls.Add(this.linkLabelGitHub);
            this.Controls.Add(this.labelAbout);
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
    }
}