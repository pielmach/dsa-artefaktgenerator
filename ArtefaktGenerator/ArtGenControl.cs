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
        public Artefakt artefakt = new Artefakt();
        public List<Zauber> magic = new List<Zauber>();
        private Wuerfel dice = new Wuerfel();
        private MaterialSammlung mat;
        private Occupation occ = new Occupation();

        public GUI gui = new GUI();

        public ArtGenControl() : this (false)
        {
        }

        public ArtGenControl(bool plugInMode)
        {
            InitializeComponent();
            mat = new MaterialSammlung(dice);

            // Disable Non-PlugIn fields
            if (plugInMode)
            {
                updatesToolStripMenuItem.Visible = false;
                programmToolStripMenuItem1.Visible = false;
            }

            for (int i = 0; i < mat.sammlung.Count; i++)
            {
                material.Items.Add(mat.sammlung[i].name);
            }
            material.SelectedItem = ("kein");

            zauber_rep.SelectedIndex = 0;
			
            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateFeedReader = new NAppUpdate.Framework.FeedReaders.NauXmlFeedReader();
            updManager.TempFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ArtefaktGenerator");
            if (!plugInMode)
                updManager.UpdateSource = new NAppUpdate.Framework.Sources.SimpleWebSource("http://www.dsa-hamburg.de/artgen/update/update.xml");
            else
                updManager.UpdateSource = new NAppUpdate.Framework.Sources.SimpleWebSource("http://www.dsa-hamburg.de/artgen/update/updatedll.xml");

			if (isLinux())
				updatesToolStripMenuItem.Visible = false;
			
            reload();
            update(false);
            if (!plugInMode && !isLinux())
                CheckForUpdates();
        }

		
		
		public bool isLinux()
		{
			int p = (int) Environment.OSVersion.Platform;
		    return (p == 4) || (p == 6) || (p == 128);
		}

        private void ClrBfrChk(object sender, GroupBox groupbox)
        {

            if (!((RadioButton)sender).Checked)
            {

                foreach (Control radioBtn in groupbox.Controls)
                {

                    RadioButton RdBtn = radioBtn as RadioButton;

                    if (RdBtn != null)
                    {

                        RdBtn.Checked = false;

                    }

                }

            }

        }

 

		/*
         * plugInHeroFromXml
         * 
         * Use this function to import the values of an Hero from the popular "Helden-Software".
         * 
         * @param xml: The XML-String as exported from the Helden-Software
         * 
         * @return The return value is false, if an illegal combination of sf's is chosen
         * (e.g. sfHypervehemenz without sfStapeleffekt) - otherwise it is true. 
         * The taw's are NOT range checked, however they must be positive.
         * Faulty TaW's or non-existing TaW's are considered to be 0
         */
        public bool plugInHeroFromXml(string xml)
        {
            bool kraftkontrolle = Regex.IsMatch(xml, "sonderfertigkeit name=\"Kraftkontrolle\"");
            bool vielLadung = Regex.IsMatch(xml, "sonderfertigkeit name=\"Vielfache Ladungen\"");
            bool stapeleffekt = Regex.IsMatch(xml, "sonderfertigkeit name=\"Stapeleffekt\"");
            bool hyper = Regex.IsMatch(xml, "sonderfertigkeit name=\"Hypervehemenz\"");
            bool matrixgeber = Regex.IsMatch(xml, "sonderfertigkeit name=\"Matrixgeber\"");
            bool semiI = Regex.IsMatch(xml, "sonderfertigkeit name=\"Semipermanenz I\"");
            bool semiII = Regex.IsMatch(xml, "sonderfertigkeit name=\"Semipermanenz II\"");
            bool aux = Regex.IsMatch(xml, "sonderfertigkeit name=\"Auxiliator\"");

            bool isMag = Regex.IsMatch(xml, "sonderfertigkeit (kommentar=\"[^\"]*\" )?name=\"Repräsentation: Magier\"");
            bool isAchaz = Regex.IsMatch(xml, "sonderfertigkeit (kommentar=\"[^\"]*\" )?name=\"Repräsentation: Kristallomant\"");

            // Default: Magier
            if (!isMag && !isAchaz)
            {
                isMag = true;
            }

            uint magiekunde = 0;
            uint analys = 0;
            uint arcanovi = 0;
            uint arcanovi_matrix = 0;
            uint arcanovi_semi = 0;
            uint odem = 0;
            uint destructibo = 0;

            string name = "";

            string[] te = Regex.Split(xml, "talent.*name=\"Magiekunde\" probe=\".*\" value=\"(.*)\".*");
            try
            {
                magiekunde = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Analys Arkanstruktur\" probe=\".*\" value=\"(.*)\".*variante");
            try
            {
                analys = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Arcanovi Artefakt\" probe=\".*\" value=\"(.*)\".*variante=\"\"");
            try
            {
                arcanovi = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Arcanovi Artefakt\" probe=\".*\" value=\"(.*)\".*variante=\"Matrixgeber\"");
            try
            {
                arcanovi_matrix = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Arcanovi Artefakt\" probe=\".*\" value=\"(.*)\".*variante=\"Semipermanenz\"");
            try
            {
                arcanovi_semi = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Odem Arcanum\" probe=\".*\" value=\"(.*)\".*variante");
            try
            {
                odem = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            te = Regex.Split(xml, "zauber.*name=\"Destructibo Arcanitas\" probe=\".*\" value=\"(.*)\".*variante");
            try
            {
                destructibo = Convert.ToUInt32(te[1]);
            }
            catch (System.Exception ex) { }

            //<held key="1316061294421" name="Kein Name">
            te = Regex.Split(xml, "held key=\".*\" name=\"(.*)\".*");
            try
            {
                name = te[1];
            }
            catch (System.Exception ex) { }


            return plugInHero(name,(isMag ? SF.SFType.OTHER : SF.SFType.ACH), kraftkontrolle, vielLadung, stapeleffekt, hyper, matrixgeber, semiI, semiII, false, aux, arcanovi, arcanovi_matrix, arcanovi_semi, odem, analys, destructibo, magiekunde);
        }

        /*
         * plugInHero
         * 
         * use the function parameters to set the values of the sf's and taw's.
         * All values must be set, however certain values may be irrelevant.
         * Example: when not setting sfMatrixgeber, the value of tawArcanoviMatrix is irrelevant,
         * as the field gets deactivated.
         * 
         * @return The return value is false, if an illegal combination of sf's is chosen
         * (e.g. sfHypervehemenz without sfStapeleffekt) - otherwise it is true. 
         * The taw's are NOT range checked, however they must be positive.
         */
        public bool plugInHero(
            string name,
            SF.SFType representation, 
            bool sfKraftkontrolle, 
            bool sfVielfacheLadung, 
            bool sfStapeleffekt, 
            bool sfHypervehemenz, 
            bool sfMatrixgeber,
            bool sfSemipermI,
            bool sfSemipermII,
            bool sfRingkunde,
            bool sfAuxiliator,
            uint tawArcanovi,
            uint tawArcanoviMatrix,
            uint tawArcanoviSemi,
            uint tawOdem,
            uint tawAnalys,
            uint tawDestructibo,
            uint tawMagiekunde
            )
        {
            if (
                (sfHypervehemenz && !sfStapeleffekt)
                || (sfSemipermII && !sfSemipermI)
                || (sfAuxiliator && !sfMatrixgeber)
                )
                return false;

            // set values
            artefakt.sf.rep = representation;
            artefakt.sf.kraftkontrolle = sfKraftkontrolle;
            artefakt.sf.vielfacheLadung = sfVielfacheLadung;
            artefakt.sf.stapel = sfStapeleffekt;
            artefakt.sf.hyper = sfHypervehemenz;
            artefakt.sf.matrix = sfMatrixgeber;
            artefakt.sf.semi1 = sfSemipermI;
            artefakt.sf.semi2 = sfSemipermII;
            artefakt.sf.ringkunde = sfRingkunde;
            artefakt.sf.auxiliator = sfAuxiliator;

            artefakt.taw.arcanovi = tawArcanovi;
            artefakt.taw.arcanovi_matrix = tawArcanoviMatrix;
            artefakt.taw.arcanovi_semi = tawArcanoviSemi;
            artefakt.taw.analys = tawAnalys;
            artefakt.taw.destructibo = tawDestructibo;
            artefakt.taw.magiekunde = tawMagiekunde;
            artefakt.taw.odem = tawOdem;

            artefakt.heldName = name;

            reload();
            update(true);

            return true;
        }
        public bool plugInHero (
            SF.SFType representation, 
            bool sfKraftkontrolle, 
            bool sfVielfacheLadung, 
            bool sfStapeleffekt, 
            bool sfHypervehemenz, 
            bool sfMatrixgeber,
            bool sfSemipermI,
            bool sfSemipermII,
            bool sfRingkunde,
            bool sfAuxiliator,
            uint tawArcanovi,
            uint tawArcanoviMatrix,
            uint tawArcanoviSemi,
            uint tawOdem,
            uint tawAnalys,
            uint tawDestructibo,
            uint tawMagiekunde
            )
        {
            return plugInHero("", representation, sfKraftkontrolle, sfVielfacheLadung, sfStapeleffekt, sfHypervehemenz, sfMatrixgeber, sfSemipermI, sfSemipermII, sfRingkunde, sfAuxiliator, tawArcanovi, tawArcanoviMatrix, tawArcanoviSemi, tawOdem, tawAnalys, tawDestructibo, tawMagiekunde);
        }

        public void plugInLoadArtefakt()
        {
            artefaktLadenToolStripMenuItem_Click(null, null);
        }

        public void plugInSaveArtefakt()
        {
            artefaktSpeichernToolStripMenuItem_Click(null, null);
        }

        public void plugInNewArtefakt()
        {
            neuesArtefaktToolStripMenuItem_Click(null, null);
        }

        public void plugInOptions(
            Artefakt.Regelbasis regelbasis,
            bool autoNeuBerechnen = true,
            bool okkupation = true,
            bool nebeneffekte = true,
            bool achazEinsparung = true
            )
        {
            artefakt.regelbasis = regelbasis;
            if (regelbasis == Artefakt.Regelbasis.WDA)
            {
                wegeDerAlchimieToolStripMenuItem.Checked = true;
                staebeRingeDschinnenlampenToolStripMenuItem.Checked = false;
            }
            else
            {
                wegeDerAlchimieToolStripMenuItem.Checked = false;
                staebeRingeDschinnenlampenToolStripMenuItem.Checked = true;
            }

        }


        private bool WDA()
        {
            return artefakt.regelbasis == Artefakt.Regelbasis.WDA;
        }

        private decimal Round(decimal x)
        {
            return Math.Round(x, MidpointRounding.AwayFromZero);
        }

        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }


        private Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public String SerializeObject(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(DasArtefakt));
                System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (System.IO.MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public Object DeserializeObject(String pXmlizedString)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(DasArtefakt));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);

            return xs.Deserialize(memoryStream);
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

            //temporaer check
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

            // add magic
            zauber_list.Items.Clear();

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
                calcCreate();
            }
        }

        private void calcCreate()
        {
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
            }
        }

        private void reload()
        {
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
                case Artefakt.SemiType.TAG: semi_tag.Checked = true; break;
                case Artefakt.SemiType.WOCHE: semi_woche.Checked = true; break;
                case Artefakt.SemiType.MONAT: semi_monat.Checked = true; break;
                case Artefakt.SemiType.JAHR: semi_jahr.Checked = true; break;
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
            for (int i = 0; i < mat.sammlung.Count; i++)
                if (artefakt.material.name == mat.sammlung[i].name)
                    material.SelectedIndex = i;
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
        }

        private void delStapelZauber()
        {
            // TODO: DELTE all with staples
        }

        private void sf_kraft_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.kraftkontrolle = sf_kraft.Checked;
            update(false);
        }

        private void rep_ach_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rep_mag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sf_stapel_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.stapel = sf_stapel.Checked;
            update(false);
        }

        private void sf_hyper_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.hyper = sf_hyper.Checked;
            update(false);
        }

        private void sf_matrix_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.matrix = sf_matrix.Checked;
            update(false);
        }

        private void sf_semiI_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.semi1 = sf_semiI.Checked;
            update(false);
        }

        private void sf_semiII_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.semi2 = sf_semiII.Checked;
            update(false);
        }

        private void sf_ringkunde_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.ringkunde = sf_ringkunde.Checked;
            update(false);
        }

        private void type_temp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_temp.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.TEMP;
                loads_lbl.Enabled = true;
                loads.Enabled = true;
                update(false);
            }
        }

        private void type_einaml_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_einaml.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.NORMAL;
                loads_lbl.Enabled = true;
                loads.Enabled = true;
                update(false);
            }
        }

        private void type_charge_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_charge.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.RECHARGE;
                loads_lbl.Enabled = true;
                loads.Enabled = true;
                update(false);
            }
        }

        private void type_matrix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_matrix.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.MATRIX;
                loads_lbl.Enabled = false;
                loads.Enabled = false;
                update(false);
            }
        }

        private void type_semi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_semi.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.SEMI;
                loads_lbl.Enabled = true;
                loads.Enabled = true;
                update(false);
            }
        }

        private void arcanovi_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.arcanovi = this.arcanovi_change.Value;
            update(false);
        }

        private void arcanovi_matrix_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.arcanovi_matrix = this.arcanovi_matrix_change.Value;
            update(false);
        }

        private void arcanovi_semi_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.arcanovi_semi = this.arcanovi_semi_change.Value;
            update(false);
        }

        private void probe_ausloes_ValueChanged(object sender, EventArgs e)
        {
            artefakt.probe.ausloeser = this.probe_ausloes.Value;
            update(false);
        }

        private void probe_affine_ValueChanged(object sender, EventArgs e)
        {
            artefakt.probe.affine = this.probe_affine.Value;
            update(false);
        }

        private void zauber_add_Click(object sender, EventArgs e)
        {
            Zauber zauber = new Zauber();
            zauber.asp = this.asp.Value;
            //zauber.load = this.loads.Value;
            zauber.staple = this.stapel.Value;
            zauber.komp = this.komp_combo.Text;
            zauber.name = this.zauber.Text;
            if (this.zauber_rep.SelectedIndex == 0)
                zauber.eigene_rep = true;
            else
                zauber.eigene_rep = false;

            magic.Add(zauber);
            update(false);
        }

        private void zauber_del_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection col = zauber_list.SelectedItems;
            for (int i = 0; i < col.Count; i++)
            {
                for (int j = 0; j < magic.Count; j++)
                {
                    if (magic[j].name == col[i].Text)
                    {
                        magic.RemoveAt(j);
                        break;
                    }
                }
            }
            update(false);
        }

        private void vielLadung_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.vielfacheLadung = sf_vielLadung.Checked;
            update(false);
        }

        private void temp_tag_CheckedChanged(object sender, EventArgs e)
        {
            if (this.temp_tag.Checked)
                artefakt.temp_typ = Artefakt.TempType.TAG;
            update(false);
        }

        private void temp_woche_CheckedChanged(object sender, EventArgs e)
        {
            if (this.temp_woche.Checked)
                artefakt.temp_typ = Artefakt.TempType.WOCHE;
            update(false);
        }

        private void temp_monat_CheckedChanged(object sender, EventArgs e)
        {
            if (this.temp_monat.Checked)
                artefakt.temp_typ = Artefakt.TempType.MONAT;
            update(false);
        }

        private void matrix_labil_CheckedChanged(object sender, EventArgs e)
        {
            if (this.matrix_labil.Checked)
                artefakt.matrix_typ = Artefakt.MatrixType.LABIL;
            update(false);
        }

        private void matrix_stable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.matrix_stable.Checked)
                artefakt.matrix_typ = Artefakt.MatrixType.STABIL;
            update(false);
        }

        private void matrix_verystable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.matrix_verystable.Checked)
                artefakt.matrix_typ = Artefakt.MatrixType.SEHRSTABIL;
            update(false);
        }

        private void matrix_unempfindlich_CheckedChanged(object sender, EventArgs e)
        {
            if (this.matrix_unempfindlich.Checked)
                artefakt.matrix_typ = Artefakt.MatrixType.UNEMPFINDLICH;
            update(false);
        }

        private void semi_tag_CheckedChanged(object sender, EventArgs e)
        {
            if (this.semi_tag.Checked)
                artefakt.semi_typ = Artefakt.SemiType.TAG;
            update(false);
        }

        private void semi_woche_CheckedChanged(object sender, EventArgs e)
        {
            if (this.semi_woche.Checked)
                artefakt.semi_typ = Artefakt.SemiType.WOCHE;
            update(false);
        }

        private void semi_monat_CheckedChanged(object sender, EventArgs e)
        {
            if (this.semi_monat.Checked)
                artefakt.semi_typ = Artefakt.SemiType.MONAT;
            update(false);
        }

        private void semi_jahr_CheckedChanged(object sender, EventArgs e)
        {
            if (this.semi_jahr.Checked)
                artefakt.semi_typ = Artefakt.SemiType.JAHR;
            update(false);
        }

        private void odem_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.odem = odem_change.Value;
            update(false);
        }

        private void analys_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.analys = analys_change.Value;
            update(false);
        }

        private void magiekunde_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.magiekunde = magiekunde_change.Value;
            update(false);
        }

        private void destruct_change_ValueChanged(object sender, EventArgs e)
        {
            artefakt.taw.destructibo = destruct_change.Value;
            update(false);
        }

        private void automatischNeuberechenenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!automatischNeuberechenenToolStripMenuItem.Checked)
            //    btn_update.Visible = true;
            //else
            //    btn_update.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            update(true);
        }

        private void special_signet_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_siegel = special_signet.Checked;
            update(false);
        }

        private void special_durable_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_unzerbrechlich = special_durable.Checked;
            update(false);
        }

        private void special_scent_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_gespuer = special_scent.Checked;
            update(false);
        }

        private void special_apport_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_apport = special_apport.Checked;
            update(false);
        }

        private void special_ferngespuer_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_ferngespuer = special_ferngespuer.Checked;
            update(false);
        }

        private void special_resistant_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_resistent = special_resistant.Checked;
            update(false);
        }

        private void special_selfrepair_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_reperatur = special_selfrepair.Checked;
            update(false);
        }

        private void special_reversalis_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_reversalis = special_reversalis.Checked;
            update(false);
        }

        private void special_variablerelease_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_variablerausloeser = special_variablerelease.Checked;
            update(false);
        }

        private void special_schleier_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_verschleierung = special_schleier.Checked;
            update(false);
        }

        private void special_eatmaterial_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.spezial_verzehrend = special_eatmaterial.Checked;
            update(false);
        }

        private void artefakt_groesse_ValueChanged(object sender, EventArgs e)
        {
            artefakt.probe.groesse = artefakt_groesse.Value;
            update(false);
        }

        private void artefakt_super_big_SelectedIndexChanged(object sender, EventArgs e)
        {
            update(false);
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hier gibts nix zu sehen!");
        }

        private void material_SelectedIndexChanged(object sender, EventArgs e)
        {
            update(false);
        }

        private void arcanovi_force_ValueChanged(object sender, EventArgs e)
        {
            artefakt.probe.erzwingen = -arcanovi_force.Value;
            update(false);
        }

        private void analys_broken_CheckedChanged(object sender, EventArgs e)
        {
            if (analys_broken.Checked)
                artefakt.analys.misslungen = true;
            else
                artefakt.analys.misslungen = false;
            update(false);
        }

        private void analys_komplex_ValueChanged(object sender, EventArgs e)
        {
            artefakt.analys.bes_komlexitaet = analys_komplex.Value;
            update(false);
        }

        private void analys_mr_ValueChanged(object sender, EventArgs e)
        {
            artefakt.analys.mr = analys_mr.Value;
            update(false);
        }

        private void analys_cloack_ValueChanged(object sender, EventArgs e)
        {
            artefakt.analys.tarnzauber = analys_cloack.Value;
            update(false);
        }

        private void loads_ValueChanged(object sender, EventArgs e)
        {
            artefakt.loads = loads.Value;
            update(false);
        }

        private void destruct_infinitum_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.destructibo.infinitum = destruct_infinitum.Checked;
            update(false);
        }

        private void destruct_komplex_ValueChanged(object sender, EventArgs e)
        {
            artefakt.destructibo.komplex = destruct_komplex.Value;
            update(false);
        }

        private void destruct_mr_ValueChanged(object sender, EventArgs e)
        {
            artefakt.destructibo.mr = destruct_mr.Value;
            update(false);
        }

        private void destruct_aktive_ValueChanged(object sender, EventArgs e)
        {
            artefakt.destructibo.aktive_loads = destruct_aktive.Value;
            update(false);
        }

        private void starkonst_ValueChanged(object sender, EventArgs e)
        {
            artefakt.probe.stars = starkonst.Value;
            update(false);
        }


        private void limbus_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.limbus = limbus.Checked;
            update(false);
        }

        private void namenlos_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.namenlos = namenlos.Checked;
            update(false);
        }

        private void special_ort_occ_ValueChanged(object sender, EventArgs e)
        {
            artefakt.special_ort_occ = special_ort_occ.Value;
            update(false);
        }

        private void special_ort_neben_ValueChanged(object sender, EventArgs e)
        {
            artefakt.special_ort_neben = special_ort_neben.Value;
            update(false);
        }

        private void agribaal_ValueChanged(object sender, EventArgs e)
        {
            artefakt.agribaal = agribaal.Value;
            update(false);
        }

        private void cb_kristalle_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.kristalle = cb_kristalle.Checked;
            update(false);
        }

        private void sf_aux_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.sf.auxiliator = sf_aux.Checked;
            update(false);
        }

        private void type_aux_CheckedChanged(object sender, EventArgs e)
        {
            if (this.type_aux.Checked)
            {
                artefakt.typ = Artefakt.ArtefaktType.AUX;
                loads_lbl.Enabled = false;
                loads.Enabled = false;
                update(false);
            }
        }

        private void aux_labil_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aux_labil.Checked)
                artefakt.aux_typ = Artefakt.MatrixType.LABIL;
            update(false);
        }

        private void aux_stable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aux_stable.Checked)
                artefakt.aux_typ = Artefakt.MatrixType.STABIL;
            update(false);
        }

        private void aux_verystable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aux_verystable.Checked)
                artefakt.aux_typ = Artefakt.MatrixType.SEHRSTABIL;
            update(false);
        }

        private void aux_unempfindlich_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aux_unempfindlich.Checked)
                artefakt.aux_typ = Artefakt.MatrixType.UNEMPFINDLICH;
            update(false);
        }

        private void aux_merkmal_CheckedChanged(object sender, EventArgs e)
        {
            artefakt.aux_merkmal = aux_merkmal.Checked;
            update(false);
        }

        private void special_ferngespuer_komp_SelectedIndexChanged(object sender, EventArgs e)
        {
            artefakt.spezial_ferngespuer_komp = special_ferngespuer_komp.SelectedIndex + 1;
            update(false);
        }

        private void special_ferngespuer_asp_ValueChanged(object sender, EventArgs e)
        {
            artefakt.spezial_ferngespuer_asp = special_ferngespuer_asp.Value;
            update(false);
        }

        private void special_variable_var_ValueChanged(object sender, EventArgs e)
        {
            artefakt.spezial_variablerausloeser_var = special_variable_var.Value;
            update(false);
        }

        private void special_eatmat_var_ValueChanged(object sender, EventArgs e)
        {
            artefakt.spezial_verzehrend_var = special_eatmat_var.Value;
            update(false);
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
                artefakt = new Artefakt();
                magic = new List<Zauber>();
                reload();
                update(true);
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
                    DasArtefakt art = (DasArtefakt)DeserializeObject(xml);
                    artefakt = art.artefakt;
                    magic = art.zauber;
                    reload();
                    update(true);
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
                DasArtefakt art = new DasArtefakt(artefakt, magic);
                string xml = SerializeObject(art);
                System.IO.File.WriteAllText(@saveFileDialog1.FileName, xml);
            }
        }

        private void nebeneffekteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            artefakt.nebeneffekte = nebeneffekteToolStripMenuItem.Checked;
            update(false);
        }

        private void occupationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            artefakt.occupation = occupationToolStripMenuItem.Checked;
            update(false);
        }

        private void alleBerechnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dice.W20 = 0;
            dice.W6 = 0;
            if (alleBerechnenToolStripMenuItem.Checked)
            {
                w6AnnehmenToolStripMenuItem.Enabled = false;
                w20ToolStripMenuItem.Enabled = false;
            }
            else
            {
                w6AnnehmenToolStripMenuItem.Enabled = true;
                w20ToolStripMenuItem.Enabled = true;
            }
            update(false);
        }

        private void w6_1_Click(object sender, EventArgs e)
        {
            dice.W6 = 1;
            if (!w6_1.Checked) w6_1.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            update(false);
        }

        private void w6_6_Click(object sender, EventArgs e)
        {
            dice.W6 = 6;
            if (!w6_6.Checked) w6_6.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_1.Checked = false;
            update(false);
        }

        private void w6_35_Click(object sender, EventArgs e)
        {
            dice.W6 = 3.5m;
            if (!w6_35.Checked) w6_35.Checked = true;
            w6_1.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            update(false);
        }

        private void w6_4_Click(object sender, EventArgs e)
        {
            dice.W6 = 4;
            if (!w6_4.Checked) w6_4.Checked = true;
            w6_1.Checked = false;
            w6_35.Checked = false;
            w6_6.Checked = false;
            update(false);
        }

        private void w20_1_Click(object sender, EventArgs e)
        {
            dice.W20 = 1;
            if (!w20_1.Checked) w20_1.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            update(false);
        }

        private void w20_10_Click(object sender, EventArgs e)
        {
            dice.W20 = 10;
            if (!w20_10.Checked) w20_10.Checked = true;
            w20_1.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            update(false);
        }

        private void w20_105_Click(object sender, EventArgs e)
        {
            dice.W20 = 10.5m;
            if (!w20_105.Checked) w20_105.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            update(false);
        }

        private void w20_11_Click(object sender, EventArgs e)
        {
            dice.W20 = 11m;
            if (!w20_11.Checked) w20_11.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_20.Checked = false;
            update(false);
        }

        private void w20_20_Click(object sender, EventArgs e)
        {
            dice.W20 = 20;
            if (!w20_20.Checked) w20_20.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_1.Checked = false;
            update(false);
        }

        private void wegeDerAlchimieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            artefakt.regelbasis = Artefakt.Regelbasis.WDA;
            wegeDerAlchimieToolStripMenuItem.Checked = true;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = false;
            update(false);
        }

        private void staebeRingeDschinnenlampenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            artefakt.regelbasis = Artefakt.Regelbasis.SRD;
            wegeDerAlchimieToolStripMenuItem.Checked = false;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = true;
            update(false);
        }
        #endregion

        private void ach_save_Click(object sender, EventArgs e)
        {

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
            this.groupBox2.DataBindings.Add("Selected", gui, "sfRepresentation", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_kraft.DataBindings.Add("Checked", gui, "sfKraftkontrolle", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_vielLadung.DataBindings.Add("Checked", gui, "sfVielfacheLadung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_stapel.DataBindings.Add("Checked", gui, "sfStapeleffekt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_hyper.DataBindings.Add("Checked", gui, "sfHypervehemenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_matrix.DataBindings.Add("Checked", gui, "sfMatrixgeber", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiI.DataBindings.Add("Checked", gui, "sfSemipermanenz1", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiII.DataBindings.Add("Checked", gui, "sfSemipermanenz2", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_semiII.DataBindings.Add("Enabled", gui, "sfSemipermanenz2Enabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_ringkunde.DataBindings.Add("Checked", gui, "sfRingkunde", false, DataSourceUpdateMode.OnPropertyChanged);
            this.sf_aux.DataBindings.Add("Checked", gui, "sfAuxiliator", false, DataSourceUpdateMode.OnPropertyChanged);

            this.arcanovi_change.DataBindings.Add("Value", gui, "tawArcanovi", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_matrix_change.DataBindings.Add("Value", gui, "tawArcanoviMatrix", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_matrix_change.DataBindings.Add("Enabled", gui, "tawArcanoviMatrixEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_semi_change.DataBindings.Add("Value", gui, "tawArcanoviSemipermanenz", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_semi_change.DataBindings.Add("Enabled", gui, "tawArcanoviSemipermanenzEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_change.DataBindings.Add("Value", gui, "tawOdem", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_change.DataBindings.Add("Value", gui, "tawAnalys", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_change.DataBindings.Add("Value", gui, "tawMagiekunde", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanovi_change.DataBindings.Add("Value", gui, "tawDestructibo", false, DataSourceUpdateMode.OnPropertyChanged);

            this.artefakttyp.DataBindings.Add("Selected", gui, "artefakttyp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_matrix.DataBindings.Add("Selected", gui, "artefakttypMatrix", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_matrix.DataBindings.Add("Visible", gui, "artefakttypMatrixVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_aux.DataBindings.Add("Selected", gui, "artefakttypAuxiliator", false, DataSourceUpdateMode.OnPropertyChanged);
            this.artefakttyp_aux.DataBindings.Add("Visible", gui, "artefakttypAuxiliatorVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.aux_merkmal.DataBindings.Add("Checked", gui, "artefakttypAuxiliatorMerkmal", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
