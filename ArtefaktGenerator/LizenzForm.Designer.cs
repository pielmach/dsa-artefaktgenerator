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
            textBox_GPL = new TextBox();
            label_UlissesDisclaimer = new Label();
            label2 = new Label();
            label_MarioGPL = new Label();
            ScriptoriumAventurisBild = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ScriptoriumAventurisBild).BeginInit();
            SuspendLayout();
            // 
            // textBox_GPL
            // 
            textBox_GPL.Font = new Font("Segoe UI", 9F);
            textBox_GPL.Location = new Point(30, 577);
            textBox_GPL.Multiline = true;
            textBox_GPL.Name = "textBox_GPL";
            textBox_GPL.ReadOnly = true;
            textBox_GPL.ScrollBars = ScrollBars.Vertical;
            textBox_GPL.Size = new Size(740, 280);
            textBox_GPL.TabIndex = 0;
            textBox_GPL.TabStop = false;
            textBox_GPL.Text = resources.GetString("textBox_GPL.Text");
            // 
            // label_UlissesDisclaimer
            // 
            label_UlissesDisclaimer.AutoSize = true;
            label_UlissesDisclaimer.Font = new Font("Segoe UI", 9F);
            label_UlissesDisclaimer.Location = new Point(30, 182);
            label_UlissesDisclaimer.MaximumSize = new Size(740, 0);
            label_UlissesDisclaimer.Name = "label_UlissesDisclaimer";
            label_UlissesDisclaimer.Size = new Size(740, 325);
            label_UlissesDisclaimer.TabIndex = 1;
            label_UlissesDisclaimer.Text = resources.GetString("label_UlissesDisclaimer.Text");
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(30, 522);
            label2.Name = "label2";
            label2.Size = new Size(740, 2);
            label2.TabIndex = 2;
            // 
            // label_MarioGPL
            // 
            label_MarioGPL.AutoSize = true;
            label_MarioGPL.Location = new Point(30, 535);
            label_MarioGPL.Name = "label_MarioGPL";
            label_MarioGPL.Size = new Size(681, 25);
            label_MarioGPL.TabIndex = 3;
            label_MarioGPL.Text = "DSA Artefaktgenerator originally released 2009 by Mario Rauschenberg under GPLv2";
            // 
            // ScriptoriumAventurisBild
            // 
            ScriptoriumAventurisBild.BackColor = Color.Transparent;
            ScriptoriumAventurisBild.Image = (Image)resources.GetObject("ScriptoriumAventurisBild.Image");
            ScriptoriumAventurisBild.Location = new Point(30, -49);
            ScriptoriumAventurisBild.Name = "ScriptoriumAventurisBild";
            ScriptoriumAventurisBild.Size = new Size(740, 275);
            ScriptoriumAventurisBild.SizeMode = PictureBoxSizeMode.Zoom;
            ScriptoriumAventurisBild.TabIndex = 4;
            ScriptoriumAventurisBild.TabStop = false;
            // 
            // LizenzForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 886);
            Controls.Add(label_MarioGPL);
            Controls.Add(label2);
            Controls.Add(label_UlissesDisclaimer);
            Controls.Add(textBox_GPL);
            Controls.Add(ScriptoriumAventurisBild);
            Name = "LizenzForm";
            Text = "Lizenz";
            ((System.ComponentModel.ISupportInitialize)ScriptoriumAventurisBild).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox_GPL;
        private System.Windows.Forms.Label label_UlissesDisclaimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_MarioGPL;
        private PictureBox ScriptoriumAventurisBild;
    }
}