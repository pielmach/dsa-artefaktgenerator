using System.Windows.Forms;
using CustomControls;
namespace ArtefaktGenerator
{
    partial class ArtGenControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.materialGroup = new System.Windows.Forms.GroupBox();
            this.material = new System.Windows.Forms.ComboBox();
            this.cb_kristalle = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.arcanoviOtherMod = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.starkonst = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.arcanovi_force = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.artefakt_groesse = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.probe_affine = new System.Windows.Forms.NumericUpDown();
            this.probe_ausloes = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.special_ferngespuer_komp = new System.Windows.Forms.ComboBox();
            this.special_eatmat_var = new System.Windows.Forms.NumericUpDown();
            this.lbl_special_asp = new System.Windows.Forms.Label();
            this.special_ferngespuer_asp = new System.Windows.Forms.NumericUpDown();
            this.special_ferngespuer = new System.Windows.Forms.CheckBox();
            this.lbl_special_komp = new System.Windows.Forms.Label();
            this.special_variable_var = new System.Windows.Forms.NumericUpDown();
            this.special_schleier = new System.Windows.Forms.CheckBox();
            this.special_variablerelease = new System.Windows.Forms.CheckBox();
            this.special_reversalis = new System.Windows.Forms.CheckBox();
            this.special_selfrepair = new System.Windows.Forms.CheckBox();
            this.special_resistant = new System.Windows.Forms.CheckBox();
            this.special_apport = new System.Windows.Forms.CheckBox();
            this.special_scent = new System.Windows.Forms.CheckBox();
            this.special_durable = new System.Windows.Forms.CheckBox();
            this.special_signet = new System.Windows.Forms.CheckBox();
            this.special_eatmaterial = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.special_additional_arcanovi = new System.Windows.Forms.NumericUpDown();
            this.gemeinschaftlich = new System.Windows.Forms.CheckBox();
            this.agribaal = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.special_ort_neben = new System.Windows.Forms.NumericUpDown();
            this.special_ort_occ = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.artefakt_super_big = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.limbus = new System.Windows.Forms.CheckBox();
            this.namenlos = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sf_aux = new System.Windows.Forms.CheckBox();
            this.sf_kraftspeicher = new System.Windows.Forms.CheckBox();
            this.sf_ringkunde = new System.Windows.Forms.CheckBox();
            this.sf_semiII = new System.Windows.Forms.CheckBox();
            this.sf_semiI = new System.Windows.Forms.CheckBox();
            this.sf_matrix = new System.Windows.Forms.CheckBox();
            this.sf_hyper = new System.Windows.Forms.CheckBox();
            this.sf_stapel = new System.Windows.Forms.CheckBox();
            this.sf_vielLadung = new System.Windows.Forms.CheckBox();
            this.sf_kraft = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.destruct_change = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.magiekunde_change = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.analys_change = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.odem_change = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.arcanovi_semi_change = new System.Windows.Forms.NumericUpDown();
            this.arcanovi_matrix_change = new System.Windows.Forms.NumericUpDown();
            this.arcanovi_change = new System.Windows.Forms.NumericUpDown();
            this.arcanovi_semi_change_lbl = new System.Windows.Forms.Label();
            this.arcanovi_matrix_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wirkendeZauber = new System.Windows.Forms.GroupBox();
            this.zauber_add = new System.Windows.Forms.Button();
            this.zauber_listbox = new System.Windows.Forms.ListBox();
            this.komp_combo = new System.Windows.Forms.ComboBox();
            this.zauber_rep = new System.Windows.Forms.ComboBox();
            this.zauber_del = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.loads_lbl = new System.Windows.Forms.Label();
            this.zauber_list = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.complexity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count_staples = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count_asp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.asp = new System.Windows.Forms.NumericUpDown();
            this.stapelung = new System.Windows.Forms.NumericUpDown();
            this.loads = new System.Windows.Forms.NumericUpDown();
            this.zauber = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_staple = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_create = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.analys_cloack = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.analys_broken = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.analys_komplex = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.analys_mr = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_analys = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.destruct_aktive = new System.Windows.Forms.NumericUpDown();
            this.lbl_infi = new System.Windows.Forms.Label();
            this.destruct_infinitum = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.destruct_komplex = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.destruct_mr = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_destruct = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.programmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importHeldensoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateInstallierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.programmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuesArtefaktToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artefaktLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artefaktSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automatischNeuberechenenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ach_save = new System.Windows.Forms.ToolStripMenuItem();
            this.regelbasis = new System.Windows.Forms.ToolStripMenuItem();
            this.wegeDerAlchimieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staebeRingeDschinnenlampenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.würfelergebnisseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleBerechnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w6AnnehmenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w6_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.w6_35 = new System.Windows.Forms.ToolStripMenuItem();
            this.w6_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.w6_6 = new System.Windows.Forms.ToolStripMenuItem();
            this.w20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w20_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.w20_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.w20_105 = new System.Windows.Forms.ToolStripMenuItem();
            this.w20_11 = new System.Windows.Forms.ToolStripMenuItem();
            this.w20_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.nebenwirkungenMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nebenReRollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nebenIgnoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.heldenimportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfo = new System.Windows.Forms.Label();
            this.hero_name = new System.Windows.Forms.Label();
            this.zauberGrid = new System.Windows.Forms.DataGridView();
            this.dasArtefaktBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dasArtefaktBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.artefakttyp = new CustomControls.RadioGroupBox();
            this.artefakttyp_aux = new CustomControls.RadioGroupBox();
            this.aux_labil = new System.Windows.Forms.RadioButton();
            this.aux_merkmal = new System.Windows.Forms.CheckBox();
            this.aux_stable = new System.Windows.Forms.RadioButton();
            this.aux_verystable = new System.Windows.Forms.RadioButton();
            this.aux_unempfindlich = new System.Windows.Forms.RadioButton();
            this.type_speicher_value = new System.Windows.Forms.NumericUpDown();
            this.lbl_type_speicher_val = new System.Windows.Forms.Label();
            this.type_speicher = new System.Windows.Forms.RadioButton();
            this.artefakttyp_temp = new CustomControls.RadioGroupBox();
            this.temp_monat = new System.Windows.Forms.RadioButton();
            this.temp_woche = new System.Windows.Forms.RadioButton();
            this.temp_tag = new System.Windows.Forms.RadioButton();
            this.type_temp = new System.Windows.Forms.RadioButton();
            this.type_einaml = new System.Windows.Forms.RadioButton();
            this.type_aux = new System.Windows.Forms.RadioButton();
            this.type_charge = new System.Windows.Forms.RadioButton();
            this.type_matrix = new System.Windows.Forms.RadioButton();
            this.type_semi = new System.Windows.Forms.RadioButton();
            this.artefakttyp_matrix = new CustomControls.RadioGroupBox();
            this.matrix_unempfindlich = new System.Windows.Forms.RadioButton();
            this.matrix_verystable = new System.Windows.Forms.RadioButton();
            this.matrix_stable = new System.Windows.Forms.RadioButton();
            this.matrix_labil = new System.Windows.Forms.RadioButton();
            this.artefakttyp_semi = new CustomControls.RadioGroupBox();
            this.semi_monat = new System.Windows.Forms.RadioButton();
            this.semi_woche = new System.Windows.Forms.RadioButton();
            this.semi_tag = new System.Windows.Forms.RadioButton();
            this.semi_jahr = new System.Windows.Forms.RadioButton();
            this.repGroup = new CustomControls.RadioGroupBox();
            this.rep_ach = new System.Windows.Forms.RadioButton();
            this.rep_mag = new System.Windows.Forms.RadioButton();
            this.materialGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcanoviOtherMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starkonst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_force)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artefakt_groesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probe_affine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probe_ausloes)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.special_eatmat_var)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ferngespuer_asp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_variable_var)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.special_additional_arcanovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agribaal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ort_neben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ort_occ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magiekunde_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odem_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_semi_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_matrix_change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_change)).BeginInit();
            this.wirkendeZauber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stapelung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loads)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analys_cloack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_komplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_mr)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_aktive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_komplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_mr)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zauberGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dasArtefaktBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dasArtefaktBindingSource1)).BeginInit();
            this.artefakttyp.SuspendLayout();
            this.artefakttyp_aux.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.type_speicher_value)).BeginInit();
            this.artefakttyp_temp.SuspendLayout();
            this.artefakttyp_matrix.SuspendLayout();
            this.artefakttyp_semi.SuspendLayout();
            this.repGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialGroup
            // 
            this.materialGroup.Controls.Add(this.material);
            this.materialGroup.Controls.Add(this.cb_kristalle);
            this.materialGroup.Location = new System.Drawing.Point(635, 317);
            this.materialGroup.Name = "materialGroup";
            this.materialGroup.Size = new System.Drawing.Size(153, 57);
            this.materialGroup.TabIndex = 21;
            this.materialGroup.TabStop = false;
            this.materialGroup.Text = "Material";
            // 
            // material
            // 
            this.material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.material.FormattingEnabled = true;
            this.material.Location = new System.Drawing.Point(7, 16);
            this.material.Name = "material";
            this.material.Size = new System.Drawing.Size(140, 22);
            this.material.TabIndex = 0;
            this.material.SelectedIndexChanged += new System.EventHandler(this.material_SelectedIndexChanged);
            // 
            // cb_kristalle
            // 
            this.cb_kristalle.AutoSize = true;
            this.cb_kristalle.Location = new System.Drawing.Point(7, 38);
            this.cb_kristalle.Name = "cb_kristalle";
            this.cb_kristalle.Size = new System.Drawing.Size(114, 18);
            this.cb_kristalle.TabIndex = 1;
            this.cb_kristalle.Text = "Kristalle (-1 pAsP)";
            this.cb_kristalle.UseVisualStyleBackColor = true;
            this.cb_kristalle.CheckedChanged += new System.EventHandler(this.cb_kristalle_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.arcanoviOtherMod);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.starkonst);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.arcanovi_force);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.artefakt_groesse);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.probe_affine);
            this.groupBox5.Controls.Add(this.probe_ausloes);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(635, 157);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(153, 161);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Probenmodifikationen";
            // 
            // arcanoviOtherMod
            // 
            this.arcanoviOtherMod.Location = new System.Drawing.Point(111, 134);
            this.arcanoviOtherMod.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.arcanoviOtherMod.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.arcanoviOtherMod.Name = "arcanoviOtherMod";
            this.arcanoviOtherMod.Size = new System.Drawing.Size(36, 20);
            this.arcanoviOtherMod.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Weitere Mod.";
            // 
            // starkonst
            // 
            this.starkonst.Location = new System.Drawing.Point(111, 111);
            this.starkonst.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.starkonst.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.starkonst.Name = "starkonst";
            this.starkonst.Size = new System.Drawing.Size(36, 20);
            this.starkonst.TabIndex = 18;
            this.starkonst.ValueChanged += new System.EventHandler(this.starkonst_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 114);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 14);
            this.label26.TabIndex = 17;
            this.label26.Text = "Sternenkonstellation";
            // 
            // arcanovi_force
            // 
            this.arcanovi_force.Location = new System.Drawing.Point(111, 88);
            this.arcanovi_force.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.arcanovi_force.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.arcanovi_force.Name = "arcanovi_force";
            this.arcanovi_force.Size = new System.Drawing.Size(36, 20);
            this.arcanovi_force.TabIndex = 16;
            this.arcanovi_force.ValueChanged += new System.EventHandler(this.arcanovi_force_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 14);
            this.label17.TabIndex = 15;
            this.label17.Text = "Arcanovi erzwingen";
            // 
            // artefakt_groesse
            // 
            this.artefakt_groesse.Location = new System.Drawing.Point(111, 65);
            this.artefakt_groesse.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.artefakt_groesse.Name = "artefakt_groesse";
            this.artefakt_groesse.Size = new System.Drawing.Size(36, 20);
            this.artefakt_groesse.TabIndex = 12;
            this.artefakt_groesse.ValueChanged += new System.EventHandler(this.artefakt_groesse_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 14);
            this.label15.TabIndex = 11;
            this.label15.Text = "Artefaktgröße";
            // 
            // probe_affine
            // 
            this.probe_affine.Location = new System.Drawing.Point(111, 42);
            this.probe_affine.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.probe_affine.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.probe_affine.Name = "probe_affine";
            this.probe_affine.Size = new System.Drawing.Size(36, 20);
            this.probe_affine.TabIndex = 10;
            this.probe_affine.ValueChanged += new System.EventHandler(this.probe_affine_ValueChanged);
            // 
            // probe_ausloes
            // 
            this.probe_ausloes.Location = new System.Drawing.Point(111, 19);
            this.probe_ausloes.Name = "probe_ausloes";
            this.probe_ausloes.Size = new System.Drawing.Size(36, 20);
            this.probe_ausloes.TabIndex = 8;
            this.probe_ausloes.ValueChanged += new System.EventHandler(this.probe_ausloes_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "Objekt-Affinität";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Auslöser";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.special_ferngespuer_komp);
            this.groupBox7.Controls.Add(this.special_eatmat_var);
            this.groupBox7.Controls.Add(this.lbl_special_asp);
            this.groupBox7.Controls.Add(this.special_ferngespuer_asp);
            this.groupBox7.Controls.Add(this.special_ferngespuer);
            this.groupBox7.Controls.Add(this.lbl_special_komp);
            this.groupBox7.Controls.Add(this.special_variable_var);
            this.groupBox7.Controls.Add(this.special_schleier);
            this.groupBox7.Controls.Add(this.special_variablerelease);
            this.groupBox7.Controls.Add(this.special_reversalis);
            this.groupBox7.Controls.Add(this.special_selfrepair);
            this.groupBox7.Controls.Add(this.special_resistant);
            this.groupBox7.Controls.Add(this.special_apport);
            this.groupBox7.Controls.Add(this.special_scent);
            this.groupBox7.Controls.Add(this.special_durable);
            this.groupBox7.Controls.Add(this.special_signet);
            this.groupBox7.Controls.Add(this.special_eatmaterial);
            this.groupBox7.Location = new System.Drawing.Point(7, 252);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(622, 90);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Spezielle Eigenschaften";
            // 
            // special_ferngespuer_komp
            // 
            this.special_ferngespuer_komp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.special_ferngespuer_komp.FormattingEnabled = true;
            this.special_ferngespuer_komp.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.special_ferngespuer_komp.Location = new System.Drawing.Point(520, 61);
            this.special_ferngespuer_komp.Name = "special_ferngespuer_komp";
            this.special_ferngespuer_komp.Size = new System.Drawing.Size(34, 22);
            this.special_ferngespuer_komp.TabIndex = 26;
            this.special_ferngespuer_komp.SelectedIndexChanged += new System.EventHandler(this.special_ferngespuer_komp_SelectedIndexChanged);
            // 
            // special_eatmat_var
            // 
            this.special_eatmat_var.Location = new System.Drawing.Point(520, 38);
            this.special_eatmat_var.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.special_eatmat_var.Name = "special_eatmat_var";
            this.special_eatmat_var.Size = new System.Drawing.Size(36, 20);
            this.special_eatmat_var.TabIndex = 29;
            this.special_eatmat_var.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.special_eatmat_var.ValueChanged += new System.EventHandler(this.special_eatmat_var_ValueChanged);
            // 
            // lbl_special_asp
            // 
            this.lbl_special_asp.AutoSize = true;
            this.lbl_special_asp.Location = new System.Drawing.Point(554, 65);
            this.lbl_special_asp.Name = "lbl_special_asp";
            this.lbl_special_asp.Size = new System.Drawing.Size(26, 14);
            this.lbl_special_asp.TabIndex = 28;
            this.lbl_special_asp.Text = "AsP";
            // 
            // special_ferngespuer_asp
            // 
            this.special_ferngespuer_asp.Location = new System.Drawing.Point(582, 62);
            this.special_ferngespuer_asp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.special_ferngespuer_asp.Name = "special_ferngespuer_asp";
            this.special_ferngespuer_asp.Size = new System.Drawing.Size(36, 20);
            this.special_ferngespuer_asp.TabIndex = 27;
            this.special_ferngespuer_asp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.special_ferngespuer_asp.ValueChanged += new System.EventHandler(this.special_ferngespuer_asp_ValueChanged);
            // 
            // special_ferngespuer
            // 
            this.special_ferngespuer.AutoSize = true;
            this.special_ferngespuer.Location = new System.Drawing.Point(394, 63);
            this.special_ferngespuer.Name = "special_ferngespuer";
            this.special_ferngespuer.Size = new System.Drawing.Size(76, 18);
            this.special_ferngespuer.TabIndex = 4;
            this.special_ferngespuer.Text = "Ferngespür";
            this.special_ferngespuer.UseVisualStyleBackColor = true;
            this.special_ferngespuer.CheckedChanged += new System.EventHandler(this.special_ferngespuer_CheckedChanged);
            // 
            // lbl_special_komp
            // 
            this.lbl_special_komp.AutoSize = true;
            this.lbl_special_komp.Location = new System.Drawing.Point(476, 64);
            this.lbl_special_komp.Name = "lbl_special_komp";
            this.lbl_special_komp.Size = new System.Drawing.Size(39, 14);
            this.lbl_special_komp.TabIndex = 25;
            this.lbl_special_komp.Text = "Komp.";
            // 
            // special_variable_var
            // 
            this.special_variable_var.Location = new System.Drawing.Point(520, 13);
            this.special_variable_var.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.special_variable_var.Name = "special_variable_var";
            this.special_variable_var.Size = new System.Drawing.Size(36, 20);
            this.special_variable_var.TabIndex = 19;
            this.special_variable_var.ValueChanged += new System.EventHandler(this.special_variable_var_ValueChanged);
            // 
            // special_schleier
            // 
            this.special_schleier.AutoSize = true;
            this.special_schleier.Location = new System.Drawing.Point(132, 63);
            this.special_schleier.Name = "special_schleier";
            this.special_schleier.Size = new System.Drawing.Size(92, 18);
            this.special_schleier.TabIndex = 9;
            this.special_schleier.Text = "Verschleierung";
            this.special_schleier.UseVisualStyleBackColor = true;
            this.special_schleier.CheckedChanged += new System.EventHandler(this.special_schleier_CheckedChanged);
            // 
            // special_variablerelease
            // 
            this.special_variablerelease.AutoSize = true;
            this.special_variablerelease.Location = new System.Drawing.Point(394, 15);
            this.special_variablerelease.Name = "special_variablerelease";
            this.special_variablerelease.Size = new System.Drawing.Size(107, 18);
            this.special_variablerelease.TabIndex = 8;
            this.special_variablerelease.Text = "Variabler Auslöser";
            this.special_variablerelease.UseVisualStyleBackColor = true;
            this.special_variablerelease.CheckedChanged += new System.EventHandler(this.special_variablerelease_CheckedChanged);
            // 
            // special_reversalis
            // 
            this.special_reversalis.AutoSize = true;
            this.special_reversalis.Location = new System.Drawing.Point(6, 63);
            this.special_reversalis.Name = "special_reversalis";
            this.special_reversalis.Size = new System.Drawing.Size(103, 18);
            this.special_reversalis.TabIndex = 7;
            this.special_reversalis.Text = "Umkehrtalisman";
            this.special_reversalis.UseVisualStyleBackColor = true;
            this.special_reversalis.CheckedChanged += new System.EventHandler(this.special_reversalis_CheckedChanged);
            // 
            // special_selfrepair
            // 
            this.special_selfrepair.AutoSize = true;
            this.special_selfrepair.Location = new System.Drawing.Point(266, 39);
            this.special_selfrepair.Name = "special_selfrepair";
            this.special_selfrepair.Size = new System.Drawing.Size(94, 18);
            this.special_selfrepair.TabIndex = 6;
            this.special_selfrepair.Text = "Selbstreparatur";
            this.special_selfrepair.UseVisualStyleBackColor = true;
            this.special_selfrepair.CheckedChanged += new System.EventHandler(this.special_selfrepair_CheckedChanged);
            // 
            // special_resistant
            // 
            this.special_resistant.AutoSize = true;
            this.special_resistant.Location = new System.Drawing.Point(132, 39);
            this.special_resistant.Name = "special_resistant";
            this.special_resistant.Size = new System.Drawing.Size(128, 18);
            this.special_resistant.TabIndex = 5;
            this.special_resistant.Text = "Res. profaner Schaden";
            this.special_resistant.UseVisualStyleBackColor = true;
            this.special_resistant.CheckedChanged += new System.EventHandler(this.special_resistant_CheckedChanged);
            // 
            // special_apport
            // 
            this.special_apport.AutoSize = true;
            this.special_apport.Location = new System.Drawing.Point(6, 39);
            this.special_apport.Name = "special_apport";
            this.special_apport.Size = new System.Drawing.Size(109, 18);
            this.special_apport.TabIndex = 3;
            this.special_apport.Text = "Magischer Apport";
            this.special_apport.UseVisualStyleBackColor = true;
            this.special_apport.CheckedChanged += new System.EventHandler(this.special_apport_CheckedChanged);
            // 
            // special_scent
            // 
            this.special_scent.AutoSize = true;
            this.special_scent.Location = new System.Drawing.Point(266, 15);
            this.special_scent.Name = "special_scent";
            this.special_scent.Size = new System.Drawing.Size(122, 18);
            this.special_scent.TabIndex = 2;
            this.special_scent.Text = "Gespür des Schöpfers";
            this.special_scent.UseVisualStyleBackColor = true;
            this.special_scent.CheckedChanged += new System.EventHandler(this.special_scent_CheckedChanged);
            // 
            // special_durable
            // 
            this.special_durable.AutoSize = true;
            this.special_durable.Location = new System.Drawing.Point(132, 15);
            this.special_durable.Name = "special_durable";
            this.special_durable.Size = new System.Drawing.Size(114, 18);
            this.special_durable.TabIndex = 1;
            this.special_durable.Text = "Unzerbrechlichkeit";
            this.special_durable.UseVisualStyleBackColor = true;
            this.special_durable.CheckedChanged += new System.EventHandler(this.special_durable_CheckedChanged);
            // 
            // special_signet
            // 
            this.special_signet.AutoSize = true;
            this.special_signet.Location = new System.Drawing.Point(6, 15);
            this.special_signet.Name = "special_signet";
            this.special_signet.Size = new System.Drawing.Size(119, 18);
            this.special_signet.TabIndex = 0;
            this.special_signet.Text = "Siegel und Zertifikat";
            this.special_signet.UseVisualStyleBackColor = true;
            this.special_signet.CheckedChanged += new System.EventHandler(this.special_signet_CheckedChanged);
            // 
            // special_eatmaterial
            // 
            this.special_eatmaterial.AutoSize = true;
            this.special_eatmaterial.Location = new System.Drawing.Point(394, 39);
            this.special_eatmaterial.Name = "special_eatmaterial";
            this.special_eatmaterial.Size = new System.Drawing.Size(120, 18);
            this.special_eatmaterial.TabIndex = 10;
            this.special_eatmaterial.Text = "Verzehrender Zauber";
            this.special_eatmaterial.UseVisualStyleBackColor = true;
            this.special_eatmaterial.CheckedChanged += new System.EventHandler(this.special_eatmaterial_CheckedChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.special_additional_arcanovi);
            this.groupBox11.Controls.Add(this.gemeinschaftlich);
            this.groupBox11.Controls.Add(this.agribaal);
            this.groupBox11.Controls.Add(this.label32);
            this.groupBox11.Controls.Add(this.special_ort_neben);
            this.groupBox11.Controls.Add(this.special_ort_occ);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Controls.Add(this.artefakt_super_big);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.limbus);
            this.groupBox11.Controls.Add(this.namenlos);
            this.groupBox11.Location = new System.Drawing.Point(793, 157);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(198, 217);
            this.groupBox11.TabIndex = 22;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Besonderes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "Weitere Arcanovi";
            // 
            // special_additional_arcanovi
            // 
            this.special_additional_arcanovi.Location = new System.Drawing.Point(6, 162);
            this.special_additional_arcanovi.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.special_additional_arcanovi.Name = "special_additional_arcanovi";
            this.special_additional_arcanovi.Size = new System.Drawing.Size(36, 20);
            this.special_additional_arcanovi.TabIndex = 26;
            // 
            // gemeinschaftlich
            // 
            this.gemeinschaftlich.AutoSize = true;
            this.gemeinschaftlich.Location = new System.Drawing.Point(6, 51);
            this.gemeinschaftlich.Name = "gemeinschaftlich";
            this.gemeinschaftlich.Size = new System.Drawing.Size(169, 18);
            this.gemeinschaftlich.TabIndex = 25;
            this.gemeinschaftlich.Text = "Gemeinschaftliche Erschaffung";
            this.gemeinschaftlich.UseVisualStyleBackColor = true;
            this.gemeinschaftlich.CheckedChanged += new System.EventHandler(this.gemeinschaftlich_CheckedChanged);
            // 
            // agribaal
            // 
            this.agribaal.Increment = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.agribaal.Location = new System.Drawing.Point(6, 72);
            this.agribaal.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.agribaal.Name = "agribaal";
            this.agribaal.Size = new System.Drawing.Size(36, 20);
            this.agribaal.TabIndex = 24;
            this.agribaal.ValueChanged += new System.EventHandler(this.agribaal_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(46, 75);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(99, 14);
            this.label32.TabIndex = 23;
            this.label32.Text = "ZfP* durch Agribaal";
            // 
            // special_ort_neben
            // 
            this.special_ort_neben.Location = new System.Drawing.Point(6, 119);
            this.special_ort_neben.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.special_ort_neben.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.special_ort_neben.Name = "special_ort_neben";
            this.special_ort_neben.Size = new System.Drawing.Size(36, 20);
            this.special_ort_neben.TabIndex = 22;
            this.special_ort_neben.ValueChanged += new System.EventHandler(this.special_ort_neben_ValueChanged);
            // 
            // special_ort_occ
            // 
            this.special_ort_occ.Location = new System.Drawing.Point(6, 96);
            this.special_ort_occ.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.special_ort_occ.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.special_ort_occ.Name = "special_ort_occ";
            this.special_ort_occ.Size = new System.Drawing.Size(36, 20);
            this.special_ort_occ.TabIndex = 20;
            this.special_ort_occ.ValueChanged += new System.EventHandler(this.special_ort_occ_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(46, 123);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(150, 14);
            this.label31.TabIndex = 21;
            this.label31.Text = "Besonderer Ort (Nebeneffekte)";
            // 
            // artefakt_super_big
            // 
            this.artefakt_super_big.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.artefakt_super_big.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.artefakt_super_big.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.artefakt_super_big.FormattingEnabled = true;
            this.artefakt_super_big.Items.AddRange(new object[] {
            "nein",
            "Kutsche",
            "kl. Haus/Schiff",
            "Palast/Burg",
            "Berg"});
            this.artefakt_super_big.Location = new System.Drawing.Point(110, 139);
            this.artefakt_super_big.Name = "artefakt_super_big";
            this.artefakt_super_big.Size = new System.Drawing.Size(83, 22);
            this.artefakt_super_big.TabIndex = 14;
            this.artefakt_super_big.SelectedIndexChanged += new System.EventHandler(this.artefakt_super_big_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(46, 99);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(143, 14);
            this.label30.TabIndex = 19;
            this.label30.Text = "Besonderer Ort (Okkupation)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 14);
            this.label16.TabIndex = 13;
            this.label16.Text = "Übergroßes Artefakt";
            // 
            // limbus
            // 
            this.limbus.AutoSize = true;
            this.limbus.Location = new System.Drawing.Point(6, 15);
            this.limbus.Name = "limbus";
            this.limbus.Size = new System.Drawing.Size(132, 18);
            this.limbus.TabIndex = 1;
            this.limbus.Text = "Erschaffung im Limbus";
            this.limbus.UseVisualStyleBackColor = true;
            this.limbus.CheckedChanged += new System.EventHandler(this.limbus_CheckedChanged);
            // 
            // namenlos
            // 
            this.namenlos.AutoSize = true;
            this.namenlos.Location = new System.Drawing.Point(6, 33);
            this.namenlos.Name = "namenlos";
            this.namenlos.Size = new System.Drawing.Size(102, 18);
            this.namenlos.TabIndex = 0;
            this.namenlos.Text = "Namenlose Tage";
            this.namenlos.UseVisualStyleBackColor = true;
            this.namenlos.CheckedChanged += new System.EventHandler(this.namenlos_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sf_aux);
            this.groupBox1.Controls.Add(this.sf_kraftspeicher);
            this.groupBox1.Controls.Add(this.sf_ringkunde);
            this.groupBox1.Controls.Add(this.sf_semiII);
            this.groupBox1.Controls.Add(this.sf_semiI);
            this.groupBox1.Controls.Add(this.sf_matrix);
            this.groupBox1.Controls.Add(this.sf_hyper);
            this.groupBox1.Controls.Add(this.sf_stapel);
            this.groupBox1.Controls.Add(this.sf_vielLadung);
            this.groupBox1.Controls.Add(this.sf_kraft);
            this.groupBox1.Location = new System.Drawing.Point(6, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 46);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sonderfertigkeiten";
            // 
            // sf_aux
            // 
            this.sf_aux.AutoSize = true;
            this.sf_aux.Location = new System.Drawing.Point(885, 19);
            this.sf_aux.Name = "sf_aux";
            this.sf_aux.Size = new System.Drawing.Size(73, 18);
            this.sf_aux.TabIndex = 9;
            this.sf_aux.Text = "Auxiliator";
            this.sf_aux.UseVisualStyleBackColor = true;
            this.sf_aux.CheckedChanged += new System.EventHandler(this.sf_aux_CheckedChanged);
            // 
            // sf_kraftspeicher
            // 
            this.sf_kraftspeicher.AutoSize = true;
            this.sf_kraftspeicher.Location = new System.Drawing.Point(796, 19);
            this.sf_kraftspeicher.Name = "sf_kraftspeicher";
            this.sf_kraftspeicher.Size = new System.Drawing.Size(89, 18);
            this.sf_kraftspeicher.TabIndex = 10;
            this.sf_kraftspeicher.Text = "Kraftspeicher";
            this.sf_kraftspeicher.UseVisualStyleBackColor = true;
            this.sf_kraftspeicher.CheckedChanged += new System.EventHandler(this.sf_kraftspeicher_CheckedChanged);
            // 
            // sf_ringkunde
            // 
            this.sf_ringkunde.AutoSize = true;
            this.sf_ringkunde.Location = new System.Drawing.Point(686, 19);
            this.sf_ringkunde.Name = "sf_ringkunde";
            this.sf_ringkunde.Size = new System.Drawing.Size(110, 18);
            this.sf_ringkunde.TabIndex = 4;
            this.sf_ringkunde.Text = "Ringkunde gelesen";
            this.sf_ringkunde.UseVisualStyleBackColor = true;
            this.sf_ringkunde.CheckedChanged += new System.EventHandler(this.sf_ringkunde_CheckedChanged);
            // 
            // sf_semiII
            // 
            this.sf_semiII.AutoSize = true;
            this.sf_semiII.Location = new System.Drawing.Point(576, 19);
            this.sf_semiII.Name = "sf_semiII";
            this.sf_semiII.Size = new System.Drawing.Size(110, 18);
            this.sf_semiII.TabIndex = 6;
            this.sf_semiII.Text = "Semipermanenz II";
            this.sf_semiII.UseVisualStyleBackColor = true;
            this.sf_semiII.CheckedChanged += new System.EventHandler(this.sf_semiII_CheckedChanged);
            // 
            // sf_semiI
            // 
            this.sf_semiI.AutoSize = true;
            this.sf_semiI.Location = new System.Drawing.Point(470, 19);
            this.sf_semiI.Name = "sf_semiI";
            this.sf_semiI.Size = new System.Drawing.Size(106, 18);
            this.sf_semiI.TabIndex = 5;
            this.sf_semiI.Text = "Semipermanenz I";
            this.sf_semiI.UseVisualStyleBackColor = true;
            this.sf_semiI.CheckedChanged += new System.EventHandler(this.sf_semiI_CheckedChanged);
            // 
            // sf_matrix
            // 
            this.sf_matrix.AutoSize = true;
            this.sf_matrix.Location = new System.Drawing.Point(388, 19);
            this.sf_matrix.Name = "sf_matrix";
            this.sf_matrix.Size = new System.Drawing.Size(82, 18);
            this.sf_matrix.TabIndex = 4;
            this.sf_matrix.Text = "Matrixgeber";
            this.sf_matrix.UseVisualStyleBackColor = true;
            this.sf_matrix.CheckedChanged += new System.EventHandler(this.sf_matrix_CheckedChanged);
            // 
            // sf_hyper
            // 
            this.sf_hyper.AutoSize = true;
            this.sf_hyper.Location = new System.Drawing.Point(286, 19);
            this.sf_hyper.Name = "sf_hyper";
            this.sf_hyper.Size = new System.Drawing.Size(102, 18);
            this.sf_hyper.TabIndex = 3;
            this.sf_hyper.Text = "Hypervehemenz";
            this.sf_hyper.UseVisualStyleBackColor = true;
            this.sf_hyper.CheckedChanged += new System.EventHandler(this.sf_hyper_CheckedChanged);
            // 
            // sf_stapel
            // 
            this.sf_stapel.AutoSize = true;
            this.sf_stapel.Location = new System.Drawing.Point(204, 19);
            this.sf_stapel.Name = "sf_stapel";
            this.sf_stapel.Size = new System.Drawing.Size(82, 18);
            this.sf_stapel.TabIndex = 2;
            this.sf_stapel.Text = "Stapeleffekt";
            this.sf_stapel.UseVisualStyleBackColor = true;
            this.sf_stapel.CheckedChanged += new System.EventHandler(this.sf_stapel_CheckedChanged);
            // 
            // sf_vielLadung
            // 
            this.sf_vielLadung.AutoSize = true;
            this.sf_vielLadung.Location = new System.Drawing.Point(100, 19);
            this.sf_vielLadung.Name = "sf_vielLadung";
            this.sf_vielLadung.Size = new System.Drawing.Size(104, 18);
            this.sf_vielLadung.TabIndex = 8;
            this.sf_vielLadung.Text = "Vielfache Ladung";
            this.sf_vielLadung.UseVisualStyleBackColor = true;
            this.sf_vielLadung.CheckedChanged += new System.EventHandler(this.sf_vielLadung_CheckedChanged);
            // 
            // sf_kraft
            // 
            this.sf_kraft.AutoSize = true;
            this.sf_kraft.Location = new System.Drawing.Point(6, 19);
            this.sf_kraft.Name = "sf_kraft";
            this.sf_kraft.Size = new System.Drawing.Size(94, 18);
            this.sf_kraft.TabIndex = 0;
            this.sf_kraft.Text = "Kraftkontrolle";
            this.sf_kraft.UseVisualStyleBackColor = true;
            this.sf_kraft.CheckedChanged += new System.EventHandler(this.sf_kraft_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.destruct_change);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.magiekunde_change);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.analys_change);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.odem_change);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.arcanovi_semi_change);
            this.groupBox4.Controls.Add(this.arcanovi_matrix_change);
            this.groupBox4.Controls.Add(this.arcanovi_change);
            this.groupBox4.Controls.Add(this.arcanovi_semi_change_lbl);
            this.groupBox4.Controls.Add(this.arcanovi_matrix_lbl);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(985, 41);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Talentwerte";
            // 
            // destruct_change
            // 
            this.destruct_change.Location = new System.Drawing.Point(868, 15);
            this.destruct_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.destruct_change.Name = "destruct_change";
            this.destruct_change.Size = new System.Drawing.Size(36, 20);
            this.destruct_change.TabIndex = 16;
            this.destruct_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.destruct_change.ValueChanged += new System.EventHandler(this.destruct_change_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(784, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 14);
            this.label14.TabIndex = 15;
            this.label14.Text = "DESTRUCTIBO";
            // 
            // magiekunde_change
            // 
            this.magiekunde_change.Location = new System.Drawing.Point(742, 15);
            this.magiekunde_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.magiekunde_change.Name = "magiekunde_change";
            this.magiekunde_change.Size = new System.Drawing.Size(36, 20);
            this.magiekunde_change.TabIndex = 14;
            this.magiekunde_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.magiekunde_change.ValueChanged += new System.EventHandler(this.magiekunde_change_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(670, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 14);
            this.label13.TabIndex = 13;
            this.label13.Text = "Magiekunde";
            // 
            // analys_change
            // 
            this.analys_change.Location = new System.Drawing.Point(629, 15);
            this.analys_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.analys_change.Name = "analys_change";
            this.analys_change.Size = new System.Drawing.Size(36, 20);
            this.analys_change.TabIndex = 12;
            this.analys_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.analys_change.ValueChanged += new System.EventHandler(this.analys_change_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(574, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "ANALYS";
            // 
            // odem_change
            // 
            this.odem_change.Location = new System.Drawing.Point(532, 15);
            this.odem_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.odem_change.Name = "odem_change";
            this.odem_change.Size = new System.Drawing.Size(36, 20);
            this.odem_change.TabIndex = 10;
            this.odem_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.odem_change.ValueChanged += new System.EventHandler(this.odem_change_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "ODEM";
            // 
            // arcanovi_semi_change
            // 
            this.arcanovi_semi_change.Enabled = false;
            this.arcanovi_semi_change.Location = new System.Drawing.Point(445, 15);
            this.arcanovi_semi_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.arcanovi_semi_change.Name = "arcanovi_semi_change";
            this.arcanovi_semi_change.Size = new System.Drawing.Size(36, 20);
            this.arcanovi_semi_change.TabIndex = 8;
            this.arcanovi_semi_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.arcanovi_semi_change.ValueChanged += new System.EventHandler(this.arcanovi_semi_change_ValueChanged);
            // 
            // arcanovi_matrix_change
            // 
            this.arcanovi_matrix_change.Enabled = false;
            this.arcanovi_matrix_change.Location = new System.Drawing.Point(251, 15);
            this.arcanovi_matrix_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.arcanovi_matrix_change.Name = "arcanovi_matrix_change";
            this.arcanovi_matrix_change.Size = new System.Drawing.Size(36, 20);
            this.arcanovi_matrix_change.TabIndex = 7;
            this.arcanovi_matrix_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.arcanovi_matrix_change.ValueChanged += new System.EventHandler(this.arcanovi_matrix_change_ValueChanged);
            // 
            // arcanovi_change
            // 
            this.arcanovi_change.Location = new System.Drawing.Point(77, 15);
            this.arcanovi_change.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.arcanovi_change.Name = "arcanovi_change";
            this.arcanovi_change.Size = new System.Drawing.Size(36, 20);
            this.arcanovi_change.TabIndex = 6;
            this.arcanovi_change.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.arcanovi_change.ValueChanged += new System.EventHandler(this.arcanovi_change_ValueChanged);
            // 
            // arcanovi_semi_change_lbl
            // 
            this.arcanovi_semi_change_lbl.AutoSize = true;
            this.arcanovi_semi_change_lbl.Enabled = false;
            this.arcanovi_semi_change_lbl.Location = new System.Drawing.Point(293, 19);
            this.arcanovi_semi_change_lbl.Name = "arcanovi_semi_change_lbl";
            this.arcanovi_semi_change_lbl.Size = new System.Drawing.Size(148, 14);
            this.arcanovi_semi_change_lbl.TabIndex = 5;
            this.arcanovi_semi_change_lbl.Text = "ARCANOVI (Semipermanenz)";
            // 
            // arcanovi_matrix_lbl
            // 
            this.arcanovi_matrix_lbl.AutoSize = true;
            this.arcanovi_matrix_lbl.Enabled = false;
            this.arcanovi_matrix_lbl.Location = new System.Drawing.Point(119, 17);
            this.arcanovi_matrix_lbl.Name = "arcanovi_matrix_lbl";
            this.arcanovi_matrix_lbl.Size = new System.Drawing.Size(131, 14);
            this.arcanovi_matrix_lbl.TabIndex = 3;
            this.arcanovi_matrix_lbl.Text = "ARCANOVI (Matrixgeber)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "ARCANOVI";
            // 
            // wirkendeZauber
            // 
            this.wirkendeZauber.Controls.Add(this.zauberGrid);
            this.wirkendeZauber.Controls.Add(this.zauber_add);
            this.wirkendeZauber.Controls.Add(this.zauber_listbox);
            this.wirkendeZauber.Controls.Add(this.komp_combo);
            this.wirkendeZauber.Controls.Add(this.zauber_rep);
            this.wirkendeZauber.Controls.Add(this.zauber_del);
            this.wirkendeZauber.Controls.Add(this.label11);
            this.wirkendeZauber.Controls.Add(this.label10);
            this.wirkendeZauber.Controls.Add(this.loads_lbl);
            this.wirkendeZauber.Controls.Add(this.zauber_list);
            this.wirkendeZauber.Controls.Add(this.asp);
            this.wirkendeZauber.Controls.Add(this.stapelung);
            this.wirkendeZauber.Controls.Add(this.loads);
            this.wirkendeZauber.Controls.Add(this.zauber);
            this.wirkendeZauber.Controls.Add(this.label18);
            this.wirkendeZauber.Controls.Add(this.label9);
            this.wirkendeZauber.Controls.Add(this.lbl_staple);
            this.wirkendeZauber.Controls.Add(this.label3);
            this.wirkendeZauber.Controls.Add(this.label2);
            this.wirkendeZauber.Location = new System.Drawing.Point(7, 368);
            this.wirkendeZauber.Name = "wirkendeZauber";
            this.wirkendeZauber.Size = new System.Drawing.Size(438, 227);
            this.wirkendeZauber.TabIndex = 16;
            this.wirkendeZauber.TabStop = false;
            this.wirkendeZauber.Text = "Wirkende Zauber";
            // 
            // zauber_add
            // 
            this.zauber_add.Location = new System.Drawing.Point(352, 35);
            this.zauber_add.Name = "zauber_add";
            this.zauber_add.Size = new System.Drawing.Size(75, 25);
            this.zauber_add.TabIndex = 13;
            this.zauber_add.Text = "Hinzuf.";
            this.zauber_add.UseVisualStyleBackColor = true;
            this.zauber_add.Click += new System.EventHandler(this.zauber_add_Click);
            // 
            // zauber_listbox
            // 
            this.zauber_listbox.FormattingEnabled = true;
            this.zauber_listbox.ItemHeight = 14;
            this.zauber_listbox.Location = new System.Drawing.Point(6, 88);
            this.zauber_listbox.Name = "zauber_listbox";
            this.zauber_listbox.Size = new System.Drawing.Size(327, 130);
            this.zauber_listbox.TabIndex = 25;
            // 
            // komp_combo
            // 
            this.komp_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.komp_combo.FormattingEnabled = true;
            this.komp_combo.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.komp_combo.Location = new System.Drawing.Point(116, 38);
            this.komp_combo.Name = "komp_combo";
            this.komp_combo.Size = new System.Drawing.Size(34, 22);
            this.komp_combo.TabIndex = 24;
            // 
            // zauber_rep
            // 
            this.zauber_rep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.zauber_rep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.zauber_rep.FormattingEnabled = true;
            this.zauber_rep.Items.AddRange(new object[] {
            "eigene",
            "fremde"});
            this.zauber_rep.Location = new System.Drawing.Point(241, 37);
            this.zauber_rep.Name = "zauber_rep";
            this.zauber_rep.Size = new System.Drawing.Size(62, 22);
            this.zauber_rep.TabIndex = 22;
            // 
            // zauber_del
            // 
            this.zauber_del.Location = new System.Drawing.Point(352, 66);
            this.zauber_del.Name = "zauber_del";
            this.zauber_del.Size = new System.Drawing.Size(75, 25);
            this.zauber_del.TabIndex = 21;
            this.zauber_del.Text = "Entf.";
            this.zauber_del.UseVisualStyleBackColor = true;
            this.zauber_del.Click += new System.EventHandler(this.zauber_del_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(337, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "→";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "→";
            // 
            // loads_lbl
            // 
            this.loads_lbl.AutoSize = true;
            this.loads_lbl.Location = new System.Drawing.Point(352, 104);
            this.loads_lbl.Name = "loads_lbl";
            this.loads_lbl.Size = new System.Drawing.Size(51, 14);
            this.loads_lbl.TabIndex = 16;
            this.loads_lbl.Text = "Ladungen";
            // 
            // zauber_list
            // 
            this.zauber_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.complexity,
            this.count_staples,
            this.count_asp,
            this.rep});
            this.zauber_list.FullRowSelect = true;
            this.zauber_list.Location = new System.Drawing.Point(6, 66);
            this.zauber_list.Name = "zauber_list";
            this.zauber_list.Size = new System.Drawing.Size(327, 152);
            this.zauber_list.TabIndex = 12;
            this.zauber_list.TileSize = new System.Drawing.Size(100, 100);
            this.zauber_list.UseCompatibleStateImageBehavior = false;
            this.zauber_list.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Zauber";
            this.name.Width = 89;
            // 
            // complexity
            // 
            this.complexity.Text = "Komp.";
            this.complexity.Width = 54;
            // 
            // count_staples
            // 
            this.count_staples.Text = "Stapel";
            this.count_staples.Width = 55;
            // 
            // count_asp
            // 
            this.count_asp.Text = "AsP";
            this.count_asp.Width = 53;
            // 
            // rep
            // 
            this.rep.Text = "Rep.";
            this.rep.Width = 51;
            // 
            // asp
            // 
            this.asp.Location = new System.Drawing.Point(198, 38);
            this.asp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.asp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.asp.Name = "asp";
            this.asp.Size = new System.Drawing.Size(38, 20);
            this.asp.TabIndex = 11;
            this.asp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stapelung
            // 
            this.stapelung.Location = new System.Drawing.Point(156, 38);
            this.stapelung.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.stapelung.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stapelung.Name = "stapelung";
            this.stapelung.Size = new System.Drawing.Size(36, 20);
            this.stapelung.TabIndex = 10;
            this.stapelung.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // loads
            // 
            this.loads.Location = new System.Drawing.Point(362, 122);
            this.loads.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.loads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loads.Name = "loads";
            this.loads.Size = new System.Drawing.Size(36, 20);
            this.loads.TabIndex = 9;
            this.loads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loads.ValueChanged += new System.EventHandler(this.loads_ValueChanged);
            // 
            // zauber
            // 
            this.zauber.Location = new System.Drawing.Point(6, 38);
            this.zauber.Name = "zauber";
            this.zauber.Size = new System.Drawing.Size(104, 20);
            this.zauber.TabIndex = 1;
            this.zauber.Text = "Manifesto";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(242, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "Rep.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "AsP";
            // 
            // lbl_staple
            // 
            this.lbl_staple.AutoSize = true;
            this.lbl_staple.Enabled = false;
            this.lbl_staple.Location = new System.Drawing.Point(153, 23);
            this.lbl_staple.Name = "lbl_staple";
            this.lbl_staple.Size = new System.Drawing.Size(35, 14);
            this.lbl_staple.TabIndex = 17;
            this.lbl_staple.Text = "Stapel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Komp.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Zauber";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(451, 368);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 227);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txt_create);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Erschaffung";
            // 
            // txt_create
            // 
            this.txt_create.AcceptsReturn = true;
            this.txt_create.AcceptsTab = true;
            this.txt_create.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_create.Location = new System.Drawing.Point(4, 4);
            this.txt_create.Multiline = true;
            this.txt_create.Name = "txt_create";
            this.txt_create.ReadOnly = true;
            this.txt_create.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_create.Size = new System.Drawing.Size(525, 193);
            this.txt_create.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.txt_analys);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analyse";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.analys_cloack);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Controls.Add(this.analys_broken);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.analys_komplex);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Controls.Add(this.analys_mr);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Location = new System.Drawing.Point(7, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(154, 192);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "ANALYS-Modifikationen";
            // 
            // analys_cloack
            // 
            this.analys_cloack.Location = new System.Drawing.Point(97, 106);
            this.analys_cloack.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.analys_cloack.Name = "analys_cloack";
            this.analys_cloack.Size = new System.Drawing.Size(36, 20);
            this.analys_cloack.TabIndex = 24;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 14);
            this.label23.TabIndex = 19;
            this.label23.Text = "Artefakt misslungen";
            // 
            // analys_broken
            // 
            this.analys_broken.AutoSize = true;
            this.analys_broken.Location = new System.Drawing.Point(115, 20);
            this.analys_broken.Name = "analys_broken";
            this.analys_broken.Size = new System.Drawing.Size(15, 14);
            this.analys_broken.TabIndex = 20;
            this.analys_broken.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 14);
            this.label22.TabIndex = 21;
            this.label22.Text = "MR Artefaktseele";
            // 
            // analys_komplex
            // 
            this.analys_komplex.Location = new System.Drawing.Point(97, 42);
            this.analys_komplex.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.analys_komplex.Name = "analys_komplex";
            this.analys_komplex.Size = new System.Drawing.Size(36, 20);
            this.analys_komplex.TabIndex = 18;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 108);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 14);
            this.label25.TabIndex = 23;
            this.label25.Text = "ZfP* Tarnzauber";
            // 
            // analys_mr
            // 
            this.analys_mr.Location = new System.Drawing.Point(97, 74);
            this.analys_mr.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.analys_mr.Name = "analys_mr";
            this.analys_mr.Size = new System.Drawing.Size(36, 20);
            this.analys_mr.TabIndex = 22;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 14);
            this.label24.TabIndex = 17;
            this.label24.Text = "bes. Komplexität";
            // 
            // txt_analys
            // 
            this.txt_analys.AcceptsReturn = true;
            this.txt_analys.AcceptsTab = true;
            this.txt_analys.Location = new System.Drawing.Point(167, 11);
            this.txt_analys.Multiline = true;
            this.txt_analys.Name = "txt_analys";
            this.txt_analys.ReadOnly = true;
            this.txt_analys.Size = new System.Drawing.Size(326, 170);
            this.txt_analys.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.txt_destruct);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(532, 201);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Zerstörung";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.destruct_aktive);
            this.groupBox10.Controls.Add(this.lbl_infi);
            this.groupBox10.Controls.Add(this.destruct_infinitum);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.destruct_komplex);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.destruct_mr);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Location = new System.Drawing.Point(7, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(182, 191);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "DESTURCTIBO-Modifikationen";
            // 
            // destruct_aktive
            // 
            this.destruct_aktive.Location = new System.Drawing.Point(126, 106);
            this.destruct_aktive.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.destruct_aktive.Name = "destruct_aktive";
            this.destruct_aktive.Size = new System.Drawing.Size(36, 20);
            this.destruct_aktive.TabIndex = 24;
            // 
            // lbl_infi
            // 
            this.lbl_infi.AutoSize = true;
            this.lbl_infi.Location = new System.Drawing.Point(6, 23);
            this.lbl_infi.Name = "lbl_infi";
            this.lbl_infi.Size = new System.Drawing.Size(51, 14);
            this.lbl_infi.TabIndex = 19;
            this.lbl_infi.Text = "Infinitum";
            // 
            // destruct_infinitum
            // 
            this.destruct_infinitum.AutoSize = true;
            this.destruct_infinitum.Location = new System.Drawing.Point(133, 20);
            this.destruct_infinitum.Name = "destruct_infinitum";
            this.destruct_infinitum.Size = new System.Drawing.Size(15, 14);
            this.destruct_infinitum.TabIndex = 20;
            this.destruct_infinitum.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 14);
            this.label27.TabIndex = 21;
            this.label27.Text = "MR Artefaktseele";
            // 
            // destruct_komplex
            // 
            this.destruct_komplex.Location = new System.Drawing.Point(126, 42);
            this.destruct_komplex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.destruct_komplex.Name = "destruct_komplex";
            this.destruct_komplex.Size = new System.Drawing.Size(36, 20);
            this.destruct_komplex.TabIndex = 18;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 108);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 14);
            this.label28.TabIndex = 23;
            this.label28.Text = "# aktive Ladungen";
            // 
            // destruct_mr
            // 
            this.destruct_mr.Location = new System.Drawing.Point(126, 74);
            this.destruct_mr.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.destruct_mr.Name = "destruct_mr";
            this.destruct_mr.Size = new System.Drawing.Size(36, 20);
            this.destruct_mr.TabIndex = 22;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 50);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(86, 14);
            this.label29.TabIndex = 17;
            this.label29.Text = "bes. Komplexität";
            // 
            // txt_destruct
            // 
            this.txt_destruct.AcceptsReturn = true;
            this.txt_destruct.AcceptsTab = true;
            this.txt_destruct.Location = new System.Drawing.Point(195, 12);
            this.txt_destruct.Multiline = true;
            this.txt_destruct.Name = "txt_destruct";
            this.txt_destruct.ReadOnly = true;
            this.txt_destruct.Size = new System.Drawing.Size(301, 169);
            this.txt_destruct.TabIndex = 2;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmToolStripMenuItem1,
            this.programmToolStripMenuItem,
            this.optionenToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.updatesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1004, 24);
            this.menu.TabIndex = 23;
            this.menu.Text = "menuStrip1";
            // 
            // programmToolStripMenuItem1
            // 
            this.programmToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importHeldensoftwareToolStripMenuItem,
            this.updateSuchenToolStripMenuItem,
            this.updateInstallierenToolStripMenuItem,
            this.beendenToolStripMenuItem1});
            this.programmToolStripMenuItem1.Name = "programmToolStripMenuItem1";
            this.programmToolStripMenuItem1.Size = new System.Drawing.Size(76, 20);
            this.programmToolStripMenuItem1.Text = "Programm";
            // 
            // importHeldensoftwareToolStripMenuItem
            // 
            this.importHeldensoftwareToolStripMenuItem.Name = "importHeldensoftwareToolStripMenuItem";
            this.importHeldensoftwareToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importHeldensoftwareToolStripMenuItem.Text = "Import Heldensoftware";
            this.importHeldensoftwareToolStripMenuItem.Click += new System.EventHandler(this.importHeldensoftwareToolStripMenuItem_Click_1);
            // 
            // updateSuchenToolStripMenuItem
            // 
            this.updateSuchenToolStripMenuItem.Name = "updateSuchenToolStripMenuItem";
            this.updateSuchenToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.updateSuchenToolStripMenuItem.Text = "Update suchen";
            this.updateSuchenToolStripMenuItem.Click += new System.EventHandler(this.updateSuchenToolStripMenuItem_Click);
            // 
            // updateInstallierenToolStripMenuItem
            // 
            this.updateInstallierenToolStripMenuItem.Enabled = false;
            this.updateInstallierenToolStripMenuItem.Name = "updateInstallierenToolStripMenuItem";
            this.updateInstallierenToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.updateInstallierenToolStripMenuItem.Text = "Update installieren";
            this.updateInstallierenToolStripMenuItem.Click += new System.EventHandler(this.updateInstallierenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem1
            // 
            this.beendenToolStripMenuItem1.Name = "beendenToolStripMenuItem1";
            this.beendenToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.beendenToolStripMenuItem1.Text = "Beenden";
            this.beendenToolStripMenuItem1.Click += new System.EventHandler(this.beendenToolStripMenuItem1_Click);
            // 
            // programmToolStripMenuItem
            // 
            this.programmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuesArtefaktToolStripMenuItem,
            this.artefaktLadenToolStripMenuItem,
            this.artefaktSpeichernToolStripMenuItem,
            this.exportierenToolStripMenuItem});
            this.programmToolStripMenuItem.Name = "programmToolStripMenuItem";
            this.programmToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.programmToolStripMenuItem.Text = "Artefakt";
            // 
            // neuesArtefaktToolStripMenuItem
            // 
            this.neuesArtefaktToolStripMenuItem.Name = "neuesArtefaktToolStripMenuItem";
            this.neuesArtefaktToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.neuesArtefaktToolStripMenuItem.Text = "Neu";
            this.neuesArtefaktToolStripMenuItem.Click += new System.EventHandler(this.neuesArtefaktToolStripMenuItem_Click);
            // 
            // artefaktLadenToolStripMenuItem
            // 
            this.artefaktLadenToolStripMenuItem.Name = "artefaktLadenToolStripMenuItem";
            this.artefaktLadenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.artefaktLadenToolStripMenuItem.Text = "Laden";
            this.artefaktLadenToolStripMenuItem.Click += new System.EventHandler(this.artefaktLadenToolStripMenuItem_Click);
            // 
            // artefaktSpeichernToolStripMenuItem
            // 
            this.artefaktSpeichernToolStripMenuItem.Name = "artefaktSpeichernToolStripMenuItem";
            this.artefaktSpeichernToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.artefaktSpeichernToolStripMenuItem.Text = "Speichern";
            this.artefaktSpeichernToolStripMenuItem.Click += new System.EventHandler(this.artefaktSpeichernToolStripMenuItem_Click);
            // 
            // exportierenToolStripMenuItem
            // 
            this.exportierenToolStripMenuItem.Name = "exportierenToolStripMenuItem";
            this.exportierenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exportierenToolStripMenuItem.Text = "Exportieren als PDF";
            this.exportierenToolStripMenuItem.Click += new System.EventHandler(this.exportierenToolStripMenuItem_Click);
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automatischNeuberechenenToolStripMenuItem,
            this.ach_save,
            this.regelbasis,
            this.würfelergebnisseToolStripMenuItem,
            this.nebenwirkungenMenuItem1,
            this.toolStripSeparator1,
            this.heldenimportToolStripMenuItem,
            this.showPDFToolStripMenuItem});
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.optionenToolStripMenuItem.Text = "Optionen";
            // 
            // automatischNeuberechenenToolStripMenuItem
            // 
            this.automatischNeuberechenenToolStripMenuItem.Checked = true;
            this.automatischNeuberechenenToolStripMenuItem.CheckOnClick = true;
            this.automatischNeuberechenenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automatischNeuberechenenToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.automatischNeuberechenenToolStripMenuItem.Name = "automatischNeuberechenenToolStripMenuItem";
            this.automatischNeuberechenenToolStripMenuItem.Size = new System.Drawing.Size(414, 22);
            this.automatischNeuberechenenToolStripMenuItem.Text = "Automatisch neu berechenen";
            this.automatischNeuberechenenToolStripMenuItem.Visible = false;
            // 
            // ach_save
            // 
            this.ach_save.Checked = true;
            this.ach_save.CheckOnClick = true;
            this.ach_save.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ach_save.Name = "ach_save";
            this.ach_save.Size = new System.Drawing.Size(414, 22);
            this.ach_save.Text = "Kostenersparnis für wirkende Zauber bei Rep. ACH einberechnen";
            this.ach_save.Click += new System.EventHandler(this.ach_save_Click);
            // 
            // regelbasis
            // 
            this.regelbasis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wegeDerAlchimieToolStripMenuItem,
            this.staebeRingeDschinnenlampenToolStripMenuItem});
            this.regelbasis.Name = "regelbasis";
            this.regelbasis.Size = new System.Drawing.Size(414, 22);
            this.regelbasis.Text = "Regelbasis";
            // 
            // wegeDerAlchimieToolStripMenuItem
            // 
            this.wegeDerAlchimieToolStripMenuItem.Checked = true;
            this.wegeDerAlchimieToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wegeDerAlchimieToolStripMenuItem.Name = "wegeDerAlchimieToolStripMenuItem";
            this.wegeDerAlchimieToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.wegeDerAlchimieToolStripMenuItem.Text = "Wege der Alchimie (4.1)";
            this.wegeDerAlchimieToolStripMenuItem.Click += new System.EventHandler(this.wegeDerAlchimieToolStripMenuItem_Click);
            // 
            // staebeRingeDschinnenlampenToolStripMenuItem
            // 
            this.staebeRingeDschinnenlampenToolStripMenuItem.Name = "staebeRingeDschinnenlampenToolStripMenuItem";
            this.staebeRingeDschinnenlampenToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.staebeRingeDschinnenlampenToolStripMenuItem.Text = "Stäbe, Ringe, Dschinnenlampen (4.0)";
            this.staebeRingeDschinnenlampenToolStripMenuItem.Click += new System.EventHandler(this.staebeRingeDschinnenlampenToolStripMenuItem_Click);
            // 
            // würfelergebnisseToolStripMenuItem
            // 
            this.würfelergebnisseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleBerechnenToolStripMenuItem,
            this.w6AnnehmenToolStripMenuItem,
            this.w20ToolStripMenuItem});
            this.würfelergebnisseToolStripMenuItem.Name = "würfelergebnisseToolStripMenuItem";
            this.würfelergebnisseToolStripMenuItem.Size = new System.Drawing.Size(414, 22);
            this.würfelergebnisseToolStripMenuItem.Text = "Würfelergebnisse";
            // 
            // alleBerechnenToolStripMenuItem
            // 
            this.alleBerechnenToolStripMenuItem.CheckOnClick = true;
            this.alleBerechnenToolStripMenuItem.Name = "alleBerechnenToolStripMenuItem";
            this.alleBerechnenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.alleBerechnenToolStripMenuItem.Text = "alle zufällig";
            this.alleBerechnenToolStripMenuItem.Click += new System.EventHandler(this.alleBerechnenToolStripMenuItem_Click);
            // 
            // w6AnnehmenToolStripMenuItem
            // 
            this.w6AnnehmenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.w6_1,
            this.w6_35,
            this.w6_4,
            this.w6_6});
            this.w6AnnehmenToolStripMenuItem.Name = "w6AnnehmenToolStripMenuItem";
            this.w6AnnehmenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.w6AnnehmenToolStripMenuItem.Text = "W6";
            // 
            // w6_1
            // 
            this.w6_1.CheckOnClick = true;
            this.w6_1.Name = "w6_1";
            this.w6_1.Size = new System.Drawing.Size(206, 22);
            this.w6_1.Text = "als Optimum annehmen";
            this.w6_1.Click += new System.EventHandler(this.w6_1_Click);
            // 
            // w6_35
            // 
            this.w6_35.Checked = true;
            this.w6_35.CheckOnClick = true;
            this.w6_35.CheckState = System.Windows.Forms.CheckState.Checked;
            this.w6_35.Name = "w6_35";
            this.w6_35.Size = new System.Drawing.Size(206, 22);
            this.w6_35.Text = "als 3,5 annehmen";
            this.w6_35.Click += new System.EventHandler(this.w6_35_Click);
            // 
            // w6_4
            // 
            this.w6_4.CheckOnClick = true;
            this.w6_4.Name = "w6_4";
            this.w6_4.Size = new System.Drawing.Size(206, 22);
            this.w6_4.Text = "als 4 annehmen";
            this.w6_4.Click += new System.EventHandler(this.w6_4_Click);
            // 
            // w6_6
            // 
            this.w6_6.CheckOnClick = true;
            this.w6_6.Name = "w6_6";
            this.w6_6.Size = new System.Drawing.Size(206, 22);
            this.w6_6.Text = "als Pessimum annehmen";
            this.w6_6.Click += new System.EventHandler(this.w6_6_Click);
            // 
            // w20ToolStripMenuItem
            // 
            this.w20ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.w20_1,
            this.w20_10,
            this.w20_105,
            this.w20_11,
            this.w20_20});
            this.w20ToolStripMenuItem.Name = "w20ToolStripMenuItem";
            this.w20ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.w20ToolStripMenuItem.Text = "W20";
            // 
            // w20_1
            // 
            this.w20_1.CheckOnClick = true;
            this.w20_1.Name = "w20_1";
            this.w20_1.Size = new System.Drawing.Size(206, 22);
            this.w20_1.Text = "als Optimum annehmen";
            this.w20_1.Click += new System.EventHandler(this.w20_1_Click);
            // 
            // w20_10
            // 
            this.w20_10.CheckOnClick = true;
            this.w20_10.Name = "w20_10";
            this.w20_10.Size = new System.Drawing.Size(206, 22);
            this.w20_10.Text = "als 10 annehmen";
            this.w20_10.Click += new System.EventHandler(this.w20_10_Click);
            // 
            // w20_105
            // 
            this.w20_105.Name = "w20_105";
            this.w20_105.Size = new System.Drawing.Size(206, 22);
            this.w20_105.Text = "als 10,5 annehmen";
            this.w20_105.Click += new System.EventHandler(this.w20_105_Click);
            // 
            // w20_11
            // 
            this.w20_11.Checked = true;
            this.w20_11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.w20_11.Name = "w20_11";
            this.w20_11.Size = new System.Drawing.Size(206, 22);
            this.w20_11.Text = "als 11 annehmen";
            this.w20_11.Click += new System.EventHandler(this.w20_11_Click);
            // 
            // w20_20
            // 
            this.w20_20.CheckOnClick = true;
            this.w20_20.Name = "w20_20";
            this.w20_20.Size = new System.Drawing.Size(206, 22);
            this.w20_20.Text = "als Pessimum annehmen";
            this.w20_20.Click += new System.EventHandler(this.w20_20_Click);
            // 
            // nebenwirkungenMenuItem1
            // 
            this.nebenwirkungenMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nebenReRollToolStripMenuItem,
            this.nebenIgnoreToolStripMenuItem});
            this.nebenwirkungenMenuItem1.Name = "nebenwirkungenMenuItem1";
            this.nebenwirkungenMenuItem1.Size = new System.Drawing.Size(414, 22);
            this.nebenwirkungenMenuItem1.Text = "Nebeneffekte";
            // 
            // nebenReRollToolStripMenuItem
            // 
            this.nebenReRollToolStripMenuItem.Checked = true;
            this.nebenReRollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nebenReRollToolStripMenuItem.Name = "nebenReRollToolStripMenuItem";
            this.nebenReRollToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.nebenReRollToolStripMenuItem.Text = "Doppelte neu auswürfeln";
            this.nebenReRollToolStripMenuItem.Click += new System.EventHandler(this.nebenReRollToolStripMenuItem_Click);
            // 
            // nebenIgnoreToolStripMenuItem
            // 
            this.nebenIgnoreToolStripMenuItem.Name = "nebenIgnoreToolStripMenuItem";
            this.nebenIgnoreToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.nebenIgnoreToolStripMenuItem.Text = "Doppelte ignorieren";
            this.nebenIgnoreToolStripMenuItem.Click += new System.EventHandler(this.nebenIgnoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(411, 6);
            // 
            // heldenimportToolStripMenuItem
            // 
            this.heldenimportToolStripMenuItem.CheckOnClick = true;
            this.heldenimportToolStripMenuItem.Name = "heldenimportToolStripMenuItem";
            this.heldenimportToolStripMenuItem.Size = new System.Drawing.Size(414, 22);
            this.heldenimportToolStripMenuItem.Text = "Helden Software Import beim Start anzeigen";
            // 
            // showPDFToolStripMenuItem
            // 
            this.showPDFToolStripMenuItem.Checked = true;
            this.showPDFToolStripMenuItem.CheckOnClick = true;
            this.showPDFToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPDFToolStripMenuItem.Name = "showPDFToolStripMenuItem";
            this.showPDFToolStripMenuItem.Size = new System.Drawing.Size(414, 22);
            this.showPDFToolStripMenuItem.Text = "PDF nach dem exportieren anzeigen";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.aboutToolStripMenuItem.Text = "Über";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Visible = false;
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.updatesToolStripMenuItem.Enabled = false;
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.updatesToolStripMenuItem.Text = "suche nach updates...";
            this.updatesToolStripMenuItem.Click += new System.EventHandler(this.updatesToolStripMenuItem_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfo.Location = new System.Drawing.Point(396, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(250, 14);
            this.lblInfo.TabIndex = 24;
            this.lblInfo.Text = "ArtefaktGenerator 2.6 BETA_3 by DSA-Hamburg.de";
            // 
            // hero_name
            // 
            this.hero_name.AutoSize = true;
            this.hero_name.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hero_name.Location = new System.Drawing.Point(154, 43);
            this.hero_name.Name = "hero_name";
            this.hero_name.Size = new System.Drawing.Size(36, 14);
            this.hero_name.TabIndex = 25;
            this.hero_name.Text = "Held: ";
            // 
            // zauberGrid
            // 
            this.zauberGrid.AllowUserToAddRows = false;
            this.zauberGrid.AllowUserToOrderColumns = true;
            this.zauberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zauberGrid.Location = new System.Drawing.Point(5, 66);
            this.zauberGrid.MultiSelect = false;
            this.zauberGrid.Name = "zauberGrid";
            this.zauberGrid.Size = new System.Drawing.Size(328, 152);
            this.zauberGrid.TabIndex = 27;
            // 
            // dasArtefaktBindingSource
            // 
            this.dasArtefaktBindingSource.DataSource = typeof(ArtefaktGenerator.DasArtefakt);
            // 
            // dasArtefaktBindingSource1
            // 
            this.dasArtefaktBindingSource1.DataSource = typeof(ArtefaktGenerator.DasArtefakt);
            // 
            // artefakttyp
            // 
            this.artefakttyp.Controls.Add(this.artefakttyp_aux);
            this.artefakttyp.Controls.Add(this.type_speicher_value);
            this.artefakttyp.Controls.Add(this.lbl_type_speicher_val);
            this.artefakttyp.Controls.Add(this.type_speicher);
            this.artefakttyp.Controls.Add(this.artefakttyp_temp);
            this.artefakttyp.Controls.Add(this.type_temp);
            this.artefakttyp.Controls.Add(this.type_einaml);
            this.artefakttyp.Controls.Add(this.type_aux);
            this.artefakttyp.Controls.Add(this.type_charge);
            this.artefakttyp.Controls.Add(this.type_matrix);
            this.artefakttyp.Controls.Add(this.type_semi);
            this.artefakttyp.Controls.Add(this.artefakttyp_matrix);
            this.artefakttyp.Controls.Add(this.artefakttyp_semi);
            this.artefakttyp.Location = new System.Drawing.Point(7, 157);
            this.artefakttyp.Name = "artefakttyp";
            this.artefakttyp.Selected = 4;
            this.artefakttyp.Size = new System.Drawing.Size(623, 93);
            this.artefakttyp.TabIndex = 26;
            this.artefakttyp.TabStop = false;
            this.artefakttyp.Text = "Artefakttyp";
            // 
            // artefakttyp_aux
            // 
            this.artefakttyp_aux.Controls.Add(this.aux_labil);
            this.artefakttyp_aux.Controls.Add(this.aux_merkmal);
            this.artefakttyp_aux.Controls.Add(this.aux_stable);
            this.artefakttyp_aux.Controls.Add(this.aux_verystable);
            this.artefakttyp_aux.Controls.Add(this.aux_unempfindlich);
            this.artefakttyp_aux.Location = new System.Drawing.Point(250, 46);
            this.artefakttyp_aux.Name = "artefakttyp_aux";
            this.artefakttyp_aux.Selected = 3;
            this.artefakttyp_aux.Size = new System.Drawing.Size(367, 42);
            this.artefakttyp_aux.TabIndex = 27;
            this.artefakttyp_aux.TabStop = false;
            this.artefakttyp_aux.Text = "Stabilität";
            // 
            // aux_labil
            // 
            this.aux_labil.AutoSize = true;
            this.aux_labil.Location = new System.Drawing.Point(11, 15);
            this.aux_labil.Name = "aux_labil";
            this.aux_labil.Size = new System.Drawing.Size(44, 18);
            this.aux_labil.TabIndex = 0;
            this.aux_labil.Tag = "0";
            this.aux_labil.Text = "labil";
            this.aux_labil.UseVisualStyleBackColor = true;
            this.aux_labil.Click += new System.EventHandler(this.aux_labil_Click);
            // 
            // aux_merkmal
            // 
            this.aux_merkmal.AutoSize = true;
            this.aux_merkmal.Location = new System.Drawing.Point(293, 16);
            this.aux_merkmal.Name = "aux_merkmal";
            this.aux_merkmal.Size = new System.Drawing.Size(68, 18);
            this.aux_merkmal.TabIndex = 5;
            this.aux_merkmal.Text = "Merkmal";
            this.aux_merkmal.UseVisualStyleBackColor = true;
            // 
            // aux_stable
            // 
            this.aux_stable.AutoSize = true;
            this.aux_stable.Location = new System.Drawing.Point(61, 15);
            this.aux_stable.Name = "aux_stable";
            this.aux_stable.Size = new System.Drawing.Size(49, 18);
            this.aux_stable.TabIndex = 1;
            this.aux_stable.Tag = "1";
            this.aux_stable.Text = "stabil";
            this.aux_stable.UseVisualStyleBackColor = true;
            this.aux_stable.Click += new System.EventHandler(this.aux_stable_Click);
            // 
            // aux_verystable
            // 
            this.aux_verystable.AutoSize = true;
            this.aux_verystable.Location = new System.Drawing.Point(117, 15);
            this.aux_verystable.Name = "aux_verystable";
            this.aux_verystable.Size = new System.Drawing.Size(71, 18);
            this.aux_verystable.TabIndex = 2;
            this.aux_verystable.Tag = "2";
            this.aux_verystable.Text = "sehr stabil";
            this.aux_verystable.UseVisualStyleBackColor = true;
            this.aux_verystable.Click += new System.EventHandler(this.aux_verystable_Click);
            // 
            // aux_unempfindlich
            // 
            this.aux_unempfindlich.AutoSize = true;
            this.aux_unempfindlich.Checked = true;
            this.aux_unempfindlich.Location = new System.Drawing.Point(196, 15);
            this.aux_unempfindlich.Name = "aux_unempfindlich";
            this.aux_unempfindlich.Size = new System.Drawing.Size(91, 18);
            this.aux_unempfindlich.TabIndex = 3;
            this.aux_unempfindlich.TabStop = true;
            this.aux_unempfindlich.Tag = "3";
            this.aux_unempfindlich.Text = "unempfindlich";
            this.aux_unempfindlich.UseVisualStyleBackColor = true;
            this.aux_unempfindlich.Click += new System.EventHandler(this.aux_unempfindlich_Click);
            // 
            // type_speicher_value
            // 
            this.type_speicher_value.Location = new System.Drawing.Point(454, 54);
            this.type_speicher_value.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.type_speicher_value.Name = "type_speicher_value";
            this.type_speicher_value.Size = new System.Drawing.Size(36, 20);
            this.type_speicher_value.TabIndex = 30;
            this.type_speicher_value.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.type_speicher_value.ValueChanged += new System.EventHandler(this.type_speicher_value_ValueChanged);
            // 
            // lbl_type_speicher_val
            // 
            this.lbl_type_speicher_val.AutoSize = true;
            this.lbl_type_speicher_val.Location = new System.Drawing.Point(422, 58);
            this.lbl_type_speicher_val.Name = "lbl_type_speicher_val";
            this.lbl_type_speicher_val.Size = new System.Drawing.Size(26, 14);
            this.lbl_type_speicher_val.TabIndex = 31;
            this.lbl_type_speicher_val.Text = "AsP";
            // 
            // type_speicher
            // 
            this.type_speicher.AutoSize = true;
            this.type_speicher.Location = new System.Drawing.Point(414, 19);
            this.type_speicher.Name = "type_speicher";
            this.type_speicher.Size = new System.Drawing.Size(86, 18);
            this.type_speicher.TabIndex = 29;
            this.type_speicher.TabStop = true;
            this.type_speicher.Tag = "6";
            this.type_speicher.Text = "kraftspeicher";
            this.type_speicher.UseVisualStyleBackColor = true;
            this.type_speicher.Click += new System.EventHandler(this.type_speicher_Click);
            // 
            // artefakttyp_temp
            // 
            this.artefakttyp_temp.Controls.Add(this.temp_monat);
            this.artefakttyp_temp.Controls.Add(this.temp_woche);
            this.artefakttyp_temp.Controls.Add(this.temp_tag);
            this.artefakttyp_temp.Location = new System.Drawing.Point(6, 45);
            this.artefakttyp_temp.Name = "artefakttyp_temp";
            this.artefakttyp_temp.Selected = 0;
            this.artefakttyp_temp.Size = new System.Drawing.Size(176, 43);
            this.artefakttyp_temp.TabIndex = 25;
            this.artefakttyp_temp.TabStop = false;
            this.artefakttyp_temp.Text = "Zeitraum";
            // 
            // temp_monat
            // 
            this.temp_monat.AutoSize = true;
            this.temp_monat.Location = new System.Drawing.Point(113, 16);
            this.temp_monat.Name = "temp_monat";
            this.temp_monat.Size = new System.Drawing.Size(56, 18);
            this.temp_monat.TabIndex = 2;
            this.temp_monat.Tag = "2";
            this.temp_monat.Text = "Monat";
            this.temp_monat.UseVisualStyleBackColor = true;
            this.temp_monat.Click += new System.EventHandler(this.temp_monat_Click);
            // 
            // temp_woche
            // 
            this.temp_woche.AutoSize = true;
            this.temp_woche.Location = new System.Drawing.Point(56, 16);
            this.temp_woche.Name = "temp_woche";
            this.temp_woche.Size = new System.Drawing.Size(57, 18);
            this.temp_woche.TabIndex = 1;
            this.temp_woche.Tag = "1";
            this.temp_woche.Text = "Woche";
            this.temp_woche.UseVisualStyleBackColor = true;
            this.temp_woche.Click += new System.EventHandler(this.temp_woche_Click);
            // 
            // temp_tag
            // 
            this.temp_tag.AutoSize = true;
            this.temp_tag.Checked = true;
            this.temp_tag.Location = new System.Drawing.Point(10, 16);
            this.temp_tag.Name = "temp_tag";
            this.temp_tag.Size = new System.Drawing.Size(42, 18);
            this.temp_tag.TabIndex = 0;
            this.temp_tag.TabStop = true;
            this.temp_tag.Tag = "0";
            this.temp_tag.Text = "Tag";
            this.temp_tag.UseVisualStyleBackColor = true;
            this.temp_tag.Click += new System.EventHandler(this.temp_tag_Click);
            // 
            // type_temp
            // 
            this.type_temp.AutoSize = true;
            this.type_temp.Location = new System.Drawing.Point(6, 19);
            this.type_temp.Name = "type_temp";
            this.type_temp.Size = new System.Drawing.Size(68, 18);
            this.type_temp.TabIndex = 0;
            this.type_temp.Tag = "0";
            this.type_temp.Text = "temporär";
            this.type_temp.UseVisualStyleBackColor = true;
            this.type_temp.Click += new System.EventHandler(this.type_temp_Click);
            // 
            // type_einaml
            // 
            this.type_einaml.AutoSize = true;
            this.type_einaml.Location = new System.Drawing.Point(80, 19);
            this.type_einaml.Name = "type_einaml";
            this.type_einaml.Size = new System.Drawing.Size(64, 18);
            this.type_einaml.TabIndex = 1;
            this.type_einaml.Tag = "1";
            this.type_einaml.Text = "einmalig";
            this.type_einaml.UseVisualStyleBackColor = true;
            this.type_einaml.Click += new System.EventHandler(this.type_einaml_Click);
            // 
            // type_aux
            // 
            this.type_aux.AutoSize = true;
            this.type_aux.Enabled = false;
            this.type_aux.Location = new System.Drawing.Point(508, 19);
            this.type_aux.Name = "type_aux";
            this.type_aux.Size = new System.Drawing.Size(69, 18);
            this.type_aux.TabIndex = 24;
            this.type_aux.Tag = "5";
            this.type_aux.Text = "auxiliator";
            this.type_aux.UseVisualStyleBackColor = true;
            this.type_aux.Click += new System.EventHandler(this.type_aux_Click);
            // 
            // type_charge
            // 
            this.type_charge.AutoSize = true;
            this.type_charge.Location = new System.Drawing.Point(150, 19);
            this.type_charge.Name = "type_charge";
            this.type_charge.Size = new System.Drawing.Size(66, 18);
            this.type_charge.TabIndex = 2;
            this.type_charge.Tag = "2";
            this.type_charge.Text = "aufladbar";
            this.type_charge.UseVisualStyleBackColor = true;
            this.type_charge.Click += new System.EventHandler(this.type_charge_Click);
            // 
            // type_matrix
            // 
            this.type_matrix.AutoSize = true;
            this.type_matrix.Enabled = false;
            this.type_matrix.Location = new System.Drawing.Point(226, 19);
            this.type_matrix.Name = "type_matrix";
            this.type_matrix.Size = new System.Drawing.Size(80, 18);
            this.type_matrix.TabIndex = 3;
            this.type_matrix.Tag = "3";
            this.type_matrix.Text = "matrixgeber";
            this.type_matrix.UseVisualStyleBackColor = true;
            this.type_matrix.Click += new System.EventHandler(this.type_matrix_Click);
            // 
            // type_semi
            // 
            this.type_semi.AutoSize = true;
            this.type_semi.Checked = true;
            this.type_semi.Enabled = false;
            this.type_semi.Location = new System.Drawing.Point(312, 19);
            this.type_semi.Name = "type_semi";
            this.type_semi.Size = new System.Drawing.Size(96, 18);
            this.type_semi.TabIndex = 4;
            this.type_semi.TabStop = true;
            this.type_semi.Tag = "4";
            this.type_semi.Text = "semipermanent";
            this.type_semi.UseVisualStyleBackColor = true;
            this.type_semi.Click += new System.EventHandler(this.type_semi_Click);
            // 
            // artefakttyp_matrix
            // 
            this.artefakttyp_matrix.Controls.Add(this.matrix_unempfindlich);
            this.artefakttyp_matrix.Controls.Add(this.matrix_verystable);
            this.artefakttyp_matrix.Controls.Add(this.matrix_stable);
            this.artefakttyp_matrix.Controls.Add(this.matrix_labil);
            this.artefakttyp_matrix.Location = new System.Drawing.Point(219, 46);
            this.artefakttyp_matrix.Name = "artefakttyp_matrix";
            this.artefakttyp_matrix.Selected = 0;
            this.artefakttyp_matrix.Size = new System.Drawing.Size(297, 42);
            this.artefakttyp_matrix.TabIndex = 26;
            this.artefakttyp_matrix.TabStop = false;
            this.artefakttyp_matrix.Text = "Stabilität";
            // 
            // matrix_unempfindlich
            // 
            this.matrix_unempfindlich.AutoSize = true;
            this.matrix_unempfindlich.Location = new System.Drawing.Point(200, 15);
            this.matrix_unempfindlich.Name = "matrix_unempfindlich";
            this.matrix_unempfindlich.Size = new System.Drawing.Size(91, 18);
            this.matrix_unempfindlich.TabIndex = 3;
            this.matrix_unempfindlich.Tag = "3";
            this.matrix_unempfindlich.Text = "unempfindlich";
            this.matrix_unempfindlich.UseVisualStyleBackColor = true;
            this.matrix_unempfindlich.Click += new System.EventHandler(this.matrix_unempfindlich_Click);
            // 
            // matrix_verystable
            // 
            this.matrix_verystable.AutoSize = true;
            this.matrix_verystable.Location = new System.Drawing.Point(121, 15);
            this.matrix_verystable.Name = "matrix_verystable";
            this.matrix_verystable.Size = new System.Drawing.Size(71, 18);
            this.matrix_verystable.TabIndex = 2;
            this.matrix_verystable.Tag = "2";
            this.matrix_verystable.Text = "sehr stabil";
            this.matrix_verystable.UseVisualStyleBackColor = true;
            this.matrix_verystable.Click += new System.EventHandler(this.matrix_verystable_Click);
            // 
            // matrix_stable
            // 
            this.matrix_stable.AutoSize = true;
            this.matrix_stable.Location = new System.Drawing.Point(65, 15);
            this.matrix_stable.Name = "matrix_stable";
            this.matrix_stable.Size = new System.Drawing.Size(49, 18);
            this.matrix_stable.TabIndex = 1;
            this.matrix_stable.Tag = "1";
            this.matrix_stable.Text = "stabil";
            this.matrix_stable.UseVisualStyleBackColor = true;
            this.matrix_stable.Click += new System.EventHandler(this.matrix_stable_Click);
            // 
            // matrix_labil
            // 
            this.matrix_labil.AutoSize = true;
            this.matrix_labil.Checked = true;
            this.matrix_labil.Location = new System.Drawing.Point(15, 15);
            this.matrix_labil.Name = "matrix_labil";
            this.matrix_labil.Size = new System.Drawing.Size(44, 18);
            this.matrix_labil.TabIndex = 0;
            this.matrix_labil.TabStop = true;
            this.matrix_labil.Tag = "0";
            this.matrix_labil.Text = "labil";
            this.matrix_labil.UseVisualStyleBackColor = true;
            this.matrix_labil.Click += new System.EventHandler(this.matrix_labil_Click);
            // 
            // artefakttyp_semi
            // 
            this.artefakttyp_semi.Controls.Add(this.semi_monat);
            this.artefakttyp_semi.Controls.Add(this.semi_woche);
            this.artefakttyp_semi.Controls.Add(this.semi_tag);
            this.artefakttyp_semi.Controls.Add(this.semi_jahr);
            this.artefakttyp_semi.Location = new System.Drawing.Point(307, 46);
            this.artefakttyp_semi.Name = "artefakttyp_semi";
            this.artefakttyp_semi.Selected = 0;
            this.artefakttyp_semi.Size = new System.Drawing.Size(249, 42);
            this.artefakttyp_semi.TabIndex = 28;
            this.artefakttyp_semi.TabStop = false;
            this.artefakttyp_semi.Text = "Intervall";
            // 
            // semi_monat
            // 
            this.semi_monat.AutoSize = true;
            this.semi_monat.Location = new System.Drawing.Point(129, 15);
            this.semi_monat.Name = "semi_monat";
            this.semi_monat.Size = new System.Drawing.Size(56, 18);
            this.semi_monat.TabIndex = 6;
            this.semi_monat.Tag = "2";
            this.semi_monat.Text = "Monat";
            this.semi_monat.UseVisualStyleBackColor = true;
            this.semi_monat.Click += new System.EventHandler(this.semi_monat_Click);
            // 
            // semi_woche
            // 
            this.semi_woche.AutoSize = true;
            this.semi_woche.Location = new System.Drawing.Point(63, 15);
            this.semi_woche.Name = "semi_woche";
            this.semi_woche.Size = new System.Drawing.Size(57, 18);
            this.semi_woche.TabIndex = 5;
            this.semi_woche.Tag = "1";
            this.semi_woche.Text = "Woche";
            this.semi_woche.UseVisualStyleBackColor = true;
            this.semi_woche.Click += new System.EventHandler(this.semi_woche_Click);
            // 
            // semi_tag
            // 
            this.semi_tag.AutoSize = true;
            this.semi_tag.Checked = true;
            this.semi_tag.Location = new System.Drawing.Point(15, 15);
            this.semi_tag.Name = "semi_tag";
            this.semi_tag.Size = new System.Drawing.Size(42, 18);
            this.semi_tag.TabIndex = 4;
            this.semi_tag.TabStop = true;
            this.semi_tag.Tag = "0";
            this.semi_tag.Text = "Tag";
            this.semi_tag.UseVisualStyleBackColor = true;
            this.semi_tag.Click += new System.EventHandler(this.semi_tag_Click);
            // 
            // semi_jahr
            // 
            this.semi_jahr.AutoSize = true;
            this.semi_jahr.Location = new System.Drawing.Point(190, 15);
            this.semi_jahr.Name = "semi_jahr";
            this.semi_jahr.Size = new System.Drawing.Size(44, 18);
            this.semi_jahr.TabIndex = 7;
            this.semi_jahr.Tag = "3";
            this.semi_jahr.Text = "Jahr";
            this.semi_jahr.UseVisualStyleBackColor = true;
            this.semi_jahr.Click += new System.EventHandler(this.semi_jahr_Click);
            // 
            // repGroup
            // 
            this.repGroup.Controls.Add(this.rep_ach);
            this.repGroup.Controls.Add(this.rep_mag);
            this.repGroup.Location = new System.Drawing.Point(6, 25);
            this.repGroup.Name = "repGroup";
            this.repGroup.Selected = 1;
            this.repGroup.Size = new System.Drawing.Size(141, 40);
            this.repGroup.TabIndex = 10;
            this.repGroup.TabStop = false;
            this.repGroup.Text = "Repräsentation";
            // 
            // rep_ach
            // 
            this.rep_ach.AutoSize = true;
            this.rep_ach.Location = new System.Drawing.Point(94, 16);
            this.rep_ach.Name = "rep_ach";
            this.rep_ach.Size = new System.Drawing.Size(44, 18);
            this.rep_ach.TabIndex = 2;
            this.rep_ach.Tag = "0";
            this.rep_ach.Text = "Ach";
            this.rep_ach.UseVisualStyleBackColor = true;
            this.rep_ach.Click += new System.EventHandler(this.rep_ach_Click);
            // 
            // rep_mag
            // 
            this.rep_mag.AutoSize = true;
            this.rep_mag.Checked = true;
            this.rep_mag.Location = new System.Drawing.Point(8, 16);
            this.rep_mag.Name = "rep_mag";
            this.rep_mag.Size = new System.Drawing.Size(76, 18);
            this.rep_mag.TabIndex = 1;
            this.rep_mag.TabStop = true;
            this.rep_mag.Tag = "1";
            this.rep_mag.Text = "Mag/Hex...";
            this.rep_mag.UseVisualStyleBackColor = true;
            this.rep_mag.Click += new System.EventHandler(this.rep_mag_Click);
            // 
            // ArtGenControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.artefakttyp);
            this.Controls.Add(this.repGroup);
            this.Controls.Add(this.hero_name);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.materialGroup);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.wirkendeZauber);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.Name = "ArtGenControl";
            this.Size = new System.Drawing.Size(1004, 610);
            this.Load += new System.EventHandler(this.ArtGenControl_Load);
            this.SizeChanged += new System.EventHandler(this.ArtGenControl_SizeChanged);
            this.Click += new System.EventHandler(this.ArtGenControl_Click);
            this.materialGroup.ResumeLayout(false);
            this.materialGroup.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcanoviOtherMod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starkonst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_force)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artefakt_groesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probe_affine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probe_ausloes)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.special_eatmat_var)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ferngespuer_asp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_variable_var)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.special_additional_arcanovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agribaal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ort_neben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.special_ort_occ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magiekunde_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odem_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_semi_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_matrix_change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcanovi_change)).EndInit();
            this.wirkendeZauber.ResumeLayout(false);
            this.wirkendeZauber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stapelung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loads)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analys_cloack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_komplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analys_mr)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_aktive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_komplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destruct_mr)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zauberGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dasArtefaktBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dasArtefaktBindingSource1)).EndInit();
            this.artefakttyp.ResumeLayout(false);
            this.artefakttyp.PerformLayout();
            this.artefakttyp_aux.ResumeLayout(false);
            this.artefakttyp_aux.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.type_speicher_value)).EndInit();
            this.artefakttyp_temp.ResumeLayout(false);
            this.artefakttyp_temp.PerformLayout();
            this.artefakttyp_matrix.ResumeLayout(false);
            this.artefakttyp_matrix.PerformLayout();
            this.artefakttyp_semi.ResumeLayout(false);
            this.artefakttyp_semi.PerformLayout();
            this.repGroup.ResumeLayout(false);
            this.repGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox materialGroup;
        private System.Windows.Forms.ComboBox material;
        private System.Windows.Forms.CheckBox cb_kristalle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown starkonst;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown arcanovi_force;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown artefakt_groesse;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown probe_affine;
        private System.Windows.Forms.NumericUpDown probe_ausloes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown special_eatmat_var;
        private System.Windows.Forms.Label lbl_special_asp;
        private System.Windows.Forms.NumericUpDown special_ferngespuer_asp;
        private System.Windows.Forms.CheckBox special_ferngespuer;
        private System.Windows.Forms.Label lbl_special_komp;
        private System.Windows.Forms.NumericUpDown special_variable_var;
        private System.Windows.Forms.CheckBox special_eatmaterial;
        private System.Windows.Forms.CheckBox special_schleier;
        private System.Windows.Forms.CheckBox special_variablerelease;
        private System.Windows.Forms.CheckBox special_reversalis;
        private System.Windows.Forms.CheckBox special_selfrepair;
        private System.Windows.Forms.CheckBox special_resistant;
        private System.Windows.Forms.CheckBox special_apport;
        private System.Windows.Forms.CheckBox special_scent;
        private System.Windows.Forms.CheckBox special_durable;
        private System.Windows.Forms.CheckBox special_signet;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.NumericUpDown agribaal;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown special_ort_neben;
        private System.Windows.Forms.NumericUpDown special_ort_occ;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox artefakt_super_big;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox limbus;
        private System.Windows.Forms.CheckBox namenlos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox sf_aux;
        private System.Windows.Forms.CheckBox sf_ringkunde;
        private System.Windows.Forms.CheckBox sf_vielLadung;
        private System.Windows.Forms.CheckBox sf_semiII;
        private System.Windows.Forms.CheckBox sf_semiI;
        private System.Windows.Forms.CheckBox sf_matrix;
        private System.Windows.Forms.CheckBox sf_hyper;
        private System.Windows.Forms.CheckBox sf_stapel;
        private System.Windows.Forms.CheckBox sf_kraft;
        private System.Windows.Forms.RadioButton rep_ach;
        private System.Windows.Forms.RadioButton rep_mag;
        private System.Windows.Forms.RadioButton aux_unempfindlich;
        private System.Windows.Forms.CheckBox aux_merkmal;
        private System.Windows.Forms.RadioButton aux_verystable;
        private System.Windows.Forms.RadioButton aux_labil;
        private System.Windows.Forms.RadioButton aux_stable;
        private System.Windows.Forms.RadioButton matrix_unempfindlich;
        private System.Windows.Forms.RadioButton matrix_verystable;
        private System.Windows.Forms.RadioButton matrix_labil;
        private System.Windows.Forms.RadioButton matrix_stable;
        private System.Windows.Forms.RadioButton type_aux;
        private System.Windows.Forms.RadioButton temp_monat;
        private System.Windows.Forms.RadioButton temp_woche;
        private System.Windows.Forms.RadioButton temp_tag;
        private System.Windows.Forms.RadioButton type_semi;
        private System.Windows.Forms.RadioButton type_matrix;
        private System.Windows.Forms.RadioButton type_charge;
        private System.Windows.Forms.RadioButton type_einaml;
        private System.Windows.Forms.RadioButton type_temp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown destruct_change;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown magiekunde_change;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown analys_change;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown odem_change;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown arcanovi_semi_change;
        private System.Windows.Forms.NumericUpDown arcanovi_matrix_change;
        private System.Windows.Forms.NumericUpDown arcanovi_change;
        private System.Windows.Forms.Label arcanovi_semi_change_lbl;
        private System.Windows.Forms.Label arcanovi_matrix_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox wirkendeZauber;
        private System.Windows.Forms.ComboBox komp_combo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox zauber_rep;
        private System.Windows.Forms.Button zauber_del;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_staple;
        private System.Windows.Forms.Label loads_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button zauber_add;
        private System.Windows.Forms.ListView zauber_list;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader complexity;
        private System.Windows.Forms.ColumnHeader count_staples;
        private System.Windows.Forms.ColumnHeader count_asp;
        private System.Windows.Forms.ColumnHeader rep;
        private System.Windows.Forms.NumericUpDown asp;
        private System.Windows.Forms.NumericUpDown stapelung;
        private System.Windows.Forms.NumericUpDown loads;
        private System.Windows.Forms.MaskedTextBox zauber;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_create;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown analys_cloack;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox analys_broken;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown analys_komplex;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown analys_mr;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_analys;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.NumericUpDown destruct_aktive;
        private System.Windows.Forms.Label lbl_infi;
        private System.Windows.Forms.CheckBox destruct_infinitum;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown destruct_komplex;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown destruct_mr;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_destruct;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem programmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuesArtefaktToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artefaktLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artefaktSpeichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automatischNeuberechenenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ach_save;
        private System.Windows.Forms.ToolStripMenuItem würfelergebnisseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleBerechnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w6AnnehmenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w6_1;
        private System.Windows.Forms.ToolStripMenuItem w6_35;
        private System.Windows.Forms.ToolStripMenuItem w6_4;
        private System.Windows.Forms.ToolStripMenuItem w6_6;
        private System.Windows.Forms.ToolStripMenuItem w20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem w20_1;
        private System.Windows.Forms.ToolStripMenuItem w20_10;
        private System.Windows.Forms.ToolStripMenuItem w20_105;
        private System.Windows.Forms.ToolStripMenuItem w20_20;
        private System.Windows.Forms.ToolStripMenuItem regelbasis;
        private System.Windows.Forms.ToolStripMenuItem wegeDerAlchimieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staebeRingeDschinnenlampenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripMenuItem w20_11;
        private System.Windows.Forms.ToolStripMenuItem programmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateInstallierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importHeldensoftwareToolStripMenuItem;
        private System.Windows.Forms.Label hero_name;
        private CustomControls.RadioGroupBox repGroup;
        private CustomControls.RadioGroupBox artefakttyp;
        private CustomControls.RadioGroupBox artefakttyp_temp;
        private CustomControls.RadioGroupBox artefakttyp_aux;
        private CustomControls.RadioGroupBox artefakttyp_matrix;
        private CustomControls.RadioGroupBox artefakttyp_semi;
        private RadioButton semi_jahr;
        private RadioButton semi_monat;
        private RadioButton semi_woche;
        private RadioButton semi_tag;
        private ListBox zauber_listbox;
        private ToolStripMenuItem exportierenToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem heldenimportToolStripMenuItem;
        private ToolStripMenuItem nebenwirkungenMenuItem1;
        private ToolStripMenuItem nebenReRollToolStripMenuItem;
        private ToolStripMenuItem nebenIgnoreToolStripMenuItem;
        private CheckBox sf_kraftspeicher;
        private RadioButton type_speicher;
        private Label lbl_type_speicher_val;
        private NumericUpDown type_speicher_value;
        private CheckBox gemeinschaftlich;
        private ToolStripMenuItem showPDFToolStripMenuItem;
        private ComboBox special_ferngespuer_komp;
        private Label label5;
        private NumericUpDown special_additional_arcanovi;
        private NumericUpDown arcanoviOtherMod;
        private Label label7;
        private DataGridView zauberGrid;
        private BindingSource dasArtefaktBindingSource;
        private BindingSource dasArtefaktBindingSource1;
    }
}
