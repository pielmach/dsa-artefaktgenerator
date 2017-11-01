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
            this.artGenControl1 = new ArtefaktGenerator.ArtGenControl();
            this.SuspendLayout();
            // 
            // artGenControl1
            // 
            this.artGenControl1.AutoSize = true;
            this.artGenControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.artGenControl1.BackColor = System.Drawing.SystemColors.Control;
            this.artGenControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artGenControl1.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.artGenControl1.Location = new System.Drawing.Point(0, 0);
            this.artGenControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.artGenControl1.MinimumSize = new System.Drawing.Size(1024, 600);
            this.artGenControl1.Name = "artGenControl1";
            this.artGenControl1.Size = new System.Drawing.Size(1040, 689);
            this.artGenControl1.TabIndex = 0;
            // 
            // ArtGenApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 689);
            this.Controls.Add(this.artGenControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "ArtGenApp";
            this.Text = "Das Schwarze Auge  -  ArtefaktGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArtGenApp_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ArtGenApp_FormClosed);
            this.Shown += new System.EventHandler(this.ArtGenApp_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ArtefaktGenerator.ArtGenControl artGenControl1;


    }
}

