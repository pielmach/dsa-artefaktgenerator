namespace ArtefaktGenerator
{
    partial class LizenzForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LizenzForm));
            this.textBox_GPL = new System.Windows.Forms.TextBox();
            this.label_UlissesDisclaimer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_MarioGPL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_GPL
            // 
            this.textBox_GPL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_GPL.Location = new System.Drawing.Point(30, 148);
            this.textBox_GPL.Multiline = true;
            this.textBox_GPL.Name = "textBox_GPL";
            this.textBox_GPL.ReadOnly = true;
            this.textBox_GPL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_GPL.Size = new System.Drawing.Size(740, 280);
            this.textBox_GPL.TabIndex = 0;
            this.textBox_GPL.TabStop = false;
            this.textBox_GPL.Text = resources.GetString("textBox_GPL.Text");
            // 
            // label_UlissesDisclaimer
            // 
            this.label_UlissesDisclaimer.AutoSize = true;
            this.label_UlissesDisclaimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_UlissesDisclaimer.Location = new System.Drawing.Point(30, 24);
            this.label_UlissesDisclaimer.MaximumSize = new System.Drawing.Size(740, 0);
            this.label_UlissesDisclaimer.Name = "label_UlissesDisclaimer";
            this.label_UlissesDisclaimer.Size = new System.Drawing.Size(711, 50);
            this.label_UlissesDisclaimer.TabIndex = 1;
            this.label_UlissesDisclaimer.Text = "DAS SCHWARZE AUGE, AVENTURIEN, DERE, MYRANOR, THARUN, UTHURIA, RIESLAND und THE D" +
    "ARK EYE sind eingetragene Marken der Ulisses Spiele GmbH, Waldems.";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(740, 2);
            this.label2.TabIndex = 2;
            // 
            // label_MarioGPL
            // 
            this.label_MarioGPL.AutoSize = true;
            this.label_MarioGPL.Location = new System.Drawing.Point(30, 106);
            this.label_MarioGPL.Name = "label_MarioGPL";
            this.label_MarioGPL.Size = new System.Drawing.Size(681, 25);
            this.label_MarioGPL.TabIndex = 3;
            this.label_MarioGPL.Text = "DSA Artefaktgenerator originally released 2009 by Mario Rauschenberg under GPLv2";
            // 
            // LizenzForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_MarioGPL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_UlissesDisclaimer);
            this.Controls.Add(this.textBox_GPL);
            this.Name = "LizenzForm";
            this.Text = "LizenzForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_GPL;
        private System.Windows.Forms.Label label_UlissesDisclaimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_MarioGPL;
    }
}