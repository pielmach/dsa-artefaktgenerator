using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using NAppUpdate.Framework;
using NAppUpdate.Framework.Sources;

namespace ArtefaktGenerator
{
    public partial class ArtGenControl : UserControl
    {
        public Controller controller = new Controller();

        public ArtGenControl() : this (false)
        {
        }

        public ArtGenControl(bool plugInMode)
        {
            InitializeComponent();
            
            // Disable Non-PlugIn fields
            if (plugInMode)
            {
                updatesToolStripMenuItem.Visible = false;
                programmToolStripMenuItem1.Visible = false;
            }
			
            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateFeedReader = new NAppUpdate.Framework.FeedReaders.NauXmlFeedReader();
            updManager.TempFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ArtefaktGenerator");
            if (!plugInMode)
                updManager.UpdateSource = new NAppUpdate.Framework.Sources.SimpleWebSource("http://www.dsa-hamburg.de/artgen/update/update.xml");
            else
                updManager.UpdateSource = new NAppUpdate.Framework.Sources.SimpleWebSource("http://www.dsa-hamburg.de/artgen/update/updatedll.xml");

			if (isLinux())
				updatesToolStripMenuItem.Visible = false;
			
            if (!plugInMode && !isLinux())
                CheckForUpdates();
        }

		
		
		public bool isLinux()
		{
			int p = (int) Environment.OSVersion.Platform;
		    return (p == 4) || (p == 6) || (p == 128);
		}


        public void plugInHeroFromXml(string xml)
        {
            controller.plugInHeroFromXml(xml);
        }

        private void OnPrepareUpdatesCompleted(bool succeeded)
        {
            if (!succeeded)
            {
                MessageBox.Show("Update fehlgeschlagen!");
                this.Enabled = true;
            }
            else
            {
                // Get a local pointer to the UpdateManager instance
                UpdateManager updManager = UpdateManager.Instance;

                // This is a synchronous method by design, make sure to save all user work before calling
                // it as it might restart your application
                if (!updManager.ApplyUpdates())
                    MessageBox.Show("Error while trying to install software updates");
            }
        }

        private void OnCheckUpdatesComplete(int e)
        {
            if (e >= 1)
            {
                updatesToolStripMenuItem.Text = "Update verfügbar - hier klicken zum installieren";
                updatesToolStripMenuItem.ForeColor = Color.Green;
                updatesToolStripMenuItem.Enabled = true;
                updateInstallierenToolStripMenuItem.Enabled = true;
                updateInstallierenToolStripMenuItem.ForeColor = Color.Green;
            } 
            else
            {
                updatesToolStripMenuItem.Text = "kein Update verfügbar";
                updatesToolStripMenuItem.Enabled = false;
                updateInstallierenToolStripMenuItem.Enabled = false;
            }
        }

