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
                heldenimportToolStripMenuItem.Visible = false;
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
            reloadData();
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

        delegate void Del(int e);

        private void OnCheckUpdatesComplete(int e)
        {
            // Fixed threaded unsynced access
            Del del = delegate(int x)
            {
                if (x >= 1)
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
            };

            if (InvokeRequired)
                this.Invoke(del, new Object[] { e });
            else
                del(e);
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

        private void zauber_add_Click(object sender, EventArgs e)
        {
            Zauber zauber = new Zauber();
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

            reloadData();
        }

        private void zauber_del_Click(object sender, EventArgs e)
        {
            try
            {
                controller.zauberListe.RemoveAt(zauberGrid.SelectedRows[0].Index);
                controller.zauberListe = controller.zauberListe;
            }
            catch (System.Exception )
            {
                	
            }
            reloadData();
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
                reloadData();
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
                    reloadData();
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
            reloadData();
        }

        private void w6_1_Click(object sender, EventArgs e)
        {
            controller.W6 = 1;
            if (!w6_1.Checked) w6_1.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            reloadData();
        }

        private void w6_6_Click(object sender, EventArgs e)
        {
            controller.W6 = 6;
            if (!w6_6.Checked) w6_6.Checked = true;
            w6_35.Checked = false;
            w6_4.Checked = false;
            w6_1.Checked = false;
            reloadData();
        }

        private void w6_35_Click(object sender, EventArgs e)
        {
            controller.W6 = 3.5m;
            if (!w6_35.Checked) w6_35.Checked = true;
            w6_1.Checked = false;
            w6_4.Checked = false;
            w6_6.Checked = false;
            reloadData();
        }

        private void w6_4_Click(object sender, EventArgs e)
        {
            controller.W6 = 4;
            if (!w6_4.Checked) w6_4.Checked = true;
            w6_1.Checked = false;
            w6_35.Checked = false;
            w6_6.Checked = false;
            reloadData();
        }

        private void w20_1_Click(object sender, EventArgs e)
        {
            controller.W20 = 1;
            if (!w20_1.Checked) w20_1.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            reloadData();
        }

        private void w20_10_Click(object sender, EventArgs e)
        {
            controller.W20 = 10;
            if (!w20_10.Checked) w20_10.Checked = true;
            w20_1.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            reloadData();
        }

        private void w20_105_Click(object sender, EventArgs e)
        {
            controller.W20 = 10.5m;
            if (!w20_105.Checked) w20_105.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_11.Checked = false;
            w20_20.Checked = false;
            reloadData();
        }

        private void w20_11_Click(object sender, EventArgs e)
        {
            controller.W20 = 11m;
            if (!w20_11.Checked) w20_11.Checked = true;
            w20_1.Checked = false;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_20.Checked = false;
            reloadData();
        }

        private void w20_20_Click(object sender, EventArgs e)
        {
            controller.W20 = 20;
            if (!w20_20.Checked) w20_20.Checked = true;
            w20_10.Checked = false;
            w20_105.Checked = false;
            w20_11.Checked = false;
            w20_1.Checked = false;
            reloadData();
        }

        private void wegeDerAlchimieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = true;
            wegeDerAlchimieToolStripMenuItem.Checked = true;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = false;
            reloadData();
        }

        private void staebeRingeDschinnenlampenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.WDA = false;
            wegeDerAlchimieToolStripMenuItem.Checked = false;
            staebeRingeDschinnenlampenToolStripMenuItem.Checked = true;
            reloadData();
        }


        private void ach_save_Click(object sender, EventArgs e)
        {
            if (ach_save.Checked)
                controller.optionAchSave = true;
            else
                controller.optionAchSave = false;
            reloadData();
        }

        private void alwaysHypervSRD_Click(object sender, EventArgs e)
        {
            if (alwaysHypervSRD.Checked)
                controller.optionAlwaysHypervehemenzSRD = true;
            else
                controller.optionAlwaysHypervehemenzSRD = false;
            reloadData();
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
            if (!isLinux())
            {
                this.hero_name.DataBindings.Add("Text", controller, "heldName", false, DataSourceUpdateMode.OnPropertyChanged);
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

                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "name";
                column.Name = "Zauber";
                this.zauberGrid.Columns.Add(column);

                DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();
                column2.DataSource = Enum.GetValues(typeof(Zauber.Komplexitaet));
                column2.DataPropertyName = "komp";
                column2.Name = "Komp.";
                this.zauberGrid.Columns.Add(column2);

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column3 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                column3.DataPropertyName = "staple";
                column3.Name = "Stapel";
                column3.DecimalPlaces = 0;
                column3.Minimum = 1;
                column3.Maximum = 99;
                this.zauberGrid.Columns.Add(column3);

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column4 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                column4.DataPropertyName = "summierung";
                column4.Name = "Summe";
                column4.DecimalPlaces = 0;
                column4.Minimum = 1;
                column4.Maximum = 99;
                this.zauberGrid.Columns.Add(column4);

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn column5 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                column5.DataPropertyName = "asp";
                column5.Name = "AsP";
                column5.DecimalPlaces = 0;
                column5.Minimum = 1;
                column5.Maximum = 99;
                this.zauberGrid.Columns.Add(column5);

                DataGridViewCheckBoxColumn column6 = new DataGridViewCheckBoxColumn();
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
                this.zauberGrid.MouseUp += zauberGrid_MouseUp;

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

            }

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

            if (isLinux())
            {
                foreach (Material m in controller.material)
                    material.Items.Add(m);
            }
            material.SelectedIndex = 0;
            reloadData();
        }

        void zauberGrid_MouseUp(object sender, MouseEventArgs e)
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

        public void saveOptions()
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
                    if (showPDFToolStripMenuItem.Checked) 
                        System.Diagnostics.Process.Start(saveFileDialog2.FileName);
                        //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog2.FileName) { UseShellExecute = false });
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

        #region Linux gedoens
        private void reloadData()
        {
            // TODO
            // Should be done via DataBinding. Investigate how to databind to column properties
            if (this.zauberGrid.ColumnCount > 0)
            {
                this.zauberGrid.Columns[2].ReadOnly = !controller.zauberStapelEnabled;
                ((DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn)(this.zauberGrid.Columns[2])).Minimum = 1;
                ((DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn)(this.zauberGrid.Columns[2])).Maximum = controller.zauberStapelMax;
            }

            if (isLinux())
            {

                repGroup.Selected = controller.sfRepresentation;
                sf_kraft.Checked = controller.sfKraftkontrolle;
                sf_vielLadung.Checked = controller.sfVielfacheLadung;
                sf_stapel.Checked = controller.sfStapeleffekt;
                sf_hyper.Checked = controller.sfHypervehemenz;
                sf_hyper.Enabled = controller.sfHypervehemenzEnabled;
                sf_matrix.Checked = controller.sfMatrixgeber;
                sf_semiI.Checked = controller.sfSemipermanenz1;
                sf_semiII.Checked = controller.sfSemipermanenz2;
                sf_semiII.Enabled = controller.sfSemipermanenz2Enabled;
                sf_ringkunde.Checked = controller.sfRingkunde;
                sf_aux.Checked = controller.sfAuxiliator;
                sf_aux.Enabled = controller.sfAuxiliatorEnabled;
                sf_aux.Visible = controller.sfAuxiliatorVisible;
                sf_kraft.Checked = controller.sfKraftspeicher;

                arcanovi_change.Value = controller.tawArcanovi;
                arcanovi_matrix_change.Value = controller.tawArcanoviMatrix;
                arcanovi_matrix_change.Enabled = controller.tawArcanoviMatrixEnabled;
                arcanovi_matrix_lbl.Enabled = controller.tawArcanoviMatrixEnabled;
                arcanovi_semi_change.Value = controller.tawArcanoviSemipermanenz;
                arcanovi_semi_change.Enabled = controller.tawArcanoviSemipermanenzEnabled;
                arcanovi_semi_change_lbl.Enabled = controller.tawArcanoviSemipermanenzEnabled;
                magiekunde_change.Value = controller.tawMagiekunde;
                destruct_change.Value = controller.tawDestructibo;
                odem_change.Value = controller.tawOdem;
                analys_change.Value = controller.tawAnalys;

                artefakttyp.Selected = controller.artefakttyp;
                artefakttyp_matrix.Selected = controller.artefakttypMatrix;
                type_matrix.Enabled = controller.sfMatrixgeber;
                artefakttyp_matrix.Visible = controller.artefakttypMatrixVisible;
                type_temp.Enabled = controller.artefakttypTempEnabled;
                artefakttyp_temp.Selected = controller.artefakttypTemp;
                artefakttyp_temp.Visible = controller.artefakttypTempVisible;
                type_semi.Enabled = controller.artefakttypSemipermanenzEnabled;
                artefakttyp_semi.Selected = controller.artefakttypSemipermanenz;
                artefakttyp_semi.Visible = controller.artefakttypSemipermanenzVisible;
                type_aux.Enabled = controller.artefakttypAuxiliatorEnabled;
                type_aux.Visible = controller.sfAuxiliatorVisible;
                artefakttyp_aux.Selected = controller.artefakttypAuxiliator;
                artefakttyp_aux.Visible = controller.artefakttypAuxiliatorVisible;
                aux_merkmal.Checked = controller.artefakttypAuxiliatorMerkmal;
                aux_merkmal.Visible = controller.artefakttypAuxiliatorVisible;
                lbl_type_speicher_val.Visible = controller.artefakttypKraftspeicherVisible;
                type_speicher_value.Value = controller.artefakttypKraftspeicher;
                type_speicher_value.Visible = controller.artefakttypKraftspeicherVisible;

                special_apport.Checked = controller.spezialApport;
                special_ferngespuer.Checked = controller.spezialFerngespuer;
                special_ferngespuer.Visible = controller.spezialFerngespuerVisible;
                special_ferngespuer.Enabled = controller.spezialFerngespuerEnabled;
                special_ferngespuer_asp.Value = controller.spezialFerngespuerAsp;
                special_ferngespuer_komp.SelectedIndex = controller.spezialFerngespuerKomp;
                special_ferngespuer_asp.Visible = controller.spezialFerngespuerVisible;
                special_ferngespuer_komp.Visible = controller.spezialFerngespuerVisible;
                special_ferngespuer_asp.Enabled = controller.spezialFerngespuerEnabled;
                special_ferngespuer_komp.Enabled = controller.spezialFerngespuerEnabled;
                lbl_special_asp.Enabled = controller.spezialFerngespuerEnabled;
                lbl_special_asp.Visible = controller.spezialFerngespuerVisible;
                lbl_special_komp.Enabled = controller.spezialFerngespuerEnabled;
                lbl_special_komp.Visible = controller.spezialFerngespuerVisible;
                special_durable.Checked = controller.spezialUnzerbrechlich;
                special_eatmaterial.Checked = controller.spezialVerzehrend;
                special_eatmaterial.Enabled = controller.spezialVerzehrendEnabled;
                special_eatmaterial.Visible = controller.spezialVerzehrendVisible;
                special_eatmat_var.Value = controller.spezialVerzehrendVar;
                special_eatmat_var.Visible = controller.spezialVerzehrendVisible;
                special_eatmat_var.Enabled = controller.spezialVerzehrendEnabled;
                special_resistant.Checked = controller.spezialResistenz;
                special_resistant.Visible = controller.spezialResistenzVisible;
                special_reversalis.Checked = controller.spezialUmkehrtalisman;
                special_reversalis.Enabled = controller.spezialUmkehrtalismanEnabled;
                special_reversalis.Visible = controller.spezialUmkehrtalismanVisible;
                special_scent.Checked = controller.spezialGespuer;
                special_schleier.Checked = controller.spezialVerschleierung;
                special_schleier.Enabled = controller.spezialVerschleierungEnabled;
                special_schleier.Visible = controller.spezialVerschleierungVisible;
                special_selfrepair.Checked = controller.spezialSelbstreparatur;
                special_selfrepair.Visible = controller.spezialSelbstreparaturVisible;
                special_signet.Checked = controller.spezialSiegel;
                special_signet.Enabled = controller.spezialSiegelEnabled;
                special_variablerelease.Checked = controller.spezialVariablerAusloeser;
                special_variablerelease.Enabled = controller.spezialVariablerAusloeserEnabled;
                special_variablerelease.Visible = controller.spezialVariablerAusloeserVisible;
                special_variable_var.Value = controller.spezialVariablerAusloeserVar;
                special_variable_var.Visible = controller.spezialVariablerAusloeserVisible;
                special_variable_var.Enabled = controller.spezialVariablerAusloeserEnabled;

                probe_ausloes.Value = controller.probeAusloeser;
                //probe_affine.Minimum = controller.probeAffinMax;
                //probe_affine.Maximum = controller.probeAffinMin;
                probe_affine.Value = controller.probeAffin;
                artefakt_groesse.Value = controller.probeGroesse;
                artefakt_groesse.Enabled = controller.probeGroesseEnabled;
                starkonst.Value = controller.probeSterne;
                arcanoviOtherMod.Value = controller.probeAndereMod;
                arcanoviZfPSternMod.Value = controller.probeZfPSternMod;
                wirkSpruchMod.Value = controller.probeWirkenderSpruchMod;
                arcanovi_force.Value = controller.probeErzwingen;

                limbus.Checked = controller.extraMadeInLimbus;
                namenlos.Checked = controller.extraNamenloseTage;
                gemeinschaftlich.Checked = controller.extraGemeinschaftlicheErschaffung;
                agribaal.Value = controller.extraAgribaal;
                special_ort_neben.Value = controller.extraNebeneffekt;
                special_additional_arcanovi.Value = controller.extraZusaetzlicheArcanovi;
                special_ort_occ.Value = controller.extraOkkupation;
                artefakt_super_big.SelectedIndex = controller.extraExtraGross;
                if (material.Items.Count > 0) material.SelectedIndex = controller.selectedMaterial;
                cb_kristalle.Checked = controller.extraKristalle;
                cb_kristalle.Visible = controller.extraKristalleVisible;

                loads.Value = controller.zauberLadungen;
                loads.Enabled = controller.zauberLadungenEnabled;
                loads_lbl.Enabled = controller.zauberLadungenEnabled;
                stapelung.Enabled = controller.zauberStapelEnabled;
                stapelung.Maximum = controller.zauberStapelMax;
                lbl_staple.Enabled = controller.zauberStapelEnabled;

                txt_create.Text = controller.resultArcanovi;
                txt_analys.Text = controller.resultAnalys;
                txt_destruct.Text = controller.resultDestructibo;

                analys_broken.Checked = controller.analysMisslungen;
                analys_cloack.Value = controller.analysTarnzauber;
                analys_komplex.Value = controller.analysKomplex;
                analys_mr.Value = controller.analysMR;

                destruct_infinitum.Checked = controller.destructiboInfinitum;
                destruct_komplex.Value = controller.destructiboKomplex;
                destruct_mr.Value = controller.destructiboMR;
                destruct_aktive.Value = controller.destructiboAktiveLadungen;
            }
        }

        private void special_variablerelease_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVariablerAusloeser = special_variablerelease.Checked;
            reloadData();
        }

        private void special_variable_var_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialVariablerAusloeserVar = (int)special_variable_var.Value;
            reloadData();
        }

        private void ArtGenControl_Click(object sender, EventArgs e)
        {
        }

        private void rep_mag_Click(object sender, EventArgs e)
        {
            controller.sfRepresentation = 1;
            reloadData();
        }

        private void rep_ach_Click(object sender, EventArgs e)
        {
            controller.sfRepresentation = 0;
            reloadData();
        }

        private void sf_kraft_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfKraftkontrolle = sf_kraft.Checked;
            reloadData();
        }

        private void sf_vielLadung_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfVielfacheLadung = sf_vielLadung.Checked;
            reloadData();
        }

        private void sf_stapel_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfStapeleffekt = sf_stapel.Checked;
            reloadData();
        }

        private void sf_hyper_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfHypervehemenz = sf_hyper.Checked;
            reloadData();
        }

        private void sf_matrix_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfMatrixgeber = sf_matrix.Checked;
            reloadData();
        }

        private void sf_semiI_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfSemipermanenz1 = sf_semiI.Checked;
            reloadData();
        }

        private void sf_semiII_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfSemipermanenz2 = sf_semiII.Checked;
            reloadData();
        }

        private void sf_ringkunde_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfRingkunde = sf_ringkunde.Checked;
            reloadData();
        }

        private void sf_kraftspeicher_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfKraftspeicher = sf_kraftspeicher.Checked;
            reloadData();
        }

        private void sf_aux_CheckedChanged(object sender, EventArgs e)
        {
            controller.sfAuxiliator = sf_aux.Checked;
            reloadData();
        }

        private void arcanovi_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanovi = (int)arcanovi_change.Value;
            reloadData();
        }

        private void arcanovi_matrix_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanoviMatrix = (int)arcanovi_matrix_change.Value;
            reloadData();
        }

        private void arcanovi_semi_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawArcanoviSemipermanenz = (int)arcanovi_semi_change.Value;
            reloadData();
        }

        private void odem_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawOdem = (int)odem_change.Value;
            reloadData();
        }

        private void analys_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawAnalys = (int)analys_change.Value;
            reloadData();
        }

        private void magiekunde_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawMagiekunde = (int)magiekunde_change.Value;
            reloadData();
        }

        private void destruct_change_ValueChanged(object sender, EventArgs e)
        {
            controller.tawDestructibo = (int)destruct_change.Value;
            reloadData();
        }

        private void type_temp_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 0;
            reloadData();
        }

        private void type_einaml_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 1;
            reloadData();
        }

        private void type_charge_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 2;
            reloadData();
        }

        private void type_matrix_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 3;
            reloadData();
        }

        private void type_semi_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 4;
            reloadData();
        }

        private void type_speicher_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 6;
            reloadData();
        }

        private void type_aux_Click(object sender, EventArgs e)
        {
            controller.artefakttyp = 5;
            reloadData();
        }

        private void temp_tag_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = 0;
            reloadData();
        }

        private void temp_woche_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = 1;
            reloadData();
        }

        private void temp_monat_Click(object sender, EventArgs e)
        {
            controller.artefakttypTemp = 2;
            reloadData();
        }

        private void matrix_labil_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = 0;
            reloadData();
        }

        private void matrix_stable_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = 1;
            reloadData();
        }

        private void matrix_verystable_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = 2;
            reloadData();
        }

        private void matrix_unempfindlich_Click(object sender, EventArgs e)
        {
            controller.artefakttypMatrix = 3;
            reloadData();
        }

        private void aux_labil_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = 0;
            reloadData();
        }

        private void aux_stable_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = 1;
            reloadData();
        }

        private void aux_verystable_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = 2;
            reloadData();

        }

        private void aux_unempfindlich_Click(object sender, EventArgs e)
        {
            controller.artefakttypAuxiliator = 3;
            reloadData();
        }

        private void semi_tag_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = 0;
            reloadData();
        }

        private void semi_woche_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = 1;
            reloadData();
        }

        private void semi_monat_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = 2;
            reloadData();
        }

        private void semi_jahr_Click(object sender, EventArgs e)
        {
            controller.artefakttypSemipermanenz = 3;
            reloadData();
        }

        private void type_speicher_value_ValueChanged(object sender, EventArgs e)
        {
            controller.artefakttypKraftspeicher = (int)type_speicher_value.Value;
            reloadData();
        }

        private void probe_ausloes_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAusloeser = (int)probe_ausloes.Value;
            reloadData();
        }

        private void probe_affine_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAffin = (int)probe_affine.Value;
            reloadData();
        }

        private void artefakt_groesse_ValueChanged(object sender, EventArgs e)
        {
            controller.probeGroesse = (int)artefakt_groesse.Value;
            reloadData();
        }

        private void arcanovi_force_ValueChanged(object sender, EventArgs e)
        {
            controller.probeErzwingen = (int)arcanovi_force.Value;
            reloadData();
        }

        private void starkonst_ValueChanged(object sender, EventArgs e)
        {
            controller.probeSterne = (int)starkonst.Value;
            reloadData();
        }

        private void arcanoviOtherMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeAndereMod = (int)arcanoviOtherMod.Value;
            reloadData();
        }

        private void arcanoviZfPSternMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeZfPSternMod = (int)arcanoviZfPSternMod.Value;
            reloadData();
        }

        private void wirkSpruchMod_ValueChanged(object sender, EventArgs e)
        {
            controller.probeWirkenderSpruchMod = (int)wirkSpruchMod.Value;
            reloadData();
        }

        private void limbus_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraMadeInLimbus = limbus.Checked;
            reloadData();
        }

        private void namenlos_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraNamenloseTage = namenlos.Checked;
            reloadData();
        }

        private void gemeinschaftlich_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraGemeinschaftlicheErschaffung = gemeinschaftlich.Checked;
            reloadData();
        }

        private void agribaal_ValueChanged(object sender, EventArgs e)
        {
            controller.extraAgribaal = (int)agribaal.Value;
            reloadData();
        }

        private void special_ort_occ_ValueChanged(object sender, EventArgs e)
        {
            controller.extraOkkupation = (int)special_ort_occ.Value;
            reloadData();
        }

        private void special_ort_neben_ValueChanged(object sender, EventArgs e)
        {
            controller.extraNebeneffekt = (int)special_ort_neben.Value;
            reloadData();
        }

        private void special_additional_arcanovi_ValueChanged(object sender, EventArgs e)
        {
            controller.extraZusaetzlicheArcanovi = (int)special_additional_arcanovi.Value;
            reloadData();
        }

        private void artefakt_super_big_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.extraExtraGross = artefakt_super_big.SelectedIndex;
            reloadData();
        }

        private void material_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.selectedMaterial = material.SelectedIndex;
            reloadData();
        }

        private void cb_kristalle_CheckedChanged(object sender, EventArgs e)
        {
            controller.extraKristalle = cb_kristalle.Checked;
            reloadData();
        }

        private void special_signet_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialSiegel = special_signet.Checked;
            reloadData();
        }

        private void special_apport_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialApport = special_apport.Checked;
            reloadData();
        }

        private void special_durable_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialUnzerbrechlich = special_durable.Checked;
            reloadData();
        }

        private void special_scent_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialGespuer = special_scent.Checked;
            reloadData();
        }

        private void special_resistant_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialResistenz = special_resistant.Checked;
            reloadData();
        }

        private void special_selfrepair_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialSelbstreparatur = special_selfrepair.Checked;
            reloadData();
        }

        private void special_reversalis_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialUmkehrtalisman = special_reversalis.Checked;
            reloadData();
        }

        private void special_schleier_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVerschleierung = special_schleier.Checked;
            reloadData();
        }

        private void special_eatmaterial_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialVerzehrend = special_eatmaterial.Checked;
            reloadData();
        }

        private void special_ferngespuer_CheckedChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuer = special_ferngespuer.Checked;
            reloadData();
        }

        private void special_eatmat_var_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialVerzehrendVar = (int)special_eatmat_var.Value;
            reloadData();
        }

        private void special_ferngespuer_komp_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuerKomp = special_ferngespuer_komp.SelectedIndex;
            reloadData();
        }

        private void special_ferngespuer_asp_ValueChanged(object sender, EventArgs e)
        {
            controller.spezialFerngespuerAsp = (int)special_ferngespuer_asp.Value;
            reloadData();
        }

        private void loads_ValueChanged(object sender, EventArgs e)
        {
            controller.zauberLadungen = (int)loads.Value;
            reloadData();
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

        private void zauberGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void zauberGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (zauberGrid.CurrentCell.ColumnIndex == 1)
                zauberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
