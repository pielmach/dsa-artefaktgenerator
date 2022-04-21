using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArtefaktGenerator
{
    public partial class HeldAuswahl : Form
    {
        private readonly ArtGenControl mainControl;

        public HeldAuswahl(ArtGenControl mainControl, List<Held> helden)
        {
            this.mainControl = mainControl;
            InitializeComponent();
            if (helden != null)
                SetHelden(helden);
        }

        private void SetHelden(List<Held> helden)
        {
            heroList.Items.Clear();

            foreach (Held held in helden)
            {
                heroList.Items.Add(held);
            }

            if (heroList.Items.Count > 0)
            {
                heroList.SetSelected(0, true);
            }
        }

        private void HeroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (heroList.SelectedIndex >= 0);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Held held = (Held)heroList.SelectedItem;
            mainControl.PlugInHeroFromXml(held.xml);

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.AddExtension = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "Helden-Software XML-Export|*.xml|Helden-Software Archiv|*.zip.hld";
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog.Multiselect = false;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.Title = "Held aus Heldensoftware importieren";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Held> helden = LadeHelden.LadeHeldenFromFile(openFileDialog.FileName);
                SetHelden(helden);
            }
        }
    }
}
