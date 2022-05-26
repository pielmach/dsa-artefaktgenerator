using System.Windows.Forms;

namespace ArtefaktGenerator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/pielmach/dsa-artefaktgenerator" });
        }
    }
}
