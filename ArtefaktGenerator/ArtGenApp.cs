using System;
using System.Windows.Forms;

namespace ArtefaktGeneratorApp
{
    public partial class ArtGenApp : Form
    {
        public ArtGenApp()
        {
            InitializeComponent();
        }

        private void ArtGenApp_Shown(object sender, EventArgs e)
        {
            if (ArtefaktGenerator.Properties.Settings.Default.showHeldenImport)
                artGenControl1.ShowSelectHeroDialog(this);
        }

        private void ArtGenApp_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ArtGenApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.artGenControl1.SaveOptions();
        }
    }
}