        private void CheckForUpdates()
        {
            updatesToolStripMenuItem.Text = "Suche nach updates...";

            UpdateManager updManager = UpdateManager.Instance;

            // Only check for updates if we haven't done so already
/*            if (updManager.State != UpdateManager.UpdateProcessState.NotChecked)
            {
                MessageBox.Show("Update process has already initialized; current state: " + updManager.State.ToString());
                return;
            }
            */
            try
            {
                updManager.CheckForUpdateAsync(OnCheckUpdatesComplete);
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException)
                {
                    updatesToolStripMenuItem.Text = "kein Update verfügbar";
                    updatesToolStripMenuItem.Enabled = false;
                    updateInstallierenToolStripMenuItem.Enabled = false;
                }
                else
                {
                    updatesToolStripMenuItem.Text = "kein Update verfügbar";
                    updatesToolStripMenuItem.Enabled = false;
                    updateInstallierenToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void update(bool force)
        {
            /*
            // Achaz
            if (artefakt.sf.rep == SF.SFType.ACH)
            {
                cb_kristalle.Visible = true;
            }
            else
            {
                cb_kristalle.Visible = false;
                cb_kristalle.Checked = false;
                artefakt.kristalle = false;
            }

            // Matrixgeber-Check
            if (artefakt.sf.matrix)
            {
                type_matrix.Enabled = true;
                arcanovi_matrix_lbl.Enabled = true;
                arcanovi_matrix_change.Enabled = true;
                sf_aux.Enabled = true;
            }
            else
            {
                type_matrix.Enabled = false;
                arcanovi_matrix_lbl.Enabled = false;
                arcanovi_matrix_change.Enabled = false;
                sf_aux.Enabled = false;
                sf_aux.Checked = false;
                artefakt.sf.auxiliator = false;
                if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                {
                    type_charge.Checked = true;
                    artefakt.typ = Artefakt.ArtefaktType.RECHARGE;
                }
            }

            // Aux Check
            if(artefakt.sf.auxiliator)
            {
                type_aux.Enabled = true;
            }
            else
            {
                type_aux.Enabled = false;
                if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                {
                    type_charge.Checked = true;
                    artefakt.typ = Artefakt.ArtefaktType.RECHARGE;
                }
            }

            // Semiperm. Check
            if (artefakt.sf.semi1)
            {
                type_semi.Enabled = true;
                arcanovi_semi_lbl.Enabled = true;
                arcanovi_semi_change.Enabled = true;
                sf_semiII.Enabled = true;
            }
            else
            {
                type_semi.Enabled = false;
                arcanovi_semi_lbl.Enabled = false;
                arcanovi_semi_change.Enabled = false;
                artefakt.sf.semi2 = false;
                sf_semiII.Checked = false;
                sf_semiII.Enabled = false;
                if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                {
                    type_charge.Checked = true;
                    artefakt.typ = Artefakt.ArtefaktType.RECHARGE;
                }
            }

            // Stapel check
            if (artefakt.sf.stapel)
            {
                sf_hyper.Enabled = true;
                lbl_staple.Enabled = true;
                stapel.Enabled = true;
            }
            else
            {
                artefakt.sf.hyper = false;
                sf_hyper.Enabled = false;
                sf_hyper.Checked = false;
                lbl_staple.Enabled = false;
                stapel.Enabled = false;
                stapel.Value = 1;
                delStapelZauber();
            }

            // Hyper check
            if (artefakt.sf.hyper)
            {
                stapel.Maximum = 100;
            }
            else
            {
                stapel.Maximum = 3;
            }
            */
            //temporaer check
            /*
            if (artefakt.typ == Artefakt.ArtefaktType.TEMP)
                temp_zeit.Visible = true;
            else
                temp_zeit.Visible = false;
            
            // semi check
            if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                semi_intervall.Visible = true;
            else
                semi_intervall.Visible = false;

            // Matrix check
            if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
            {
                matrix_stability.Visible = true;
                probe_ausloes.Minimum = 3;
            }
            else
            {
                matrix_stability.Visible = false;
                if (artefakt.regelbasis == Artefakt.Regelbasis.SRD)
                    probe_ausloes.Minimum = 1;
                else
                    probe_ausloes.Minimum = 0;
            }

            //Aux Check

            if (artefakt.typ == Artefakt.ArtefaktType.AUX)
            {
                aux_stability.Visible = true;
            }
            else
            {
                aux_stability.Visible = false;
            }
            */
            // add magic
            //zauber_list.Items.Clear();
            /*
            zauber_list.BeginUpdate(); ;
            for (int i = 0; i < magic.Count; i++)
            {
                ListViewItem item = new ListViewItem(magic[i].name.ToString());
                //item.SubItems.Add(magic[i].name.ToString());
                item.SubItems.Add(magic[i].komp.ToString());
                //item.SubItems.Add(magic[i].load.ToString());
                item.SubItems.Add(magic[i].staple.ToString());
                item.SubItems.Add(magic[i].asp.ToString());
                if(magic[i].eigene_rep)
                    item.SubItems.Add("eigene");
                else
                    item.SubItems.Add("fremde");
                zauber_list.Items.Add(item);
            }
            zauber_list.EndUpdate();


            // update Max Ladungen for Destructibo
            destruct_aktive.Maximum = artefakt.loads;

            //spezial spezial
            if (artefakt.taw.arcanovi < 10) 
            { 
                special_signet.Enabled = false;
                special_signet.Checked = false;
                artefakt.spezial_siegel = false; 
            }
            else special_signet.Enabled = true;

            // super_big
            if (WDA())
            {
                switch (artefakt_super_big.SelectedIndex)
                {
                    case 0: artefakt.probe.superBig_zuschlag = 0; artefakt.probe.superBig_asp_w = 0; break;
                    case 1: artefakt.probe.superBig_zuschlag = 5; artefakt.probe.superBig_asp_w = 2; break;
                    case 2: artefakt.probe.superBig_zuschlag = 10; artefakt.probe.superBig_asp_w = 4; break;
                    case 3: artefakt.probe.superBig_zuschlag = 15; artefakt.probe.superBig_asp_w = 8; break;
                    case 4: artefakt.probe.superBig_zuschlag = 20; artefakt.probe.superBig_asp_w = 16; break;
                }
            }
            else
            {
                switch (artefakt_super_big.SelectedIndex)
                {
                    case 0: artefakt.probe.superBig_zuschlag = 0; artefakt.probe.superBig_asp_w = 0; break;
                    case 1: artefakt.probe.superBig_zuschlag = 3; artefakt.probe.superBig_asp_w = 1; break;
                    case 2: artefakt.probe.superBig_zuschlag = 6; artefakt.probe.superBig_asp_w = 2; break;
                    case 3: artefakt.probe.superBig_zuschlag = 9; artefakt.probe.superBig_asp_w = 4; break;
                    case 4: artefakt.probe.superBig_zuschlag = 12; artefakt.probe.superBig_asp_w = 8; break;
                }
            }
            if (artefakt_super_big.SelectedIndex != 0)
            {
                artefakt_groesse.Enabled = false;
                label15.Enabled = false;
            }
            else
            {
                artefakt_groesse.Enabled = true;
                label15.Enabled = true;
            }


            // TODO UMSETZEN
            // check for WDA basis
            if (!WDA())
            {
                cb_kristalle.Visible = true;

                sf_aux.Visible = false;
                type_aux.Visible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                {
                    type_charge.Checked = true;
                }
                probe_ausloes.Minimum = 1;

                special_schleier.Visible = false;
                special_resistant.Visible = false;
                special_reversalis.Visible = false;
                special_selfrepair.Visible = false;
                special_variablerelease.Visible = false;
                special_ferngespuer.Visible = false;
                special_eatmaterial.Visible = false;
                lbl_special_asp.Visible = false;
                lbl_special_komp.Visible = false;
                special_ferngespuer_asp.Visible = false;
                special_ferngespuer_komp.Visible = false;
                special_variable_var.Visible = false;
                special_eatmat_var.Visible = false;

                // Afinität
                probe_affine.Maximum = 4;
                probe_affine.Minimum = -2;
            }
            else 
            {
                type_aux.Visible = true;
                sf_aux.Visible = true;
                probe_ausloes.Minimum = 0;
                // Kristalle
                cb_kristalle.Visible = false;

                // Temp Speicher
                if (artefakt.taw.arcanovi < 12)
                {
                    if (type_temp.Checked)
                        type_einaml.Checked = true;
                    type_temp.Enabled = false;
                }
                else
                    type_temp.Enabled = true;

                special_schleier.Visible = true;
                special_resistant.Visible = true;
                special_reversalis.Visible = true;
                special_selfrepair.Visible = true;
                special_variablerelease.Visible = true;
                special_ferngespuer.Visible = true;
                special_eatmaterial.Visible = true;

                // Afinität
                probe_affine.Maximum = 3;
                probe_affine.Minimum = -3;

                //Spezial spezials
                if (artefakt.taw.arcanovi < 12) 
                {
                    special_ferngespuer.Checked = false;
                    artefakt.spezial_ferngespuer = false;
                    special_ferngespuer.Enabled = false;
                }
                else
                    special_ferngespuer.Enabled = true;

                if (artefakt.taw.arcanovi < 12 || artefakt.typ != Artefakt.ArtefaktType.RECHARGE)
                {
                    special_variablerelease.Checked = false;
                    artefakt.spezial_variablerausloeser = false;
                    special_variablerelease.Enabled = false;
                }
                else
                    special_variablerelease.Enabled = true;

                if (artefakt.taw.arcanovi < 10)
                {
                    special_schleier.Enabled = false;
                    special_schleier.Checked = false;
                    artefakt.spezial_verschleierung = false;
                }
                else
                    special_schleier.Enabled = true;

                if (artefakt.taw.arcanovi_matrix < 15 || artefakt.typ != Artefakt.ArtefaktType.AUX)
                {
                    special_reversalis.Checked = false;
                    special_reversalis.Enabled = false;
                    artefakt.spezial_reversalis = false;
                }
                else
                    special_reversalis.Enabled = true;

                if ((artefakt.typ == Artefakt.ArtefaktType.NORMAL || artefakt.typ == Artefakt.ArtefaktType.TEMP) && (artefakt.loads <= 1))
                    special_eatmaterial.Enabled = true;
                else
                {
                    special_eatmaterial.Enabled = false;
                    special_eatmaterial.Checked = false;
                    artefakt.spezial_verzehrend = false;
                }

                if (special_variablerelease.Checked) special_variable_var.Visible = true;
                else special_variable_var.Visible = false;

                if (special_eatmaterial.Checked) special_eatmat_var.Visible = true;
                else special_eatmat_var.Visible = false;

                if (special_ferngespuer.Checked)
                {
                    lbl_special_asp.Visible = true;
                    lbl_special_komp.Visible = true;
                    special_ferngespuer_asp.Visible = true;
                    special_ferngespuer_komp.Visible = true;
                }
                else
                {
                    lbl_special_asp.Visible = false;
                    lbl_special_komp.Visible = false;
                    special_ferngespuer_asp.Visible = false;
                    special_ferngespuer_komp.Visible = false;
                }
            }

            if (automatischNeuberechenenToolStripMenuItem.Checked || force)
            {
               // calcCreate();
            }
             */
        }

        private void calcCreate()
        {/*
            txt_create.ResetText();
            txt_analys.ResetText();
            txt_destruct.ResetText();

            string debugArcanoviErschwernis = "";

            // Material
            mat = new MaterialSammlung(dice);

            for (int i = 0; i < mat.sammlung.Count; i++)
                if ((string)material.SelectedItem == mat.sammlung[i].name)
                    artefakt.material = mat.sammlung[i];

            if (magic.Count >= 1)
            {
                // DEBUG
                if (artefakt.debugMode)
                {
                    debugArcanoviErschwernis += "Arcanovi Erschwerniss ergibt sich wie folgt:\r\n";
                    debugArcanoviErschwernis += "Affinität: " + artefakt.probe.affine;
                    debugArcanoviErschwernis += "Auslöser: " + artefakt.probe.ausloeser;
                    debugArcanoviErschwernis += "Auslöser: " + artefakt.probe.ausloeser;
                }

                decimal agribaal_zfp = artefakt.agribaal;
                decimal arcanovi_erschwernis = artefakt.probe.affine + artefakt.probe.ausloeser + artefakt.probe.material + artefakt.material.arcanovi_mod + artefakt.probe.superBig_zuschlag + artefakt.probe.erzwingen + artefakt.probe.stars;
                if (artefakt.probe.superBig_zuschlag == 0) arcanovi_erschwernis += artefakt.probe.groesse;
                //spezielle Eigenschaften
                if (artefakt.spezial_apport) arcanovi_erschwernis += 4;
                if (artefakt.spezial_gespuer) arcanovi_erschwernis += 3;
                if (artefakt.spezial_unzerbrechlich) arcanovi_erschwernis += 3;
                if (WDA() && artefakt.spezial_ferngespuer) arcanovi_erschwernis += (5+artefakt.spezial_ferngespuer_komp);
                if (WDA() && artefakt.spezial_resistent) arcanovi_erschwernis += 2;
                if (WDA() && artefakt.typ == Artefakt.ArtefaktType.AUX && artefakt.spezial_reversalis) arcanovi_erschwernis += 4;
                if (WDA() && artefakt.spezial_variablerausloeser) arcanovi_erschwernis += (2+artefakt.spezial_variablerausloeser_var);
                if (WDA() && artefakt.spezial_verschleierung) arcanovi_erschwernis += 3;
                if (WDA() && artefakt.spezial_verzehrend) arcanovi_erschwernis += 1;

                if (artefakt.typ == Artefakt.ArtefaktType.RECHARGE) arcanovi_erschwernis += 5;
                decimal magic_asp_mult = 1;
                decimal magic_asp_mult_extra = 1;

                if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                {
                    if (artefakt.typ == Artefakt.ArtefaktType.SEMI && artefakt.sf.semi1 && !(artefakt.sf.semi2))
                    {
                        switch (artefakt.semi_typ)
                        {
                            case Artefakt.SemiType.MONAT: arcanovi_erschwernis += 3; magic_asp_mult = 2; break;
                            case Artefakt.SemiType.WOCHE: arcanovi_erschwernis += 6; magic_asp_mult = 3; break;
                            case Artefakt.SemiType.TAG: arcanovi_erschwernis += 9; magic_asp_mult = 5; break;
                            default: magic_asp_mult = 1; break;
                        }
                    }
                    if (artefakt.typ == Artefakt.ArtefaktType.SEMI && artefakt.sf.semi1 && artefakt.sf.semi2)
                    {
                        switch (artefakt.semi_typ)
                        {
                            case Artefakt.SemiType.MONAT: arcanovi_erschwernis += 3; magic_asp_mult = 1; break;
                            case Artefakt.SemiType.WOCHE: arcanovi_erschwernis += 6; magic_asp_mult = 2; break;
                            case Artefakt.SemiType.TAG: arcanovi_erschwernis += 9; magic_asp_mult = 4; break;
                            default: magic_asp_mult = 1;  break;
                        }
                    }
                }
                if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                {
                    switch (artefakt.matrix_typ)
                    {
                        case Artefakt.MatrixType.STABIL: arcanovi_erschwernis += 2; if (WDA()) magic_asp_mult = 2; break;
                        case Artefakt.MatrixType.SEHRSTABIL: arcanovi_erschwernis += 4; if (WDA()) magic_asp_mult = 3; break;
                        case Artefakt.MatrixType.UNEMPFINDLICH: arcanovi_erschwernis += 6; if (WDA()) magic_asp_mult = 4; break;
                        default: break;
                    }
                }
                if (WDA())
                {
                    if (artefakt.typ == Artefakt.ArtefaktType.TEMP)
                    {
                        switch (artefakt.temp_typ)
                        {
                            case Artefakt.TempType.TAG: arcanovi_erschwernis += 5; break;
                            case Artefakt.TempType.WOCHE: arcanovi_erschwernis += 7; break;
                            case Artefakt.TempType.MONAT: arcanovi_erschwernis += 9; break;
                            default: break;
                        }
                    }
                    if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                    {
                        arcanovi_erschwernis += 3;
                        if (artefakt.aux_merkmal) arcanovi_erschwernis += 2;
                        magic_asp_mult_extra = 3;
                        switch (artefakt.aux_typ)
                        {
                            case Artefakt.MatrixType.STABIL: arcanovi_erschwernis += 3; magic_asp_mult = 2; break;
                            case Artefakt.MatrixType.SEHRSTABIL: arcanovi_erschwernis += 6; magic_asp_mult = 3; break;
                            case Artefakt.MatrixType.UNEMPFINDLICH: arcanovi_erschwernis += 9; magic_asp_mult = 4; break;
                            default: break;
                        }
                    }
                }

                decimal arcanovi_zfp = 0;
                decimal magic_asp = 0;
                decimal eigene_rep_count = 0;
                for (int i = 0; i < magic.Count; i++)
                {
                    // Rep
                    if (magic[i].eigene_rep) eigene_rep_count++;
                    // komplexität
                    switch (magic[i].komp)
                    {
                        case "A": break;
                        case "B": arcanovi_zfp += 1 * artefakt.loads * magic_asp_mult; break;
                        case "C": arcanovi_zfp += 1 * artefakt.loads * magic_asp_mult; break;
                        case "D": arcanovi_zfp += 2 * artefakt.loads * magic_asp_mult; break;
                        case "E": arcanovi_zfp += 2 * artefakt.loads * magic_asp_mult; break;
                        default: arcanovi_zfp += 3 * artefakt.loads * magic_asp_mult; break;
                    }
                    // Ladungen
                    //arcanovi_zfp += (magic[i].load - 1) * 3;
                    // Stapel
                    if (magic[i].staple > 1) arcanovi_zfp += magic[i].staple * 2;
                    // AsP wirkende Sprüche
                    decimal thismagic_asp = magic[i].asp;
                    if (artefakt.sf.rep == SF.SFType.ACH && ach_save.Checked) thismagic_asp = Round(thismagic_asp * 3 / 4);
                    if (artefakt.sf.kraftkontrolle) thismagic_asp -= 1;

                    magic_asp += thismagic_asp * artefakt.loads * magic[i].staple * magic_asp_mult * magic_asp_mult_extra;
                }
                if (artefakt.limbus)
                {
                    magic_asp = Round(magic_asp / 10);
                    arcanovi_erschwernis += 15;
                }
                if (magic_asp <= 0) magic_asp = 1;

                //arcanovi_zfp += artefakt.loads * magic.Count;
                if (artefakt.typ != Artefakt.ArtefaktType.MATRIX )//&& artefakt.typ != Artefakt.ArtefaktType.SEMI)
                    arcanovi_zfp += (artefakt.loads - 1) * 3;

                // TODO: Vielfache Ladung nur bei Ladnugsbasiert?
                if (magic.Count > 1)
                {
                    if (artefakt.sf.vielfacheLadung)
                        arcanovi_zfp += magic.Count * artefakt.loads * magic_asp_mult;
                    else
                        arcanovi_zfp += (((magic.Count * artefakt.loads * magic_asp_mult) - 1) * magic.Count * artefakt.loads) / 2;
                }

                decimal arcanovi_taw = 0;
                switch (artefakt.typ)
                {
                    case Artefakt.ArtefaktType.MATRIX: arcanovi_taw = artefakt.taw.arcanovi_matrix; break;
                    case Artefakt.ArtefaktType.AUX: if (WDA()) arcanovi_taw = artefakt.taw.arcanovi_matrix; break;
                    case Artefakt.ArtefaktType.SEMI: arcanovi_taw = artefakt.taw.arcanovi_semi; break;
                    default: arcanovi_taw = artefakt.taw.arcanovi; break;
                }

                // Arcanovi mit Agribaal
                decimal arcanovi_count = 0;
                decimal agribaal_for_arcanovi = agribaal_zfp;
                while (true)
                {
                    decimal arcanovi_taw_new = arcanovi_taw - arcanovi_erschwernis;
                    if (arcanovi_taw_new == 0) arcanovi_taw_new = 1;
                    if (arcanovi_taw_new > arcanovi_taw) arcanovi_taw_new = arcanovi_taw;
                    if (arcanovi_taw_new > 0)
                        arcanovi_count = Math.Ceiling(arcanovi_zfp / arcanovi_taw_new);
                    if ((arcanovi_taw_new < 0 || arcanovi_count > 1) && agribaal_zfp > 0)
                    {
                        --agribaal_zfp;
                        --arcanovi_erschwernis;
                    }
                    else break;
                }
                if (arcanovi_count == 0) arcanovi_count = 1;
                agribaal_for_arcanovi = agribaal_for_arcanovi - agribaal_zfp;

                decimal arcanovi_asp = 0;
                decimal arcanovi_special_w = 0;
                decimal arcanovi_special_w_asp = 0;
                decimal arcanovi_special_asp = 0;
                //arcanovi_special_w += artefakt.probe.superBig_asp_w;
                decimal arcanovi_base_asp = 0;
                arcanovi_base_asp = 10;
                if (!WDA() && artefakt.typ == Artefakt.ArtefaktType.TEMP)
                {
                    switch (artefakt.temp_typ)
                    {
                        case Artefakt.TempType.TAG: arcanovi_base_asp = 5; break;
                        case Artefakt.TempType.WOCHE: arcanovi_base_asp = 7; break;
                        case Artefakt.TempType.MONAT: arcanovi_base_asp = 9; break;
                    }
                }

                // erzwingen auf base
                decimal erzwingen_asp = 0;
                for (int i = 0; i < -artefakt.probe.erzwingen; i++)
                {
                    if (i > 0) erzwingen_asp = erzwingen_asp * 2;
                    else erzwingen_asp = 1;
                }
                arcanovi_base_asp += erzwingen_asp;

                if (artefakt.sf.rep == SF.SFType.ACH)
                    arcanovi_base_asp = Round(arcanovi_base_asp * 3 / 4);
                if (artefakt.sf.kraftkontrolle)
                    arcanovi_base_asp = arcanovi_base_asp - 1;
                if (artefakt.limbus)
                    arcanovi_base_asp = Round(arcanovi_base_asp / 10);

                arcanovi_asp += arcanovi_count * arcanovi_base_asp;


                // Spezielle eigenschaften
                if (artefakt.spezial_siegel) arcanovi_special_w += 1;
                if (artefakt.spezial_unzerbrechlich) arcanovi_special_w += 6;
                if (artefakt.spezial_gespuer) arcanovi_special_w += 3;
                if (artefakt.spezial_apport) arcanovi_special_w += 4;
                if (WDA() && artefakt.spezial_ferngespuer) { arcanovi_special_w += 2; arcanovi_special_w_asp += artefakt.spezial_ferngespuer_asp; };
                if (WDA() && artefakt.spezial_resistent) arcanovi_special_w += 4;
                if (WDA() && artefakt.spezial_reperatur) arcanovi_special_w += 5;
                if (WDA() && artefakt.spezial_reversalis) { arcanovi_special_w += 2; arcanovi_special_w_asp += 7; }
                if (WDA() && artefakt.spezial_variablerausloeser) arcanovi_special_w += 2;
                if (WDA() && artefakt.spezial_verschleierung) arcanovi_special_w += 3;
                if (WDA() && artefakt.spezial_verzehrend) arcanovi_special_w_asp -= Round(artefakt.spezial_verzehrend_var/10);

                for (int i = 0; i < arcanovi_special_w; i++)
                    arcanovi_special_asp += dice.W6;
                if (artefakt.sf.ringkunde && arcanovi_special_asp > 0)
                    arcanovi_special_asp /= 2;
                for (int i = 0; i < artefakt.probe.superBig_asp_w; i++)
                    arcanovi_special_asp += dice.W20;

                arcanovi_special_asp += artefakt.material.asp_mod;
                arcanovi_special_asp += arcanovi_special_w_asp;
                arcanovi_special_asp = Round(arcanovi_special_asp);

                // pAsP
                decimal pasp = 0;
                dice.W6_Opt = Wuerfel.Optimum.LOW;
                switch (artefakt.typ)
                {
                    case Artefakt.ArtefaktType.TEMP: pasp = Round(Round((Math.Floor((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20)) / 2)*artefakt.material.pasp_mod); break;
                    case Artefakt.ArtefaktType.NORMAL: pasp = Round(Math.Floor((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20)*artefakt.material.pasp_mod); break;
                    case Artefakt.ArtefaktType.RECHARGE: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 15)*artefakt.material.pasp_mod); break;
                    case Artefakt.ArtefaktType.MATRIX: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20)*artefakt.material.pasp_mod); break;
                    case Artefakt.ArtefaktType.SEMI: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 10) * artefakt.material.pasp_mod); break;
                    case Artefakt.ArtefaktType.AUX: if (WDA()) pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 15) * artefakt.material.pasp_mod); break;
                    default: break;
                }
                if (pasp <= 0 && !(artefakt.typ == Artefakt.ArtefaktType.TEMP) && !(artefakt.kristalle))
                    pasp = 1;
                if (!WDA() && artefakt.kristalle && pasp > 0) pasp -= 1;

                // Erschwerniss Wirkende Zauber
                decimal magic_erschwerniss = 2 + artefakt.material.wirkende_mod;

                // Nebeneffekte
                decimal neben_probe_count = Math.Floor(pasp / 2);
                decimal neben_count = 0;
                decimal neben_agribaal_mod = (artefakt.agribaal > 0) ? -3 : 0;
                for (int i = 0; i < neben_probe_count; i++)
                    if ((dice.W20 + artefakt.material.nebenwirkung_mod + artefakt.special_ort_neben + neben_agribaal_mod) <= pasp) neben_count++;
                List<decimal> nebens = new List<decimal>();
                for (int i = 0; i < neben_count; i++)
                    nebens.Add(dice.W20 + dice.W20 + artefakt.material.nebenwirkung_art_mod);

                if ((arcanovi_taw - arcanovi_erschwernis >= 0))
                {
                    if (arcanovi_taw >= 7 && artefakt.taw.magiekunde >= 7)
                    {
                        txt_create.AppendText("Erstellung der Artefaktthesis benötigt " + arcanovi_zfp + " ZE (=" + arcanovi_zfp * 2 + " h)\r\n");
                        txt_create.AppendText("Zu Papier bringen mit Magiekunde & Malen/Zeichnen, zusammen erschwert um " + arcanovi_zfp + "\r\n");
                    }
                    else
                        txt_create.AppendText("Artefaktthesis kann nicht selber erstellt werden. TaW ARCANOVI bzw. Magiekunde zu gering.\r\n\r\n");

                    if (artefakt.agribaal == 0)
                        txt_create.AppendText("Erschwernis für Arcanovi: " + arcanovi_erschwernis + "\r\n");
                    else
                        txt_create.AppendText("Erschwernis für Arcanovi: " + arcanovi_erschwernis + " (erleichterung von " + agribaal_for_arcanovi + " durch Agribaal)\r\n");

                    txt_create.AppendText("Erforderliche Arcanovi ZfP*: " + arcanovi_zfp + "\r\n");
                    txt_create.AppendText("Bester Fall: " + arcanovi_count + " Arcanovi für " + arcanovi_asp + " AsP\r\n");
                    if (artefakt.agribaal == 0)
                        txt_create.AppendText("Erschwernis wirkende Sprüche: " + magic_erschwerniss + "\r\n");
                    else
                        txt_create.AppendText("Erschwernis wirkende Sprüche: " + (magic_erschwerniss - agribaal_zfp) + "(erleichterung von " + agribaal_zfp + " durch Agribaal)\r\n");
                    txt_create.AppendText("AsP für wirkende Sprüche: " + magic_asp + "\r\n");

                    string sArcanoviSpecialAsP = "";
                    string sArcanoviSpecialDiv = ""; 
                    if (arcanovi_special_w_asp > 0)
                        sArcanoviSpecialAsP = " + " + arcanovi_special_w_asp;
                    if (artefakt.sf.ringkunde)
                        sArcanoviSpecialDiv = "/ 2";
                    if (artefakt.sf.ringkunde)
                        txt_create.AppendText("AsP gesamt: " + (magic_asp + arcanovi_asp) + " + (" + arcanovi_special_w + " W6" + sArcanoviSpecialAsP + ") " + sArcanoviSpecialDiv + " + " + artefakt.probe.superBig_asp_w + " W20 = " + (magic_asp + arcanovi_asp + arcanovi_special_asp) + "\r\n");
                    else
                        txt_create.AppendText("AsP gesamt: " + (magic_asp + arcanovi_asp) + " + " + arcanovi_special_w + " W6" + sArcanoviSpecialAsP + sArcanoviSpecialDiv + " + " + artefakt.probe.superBig_asp_w + " W20 = " + (magic_asp + arcanovi_asp + arcanovi_special_asp) + "\r\n");
                    
                    txt_create.AppendText("pAsP gesamt: " + pasp + "\r\n");

                    //Nebens
                    txt_create.AppendText("Anzahl Nebeneffektproben: " + neben_probe_count + "\r\n");
                    if (artefakt.nebeneffekte && alleBerechnenToolStripMenuItem.Checked)
                    {
                        txt_create.AppendText("\t" + neben_count + " Nebeneffekte (");
                        for (int i = 0; i < nebens.Count; i++)
                            txt_create.AppendText(" " + nebens[i]);
                        txt_create.AppendText(")\r\n");
                    }
                    //Occupation
                    if (artefakt.occupation && alleBerechnenToolStripMenuItem.Checked)
                    {
                        decimal occ_wurf = dice.W20;
                        decimal limbus_mod = artefakt.limbus ? -7 : 0;
                        decimal namenlos_mod = artefakt.namenlos ? -3 : 0;
                        decimal agribaal_mod = (artefakt.agribaal > 0) ? -3 : 0;
                        if ((occ_wurf + artefakt.material.occupation_mod + limbus_mod + namenlos_mod + artefakt.special_ort_occ + agribaal_mod) <= pasp)
                            txt_create.AppendText("Occupation: " + occ.occupationName(dice.W20 + artefakt.material.occupation_art_mod) + "\r\n");
                        else txt_create.AppendText("Occupation: keine\r\n");
                    }
                    
                }
                else
                    txt_create.AppendText("Artefakt nicht möglich. ZfW Arcanovi zu gering.");

                // Analys
                decimal odem_erschwernis = 0;
                if (WDA())
                {
                    odem_erschwernis -= pasp;
                    odem_erschwernis += Math.Floor(arcanovi_erschwernis / 2) + artefakt.analys.mr + artefakt.analys.tarnzauber;
                    if (magic_asp > 30)
                        odem_erschwernis -= Math.Ceiling((magic_asp - 30) / 10);
                    else
                        odem_erschwernis += Math.Ceiling((magic_asp - 30) / 5);
                }
                else
                    odem_erschwernis = arcanovi_erschwernis;

                decimal odem_zfpstar = artefakt.taw.odem - odem_erschwernis;
                if (odem_zfpstar < 0) odem_zfpstar = 0;
                if (odem_zfpstar > artefakt.taw.odem) odem_zfpstar = artefakt.taw.odem;

                decimal analys_erschwernis = 0;
                analys_erschwernis -= Math.Floor(odem_zfpstar / 2);
                //TODO: What is this?
                //if (analys_erschwernis > artefakt.taw.analys) analys_erschwernis = -artefakt.taw.analys;

                decimal tawMagie = artefakt.taw.magiekunde - 7;
                if (tawMagie > 0) analys_erschwernis -= Math.Floor(tawMagie/3);

                // TODO: KRISTALL pAsP
                // TODO: WHAT ABOUT HOHE ASP?
                analys_erschwernis += Math.Floor(arcanovi_zfp / 5) + Math.Floor(arcanovi_erschwernis / 2) + pasp + artefakt.analys.bes_komlexitaet + artefakt.analys.mr + artefakt.analys.tarnzauber;

                if (!(eigene_rep_count >= (magic.Count / 2))) analys_erschwernis += 2;

                if (artefakt.analys.misslungen) analys_erschwernis += 3;

                decimal txt_analys_erschwernis = analys_erschwernis;
                if (analys_erschwernis < 0) analys_erschwernis = 0;
                decimal analys_count = 0;
                if ((artefakt.taw.analys - analys_erschwernis) > 0)
                {
                    analys_count = Math.Ceiling(19 / (artefakt.taw.analys - analys_erschwernis));
                    decimal analys_asp = 10;
                    if (artefakt.sf.rep == SF.SFType.ACH && ach_save.Checked) analys_asp = 8;
                    if (artefakt.sf.kraftkontrolle) analys_asp -= (1 + analys_count);                     
                    if (artefakt.sf.rep == SF.SFType.ACH && ach_save.Checked)
                        analys_asp += (analys_count - 1) * 2;
                    else
                        analys_asp += (analys_count - 1) * 3;

                    txt_analys.AppendText("ODEM erschwert um " + odem_erschwernis + " (maximal " + odem_zfpstar + " ZfP*)\r\n");
                    txt_analys.AppendText("ANALYS erschwert um " + txt_analys_erschwernis + "\r\n");
                    txt_analys.AppendText("Bester Fall: Vollständige Entschlüsselung nach " + analys_count + " ANALYS\r\n");
                    txt_analys.AppendText("Kosten für ODEM & ANALYS: " + analys_asp + "AsP\r\n");
                }
                else
                {
                    txt_analys.AppendText("Artefakt nicht analysierbar. TaW ANALYS zu gering.");
                }

                // Destructibo
                decimal destruct_erschwernis = 0;

                if (artefakt.destructibo.infinitum) destruct_erschwernis += 12;
                else destruct_erschwernis += 1;

                destruct_erschwernis += eigene_rep_count * 2 * (artefakt.loads * magic_asp_mult);
                destruct_erschwernis += (magic.Count - eigene_rep_count) * 4 * (artefakt.loads * magic_asp_mult);

                destruct_erschwernis += (artefakt.loads - artefakt.destructibo.aktive_loads);
                destruct_erschwernis += artefakt.destructibo.aktive_loads * 3;

                destruct_erschwernis += pasp;

                destruct_erschwernis += artefakt.destructibo.mr;

                destruct_erschwernis += artefakt.destructibo.komplex;

                txt_destruct.AppendText("Erschwernis DESTRUCTIBO: " + destruct_erschwernis + "\r\n");

                // Destructibo Einstimmung
                decimal destruct_einstimmung = Math.Floor(artefakt.taw.analys / 4);
                txt_destruct.AppendText("Maximal " + (destruct_einstimmung * 4) + " Stunden Einstimmung\r\n");
                destruct_erschwernis -= destruct_einstimmung;

                decimal destruct_analys_asp = 0;
                if (artefakt.taw.destructibo - destruct_erschwernis >= 0)
                    txt_destruct.AppendText("Bester Fall: 0 ANALYS\r\n");
                else if (Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3) > 0)
                {
                    decimal destruct_analys_count = Math.Ceiling((destruct_erschwernis - artefakt.taw.destructibo) / Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3));
                    destruct_analys_asp = 10;
                    if (artefakt.sf.rep == SF.SFType.ACH && ach_save.Checked) destruct_analys_asp = 8;
                    if (artefakt.sf.kraftkontrolle) destruct_analys_asp -= 2;
                    if (artefakt.sf.rep == SF.SFType.ACH && ach_save.Checked)
                        destruct_analys_asp += (destruct_analys_count - 1) * 2;
                    else
                        destruct_analys_asp += (destruct_analys_count - 1) * 3;

                    txt_destruct.AppendText("Bester Fall: " + destruct_analys_count + " ANALYS für insg. " + destruct_analys_asp + " AsP\r\n");

                    destruct_erschwernis -= Math.Floor(destruct_analys_count * (artefakt.taw.analys-analys_erschwernis) / 3);
                 }
                if (artefakt.taw.destructibo - destruct_erschwernis >= 0 || Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3) > 0)
                {
                    txt_destruct.AppendText("DESTRUCTIBO Gesamterschwernis: " + destruct_erschwernis + "\r\n");
                    txt_destruct.AppendText("Gesamt-AsP Kosten: " + (destruct_analys_asp + (magic_asp + arcanovi_asp + arcanovi_special_asp)) + "\r\n");
                    decimal destruct_pasp = Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20);
                    if (destruct_pasp <= 0) destruct_pasp = 1;
                    txt_destruct.AppendText("pAsP Kosten: " + destruct_pasp + "\r\n");
                }
                else
                    txt_destruct.AppendText("Zerstörung nicht möglich TaW DESTRUCTIBO bzw. ANALYS zu gering.\r\n");
            }*/
        }

        private void reload()
        {
            /*
            // Name
            if (artefakt.heldName != "")
                hero_name.Text = "Held: " + artefakt.heldName;
            else
                hero_name.Text = "";
            //SF
            sf_kraft.Checked = artefakt.sf.kraftkontrolle;
            sf_matrix.Checked = artefakt.sf.matrix;
            sf_ringkunde.Checked = artefakt.sf.ringkunde;
            sf_semiI.Checked = artefakt.sf.semi1;
            sf_semiII.Checked = artefakt.sf.semi2;
            sf_stapel.Checked = artefakt.sf.stapel;
            sf_hyper.Checked = artefakt.sf.hyper;
            sf_aux.Checked = artefakt.sf.auxiliator;
            sf_vielLadung.Checked = artefakt.sf.vielfacheLadung;
            rep_mag.Checked = (artefakt.sf.rep == SF.SFType.OTHER);
            rep_ach.Checked = (artefakt.sf.rep == SF.SFType.ACH);
            //TAW
            arcanovi_change.Value = artefakt.taw.arcanovi;
            arcanovi_matrix_change.Value = artefakt.taw.arcanovi_matrix;
            arcanovi_semi_change.Value = artefakt.taw.arcanovi_semi;
            odem_change.Value = artefakt.taw.odem;
            analys_change.Value = artefakt.taw.analys;
            magiekunde_change.Value = artefakt.taw.magiekunde;
            destruct_change.Value = artefakt.taw.destructibo;
            //Artefakttyp
            switch(artefakt.typ)
            {
                case Artefakt.ArtefaktType.TEMP: type_temp.Checked = true; break;
                case Artefakt.ArtefaktType.NORMAL: type_einaml.Checked = true; break;
                case Artefakt.ArtefaktType.RECHARGE: type_charge.Checked = true; break;
                case Artefakt.ArtefaktType.MATRIX: type_matrix.Checked = true; break;
                case Artefakt.ArtefaktType.SEMI: type_semi.Checked = true; break;
                case Artefakt.ArtefaktType.AUX: type_aux.Checked = true; break;
            };
            switch (artefakt.temp_typ)
            {
                case Artefakt.TempType.TAG: temp_tag.Checked = true; break;
                case Artefakt.TempType.WOCHE: temp_woche.Checked = true; break;
                case Artefakt.TempType.MONAT: temp_monat.Checked = true; break;
            };
            switch (artefakt.matrix_typ)
            {
                case Artefakt.MatrixType.LABIL: matrix_labil.Checked = true; break;
                case Artefakt.MatrixType.STABIL: matrix_stable.Checked = true; break;
                case Artefakt.MatrixType.SEHRSTABIL: matrix_verystable.Checked = true; break;
                case Artefakt.MatrixType.UNEMPFINDLICH: matrix_unempfindlich.Checked = true; break;
            };
            switch (artefakt.aux_typ)
            {
                case Artefakt.MatrixType.LABIL: aux_labil.Checked = true; break;
                case Artefakt.MatrixType.STABIL: aux_stable.Checked = true; break;
                case Artefakt.MatrixType.SEHRSTABIL: aux_verystable.Checked = true; break;
                case Artefakt.MatrixType.UNEMPFINDLICH: aux_unempfindlich.Checked = true; break;
            };
            aux_merkmal.Checked = artefakt.aux_merkmal;
            switch (artefakt.semi_typ)
            {
                    /*
                case Artefakt.SemiType.TAG: semi_tag.Checked = true; break;
                case Artefakt.SemiType.WOCHE: semi_woche.Checked = true; break;
                case Artefakt.SemiType.MONAT: semi_monat.Checked = true; break;
                case Artefakt.SemiType.JAHR: semi_jahr.Checked = true; break;
                     * */
            /*
            };
            // Spezielle eigenschaften
            special_signet.Checked = artefakt.spezial_siegel;
            special_scent.Checked = artefakt.spezial_gespuer;
            special_durable.Checked = artefakt.spezial_unzerbrechlich;
            special_apport.Checked = artefakt.spezial_apport;
            //WDA
            special_eatmaterial.Checked = artefakt.spezial_verzehrend;
            special_eatmat_var.Value = artefakt.spezial_verzehrend_var;
            special_reversalis.Checked = artefakt.spezial_reversalis;
            special_schleier.Checked = artefakt.spezial_verschleierung;
            special_variablerelease.Checked = artefakt.spezial_variablerausloeser;
            special_variable_var.Value = artefakt.spezial_variablerausloeser_var;
            special_selfrepair.Checked = artefakt.spezial_reperatur;
            special_ferngespuer.Checked = artefakt.spezial_ferngespuer;
            special_ferngespuer_komp.SelectedIndex = (int)(artefakt.spezial_ferngespuer_komp - 1);
            special_ferngespuer_asp.Value = artefakt.spezial_ferngespuer_asp;
            special_resistant.Checked = artefakt.spezial_resistent;
            //Material
            /*
            for (int i = 0; i < mat.sammlung.Count; i++)
                if (artefakt.material.name == mat.sammlung[i].name)
                    material.SelectedIndex = i;
             */
            /*
            //Besonderes
            limbus.Checked = artefakt.limbus;
            namenlos.Checked = artefakt.namenlos;
            agribaal.Value = artefakt.agribaal;
            special_ort_occ.Value = artefakt.special_ort_occ;
            special_ort_neben.Value = artefakt.special_ort_neben;
            //artefakt_super_big.SelectedIndex = (int)(artefakt.probe.superBig_zuschlag / 3);
            artefakt_super_big.SelectedIndex = 0; 
            //Probenzuschlaege
            probe_ausloes.Value = artefakt.probe.ausloeser;
            probe_affine.Value = artefakt.probe.affine;
            artefakt_groesse.Value = artefakt.probe.groesse;
            arcanovi_force.Value = artefakt.probe.erzwingen;
            starkonst.Value = artefakt.probe.stars;
            //Analys
            analys_broken.Checked = artefakt.analys.misslungen;
            analys_cloack.Value = artefakt.analys.tarnzauber;
            analys_komplex.Value = artefakt.analys.bes_komlexitaet;
            analys_mr.Value = artefakt.analys.mr;
            // Destructibo
            destruct_infinitum.Checked = artefakt.destructibo.infinitum;
            destruct_komplex.Value = artefakt.destructibo.komplex;
            destruct_mr.Value = artefakt.destructibo.mr;
            destruct_aktive.Value = artefakt.destructibo.aktive_loads;
            //ladungen
            loads.Value = artefakt.loads;
             * */
        }

        private void zauber_add_Click(object sender, EventArgs e)
        {
            Zauber zauber = new Zauber();
            zauber.asp = this.asp.Value;
            //zauber.load = this.loads.Value;
            zauber.staple = this.stapelung.Value;
            zauber.komp = this.komp_combo.Text;
            zauber.name = this.zauber.Text;
            if (this.zauber_rep.SelectedIndex == 0)
                zauber.eigene_rep = true;
            else
                zauber.eigene_rep = false;

            //magic.Add(zauber);
            BindingList<Zauber> z = controller.zauberListe;
            z.Add(zauber);
            controller.zauberListe = z;
            update(false);
        }

        private void zauber_del_Click(object sender, EventArgs e)
        {
            try
            {
                controller.zauberListe.RemoveAt(zauber_listbox.SelectedIndex);
                controller.zauberListe = controller.zauberListe;
            }
            catch (System.Exception ex)
            {
                	
            }
        }

        private void ArtGenControl_SizeChanged(object sender, EventArgs e)
        {
            //968; 516
            if (this.Size.Height < 515 || this.Size.Width < 967)
                this.Font = new System.Drawing.Font( this.Font.Name, 7.0f,
                this.Font.Style, this.Font.Unit,
                this.Font.GdiCharSet, this.Font.GdiVerticalFont );
            else
                this.Font = new System.Drawing.Font(this.Font.Name, 8.25f,
                this.Font.Style, this.Font.Unit,
                this.Font.GdiCharSet, this.Font.GdiVerticalFont);
        }

        #region MenuItems


        private void beendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }


        private void updateInstallierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatesToolStripMenuItem_Click(this,new EventArgs());
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateManager updManager = UpdateManager.Instance;
            DialogResult dr = MessageBox.Show(
        "Möchtest du jetzt das Update installieren? Alle nicht gespeicherten Änderungen gehen dabei verloren!",
        "Update installieren",
         MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                updManager.PrepareUpdatesAsync(OnPrepareUpdatesCompleted);
                this.Enabled = false;
                updatesToolStripMenuItem.Text = "Update wird installiert...";
                updatesToolStripMenuItem.ForeColor = Color.Green;
                updatesToolStripMenuItem.Enabled = false;
            }
        }

