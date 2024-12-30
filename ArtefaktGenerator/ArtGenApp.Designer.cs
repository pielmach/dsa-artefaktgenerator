namespace ArtefaktGeneratorApp
{
    partial class ArtGenApp
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
            artGenControl1 = new ArtefaktGenerator.ArtGenControl();
            SuspendLayout();
            // 
            // artGenControl1
            // 
            artGenControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            artGenControl1.BackColor = SystemColors.Control;
            artGenControl1.Dock = DockStyle.Fill;
            artGenControl1.Font = new Font("Segoe UI", 8.25F);
            artGenControl1.Location = new Point(0, 0);
            artGenControl1.Margin = new Padding(3, 4, 3, 4);
            artGenControl1.MinimumSize = new Size(1400, 1000);
            artGenControl1.Name = "artGenControl1";
            artGenControl1.Size = new Size(1528, 1000);
            artGenControl1.TabIndex = 0;
            // 
            // ArtGenApp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1528, 994);
            Controls.Add(artGenControl1);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1550, 1050);
            Name = "ArtGenApp";
            Text = "Das Schwarze Auge  -  ArtefaktGenerator";
            FormClosing += ArtGenApp_FormClosing;
            FormClosed += ArtGenApp_FormClosed;
            Shown += ArtGenApp_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ArtefaktGenerator.ArtGenControl artGenControl1;


    }
}

