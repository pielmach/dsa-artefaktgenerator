/*
    This file is part of ArtefaktGenerator.
 
    Copyright (C) 2009,2010 Mario Rauschenberg (www.dsa-hamburg.de)

    ArtefaktGenerator is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 2 as published by
    the Free Software Foundation.

    ArtefaktGenerator is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see http://www.gnu.org/licenses/ .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArtefaktGeneratorApp
{
    public partial class ArtGenApp : Form
    {
        private List<Held> helden;

        public ArtGenApp()
        {
            LadeHelden loader = new LadeHelden();
            helden = loader.heldenList;

            InitializeComponent();
        }

        private void ArtGenApp_Shown(object sender, EventArgs e)
        {
            if (helden != null)
            {
                HeldAuswahl auswahl = new HeldAuswahl(this, helden);
                auswahl.StartPosition = FormStartPosition.CenterParent;
                auswahl.ShowDialog(this);
            }
        }

        public void loadHero(string xml)
        {
            artGenControl1.plugInHeroFromXml(xml);
        }
    }
}