        private void neuesArtefaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alle nicht gespeicherten Änderungen am bisherigen Artefakt gehen verloren.\r\nWillst du wirklich ein neues Artefakt beginnen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                controller.clearArtefakt();
            }
        }

        private void artefaktLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = ".artefakt";
            openFileDialog.Filter = "Artefakte (*.artefakt)|*.artefakt";
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog.Multiselect = false;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.Title = "Artefakt Laden";

            if (MessageBox.Show("Alle nicht gespeicherten Änderungen am bisherigen Artefakt gehen verloren.\r\nWillst du wirklich ein anderes Artefakt laden?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog.OpenFile());

                    string xml = reader.ReadToEnd();
                    //string xml = System.IO.File.ReadAllText(@".\test.artefakt");

                    controller.loadArtefakt(xml);
                }
            }
        }

        private void artefaktSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Artefakte (*.artefakt)|*.artefakt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = "Artefakt speichern";
            saveFileDialog1.CheckPathExists = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(@saveFileDialog1.FileName, controller.saveArtefakt());
            }
        }

        private void nebeneffekteToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             artefakt.nebeneffekte = nebeneffekteToolStripMenuItem.Checked;
//             update(false);
        }

        private void occupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             artefakt.occupation = occupationToolStripMenuItem.Checked;
