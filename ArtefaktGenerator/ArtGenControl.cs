using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ArtefaktGenerator
{
    public partial class ArtGenControl : UserControl
    {
        public Controller controller = new();

        public ArtGenControl() : this(false)
        {
        }

        public ArtGenControl(bool plugInMode)
        {
            InitializeComponent();

            // Disable Non-PlugIn fields
            if (plugInMode)
            {
                programmToolStripMenuItem1.Visible = false;
                heldenimportToolStripMenuItem.Visible = false;
            }
        }

        public void PlugInHeroFromXml(string xml)
        {
            controller.plugInHeroFromXml(xml);
            ReloadData();
        }

        delegate void Del(int e);

        private void Zauber_add_Click(object sender, EventArgs e)
        {
            Zauber zauber = new();
            zauber.asp = this.asp.Value;
            //zauber.load = this.loads.Value;
            zauber.staple = this.stapelung.Value;
            Array vals = Enum.GetValues(typeof(Zauber.Komplexitaet));
            zauber.komp = (Zauber.Komplexitaet)(vals.GetValue(this.komp_combo.SelectedIndex));
            zauber.name = this.zauber.Text;
            if (this.zauber_rep.SelectedIndex == 0)
                zauber.eigene_rep = true;
            else
                zauber.eigene_rep = false;

            //magic.Add(zauber);
            BindingList<Zauber> z = controller.zauberListe;
            z.Add(zauber);
            controller.zauberListe = z;

            ReloadData();
        }

        private void Zauber_del_Click(object sender, EventArgs e)
        {
            try
            {
                controller.zauberListe.RemoveAt(zauberGrid.SelectedCells[0].RowIndex);
                controller.zauberListe = controller.zauberListe;
            }
            catch (System.Exception)
            {

            }
            ReloadData();
        }

        private void BeendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NeuesArtefaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alle nicht gespeicherten Änderungen am bisherigen Artefakt gehen verloren.\r\nWillst du wirklich ein neues Artefakt beginnen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                controller.clearArtefakt();
                ReloadData();
            }
        }

        private void ArtefaktLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new();
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
                    System.IO.StreamReader reader = new(openFileDialog.OpenFile());

                    string xml = reader.ReadToEnd();
                    //string xml = System.IO.File.ReadAllText(@".\test.artefakt");

                    controller.loadArtefakt(xml);
                    ReloadData();
                }
            }
        }

        private void ArtefaktSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new();

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

        private void AlleBerechnenToolStripMenuItem_Click(object sender, EventArgs e)
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
            ReloadData();
        }

        private void W6_1_Click(object sender, EventArgs e)
        {
            controller.W6 = 1;
            if (!w6_1.Checked) w6_1.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            ReloadData();
        }

        private void W6_6_Click(object sender, EventArgs e)
        {
            controller.W6 = 6;
            if (!w6_6.Checked) w6_6.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_1.Checked = false;
            ReloadData();
        }

        private void W6_35_Click(object sender, EventArgs e)
        {
            controller.W6 = 3.5m;
            if (!w6_35.Checked) w6_35.Checked = true;
            w6_1.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            ReloadData();
        }

        private void W6_4_Click(object sender, EventArgs e)
        {
            controller.W6 = 4;
            if (!w6_4.Checked) w6_4.Checked = true;
            w6_1.Checked = false;
            w6_35.Checked = false;
            w6_6.Checked = false;
            ReloadData();
        }

        private void W20_1_Click(object sender, EventArgs e)
        {
            controller.W20 = 1;
            if (!w20_1.Checked) w20_1.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            ReloadData();
        }

        private void W20_10_Click(object sender, EventArgs e)
        {
            controller.W20 = 10;
            if (!w20_10.Checked) w20_10.Checked = true;
            w20_1.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            ReloadData();
        }

        private void W20_105_Click(object sender, EventArgs e)
        {
            controller.W20 = 10.5m;
            if (!w20_105.Checked) w20_105.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            ReloadData();
        }

        private void W20_11_Click(object sender, EventArgs e)
        {
            controller.W20 = 11m;
            if (!w20_11.Checked) w20_11.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_20.Checked = false;
            ReloadData();
        }

        private void W20_20_Click(object sender, EventArgs e)
        {
            controller.W20 = 20;
            if (!w20_20.Checked) w20_20.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_1.Checked = false;
            ReloadData();
        }

        private void WegeDerAlchimieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = true;
            wegeDerAlchimieToolStripMenuItem.Checked = true;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = false;
            ReloadData();
        }

        private void StaebeRingeDschinnenlampenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = false;
            wegeDerAlchimieToolStripMenuItem.Checked = false;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = true;
            ReloadData();
        }


        private void Ach_save_Click(object sender, EventArgs e)
        {
            if (ach_save.Checked)
                controller.optionAchSave = true;
            else
                controller.optionAchSave = false;
            ReloadData();
        }

        private void AlwaysHypervSRD_Click(object sender, EventArgs e)
        {
            if (alwaysHypervSRD.Checked)
                controller.optionAlwaysHypervehemenzSRD = true;
            else
                controller.optionAlwaysHypervehemenzSRD = false;
            ReloadData();
        }

        private void ImportHeldensoftwareToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowSelectHeroDialog(Form.ActiveForm);
        }

        public void ShowSelectHeroDialog(Form form)
        {
            HeldAuswahl auswahl = new(this, LadeHelden.LadeHeldenFromDefaultPath());
            auswahl.StartPosition = FormStartPosition.CenterParent;
            auswahl.ShowDialog(form);
        }

        private void ArtGenControl_Load(object sender, EventArgs e)
        {
            this.repGroup.DataBindings.Add("Selected", controller, "sfRepresentation", false, DataSourceUpdateMode.OnPropertyChanged);
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
            this.arcanovi_semi_change_lbl.DataBindings.Add("Enabled", controller, "tawArcanoviSemipermanenzEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
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
            this.lbl_special_asp.DataBindings.Add("Enabled", controller, "spezialFerngespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbl_special_komp.DataBindings.Add("Enabled", controller, "spezialFerngespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Visible", controller, "spezialFerngespuerVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("Enabled", controller, "spezialFerngespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Enabled", controller, "spezialFerngespuer", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_asp.DataBindings.Add("Value", controller, "spezialFerngespuerAsp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ferngespuer_komp.DataBindings.Add("SelectedIndex", controller, "spezialFerngespuerKomp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Checked", controller, "spezialUmkehrtalisman", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Visible", controller, "spezialUmkehrtalismanVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_reversalis.DataBindings.Add("Enabled", controller, "spezialUmkehrtalismanEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Checked", controller, "spezialVariablerAusloeser", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Visible", controller, "spezialVariablerAusloeserVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variablerelease.DataBindings.Add("Enabled", controller, "spezialVariablerAusloeserEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Value", controller, "spezialVariablerAusloeserVar", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Visible", controller, "spezialVariablerAusloeserVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_variable_var.DataBindings.Add("Enabled", controller, "spezialVariablerAusloeser", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Checked", controller, "spezialVerschleierung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Visible", controller, "spezialVerschleierungVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_schleier.DataBindings.Add("Enabled", controller, "spezialVerschleierungEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Checked", controller, "spezialVerzehrend", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Visible", controller, "spezialVerzehrendVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmaterial.DataBindings.Add("Enabled", controller, "spezialVerzehrendEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Value", controller, "spezialVerzehrendVar", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Visible", controller, "spezialVerzehrendVisible", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_eatmat_var.DataBindings.Add("Enabled", controller, "spezialVerzehrend", false, DataSourceUpdateMode.OnPropertyChanged);

            this.limbus.DataBindings.Add("Checked", controller, "extraMadeInLimbus", false, DataSourceUpdateMode.OnPropertyChanged);
            this.namenlos.DataBindings.Add("Checked", controller, "extraNamenloseTage", false, DataSourceUpdateMode.OnPropertyChanged);
            this.gemeinschaftlich.DataBindings.Add("Checked", controller, "extraGemeinschaftlicheErschaffung", false, DataSourceUpdateMode.OnPropertyChanged);
            this.agribaal.DataBindings.Add("Value", controller, "extraAgribaal", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ort_occ.DataBindings.Add("Value", controller, "extraOkkupation", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_ort_neben.DataBindings.Add("Value", controller, "extraNebeneffekt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.special_additional_arcanovi.DataBindings.Add("Value", controller, "extraZusaetzlicheArcanovi", false, DataSourceUpdateMode.OnPropertyChanged);
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
            this.arcanoviOtherMod.DataBindings.Add("Value", controller, "probeAndereMod", false, DataSourceUpdateMode.OnPropertyChanged);
            this.arcanoviZfPSternMod.DataBindings.Add("Value", controller, "probeZfPSternMod", false, DataSourceUpdateMode.OnPropertyChanged);
            this.wirkSpruchMod.DataBindings.Add("Value", controller, "probeWirkenderSpruchMod", false, DataSourceUpdateMode.OnPropertyChanged);

            this.zauberGrid.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "name",
                Name = "Zauber"
            };
            this.zauberGrid.Columns.Add(column);

            DataGridViewComboBoxColumn column2 = new()
            {
                DataSource = Enum.GetValues(typeof(Zauber.Komplexitaet)),
                DataPropertyName = "komp",
                Name = "Komp."
            };
            this.zauberGrid.Columns.Add(column2);

            DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column3 = new()
            {
                DataPropertyName = "staple",
                Name = "Stapel",
                DecimalPlaces = 0,
                Minimum = 1,
                Maximum = 99
            };
            this.zauberGrid.Columns.Add(column3);

            DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column4 = new()
            {
                DataPropertyName = "summierung",
                Name = "Summe",
                DecimalPlaces = 0,
                Minimum = 1,
                Maximum = 99
            };
            this.zauberGrid.Columns.Add(column4);

            DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column5 = new()
            {
                DataPropertyName = "asp",
                Name = "AsP",
                DecimalPlaces = 0,
                Minimum = 1,
                Maximum = 999
            };
            this.zauberGrid.Columns.Add(column5);

            DataGridViewCheckBoxColumn column6 = new();
            column6.DataPropertyName = "eigene_rep";
            column6.Name = "Eigene Rep.";
            this.zauberGrid.Columns.Add(column6);

            this.zauberGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.zauberGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zauberGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zauberGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zauberGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zauberGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            this.zauberGrid.DataSource = controller.zauberListe;
            this.zauberGrid.MouseUp += ZauberGrid_MouseUp;

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
            artefakt_super_big.SelectedIndex = 0;
            komp_combo.SelectedIndex = 0;
            special_ferngespuer_komp.SelectedIndex = 0;

            controller.optionAchSave = ArtefaktGenerator.Properties.Settings.Default.saveAch;
            controller.artefakttyp = 1;
            ach_save.Checked = controller.optionAchSave;
            alwaysHypervSRD.Checked = controller.optionAlwaysHypervehemenzSRD;
            controller.WDA = ArtefaktGenerator.Properties.Settings.Default.WDA;
            wegeDerAlchimieToolStripMenuItem.Checked = controller.WDA;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = !controller.WDA;
            heldenimportToolStripMenuItem.Checked = ArtefaktGenerator.Properties.Settings.Default.showHeldenImport;
            controller.optionNebeneffekteNeuWuerfeln = ArtefaktGenerator.Properties.Settings.Default.reRollNeben;
            nebenReRollToolStripMenuItem.Checked = controller.optionNebeneffekteNeuWuerfeln;
            nebenIgnoreToolStripMenuItem.Checked = !controller.optionNebeneffekteNeuWuerfeln;
            showPDFToolStripMenuItem.Checked = ArtefaktGenerator.Properties.Settings.Default.showSavedPDF;
            switch (ArtefaktGenerator.Properties.Settings.Default.diceW6)
            {
                case 0: W6_1_Click(this, null); break;
                case 1: W6_35_Click(this, null); break;
                case 2: W6_4_Click(this, null); break;
                case 3: W6_6_Click(this, null); break;
            }
            switch (ArtefaktGenerator.Properties.Settings.Default.diceW20)
            {
                case 0: W20_1_Click(this, null); break;
                case 1: W20_10_Click(this, null); break;
                case 2: W20_105_Click(this, null); break;
                case 3: W20_11_Click(this, null); break;
                case 4: W20_20_Click(this, null); break;
            }
            if (ArtefaktGenerator.Properties.Settings.Default.diceRandom)
            {
                alleBerechnenToolStripMenuItem.Checked = true;
                AlleBerechnenToolStripMenuItem_Click(this, null);
            }

            material.SelectedIndex = 0;
            ReloadData();
        }

        void ZauberGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hitTestInfo = zauberGrid.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    zauberGrid.BeginEdit(true);
                else
                    zauberGrid.EndEdit();
            }
        }

        public void SaveOptions()
        {
            ArtefaktGenerator.Properties.Settings.Default.saveAch = controller.optionAchSave;
            ArtefaktGenerator.Properties.Settings.Default.WDA = controller.WDA;
            ArtefaktGenerator.Properties.Settings.Default.SFHyperNachSRD = controller.optionAlwaysHypervehemenzSRD;
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

        private void ExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new();

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
                    if (showPDFToolStripMenuItem.Checked)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog2.FileName) { UseShellExecute = true });
                    }
                }
            }
            else
                MessageBox.Show("Dein Artefakt hat keine wirkenden Zauber!", "Fehler");
        }


        private void NebenReRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.optionNebeneffekteNeuWuerfeln = true;
            nebenReRollToolStripMenuItem.Checked = true;
            nebenIgnoreToolStripMenuItem.Checked = false;
        }

        private void NebenIgnoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.optionNebeneffekteNeuWuerfeln = false;
            nebenIgnoreToolStripMenuItem.Checked = true;
            nebenReRollToolStripMenuItem.Checked = false;
        }

        #region Linux gedoens
        // TODO: Verify if this entire reload method could be obsolete on Windows only
        private void ReloadData()
        {
            // TODO Should be done via DataBinding. Investigate how to databind to column properties
            if (this.zauberGrid.ColumnCount > 0)
            {
                this.zauberGrid.Columns[2].ReadOnly = !controller.zauberStapelEnabled;
                ((DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn)(this.zauberGrid.Columns[2])).Minimum = 1;
                ((DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn)(this.zauberGrid.Columns[2])).Maximum = controller.zauberStapelMax;
            }
        }

        private void Special_variablerelease_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVariablerAusloeser = special_variablerelease.Checked;
            ReloadData();
        }

        private void Special_variable_var_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialVariablerAusloeserVar = (int)special_variable_var.Value;
            ReloadData();
        }

        private void ArtGenControl_Click(object sender, EventArgs e)
        {
        }

        private void Rep_mag_Click(object sender, EventArgs e)
        {
            controller.sfRepresentation = 1;
            ReloadData();
        }

        private void Rep_ach_Click(object sender, EventArgs e)
        {
            controller.sfRepresentation = 0;
            ReloadData();
        }

        private void SF_kraft_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfKraftkontrolle = sf_kraft.Checked;
            ReloadData();
        }

        private void SF_vielLadung_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfVielfacheLadung = sf_vielLadung.Checked;
            ReloadData();
        }

        private void SF_stapel_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfStapeleffekt = sf_stapel.Checked;
            ReloadData();
        }

        private void SF_hyper_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfHypervehemenz = sf_hyper.Checked;
            ReloadData();
        }

        private void SF_matrix_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfMatrixgeber = sf_matrix.Checked;
            ReloadData();
        }

        private void SF_semiI_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfSemipermanenz1 = sf_semiI.Checked;
            ReloadData();
        }

        private void SF_semiII_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfSemipermanenz2 = sf_semiII.Checked;
            ReloadData();
        }

        private void SF_ringkunde_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfRingkunde = sf_ringkunde.Checked;
            ReloadData();
        }

        private void SF_kraftspeicher_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfKraftspeicher = sf_kraftspeicher.Checked;
            ReloadData();
        }

        private void SF_aux_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfAuxiliator = sf_aux.Checked;
            ReloadData();
        }

        private void Arcanovi_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanovi = (int)arcanovi_change.Value;
            ReloadData();
        }

        private void Arcanovi_matrix_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanoviMatrix = (int)arcanovi_matrix_change.Value;
            ReloadData();
        }

        private void Arcanovi_semi_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanoviSemipermanenz = (int)arcanovi_semi_change.Value;
            ReloadData();
        }

        private void Odem_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawOdem = (int)odem_change.Value;
            ReloadData();
        }

        private void Analys_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawAnalys = (int)analys_change.Value;
            ReloadData();
        }

        private void Magiekunde_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawMagiekunde = (int)magiekunde_change.Value;
            ReloadData();
        }

        private void Destruct_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawDestructibo = (int)destruct_change.Value;
            ReloadData();
        }

        private void Type_temp_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.TEMP;
            ReloadData();
        }

        private void Type_einaml_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.NORMAL;
            ReloadData();
        }

        private void Type_charge_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.RECHARGE;
            ReloadData();
        }

        private void Type_matrix_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.MATRIX;
            ReloadData();
        }

        private void Type_semi_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.SEMI;
            ReloadData();
        }

        private void Type_speicher_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.SPEICHER;
            ReloadData();
        }

        private void Type_aux_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = (int)Artefakt.ArtefaktType.AUX;
            ReloadData();
        }

        private void Temp_tag_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = (int)Artefakt.TempType.TAG;
            ReloadData();
        }

        private void Temp_woche_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = (int)Artefakt.TempType.WOCHE;
            ReloadData();
        }

        private void Temp_monat_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = (int)Artefakt.TempType.MONAT;
            ReloadData();
        }

        private void Matrix_labil_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = (int)Artefakt.MatrixType.LABIL;
            ReloadData();
        }

        private void Matrix_stable_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = (int)Artefakt.MatrixType.STABIL;
            ReloadData();
        }

        private void Matrix_verystable_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = (int)Artefakt.MatrixType.SEHRSTABIL;
            ReloadData();
        }

        private void Matrix_unempfindlich_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = (int)Artefakt.MatrixType.UNEMPFINDLICH;
            ReloadData();
        }

        private void Aux_labil_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = (int)Artefakt.MatrixType.LABIL;
            ReloadData();
        }

        private void Aux_stable_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = (int)Artefakt.MatrixType.STABIL;
            ReloadData();
        }

        private void Aux_verystable_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = (int)Artefakt.MatrixType.SEHRSTABIL;
            ReloadData();

        }

        private void Aux_unempfindlich_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = (int)Artefakt.MatrixType.UNEMPFINDLICH;
            ReloadData();
        }

        private void Semi_tag_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = (int)Artefakt.SemiType.TAG;
            ReloadData();
        }

        private void Semi_woche_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = (int)Artefakt.SemiType.WOCHE;
            ReloadData();
        }

        private void Semi_monat_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = (int)Artefakt.SemiType.MONAT;
            ReloadData();
        }

        private void Semi_jahr_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = (int)Artefakt.SemiType.JAHR;
            ReloadData();
        }

        private void Type_speicher_value_ValueChanged(object sender, EventArgs e)
        {
            controller.artefakttypKraftspeicher = (int)type_speicher_value.Value;
            ReloadData();
        }

        private void Probe_ausloes_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAusloeser = (int)probe_ausloes.Value;
            ReloadData();
        }

        private void Probe_affine_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAffin = (int)probe_affine.Value;
            ReloadData();
        }

        private void Artefakt_groesse_ValueChanged(object sender, EventArgs e)
        {
            controller.probeGroesse = (int)artefakt_groesse.Value;
            ReloadData();
        }

        private void Arcanovi_force_ValueChanged(object sender, EventArgs e)
        {
            controller.probeErzwingen = (int)arcanovi_force.Value;
            ReloadData();
        }

        private void Starkonst_ValueChanged(object sender, EventArgs e)
        {
            controller.probeSterne = (int)starkonst.Value;
            ReloadData();
        }

        private void ArcanoviOtherMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAndereMod = (int)arcanoviOtherMod.Value;
            ReloadData();
        }

        private void ArcanoviZfPSternMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeZfPSternMod = (int)arcanoviZfPSternMod.Value;
            ReloadData();
        }

        private void WirkSpruchMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeWirkenderSpruchMod = (int)wirkSpruchMod.Value;
            ReloadData();
        }

        private void Limbus_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraMadeInLimbus = limbus.Checked;
            ReloadData();
        }

        private void Namenlos_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraNamenloseTage = namenlos.Checked;
            ReloadData();
        }

        private void Gemeinschaftlich_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraGemeinschaftlicheErschaffung = gemeinschaftlich.Checked;
            ReloadData();
        }

        private void Agribaal_ValueChanged(object sender, EventArgs e)
        {
            controller.extraAgribaal = (int)agribaal.Value;
            ReloadData();
        }

        private void Special_ort_occ_ValueChanged(object sender, EventArgs e)
        {
            controller.extraOkkupation = (int)special_ort_occ.Value;
            ReloadData();
        }

        private void Special_ort_neben_ValueChanged(object sender, EventArgs e)
        {
            controller.extraNebeneffekt = (int)special_ort_neben.Value;
            ReloadData();
        }

        private void Special_additional_arcanovi_ValueChanged(object sender, EventArgs e)
        {
            controller.extraZusaetzlicheArcanovi = (int)special_additional_arcanovi.Value;
            ReloadData();
        }

        private void Artefakt_super_big_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.extraExtraGross = artefakt_super_big.SelectedIndex;
            ReloadData();
        }

        private void Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.selectedMaterial = material.SelectedIndex;
            ReloadData();
        }

        private void Cb_kristalle_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraKristalle = cb_kristalle.Checked;
            ReloadData();
        }

        private void Special_signet_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialSiegel = special_signet.Checked;
            ReloadData();
        }

        private void Special_apport_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialApport = special_apport.Checked;
            ReloadData();
        }

        private void Special_durable_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialUnzerbrechlich = special_durable.Checked;
            ReloadData();
        }

        private void Special_scent_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialGespuer = special_scent.Checked;
            ReloadData();
        }

        private void Special_resistant_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialResistenz = special_resistant.Checked;
            ReloadData();
        }

        private void Special_selfrepair_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialSelbstreparatur = special_selfrepair.Checked;
            ReloadData();
        }

        private void Special_reversalis_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialUmkehrtalisman = special_reversalis.Checked;
            ReloadData();
        }

        private void Special_schleier_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVerschleierung = special_schleier.Checked;
            ReloadData();
        }

        private void Special_eatmaterial_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVerzehrend = special_eatmaterial.Checked;
            ReloadData();
        }

        private void Special_ferngespuer_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuer = special_ferngespuer.Checked;
            ReloadData();
        }

        private void Special_eatmat_var_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialVerzehrendVar = (int)special_eatmat_var.Value;
            ReloadData();
        }

        private void Special_ferngespuer_komp_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuerKomp = special_ferngespuer_komp.SelectedIndex;
            ReloadData();
        }

        private void Special_ferngespuer_asp_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuerAsp = (int)special_ferngespuer_asp.Value;
            ReloadData();
        }

        private void Loads_ValueChanged(object sender, EventArgs e)
        {
            controller.zauberLadungen = (int)loads.Value;
            ReloadData();
        }
        #endregion
        private void SFGroupBox_Resize(object sender, EventArgs e)
        {
            SFGroupBox.SuspendLayout();
            SFGroupBox.MinimumSize = new Size(SFPanel.Size.Width, SFPanel.Size.Height + 20);
            SFGroupBox.ResumeLayout();
        }

        private void TalentGroupBox_Resize(object sender, EventArgs e)
        {
            TalentGroupBox.SuspendLayout();
            TalentGroupBox.MinimumSize = new Size(TalentPanel.Size.Width, TalentPanel.Size.Height + 20);
            TalentGroupBox.ResumeLayout();
        }

        private void ZauberGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ZauberGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (zauberGrid.CurrentCell.ColumnIndex == 1)
                zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        public static void ShowAboutDialog()
        {
            AboutForm form = new();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void LizenzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLizenzDialog();
        }

        public static void ShowLizenzDialog()
        {
            LizenzForm form = new();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

    }
}
