using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArtefaktGenerator
{
    public partial class HeldAuswahl : Form
    {
        private ArtGenControl mainControl;

        public HeldAuswahl(ArtGenControl mainControl, List<Held> helden)
        {
            this.mainControl = mainControl;
            InitializeComponent();
            if (helden != null)
                setHelden(helden);
        }

        private void setHelden(List<Held> helden)
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

        private void heroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (heroList.SelectedIndex >= 0);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Held held = (Held)heroList.SelectedItem;
            mainControl.plugInHeroFromXml(held.xml);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
                List<Held> helden = LadeHelden.ladeHelden(openFileDialog.FileName);
                setHelden(helden);
            }
        }
    }
}
