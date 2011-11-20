using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArtefaktGeneratorApp
{
    public partial class HeldAuswahl : Form
    {
        private ArtGenApp parent;

        public HeldAuswahl(ArtGenApp parent, List<Held> helden)
        {
            this.parent = parent;

            InitializeComponent();

            foreach (Held held in helden)
            {
                heroList.Items.Add(held);
            }
        }

        private void heroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (heroList.SelectedIndex >= 0);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Held held = (Held) heroList.SelectedItem;
            parent.loadHero(held.xml);

            Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