//             update(false);
        }

        private void alleBerechnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alleBerechnenToolStripMenuItem.Checked)
            {
                controller.W20 = 0;
                controller.W6 = 0;
                w6AnnehmenToolStripMenuItem.Enabled = false;
                w20ToolStripMenuItem.Enabled = false;
                controller.optionAllesBerechnen = true;
            }
            else
            {
                w6AnnehmenToolStripMenuItem.Enabled = true;
                w20ToolStripMenuItem.Enabled = true;
                controller.optionAllesBerechnen = false;
                if (w6_1.Checked) controller.W6 = 1;
                if (w6_35.Checked) controller.W6 = 3.5m;
                if (w6_4.Checked) controller.W6 = 4;
                if (w6_6.Checked) controller.W6 = 6;
                if (w20_1.Checked) controller.W20 = 1;
                if (w20_10.Checked) controller.W20 = 10;
                if (w20_105.Checked) controller.W20 = 10.5m;
                if (w20_11.Checked) controller.W20 = 11;
                if (w20_20.Checked) controller.W20 = 20;
            }
        }

        private void w6_1_Click(object sender, EventArgs e)
        {
            controller.W6 = 1;
            if (!w6_1.Checked) w6_1.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
        }

        private void w6_6_Click(object sender, EventArgs e)
        {
            controller.W6 = 6;
            if (!w6_6.Checked) w6_6.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_1.Checked = false;
        }

        private void w6_35_Click(object sender, EventArgs e)
        {
            controller.W6 = 3.5m;
            if (!w6_35.Checked) w6_35.Checked = true;
            w6_1.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
        }

        private void w6_4_Click(object sender, EventArgs e)
        {
            controller.W6 = 4;
            if (!w6_4.Checked) w6_4.Checked = true;
            w6_1.Checked = false;
            w6_35.Checked = false;
            w6_6.Checked = false;
        }

        private void w20_1_Click(object sender, EventArgs e)
        {
            controller.W20 = 1;
            if (!w20_1.Checked) w20_1.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
        }

        private void w20_10_Click(object sender, EventArgs e)
        {
            controller.W20 = 10;
            if (!w20_10.Checked) w20_10.Checked = true;
            w20_1.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
        }

        private void w20_105_Click(object sender, EventArgs e)
        {
            controller.W20 = 10.5m;
            if (!w20_105.Checked) w20_105.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
        }

        private void w20_11_Click(object sender, EventArgs e)
        {
            controller.W20 = 11m;
            if (!w20_11.Checked) w20_11.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_20.Checked = false;
        }

        private void w20_20_Click(object sender, EventArgs e)
        {
            controller.W20 = 20;
            if (!w20_20.Checked) w20_20.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_1.Checked = false;
        }

        private void wegeDerAlchimieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = true;
            wegeDerAlchimieToolStripMenuItem.Checked = true;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = false;
        }

        private void staebeRingeDschinnenlampenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = false;
            wegeDerAlchimieToolStripMenuItem.Checked = false;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = true;
        }
        #endregion

        private void ach_save_Click(object sender, EventArgs e)
        {
            if (ach_save.Checked)
                controller.optionAchSave = true;
            else
                controller.optionAchSave = false;
        }

        private void importHeldensoftwareToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showSelectHeroDialog(Form.ActiveForm);
        }

        public void showSelectHeroDialog(Form form)
        {
            HeldAuswahl auswahl = new HeldAuswahl(this, LadeHelden.ladeHelden());
            auswahl.StartPosition = FormStartPosition.CenterParent;
            auswahl.ShowDialog(form);
        }

        private void ArtGenControl_Load(object sender, EventArgs e)
        {
            this.hero_name.DataBindings.Add("Text", controller, "heldName",false, DataSourceUpdateMode.OnPropertyChanged);
            this.groupBox2.DataBindings.Add("Selected", controller, "sfRepresentation", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_kraft.DataBindings.Add("Checked", controller, "sfKraftkontrolle", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_vielLadung.DataBindings.Add("Checked", controller, "sfVielfacheLadung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_stapel.DataBindings.Add("Checked", controller, "sfStapeleffekt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_hyper.DataBindings.Add("Checked", controller, "sfHypervehemenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_hyper.DataBindings.Add("Enabled", controller, "sfHypervehemenzEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_matrix.DataBindings.Add("Checked", controller, "sfMatrixgeber", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiI.DataBindings.Add("Checked", controller, "sfSemipermanenz1", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiII.DataBindings.Add("Checked", controller, "sfSemipermanenz2", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiII.DataBindings.Add("Enabled", controller, "sfSemipermanenz2Enabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_ringkunde.DataBindings.Add("Checked", controller, "sfRingkunde", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_kraftspeicher.DataBindings.Add("Checked", controller, "sfKraftspeicher", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_aux.DataBindings.Add("Checked", controller, "sfAuxiliator", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_aux.DataBindings.Add("Enabled", controller, "sfAuxiliatorEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_aux.DataBindings.Add("Visible", controller, "sfAuxiliatorVisible", false, DataSourceUpdateMode.OnPropertyChanged);

            this.arcanovi_change.DataBindings.Add("Value", controller, "tawArcanovi", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_matrix_change.DataBindings.Add("Value", controller, "tawArcanoviMatrix", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_matrix_change.DataBindings.Add("Enabled", controller, "tawArcanoviMatrixEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_matrix_lbl.DataBindings.Add("Enabled", controller, "tawArcanoviMatrixEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_semi_change.DataBindings.Add("Value", controller, "tawArcanoviSemipermanenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_semi_change.DataBindings.Add("Enabled", controller, "tawArcanoviSemipermanenzEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.odem_change.DataBindings.Add("Value", controller, "tawOdem", false, DataSourceUpdateMode.OnPropertyChanged);
            this.analys_change.DataBindings.Add("Value", controller, "tawAnalys", false, DataSourceUpdateMode.OnPropertyChanged);
            this.magiekunde_change.DataBindings.Add("Value", controller, "tawMagiekunde", false, DataSourceUpdateMode.OnPropertyChanged);
            this.destruct_change.DataBindings.Add("Value", controller, "tawDestructibo", false, DataSourceUpdateMode.OnPropertyChanged);

            this.artefakttyp.DataBindings.Add("Selected", controller, "artefakttyp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_matrix.DataBindings.Add("Enabled", controller, "sfMatrixgeber", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_semi.DataBindings.Add("Enabled", controller, "artefakttypSemipermanenzEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_aux.DataBindings.Add("Enabled", controller, "artefakttypAuxiliatorEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_temp.DataBindings.Add("Enabled", controller, "artefakttypTempEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_aux.DataBindings.Add("Visible", controller, "sfAuxiliatorVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_speicher.DataBindings.Add("Enabled", controller, "sfKraftspeicher", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_temp.DataBindings.Add("Selected", controller, "artefakttypTemp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_temp.DataBindings.Add("Visible", controller, "artefakttypTempVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_matrix.DataBindings.Add("Selected", controller, "artefakttypMatrix", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_matrix.DataBindings.Add("Visible", controller, "artefakttypMatrixVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_semi.DataBindings.Add("Selected", controller, "artefakttypSemipermanenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_semi.DataBindings.Add("Visible", controller, "artefakttypSemipermanenzVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_speicher_value.DataBindings.Add("Visible", controller, "artefakttypKraftspeicherVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_type_speicher_val.DataBindings.Add("Visible", controller, "artefakttypKraftspeicherVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.wirkendeZauber.DataBindings.Add("Enabled", controller, "wirkendeZauberEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.materialGroup.DataBindings.Add("Enabled", controller, "wirkendeZauberEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.type_speicher_value.DataBindings.Add("Value", controller, "artefakttypKraftspeicher", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_aux.DataBindings.Add("Selected", controller, "artefakttypAuxiliator", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_aux.DataBindings.Add("Visible", controller, "artefakttypAuxiliatorVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.aux_merkmal.DataBindings.Add("Checked", controller, "artefakttypAuxiliatorMerkmal", false, DataSourceUpdateMode.OnPropertyChanged);

            this.special_signet.DataBindings.Add("Checked", controller, "spezialSiegel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_signet.DataBindings.Add("Enabled", controller, "spezialSiegelEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_durable.DataBindings.Add("Checked", controller, "spezialUnzerbrechlich", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_scent.DataBindings.Add("Checked", controller, "spezialGespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_apport.DataBindings.Add("Checked", controller, "spezialApport", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_resistant.DataBindings.Add("Checked", controller, "spezialResistenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_resistant.DataBindings.Add("Visible", controller, "spezialResistenzVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_selfrepair.DataBindings.Add("Checked", controller, "spezialSelbstreparatur", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_selfrepair.DataBindings.Add("Visible", controller, "spezialSelbstreparaturVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer.DataBindings.Add("Checked", controller, "spezialFerngespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer.DataBindings.Add("Enabled", controller, "spezialFerngespuerEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_special_asp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_special_komp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_special_asp.DataBindings.Add("Enabled", controller, "spezialFerngespuerEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_special_komp.DataBindings.Add("Enabled", controller, "spezialFerngespuerEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("Enabled", controller, "spezialFerngespuerEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Enabled", controller, "spezialFerngespuerEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Value", controller, "spezialFerngespuerAsp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("SelectedValue", controller, "spezialFerngespuerKomp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Checked", controller, "spezialUmkehrtalisman", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Visible", controller, "spezialUmkehrtalismanVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Enabled", controller, "spezialUmkehrtalismanEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Checked", controller, "spezialVariablerAusloeser", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Visible", controller, "spezialVariablerAusloeserVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Enabled", controller, "spezialVariablerAusloeserEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Value", controller, "spezialVariablerAusloeserVar", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Visible", controller, "spezialVariablerAusloeserVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Enabled", controller, "spezialVariablerAusloeserEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Checked", controller, "spezialVerschleierung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Visible", controller, "spezialVerschleierungVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Enabled", controller, "spezialVerschleierungEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Checked", controller, "spezialVerzehrend", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Visible", controller, "spezialVerzehrendVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Enabled", controller, "spezialVerzehrendEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Value", controller, "spezialVerzehrendVar", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Visible", controller, "spezialVerzehrendVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Enabled", controller, "spezialVerzehrendEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

            this.limbus.DataBindings.Add("Checked", controller, "extraMadeInLimbus", false, DataSourceUpdateMode.OnPropertyChanged);
            this.namenlos.DataBindings.Add("Checked", controller, "extraNamenloseTage", false, DataSourceUpdateMode.OnPropertyChanged);
            this.gemeinschaftlich.DataBindings.Add("Checked", controller, "extraGemeinschaftlicheErschaffung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.agribaal.DataBindings.Add("Value", controller, "extraAgribaal", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ort_occ.DataBindings.Add("Value", controller, "extraOkkupation", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ort_neben.DataBindings.Add("Value", controller, "extraNebeneffekt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakt_super_big.DataBindings.Add("SelectedIndex", controller, "extraExtraGross", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cb_kristalle.DataBindings.Add("Checked", controller, "extraKristalle", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cb_kristalle.DataBindings.Add("Visible", controller, "extraKristalleVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.material.DataSource = controller.material;
            this.material.DataBindings.Add("SelectedIndex", controller, "selectedMaterial", false, DataSourceUpdateMode.OnPropertyChanged);

            this.probe_ausloes.DataBindings.Add("Value", controller, "probeAusloeser", false, DataSourceUpdateMode.OnPropertyChanged);
            this.probe_affine.DataBindings.Add("Value", controller, "probeAffin", false, DataSourceUpdateMode.OnPropertyChanged);
            this.probe_affine.DataBindings.Add("Maximum", controller, "probeAffinMax", false, DataSourceUpdateMode.OnPropertyChanged);
            this.probe_affine.DataBindings.Add("Minimum", controller, "probeAffinMin", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakt_groesse.DataBindings.Add("Value", controller, "probeGroesse", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakt_groesse.DataBindings.Add("Enabled", controller, "probeGroesseEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_force.DataBindings.Add("Value", controller, "probeErzwingen", false, DataSourceUpdateMode.OnPropertyChanged);
            this.starkonst.DataBindings.Add("Value", controller, "probeSterne", false, DataSourceUpdateMode.OnPropertyChanged);

            this.zauber_listbox.DataSource = controller.zauberListe;
            this.stapelung.DataBindings.Add("Maximum", controller, "zauberStapelMax", false, DataSourceUpdateMode.OnPropertyChanged);
            this.stapelung.DataBindings.Add("Enabled", controller, "zauberStapelEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_staple.DataBindings.Add("Enabled", controller, "zauberStapelEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.loads.DataBindings.Add("Value", controller, "zauberLadungen", false, DataSourceUpdateMode.OnPropertyChanged);
            this.loads.DataBindings.Add("Enabled", controller, "zauberLadungenEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.loads_lbl.DataBindings.Add("Enabled", controller, "zauberLadungenEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

            this.txt_create.DataBindings.Add("Text", controller, "resultArcanovi", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_analys.DataBindings.Add("Text", controller, "resultAnalys", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txt_destruct.DataBindings.Add("Text", controller, "resultDestructibo", false, DataSourceUpdateMode.OnPropertyChanged);

            this.analys_broken.DataBindings.Add("Checked", controller, "analysMisslungen", false, DataSourceUpdateMode.OnPropertyChanged);
            this.analys_komplex.DataBindings.Add("Value", controller, "analysKomplex", false, DataSourceUpdateMode.OnPropertyChanged);
            this.analys_mr.DataBindings.Add("Value", controller, "analysMR", false, DataSourceUpdateMode.OnPropertyChanged);
            this.analys_cloack.DataBindings.Add("Value", controller, "analysTarnzauber", false, DataSourceUpdateMode.OnPropertyChanged);

            this.destruct_infinitum.DataBindings.Add("Checked", controller, "destructiboInfinitum", false, DataSourceUpdateMode.OnPropertyChanged);
            this.destruct_komplex.DataBindings.Add("Value", controller, "destructiboKomplex", false, DataSourceUpdateMode.OnPropertyChanged);
            this.destruct_mr.DataBindings.Add("Value", controller, "destructiboMR", false, DataSourceUpdateMode.OnPropertyChanged);
            this.destruct_aktive.DataBindings.Add("Value", controller, "destructiboAktiveLadungen", false, DataSourceUpdateMode.OnPropertyChanged);

            controller.init();

            stapelung.Minimum = 1;
            zauber_rep.SelectedIndex = 0;

            controller.optionAchSave = ArtefaktGenerator.Properties.Settings.Default.saveAch;
            ach_save.Checked = controller.optionAchSave;
            controller.WDA = ArtefaktGenerator.Properties.Settings.Default.WDA;
            wegeDerAlchimieToolStripMenuItem.Checked = controller.WDA;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = !controller.WDA;
            heldenimportToolStripMenuItem.Checked = ArtefaktGenerator.Properties.Settings.Default.showHeldenImport;
            controller.optionNebeneffekteNeuWuerfeln = ArtefaktGenerator.Properties.Settings.Default.reRollNeben;
            nebenReRollToolStripMenuItem.Checked = controller.optionNebeneffekteNeuWuerfeln;
            nebenIgnoreToolStripMenuItem.Checked = !controller.optionNebeneffekteNeuWuerfeln;
            showPDFToolStripMenuItem.Checked = ArtefaktGenerator.Properties.Settings.Default.showSavedPDF;
            switch(ArtefaktGenerator.Properties.Settings.Default.diceW6)
            {
                case 0: w6_1_Click(this, null); break;
                case 1: w6_35_Click(this, null); break;
                case 2: w6_4_Click(this, null); break;
                case 3: w6_6_Click(this, null); break;
            }
            switch (ArtefaktGenerator.Properties.Settings.Default.diceW20)
            {
                case 0: w20_1_Click(this, null); break;
                case 1: w20_10_Click(this, null); break;
                case 2: w20_105_Click(this, null); break;
                case 3: w20_11_Click(this, null); break;
                case 4: w20_20_Click(this, null); break;
            }
            if (ArtefaktGenerator.Properties.Settings.Default.diceRandom)
            {
                alleBerechnenToolStripMenuItem.Checked = true;
                alleBerechnenToolStripMenuItem_Click(this, null);
            }

        }

        public void saveOptions()
        {
            ArtefaktGenerator.Properties.Settings.Default.saveAch = controller.optionAchSave;
            ArtefaktGenerator.Properties.Settings.Default.WDA = controller.WDA;
            if (controller.W6 == 1) ArtefaktGenerator.Properties.Settings.Default.diceW6 = 0;
            if (controller.W6 == 3.5m) ArtefaktGenerator.Properties.Settings.Default.diceW6 = 1;
            if (controller.W6 == 4) ArtefaktGenerator.Properties.Settings.Default.diceW6 = 2;
            if (controller.W6 == 6) ArtefaktGenerator.Properties.Settings.Default.diceW6 = 3;
            if (controller.W20 == 1) ArtefaktGenerator.Properties.Settings.Default.diceW20 = 0;
            if (controller.W20 == 10) ArtefaktGenerator.Properties.Settings.Default.diceW20 = 1;
            if (controller.W20 == 10.5m) ArtefaktGenerator.Properties.Settings.Default.diceW20 = 2;
            if (controller.W20 == 11) ArtefaktGenerator.Properties.Settings.Default.diceW20 = 3;
            if (controller.W20 == 20) ArtefaktGenerator.Properties.Settings.Default.diceW20 = 4;
            ArtefaktGenerator.Properties.Settings.Default.diceRandom = controller.optionAllesBerechnen;
            ArtefaktGenerator.Properties.Settings.Default.showHeldenImport = heldenimportToolStripMenuItem.Checked;
            ArtefaktGenerator.Properties.Settings.Default.showSavedPDF = showPDFToolStripMenuItem.Checked;
            ArtefaktGenerator.Properties.Settings.Default.reRollNeben = controller.optionNebeneffekteNeuWuerfeln;
            Properties.Settings.Default.Save();
        }

        private void exportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new SaveFileDialog();

            saveFileDialog2.Filter = "PDF (*.pdf)|*.pdf";
            saveFileDialog2.FilterIndex = 1;
            saveFileDialog2.RestoreDirectory = true;
            saveFileDialog2.AddExtension = true;
            saveFileDialog2.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            saveFileDialog2.OverwritePrompt = true;
            saveFileDialog2.Title = "Artefakt als PDF exportieren";
            saveFileDialog2.CheckPathExists = true;

            if (controller.zauberListe.Count > 0)
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    controller.exportArtefaktAsPDF(saveFileDialog2.FileName);
                    if (showPDFToolStripMenuItem.Checked) System.Diagnostics.Process.Start(saveFileDialog2.FileName);
                }
            }
            else
                MessageBox.Show("Dein Artefakt hat keine wirkenden Zauber!", "Fehler");
        }

        private void nebenReRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.optionNebeneffekteNeuWuerfeln = true;
            nebenReRollToolStripMenuItem.Checked = true;
            nebenIgnoreToolStripMenuItem.Checked = false;
        }

        private void nebenIgnoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.optionNebeneffekteNeuWuerfeln = false;
            nebenIgnoreToolStripMenuItem.Checked = true;
            nebenReRollToolStripMenuItem.Checked = false;
        }

        private void special_variablerelease_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void special_variable_var_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
