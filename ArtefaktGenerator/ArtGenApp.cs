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
//using System.Linq;
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
