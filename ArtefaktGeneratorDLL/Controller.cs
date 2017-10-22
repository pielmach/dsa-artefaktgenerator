using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace ArtefaktGenerator
{
    public class Controller : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Artefakt artefakt = new Artefakt();
        private BindingList<Zauber> magic = new BindingList<Zauber>();
        private Wuerfel dice = new Wuerfel();
        private MaterialSammlung mat = new MaterialSammlung();
        private Occupation occ = new Occupation();
        private Nebeneffekte nebeneffekte = new Nebeneffekte();
        private Kraftspeicher kraftspeicher = new Kraftspeicher();

        public Controller() { mat = new MaterialSammlung(dice); }

        #region Options
        public bool WDA
        {
            get { return artefakt.regelbasis == Artefakt.Regelbasis.WDA; }
            set { 
                if (value) 
                {
                    artefakt.regelbasis = Artefakt.Regelbasis.WDA;
                    sfAuxiliatorVisible = true;

                    spezialFerngespuerVisible = true;
                    spezialResistenzVisible = true;
                    spezialSelbstreparaturVisible = true;
                    spezialUmkehrtalismanVisible = true;
                    spezialVariablerAusloeserVisible = true;
                    spezialVerschleierungVisible = true;
                    spezialVerzehrendVisible = true;

                    probeAffinMax = 3;
                    probeAffinMin = -3;

                    if (tawArcanovi < 12)
                    {
                        if (artefakttyp == (int)Artefakt.ArtefaktType.TEMP)
                            artefakttyp = (int)Artefakt.ArtefaktType.NORMAL;
                        artefakttypTempEnabled = false;
                    }
                }
                else
                {
                    artefakt.regelbasis = Artefakt.Regelbasis.SRD;
                    sfAuxiliatorVisible = false;

                    spezialFerngespuerVisible = false;
                    spezialFerngespuer = false;
                    spezialResistenzVisible = false;
                    spezialResistenz = false;
                    spezialSelbstreparaturVisible = false;
                    spezialSelbstreparatur = false;
                    spezialUmkehrtalismanVisible = false;
                    spezialUmkehrtalisman = false;
                    spezialVariablerAusloeserVisible = false;
                    spezialVariablerAusloeser = false;
                    spezialVerschleierungVisible = false;
                    spezialVerschleierung = false;
                    spezialVerzehrendVisible = false;
                    spezialVerzehrend = false;

                    probeAffinMax = 4;
                    probeAffinMin = -2;

                    artefakttypTempEnabled = true;
                }
                extraExtraGross = extraExtraGross;
                RaisePropertyChanged("WDA");
            }
        }

        private bool _achSave;
        public bool optionAchSave
        {
            get { return _achSave; }
            set { _achSave = value; RaisePropertyChanged("optionAchSave"); }
        }
        private bool _allesBerechnen;
        public bool optionAllesBerechnen
        {
            get { return _allesBerechnen; }
            set { _allesBerechnen = value; RaisePropertyChanged("optionAllesBerechnen"); }
        }
        private bool _nebeneffekteNeuWuerfeln;
        public bool optionNebeneffekteNeuWuerfeln
        {
            get { return _nebeneffekteNeuWuerfeln; }
            set { _nebeneffekteNeuWuerfeln = value; RaisePropertyChanged("nebeneffekteNeuWuerfeln"); }
        }

        public string heldName
        {
            get { return artefakt.heldName; }
            set { artefakt.heldName = value; RaisePropertyChanged("heldName"); }
        }

        #endregion

        #region SF Properties

        public int sfRepresentation
        {
            get
            {
                return (int)artefakt.sf.rep;
            }
            set
            {
                artefakt.sf.rep = (SF.SFType)value;
                if (artefakt.sf.rep == SF.SFType.ACH)
                    extraKristalleVisible = true;
                else
                {
                    extraKristalleVisible = false;
                    extraKristalle = false;
                }
                RaisePropertyChanged("sfRepresentation");
            }
        }

        public bool sfKraftkontrolle
        {
            get
            {
                return artefakt.sf.kraftkontrolle;
            }
            set
            {
                artefakt.sf.kraftkontrolle = value;
                RaisePropertyChanged("sfKraftkontrolle");
            }
        }
        public bool sfVielfacheLadung
        {
            get
            {
                return artefakt.sf.vielfacheLadung;
            }
            set
            {
                artefakt.sf.vielfacheLadung = value;
                RaisePropertyChanged("sfVielfacheLadung");
            }
        }
        public bool sfStapeleffekt
        {
            get
            {
                return artefakt.sf.stapel;
            }
            set
            {
                artefakt.sf.stapel = value;
                if (value)
                {
                    sfHypervehemenzEnabled = true;
                    zauberStapelEnabled = true;
                    zauberStapelMax = 3;
                }
                else
                {
                    sfHypervehemenzEnabled = false;
                    sfHypervehemenz = false;
                    zauberStapelEnabled = false;

                    BindingList<Zauber> z = zauberListe;
                    for (int i = 0; i < z.Count; i++ )
                    {
                        if (z[i].staple > 1)
                        {
                            Zauber zx = z[i];
                            zx.staple = 1;
                            z.RemoveAt(i);
                            z.Add(zx);
                        }
                    }
                    zauberListe = z;
                    zauberStapelMax = 1;
                }
                RaisePropertyChanged("sfStapeleffekt");
            }
        }
        public bool sfHypervehemenz
        {
            get
            {
                return artefakt.sf.hyper;
            }
            set
            {
                artefakt.sf.hyper = value;
                if (value)
                    zauberStapelMax = 1000;
                else
                    zauberStapelMax = 3;
                RaisePropertyChanged("sfHypervehemenz");
            }
        }
        private bool _sfHypervehemenzEnabled;
        public bool sfHypervehemenzEnabled
        {
            get
            {
                return _sfHypervehemenzEnabled;
            }
            set
            {
                _sfHypervehemenzEnabled = value;
                RaisePropertyChanged("sfHypervehemenzEnabled");
            }
        }
        public bool sfMatrixgeber
        {
            get { return artefakt.sf.matrix; }
            set
            {
                artefakt.sf.matrix = value;
                if (artefakt.sf.matrix)
                {
                    tawArcanoviMatrixEnabled = true;
                    sfAuxiliatorEnabled = true;
                }
                else
                {
                    artefakttypMatrixVisible = false;
                    tawArcanoviMatrixEnabled = false;
                    sfAuxiliatorEnabled = false;
                    sfAuxiliator = false;
                    if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                        artefakttyp = (int)Artefakt.ArtefaktType.RECHARGE;
                }
                RaisePropertyChanged("sfMatrixgeber");
            }
        }
        public bool sfSemipermanenz1
        {
            get
            {
                return artefakt.sf.semi1;
            }
            set
            {
                if (value)
                {
                    sfSemipermanenz2Enabled = true;
                    artefakttypSemipermanenzEnabled = true;
                    tawArcanoviSemipermanenzEnabled = true;
                }
                else
                {
                    sfSemipermanenz2Enabled = false;
                    sfSemipermanenz2 = false;
                    artefakttypSemipermanenzEnabled = false;
                    tawArcanoviSemipermanenzEnabled = false;
                    if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                        artefakttyp = (int)Artefakt.ArtefaktType.RECHARGE;
                }
                artefakt.sf.semi1 = value;
                RaisePropertyChanged("sfSemipermanenz1");
            }
        }
        public bool sfSemipermanenz2
        {
            get
            {
                return artefakt.sf.semi2;
            }
            set
            {
                artefakt.sf.semi2 = value;
                RaisePropertyChanged("sfSemipermanenz2");
            }
        }
        private bool semi2_enabled;
        public bool sfSemipermanenz2Enabled
        {
            get
            {
                return semi2_enabled;
            }
            set
            {
                semi2_enabled = value;
                RaisePropertyChanged("sfSemipermanenz2Enabled");
            }
        }

        public bool sfRingkunde
        {
            get
            {
                return artefakt.sf.ringkunde;
            }
            set
            {
                artefakt.sf.ringkunde = value;
                RaisePropertyChanged("sfRingkunde");
            }
        }
        public bool sfKraftspeicher
        {
            get
            {
                return artefakt.sf.kraftspeicher;
            }
            set
            {
                artefakt.sf.kraftspeicher = value;
                if (!artefakt.sf.kraftspeicher && artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
                {
                    artefakttyp = (int)Artefakt.ArtefaktType.NORMAL;
                }
                RaisePropertyChanged("sfKraftspeicher");
            }
        }

        public bool sfAuxiliator
        {
            get { return artefakt.sf.auxiliator; }
            set
            {
                artefakt.sf.auxiliator = value;
                if (value)
                {
                    artefakttypAuxiliatorEnabled = true;
                }
                else
                {
                    artefakttypAuxiliatorEnabled = false;
                    if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                        artefakttyp = 1;
                }
                RaisePropertyChanged("sfAuxiliator");
            }
        }
        private bool _sfAuxiliatorEnabled;
        public bool sfAuxiliatorEnabled
        {
            get
            {
                return _sfAuxiliatorEnabled;
            }
            set
            {
                _sfAuxiliatorEnabled = value;
                RaisePropertyChanged("sfAuxiliatorEnabled");
            }
        }
        private bool _sfAuxiliatorVisible;
        public bool sfAuxiliatorVisible
        {
            get
            {
                return _sfAuxiliatorVisible;
            }
            set
            {
                 _sfAuxiliatorVisible = value;
                 if (value)
                 {
                 }
                 else
                 {
                     sfAuxiliator = false;
                 }
                 RaisePropertyChanged("sfAuxiliatorVisible");
            }
        }
        #endregion

        #region TAW Properties
        public int tawArcanovi
        {
            get { return (int)artefakt.taw.arcanovi; }
            set { 
                artefakt.taw.arcanovi = (decimal)value;
                if (value < 10)
                {
                    spezialSiegel = false;
                    spezialSiegelEnabled = false;
                    spezialVerschleierung = false;
                    spezialVerschleierungEnabled = false;
                }
                else
                {
                    spezialSiegelEnabled = true;
                    spezialVerschleierungEnabled = true;
                }
                if (value < 12)
                {
                    spezialFerngespuer = false;
                    spezialFerngespuerEnabled = false;
                    spezialVariablerAusloeserEnabled = false;
                    spezialVariablerAusloeser = false;
                    if (WDA && artefakt.typ == Artefakt.ArtefaktType.TEMP)
                        artefakttyp = (int)Artefakt.ArtefaktType.NORMAL;
                    if (WDA) artefakttypTempEnabled = false;
                }
                else
                {
                    spezialFerngespuerEnabled = true;
                    spezialVariablerAusloeserEnabled = true;
                    artefakttypTempEnabled = true;
                    if (artefakttyp == (int)Artefakt.ArtefaktType.RECHARGE) spezialVariablerAusloeserEnabled = true;
                }
                RaisePropertyChanged("tawArcanovi");
            }
        }
        public int tawArcanoviMatrix
        {
            get { return (int)artefakt.taw.arcanovi_matrix; }
            set { 
                artefakt.taw.arcanovi_matrix = (decimal)value; 
                if (value < 15)
                {
                    spezialUmkehrtalisman = false;
                    spezialUmkehrtalismanEnabled = false;
                }
                else if (artefakttyp == (int)Artefakt.ArtefaktType.AUX)
                    spezialUmkehrtalismanEnabled = true;
                RaisePropertyChanged("tawArcanoviMatrix"); 
            }
        }
        private bool _tawArcanoviMatrixEnabled;
        public bool tawArcanoviMatrixEnabled
        {
            get { return _tawArcanoviMatrixEnabled; }
            set { _tawArcanoviMatrixEnabled = value; RaisePropertyChanged("tawArcanoviMatrixEnabled"); }
        }
        public int tawArcanoviSemipermanenz
        {
            get { return (int)artefakt.taw.arcanovi_semi; }
            set { artefakt.taw.arcanovi_semi = (decimal)value; RaisePropertyChanged("tawArcanoviSemipermanenz"); }
        }
        private bool _tawArcanoviSemipermanenzEnabled;
        public bool tawArcanoviSemipermanenzEnabled
        {
            get { return _tawArcanoviSemipermanenzEnabled; }
            set { _tawArcanoviSemipermanenzEnabled = value; RaisePropertyChanged("tawArcanoviSemipermanenzEnabled"); }
        }
        public int tawOdem
        {
            get { return (int)artefakt.taw.odem; }
            set { artefakt.taw.odem = (decimal)value; RaisePropertyChanged("tawOdem"); }
        }
        public int tawAnalys
        {
            get { return (int)artefakt.taw.analys; }
            set { artefakt.taw.analys = (decimal)value; RaisePropertyChanged("tawAnalys"); }
        }
        public int tawMagiekunde
        {
            get { return (int)artefakt.taw.magiekunde; }
            set { artefakt.taw.magiekunde = (decimal)value; RaisePropertyChanged("tawMagiekunde"); }
        }
        public int tawDestructibo
        {
            get { return (int)artefakt.taw.destructibo; }
            set { artefakt.taw.destructibo = (decimal)value; RaisePropertyChanged("tawDestructibo"); }
        }


        #endregion

        #region Artefakttyp Properties

        public int artefakttyp
        {
            get { return (int)artefakt.typ; }
            set { 
                artefakt.typ = (Artefakt.ArtefaktType)value;
                if (artefakt.typ == Artefakt.ArtefaktType.TEMP)
                    artefakttypTempVisible = true;
                else artefakttypTempVisible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
                {
                    artefakttypKraftspeicherVisible = true;
                    spezialFerngespuerEnabled = false;
                    wirkendeZauberEnabled = false;
                    selectedMaterial = 0;
                }
                else
                {
                    artefakttypKraftspeicherVisible = false;
                    spezialFerngespuerEnabled = true;
                    wirkendeZauberEnabled = true;
                }
                if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                {
                    artefakttypMatrixVisible = true;
                    zauberLadungenEnabled = false;
                    zauberLadungen = 1;
                }
                else
                {
                    artefakttypMatrixVisible = false;
                    zauberLadungenEnabled = true;
                }
                if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                    artefakttypSemipermanenzVisible = true;
                else artefakttypSemipermanenzVisible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                {
                    artefakttypAuxiliatorVisible = true;
                    if (tawArcanoviMatrix >= 15) spezialUmkehrtalismanEnabled = true;
                    else spezialUmkehrtalismanEnabled = false;
                }
                else artefakttypAuxiliatorVisible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.RECHARGE && tawArcanovi >= 12)
                    spezialVariablerAusloeserEnabled = true;
                else spezialVariablerAusloeserEnabled = false;
                if ((artefakt.typ == Artefakt.ArtefaktType.NORMAL || artefakt.typ == Artefakt.ArtefaktType.TEMP) && zauberLadungen == 1)
                    spezialVerzehrendEnabled = true;
                else
                    spezialVerzehrendEnabled = false;

                RaisePropertyChanged("artefakttyp"); 
            }
        }

        public int artefakttypTemp
        {
            get { return (int)artefakt.temp_typ; }
            set { artefakt.temp_typ = (Artefakt.TempType)value; RaisePropertyChanged("artefakttypTemp"); }
        }
        private bool _artefakttypTempVisible;
        public bool artefakttypTempVisible
        {
            get { return _artefakttypTempVisible; }
            set { _artefakttypTempVisible = value; RaisePropertyChanged("artefakttypTempVisible"); }
        }
        private bool _artefakttypTempEnabled;
        public bool artefakttypTempEnabled
        {
            get { return _artefakttypTempEnabled; }
            set { _artefakttypTempEnabled = value; RaisePropertyChanged("artefakttypTempEnabled"); }
        }

        public int artefakttypMatrix
        {
            get { return (int)artefakt.matrix_typ; }
            set { artefakt.matrix_typ = (Artefakt.MatrixType)value; RaisePropertyChanged("artefakttypMatrix"); }
        }
        private bool _artefakttypMatrixVisible;
        public bool artefakttypMatrixVisible
        {
            get { return _artefakttypMatrixVisible; }
            set { _artefakttypMatrixVisible = value; RaisePropertyChanged("artefakttypMatrixVisible"); }
        }

        public int artefakttypSemipermanenz
        {
            get { return (int)artefakt.semi_typ; }
            set { artefakt.semi_typ = (Artefakt.SemiType)value; RaisePropertyChanged("artefakttypSemipermanenz"); }
        }
        private bool _artefakttypSemipermanenzVisible;
        public bool artefakttypSemipermanenzVisible
        {
            get { return _artefakttypSemipermanenzVisible; }
            set { _artefakttypSemipermanenzVisible = value; RaisePropertyChanged("artefakttypSemipermanenzVisible"); }
        }
        private bool _artefakttypSemipermanenzEnabled;
        public bool artefakttypSemipermanenzEnabled
        {
            get { return _artefakttypSemipermanenzEnabled; }
            set { _artefakttypSemipermanenzEnabled = value; RaisePropertyChanged("artefakttypSemipermanenzEnabled"); }
        }
        public int artefakttypKraftspeicher
        {
            get { return (int)artefakt.kraftspeicher_asp; }
            set { artefakt.kraftspeicher_asp = (decimal)value; RaisePropertyChanged("artefakttypKraftspeicher"); }
        }
        private bool _artefakttypKraftspeicherVisible;
        public bool artefakttypKraftspeicherVisible
        {
            get { return _artefakttypKraftspeicherVisible; }
            set { _artefakttypKraftspeicherVisible = value; RaisePropertyChanged("artefakttypKraftspeicherVisible"); }
        }
        private bool _wirkendeZauberEnabled;
        public bool wirkendeZauberEnabled
        {
            get { return _wirkendeZauberEnabled; }
            set { _wirkendeZauberEnabled = value; RaisePropertyChanged("wirkendeZauberEnabled"); }
        }

        public int artefakttypAuxiliator
        {
            get { return (int)artefakt.aux_typ; }
            set { artefakt.aux_typ = (Artefakt.MatrixType)value; RaisePropertyChanged("artefakttypAuxiliator"); }
        }
        private bool _artefakttypAuxiliatorVisible;
        public bool artefakttypAuxiliatorVisible
        {
            get { return _artefakttypAuxiliatorVisible; }
            set { _artefakttypAuxiliatorVisible = value; RaisePropertyChanged("artefakttypAuxiliatorVisible"); }
        }
        private bool _artefakttypAuxiliatorEnabled;
        public bool artefakttypAuxiliatorEnabled
        {
            get { return _artefakttypAuxiliatorEnabled; }
            set { _artefakttypAuxiliatorEnabled = value; RaisePropertyChanged("artefakttypAuxiliatorEnabled"); }
        }
        public bool artefakttypAuxiliatorMerkmal
        {
            get { return artefakt.aux_merkmal; }
            set { artefakt.aux_merkmal = value; RaisePropertyChanged("artefakttypAuxiliatorMerkmal"); }
        }

        #endregion

        #region Artefakt spezielle Eigenschaften

        public bool spezialSiegel
        {
            get { return artefakt.spezial_siegel; }
            set { artefakt.spezial_siegel = value; RaisePropertyChanged("spezialSiegel"); }
        }
        private bool _spezialSiegelEnabled;
        public bool spezialSiegelEnabled
        {
            get { return _spezialSiegelEnabled; }
            set { _spezialSiegelEnabled = value; RaisePropertyChanged("spezialSiegelEnabled"); }
        }

        public bool spezialUnzerbrechlich
        {
            get { return artefakt.spezial_unzerbrechlich; }
            set { artefakt.spezial_unzerbrechlich = value; RaisePropertyChanged("spezialUnzerbrechlich"); }
        }
        public bool spezialGespuer
        {
            get { return artefakt.spezial_gespuer; }
            set { artefakt.spezial_gespuer = value; RaisePropertyChanged("spezialGespuer"); }
        }
        public bool spezialApport
        {
            get { return artefakt.spezial_apport; }
            set { artefakt.spezial_apport = value; RaisePropertyChanged("spezialApport"); }
        }

        public bool spezialResistenz
        {
            get { return artefakt.spezial_resistent; }
            set { artefakt.spezial_resistent = value; RaisePropertyChanged("spezialResistenz"); }
        }
        private bool _spezialResistenzVisible;
        public bool spezialResistenzVisible
        {
            get { return _spezialResistenzVisible; }
            set { _spezialResistenzVisible = value; RaisePropertyChanged("spezialResistenzVisible"); }
        }

        public bool spezialSelbstreparatur
        {
            get { return artefakt.spezial_reperatur; }
            set { artefakt.spezial_reperatur = value; RaisePropertyChanged("spezialSelbstreparatur"); }
        }
        private bool _spezialSelbstreparaturVisible;
        public bool spezialSelbstreparaturVisible
        {
            get { return _spezialSelbstreparaturVisible; }
            set { _spezialSelbstreparaturVisible = value; RaisePropertyChanged("spezialSelbstreparaturVisible"); }
        }

        public bool spezialFerngespuer
        {
            get { return artefakt.spezial_ferngespuer; }
            set { artefakt.spezial_ferngespuer = value; RaisePropertyChanged("spezialFerngespuer"); }
        }
        private bool _spezialFerngespuerVisible;
        public bool spezialFerngespuerVisible
        {
            get { return _spezialFerngespuerVisible; }
            set { _spezialFerngespuerVisible = value; RaisePropertyChanged("spezialFerngespuerVisible"); }
        }
        private bool _spezialFerngespuerEnabled;
        public bool spezialFerngespuerEnabled
        {
            get { return _spezialFerngespuerEnabled; }
            set { _spezialFerngespuerEnabled = value; RaisePropertyChanged("spezialFerngespuerEnabled"); }
        }
        public int spezialFerngespuerAsp
        {
            get { return (int)artefakt.spezial_ferngespuer_asp; }
            set { artefakt.spezial_ferngespuer_asp = (decimal)value; RaisePropertyChanged("spezialFerngespuerAsp"); }
        }
        public int spezialFerngespuerKomp
        {
            get { return (int)artefakt.spezial_ferngespuer_komp - 1; }
            set { artefakt.spezial_ferngespuer_komp = (decimal)value + 1; RaisePropertyChanged("spezialFerngespuerKomp"); }
        }

        public bool spezialUmkehrtalisman
        {
            get { return artefakt.spezial_reversalis; }
            set { artefakt.spezial_reversalis = value; RaisePropertyChanged("spezialUmkehrtalisman"); }
        }
        private bool _spezialUmkehrtalismanVisible;
        public bool spezialUmkehrtalismanVisible
        {
            get { return _spezialUmkehrtalismanVisible; }
            set { _spezialUmkehrtalismanVisible = value; RaisePropertyChanged("spezialUmkehrtalismanVisible"); }
        }
        private bool _spezialUmkehrtalismanEnabled;
        public bool spezialUmkehrtalismanEnabled
        {
            get { return _spezialUmkehrtalismanEnabled; }
            set { _spezialUmkehrtalismanEnabled = value; RaisePropertyChanged("spezialUmkehrtalismanEnabled"); }
        }

        public bool spezialVariablerAusloeser
        {
            get { return artefakt.spezial_variablerausloeser; }
            set { artefakt.spezial_variablerausloeser = value; RaisePropertyChanged("spezialVariablerAusloeser"); }
        }
        private bool _spezialVariablerAusloeserVisible;
        public bool spezialVariablerAusloeserVisible
        {
            get { return _spezialVariablerAusloeserVisible; }
            set { _spezialVariablerAusloeserVisible = value; RaisePropertyChanged("spezialVariablerAusloeserVisible"); }
        }
        private bool _spezialVariablerAusloeserEnabled;
        public bool spezialVariablerAusloeserEnabled
        {
            get { return _spezialVariablerAusloeserEnabled; }
            set { _spezialVariablerAusloeserEnabled = value; RaisePropertyChanged("spezialVariablerAusloeserEnabled"); }
        }
        public int spezialVariablerAusloeserVar
        {
            get { return (int)artefakt.spezial_variablerausloeser_var; }
            set { artefakt.spezial_variablerausloeser_var = (decimal)value; RaisePropertyChanged("spezialVariablerAusloeserVar"); }
        }

        public bool spezialVerschleierung
        {
            get { return artefakt.spezial_verschleierung; }
            set { artefakt.spezial_verschleierung = value; RaisePropertyChanged("spezialVerschleierung"); }
        }
        private bool _spezialVerschleierungVisible;
        public bool spezialVerschleierungVisible
        {
            get { return _spezialVerschleierungVisible; }
            set { _spezialVerschleierungVisible = value; RaisePropertyChanged("spezialVerschleierungVisible"); }
        }
        private bool _spezialVerschleierungEnabled;
        public bool spezialVerschleierungEnabled
        {
            get { return _spezialVerschleierungEnabled; }
            set { _spezialVerschleierungEnabled = value; RaisePropertyChanged("spezialVerschleierungEnabled"); }
        }

        public bool spezialVerzehrend
        {
            get { return artefakt.spezial_verzehrend; }
            set { artefakt.spezial_verzehrend = value; RaisePropertyChanged("spezialVerzehrend"); }
        }
        private bool _spezialVerzehrendVisible;
        public bool spezialVerzehrendVisible
        {
            get { return _spezialVerzehrendVisible; }
            set { _spezialVerzehrendVisible = value; RaisePropertyChanged("spezialVerzehrendVisible"); }
        }
        private bool _spezialVerzehrendEnabled;
        public bool spezialVerzehrendEnabled
        {
            get { return _spezialVerzehrendEnabled; }
            set { _spezialVerzehrendEnabled = value; RaisePropertyChanged("spezialVerzehrendEnabled"); }
        }
        public int spezialVerzehrendVar
        {
            get { return (int)artefakt.spezial_verzehrend_var; }
            set { artefakt.spezial_verzehrend_var = (decimal)value; RaisePropertyChanged("spezialVerzehrendVar"); }
        }
       
        #endregion

        #region Artefakt Besondere Umstaende

        public bool extraMadeInLimbus
        {
            get { return artefakt.limbus; }
            set { artefakt.limbus = value; RaisePropertyChanged("extraMadeInLimbus"); }
        }

        public bool extraNamenloseTage
        {
            get { return artefakt.namenlos; }
            set { artefakt.namenlos = value; RaisePropertyChanged("extraNamenloseTage"); }
        }

        public bool extraGemeinschaftlicheErschaffung
        {
            get { return artefakt.gemeinschaftlich; }
            set { artefakt.gemeinschaftlich = value; RaisePropertyChanged("extraGemeinschaftlicheErschaffung"); }
        }

        public int extraAgribaal
        {
            get { return (int)artefakt.agribaal; }
            set { artefakt.agribaal = (decimal)value; RaisePropertyChanged("extraAgribaal"); }
        }

        public int extraOkkupation
        {
            get { return (int)artefakt.special_ort_occ; }
            set { artefakt.special_ort_occ = (decimal)value; RaisePropertyChanged("extraOkkupation"); }
        }

        public int extraNebeneffekt
        {
            get { return (int)artefakt.special_ort_neben; }
            set { artefakt.special_ort_neben = (decimal)value; RaisePropertyChanged("extraNebeneffekt"); }
        }

        private int _extraExtraGross;
        public int extraExtraGross
        {
            get { return _extraExtraGross; }
            set { 
                _extraExtraGross = value;
                if (WDA)
                {
                    switch (value)
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
                    switch (value)
                    {
                        case 0: artefakt.probe.superBig_zuschlag = 0; artefakt.probe.superBig_asp_w = 0; break;
                        case 1: artefakt.probe.superBig_zuschlag = 3; artefakt.probe.superBig_asp_w = 1; break;
                        case 2: artefakt.probe.superBig_zuschlag = 6; artefakt.probe.superBig_asp_w = 2; break;
                        case 3: artefakt.probe.superBig_zuschlag = 9; artefakt.probe.superBig_asp_w = 4; break;
                        case 4: artefakt.probe.superBig_zuschlag = 12; artefakt.probe.superBig_asp_w = 8; break;
                    }
                }
                if (value != 0)
                {
                    probeGroesseEnabled = false;
                }
                else
                {
                    probeGroesse = 0;
                    probeGroesseEnabled = true;
                }
                RaisePropertyChanged("extraExtraGross"); 
            }
        }

        public int extraZusaetzlicheArcanovi
        {
            get { return (int)artefakt.special_additional_arcanovi; }
            set { artefakt.special_additional_arcanovi = (decimal)value; RaisePropertyChanged("extraZusaetzlicheArcanovi"); }
        }

        //Material
        public List<Material> material
        {
            get { return mat.getList(); }
            set {}
        }

        private int _selectedMaterial;
        public int selectedMaterial
        {
            get { return _selectedMaterial; }
            set { _selectedMaterial = value; RaisePropertyChanged("selectedMaterial"); }
        }

        public bool extraKristalle
        {
            get { return artefakt.kristalle; }
            set { artefakt.kristalle = value; RaisePropertyChanged("extraKristalle"); }
        }
        private bool _extraKristalleVisible;
        public bool extraKristalleVisible
        {
            get { return _extraKristalleVisible; }
            set { _extraKristalleVisible = value; RaisePropertyChanged("extraKristalleVisible"); }
        }

        #endregion

        #region Probenzuschlaege

        public int probeAusloeser
        {
            get { return (int)artefakt.probe.ausloeser; }
            set { artefakt.probe.ausloeser = (decimal)value; RaisePropertyChanged("probeAusloeser"); }
        }

        public int probeAffin
        {
            get { return (int)artefakt.probe.affine; }
            set { artefakt.probe.affine = (decimal)value; RaisePropertyChanged("probeAffin"); }
        }
        private int _probeAffinMax;
        public int probeAffinMax
        {
            get { return _probeAffinMax; }
            set { _probeAffinMax = value; RaisePropertyChanged("probeAffinMax"); }
        }
        private int _probeAffinMin;
        public int probeAffinMin
        {
            get { return _probeAffinMin; }
            set { _probeAffinMin = value; RaisePropertyChanged("probeAffinMin"); }
        }

        public int probeGroesse
        {
            get { return (int)artefakt.probe.groesse; }
            set { artefakt.probe.groesse = (decimal)value; RaisePropertyChanged("probeGroesse"); }
        }
        private bool _probeGroesseEnabled;
        public bool probeGroesseEnabled
        {
            get { return _probeGroesseEnabled; ; }
            set { _probeGroesseEnabled = value; RaisePropertyChanged("probeGroesseEnabled"); }
        }

        public int probeErzwingen
        {
            get { return (int)artefakt.probe.erzwingen; }
            set { artefakt.probe.erzwingen = (decimal)value; RaisePropertyChanged("probeErzwingen"); }
        }
        public int probeSterne
        {
            get { return (int)artefakt.probe.stars; }
            set { artefakt.probe.stars = (decimal)value; RaisePropertyChanged("probeSterne"); }
        }
        public int probeAndereMod
        {
            get { return (int)artefakt.probe.otherMods; }
            set { artefakt.probe.otherMods = (decimal)value; RaisePropertyChanged("probeAndereMod"); }
        }
        public int probeZfPSternMod
        {
            get { return (int)artefakt.probe.zfpSternMod; }
            set { artefakt.probe.zfpSternMod = (decimal)value; RaisePropertyChanged("probeZfPSternMod"); }
        }

        public int probeWirkenderSpruchMod
        {
            get { return (int)artefakt.probe.wirkenderSpruchMod; }
            set { artefakt.probe.wirkenderSpruchMod = (decimal)value; RaisePropertyChanged("probeWirkenderSpruch"); }
        }

        #endregion

        #region Zauber Liste

        private bool _zauberStapelEnabled;
        public bool zauberStapelEnabled
        {
            get { return _zauberStapelEnabled; }
            set { _zauberStapelEnabled = value; RaisePropertyChanged("zauberStapelEnabled"); }
        }
        private int _zauberStapelMax;
        public int zauberStapelMax
        {
            get { return _zauberStapelMax; }
            set { _zauberStapelMax = value; RaisePropertyChanged("zauberStapelMax"); }
        }

        public BindingList<Zauber> zauberListe
        {
            get { magic.AllowEdit = true; return magic; }
            set {
                magic = value; RaisePropertyChanged("zauberListe");
                magic.ListChanged += delegate(object sender, ListChangedEventArgs args)
                {
                    generateArtefakt();
                };
            }
        }

        public int zauberLadungen
        {
            get { return (int)artefakt.loads; }
            set { artefakt.loads = (decimal)value; RaisePropertyChanged("zauberLadungen"); }
        }
        private bool _zauberLadungenEnabled;
        public bool zauberLadungenEnabled
        {
            get { return _zauberLadungenEnabled; }
            set { _zauberLadungenEnabled = value; RaisePropertyChanged("zauberLadungenEnabled"); }
        }
        #endregion

        #region Results

        private string _resArcanovi;
        public string resultArcanovi
        {
            get { return _resArcanovi; }
            set { _resArcanovi = value; RaisePropertyChanged("resultArcanovi"); }
        }

        private string _resAnalys;
        public string resultAnalys
        {
            get { return _resAnalys; }
            set { _resAnalys = value; RaisePropertyChanged("resultAnalys"); }
        }

        private string _resDestructibo;
        public string resultDestructibo
        {
            get { return _resDestructibo; }
            set { _resDestructibo = value; RaisePropertyChanged("resultDestructibo"); }
        }

        #endregion

        #region Dice

        public decimal W6
        {
            get { return dice.W6; }
            set { dice.W6 = value; RaisePropertyChanged("W6"); }
        }
        public decimal W20
        {
            get { return dice.W20; }
            set { dice.W20 = value; RaisePropertyChanged("W20"); }
        }

        #endregion

        #region Analys Specifics

        public bool analysMisslungen
        {
            get { return artefakt.analys.misslungen; }
            set { artefakt.analys.misslungen = value; RaisePropertyChanged("analysMisslungen"); }
        }
        public int analysKomplex
        {
            get { return (int)artefakt.analys.bes_komlexitaet; }
            set { artefakt.analys.bes_komlexitaet = (int)value; RaisePropertyChanged("analysKomplex"); }
        }
        public int analysMR
        {
            get { return (int)artefakt.analys.mr; }
            set { artefakt.analys.mr = (int)value; RaisePropertyChanged("analysMR"); }
        }
        public int analysTarnzauber
        {
            get { return (int)artefakt.analys.tarnzauber; }
            set { artefakt.analys.tarnzauber = (int)value; RaisePropertyChanged("analysTarnzauber"); }
        }

        #endregion

        #region Destructibo Specifics

        public bool destructiboInfinitum
        {
            get { return artefakt.destructibo.infinitum; }
            set { artefakt.destructibo.infinitum = value; RaisePropertyChanged("destructiboInfinitum"); }
        }
        public int destructiboKomplex
        {
            get { return (int)artefakt.destructibo.komplex; }
            set { artefakt.destructibo.komplex = (int)value; RaisePropertyChanged("destructiboKomplex"); }
        }
        public int destructiboMR
        {
            get { return (int)artefakt.destructibo.mr; }
            set { artefakt.destructibo.mr = (int)value; RaisePropertyChanged("destructiboMR"); }
        }
        public int destructiboAktiveLadungen
        {
            get { return (int)artefakt.destructibo.aktive_loads; }
            set { artefakt.destructibo.aktive_loads = (int)value; RaisePropertyChanged("destructiboAktiveLadungen"); }
        }

        #endregion

        #region Implement INotifyPropertyChanged

        protected void RaisePropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }

            if (propertyName != "resultArcanovi" && propertyName != "resultAnalys" && propertyName != "resultDestructibo")
                generateArtefakt();

        }

        #endregion

        #region Control Functions

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

        private void reInitArtefakt()
        {
            heldName = heldName;
            WDA = WDA;
            optionAchSave = optionAchSave;
            optionAllesBerechnen = optionAllesBerechnen;
            sfHypervehemenz = sfHypervehemenz;
            sfVielfacheLadung = sfVielfacheLadung;
            sfKraftkontrolle = sfKraftkontrolle;
            sfRepresentation = sfRepresentation;
            sfAuxiliator = sfAuxiliator;
            sfKraftkontrolle = sfKraftkontrolle;
            sfRingkunde = sfRingkunde;
            sfSemipermanenz2 = sfSemipermanenz2;
            sfStapeleffekt = sfStapeleffekt;
            sfSemipermanenz1 = sfSemipermanenz1;
            tawArcanovi = tawArcanovi;
            tawArcanoviMatrix = tawArcanoviMatrix;
            tawArcanoviSemipermanenz = tawArcanoviSemipermanenz;
            tawMagiekunde = tawMagiekunde;
            tawOdem = tawOdem;
            tawDestructibo = tawDestructibo;
            tawAnalys = tawAnalys;
            artefakttyp = artefakttyp;
            artefakttypAuxiliator = artefakttypAuxiliator;
            artefakttypMatrix = artefakttypMatrix;
            artefakttypTemp = artefakttypTemp;
            artefakttypSemipermanenz = artefakttypSemipermanenz;

            BindingList<Zauber> z = zauberListe;
            zauberListe = z;
        }

        private String SerializeObject(Object pObject)
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

            catch (Exception)
            {
                return null;
            }
        }

        private Object DeserializeObject(String pXmlizedString)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(DasArtefakt));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);

            return xs.Deserialize(memoryStream);
        }

        public void init()
        {
            WDA = true;
            optionAchSave = true;
            optionAllesBerechnen = false;
            optionNebeneffekteNeuWuerfeln = true;
            wirkendeZauberEnabled = true;

            tawArcanovi = tawArcanovi;
            tawArcanoviMatrix = tawArcanoviMatrix;
            sfStapeleffekt = sfStapeleffekt;
            selectedMaterial = 0;
            W6 = 4;
            W20 = 11;

        }

        public void loadArtefakt(string xmlArtefakt)
        {
            DasArtefakt art = (DasArtefakt)DeserializeObject(xmlArtefakt);
            magic.Clear();
            for (int i = 0; i < art.zauber.Count; i++ )
                magic.Add(art.zauber[i]);

            artefakt = art.artefakt;

            if (WDA)
            {
                switch ((int)artefakt.probe.superBig_zuschlag)
                {
                    case 0: extraExtraGross = 0; break;
                    case 5: extraExtraGross = 1; break;
                    case 10: extraExtraGross = 2; break;
                    case 15: extraExtraGross = 3; break;
                    case 20: extraExtraGross = 4; break;
                }
            }
            else
            {
                switch ((int)artefakt.probe.superBig_zuschlag)
                {
                    case 0: extraExtraGross = 0; break;
                    case 3: extraExtraGross = 1; break;
                    case 6: extraExtraGross = 2; break;
                    case 9: extraExtraGross = 3; break;
                    case 12: extraExtraGross = 4; break;
                }
            }
            selectedMaterial = 0;

            reInitArtefakt();
        }

        public string saveArtefakt()
        {
            DasArtefakt art = new DasArtefakt(artefakt, magic);
            string xml = SerializeObject(art);
            return xml;
        }

        public void exportArtefaktAsPDF(string path)
        {
            DasArtefakt art = new DasArtefakt(artefakt,magic);
            PDFExport.saveArtefaktAsPDF(art,path);
        }

        public void clearArtefakt()
        {
            artefakt = new Artefakt();
            zauberListe.Clear();
            extraExtraGross = 0;
            selectedMaterial = 0;
            reInitArtefakt();
        }

        public void generateArtefakt()
        {
            string resArcanovi = "";
            string resAnalys = "";
            string resDestructibo = "";

            if (zauberListe.Count > 0 || artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
            {
                // Material reinit
                mat = new MaterialSammlung(dice);
                artefakt.material = mat.sammlung[selectedMaterial];

                if (magic.Count >= 1 || artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
                {
                    // DEBUG
                    decimal agribaal_zfp = artefakt.agribaal;
                    decimal arcanovi_erschwernis = artefakt.probe.affine + artefakt.probe.ausloeser + artefakt.probe.material + artefakt.material.arcanovi_mod + artefakt.probe.superBig_zuschlag + artefakt.probe.erzwingen + artefakt.probe.stars + artefakt.probe.otherMods;
                    if (artefakt.probe.superBig_zuschlag == 0) arcanovi_erschwernis += artefakt.probe.groesse;
                    //spezielle Eigenschaften
                    if (artefakt.spezial_apport) arcanovi_erschwernis += 4;
                    if (artefakt.spezial_gespuer) arcanovi_erschwernis += 3;
                    if (artefakt.spezial_unzerbrechlich) arcanovi_erschwernis += 3;
                    if (WDA && artefakt.spezial_ferngespuer) arcanovi_erschwernis += (5 + artefakt.spezial_ferngespuer_komp);
                    if (WDA && artefakt.spezial_resistent) arcanovi_erschwernis += 2;
                    if (WDA && artefakt.typ == Artefakt.ArtefaktType.AUX && artefakt.spezial_reversalis) arcanovi_erschwernis += 4;
                    if (WDA && artefakt.spezial_variablerausloeser) arcanovi_erschwernis += (2 + artefakt.spezial_variablerausloeser_var);
                    if (WDA && artefakt.spezial_verschleierung) arcanovi_erschwernis += 3;
                    if (WDA && artefakt.spezial_verzehrend) arcanovi_erschwernis += 1;

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
                                default: magic_asp_mult = 1; break;
                            }
                        }
                    }
                    if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                    {
                        switch (artefakt.matrix_typ)
                        {
                            case Artefakt.MatrixType.STABIL: arcanovi_erschwernis += 2; if (WDA) magic_asp_mult = 2; break;
                            case Artefakt.MatrixType.SEHRSTABIL: arcanovi_erschwernis += 4; if (WDA) magic_asp_mult = 3; break;
                            case Artefakt.MatrixType.UNEMPFINDLICH: arcanovi_erschwernis += 6; if (WDA) magic_asp_mult = 4; break;
                            default: break;
                        }
                    }
                    if (WDA)
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

                    decimal arcanovi_zfp = artefakt.probe.zfpSternMod; // Arcanovi Erschwernis // TODO: Ist das hier wirklich "Arcanovi Erschwernis"? und nicht eher die notwendigen ZfP* für die Arcanovi Probe? wird zumindest so verwendet
                    decimal magic_asp = 0;
                    decimal eigene_rep_count = 0;

                    // Anzahl wirkende Sprueche
                    decimal nrOfCountRelevants = (magic.Count * magic_asp_mult * artefakt.loads);
                    decimal currentZfpAdd = 0;
                    if (artefakt.sf.vielfacheLadung && (artefakt.typ == Artefakt.ArtefaktType.NORMAL || artefakt.typ == Artefakt.ArtefaktType.RECHARGE || artefakt.typ == Artefakt.ArtefaktType.TEMP))
                        arcanovi_zfp += nrOfCountRelevants;
                    else
                        for (int i = 0; i < nrOfCountRelevants; i++ )
                        {
                            arcanovi_zfp += currentZfpAdd;
                            currentZfpAdd++;
                        }

                    // Anzahl Zauberdurchgaenge je wirkendem Spruch
                    // Semipermanent bei zB 3 mal pro Monat muss 3*2=6 mal der Zauber gesprochen werden (2 für Monat, 3 wegen 3 Ladungen)
                    // Kann durch SF SemiP2 verbessert werden, was aber schon in "magic_asp_mult" steckt (siehe oben)
                    decimal[] magicNumOfCasts = new decimal[magic.Count];

                    // Komplexität
                    for (int i = 0; i < magic.Count; i++)
                    {
                        // Rep
                        if (magic[i].eigene_rep) eigene_rep_count++;
                        // komplexität
                        switch (magic[i].komp)
                        {
                            case Zauber.Komplexitaet.A: break;
                            case Zauber.Komplexitaet.B: arcanovi_zfp += 1 * artefakt.loads * magic_asp_mult; break;
                            case Zauber.Komplexitaet.C: arcanovi_zfp += 1 * artefakt.loads * magic_asp_mult; break;
                            case Zauber.Komplexitaet.D: arcanovi_zfp += 2 * artefakt.loads * magic_asp_mult; break;
                            case Zauber.Komplexitaet.E: arcanovi_zfp += 2 * artefakt.loads * magic_asp_mult; break;
                            default: arcanovi_zfp += 3 * artefakt.loads * magic_asp_mult; break;
                        }

                        // Stapel
                        if (magic[i].staple > 1)
                            arcanovi_zfp += magic[i].staple * 2;
                        //{ // TODO: Diskutieren oder konfigurierbar machen:
                        //    if (artefakt.sf.hyper) //SF:Hypervehemenz: WdA S.109 ergänzt WdZ S.55 wo wiederum auf SRD S.123 verwiesen wird. Dort steht, dass mit dieser SF die notwendigen ZfP* nur 1 pro Stapel steigen und nicht 2
                        //        arcanovi_zfp += magic[i].staple * 1;
                        //    else
                        //        arcanovi_zfp += magic[i].staple * 2;
                        //}
                        // AsP wirkende Sprüche
                        decimal thismagic_asp = magic[i].asp + artefakt.material.asp_mod;

                        if (artefakt.sf.rep == SF.SFType.ACH && optionAchSave) 
                            thismagic_asp = Round(thismagic_asp * 3 / 4);

                        if (artefakt.sf.kraftkontrolle) 
                            thismagic_asp -= 1;

                        if (artefakt.limbus)
                            thismagic_asp = Round(thismagic_asp / 10);

                        if (thismagic_asp == 0) 
                            thismagic_asp = 1;

                        magicNumOfCasts[i] = artefakt.loads * magic[i].staple * magic_asp_mult * magic_asp_mult_extra;
                        magic_asp += thismagic_asp * magicNumOfCasts[i];
                    }

                    // Anzahl Ladungen
                    if (artefakt.typ != Artefakt.ArtefaktType.SEMI) // WDA S.83 "Anzahl der Ladungen"
                        arcanovi_zfp += (artefakt.loads - 1) * 3;
                    else
                        arcanovi_erschwernis += artefakt.loads - 1; // WdA S.82 "Kategorie und Präservanz" "jede zusätzliche Anwendung pro Intervall erhöht den Probenzuschlag um +1"

                    if (artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
                        magic_asp = artefakt.kraftspeicher_asp;

                    if (artefakt.limbus)
                    {
                        // Diese Rechnung magic_asp = Round(magic_asp / 10); passiert nun nicht mehr hier für die Summe der Kosten sondern oben JE zauber, 
                        // da jeder Zauber auch im Limbus für sich alleine schon 1AsP kostet und nicht etwa 9 Zauber a 6 AsP = 9*6=54, 54/10=5 denn korrekt ist leider 9*1=9

                        arcanovi_erschwernis += 15;
                    }

                    if (magic_asp <= 0) 
                        magic_asp = 1;

                    if (artefakt.gemeinschaftlich) 
                        arcanovi_erschwernis += 5;

                    // Arcanovi TAW
                    decimal arcanovi_taw = 0;
                    switch (artefakt.typ)
                    {
                        case Artefakt.ArtefaktType.MATRIX: arcanovi_taw = artefakt.taw.arcanovi_matrix; break;
                        case Artefakt.ArtefaktType.AUX: if (WDA) arcanovi_taw = artefakt.taw.arcanovi_matrix; break;
                        case Artefakt.ArtefaktType.SEMI: arcanovi_taw = artefakt.taw.arcanovi_semi; break;
                        default: arcanovi_taw = artefakt.taw.arcanovi; break;
                    }

                    // Arcanovi mit Agribaal
                    decimal arcanovi_count = 1;
                    decimal agribaal_for_arcanovi = agribaal_zfp;
                    decimal arcanovi_taw_new = 0; // Uebrige ZfP* pro Arcanovi Durchfuehrung
                    while (true)
                    {
                        arcanovi_taw_new = arcanovi_taw - arcanovi_erschwernis;
                        if (arcanovi_taw_new == 0) arcanovi_taw_new = 1;
                        if (arcanovi_taw_new > arcanovi_taw) arcanovi_taw_new = arcanovi_taw;
                        if (arcanovi_taw_new > 0)
                        {
                            arcanovi_count = Math.Ceiling(arcanovi_zfp / arcanovi_taw_new);
                            if (arcanovi_count == 0)
                                arcanovi_count = 1;
                        }
                        if ((arcanovi_taw_new < 0 || arcanovi_count > 1) && agribaal_zfp > 0)
                        {
                            --agribaal_zfp;
                            --arcanovi_erschwernis;
                        }
                        else break;
                    }

                    arcanovi_count += artefakt.special_additional_arcanovi;
                    decimal arcanovi_zfpLeft = arcanovi_count * arcanovi_taw_new - arcanovi_zfp;

                    agribaal_for_arcanovi = agribaal_for_arcanovi - agribaal_zfp;

                    decimal arcanovi_asp = 0;
                    decimal arcanovi_special_w = 0;
                    decimal arcanovi_special_w_asp = 0;
                    decimal arcanovi_special_asp = 0;
                    //arcanovi_special_w += artefakt.probe.superBig_asp_w;
                    decimal arcanovi_base_asp = 0;
                    arcanovi_base_asp = 10;
                    if (!WDA && artefakt.typ == Artefakt.ArtefaktType.TEMP)
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

                    if (arcanovi_base_asp < 1)
                        arcanovi_base_asp = 1;

                    arcanovi_asp += arcanovi_count * arcanovi_base_asp;


                    // Spezielle eigenschaften
                    if (artefakt.spezial_siegel) arcanovi_special_w += 1;
                    if (artefakt.spezial_unzerbrechlich) arcanovi_special_w += 6;
                    if (artefakt.spezial_gespuer) arcanovi_special_w += 3;
                    if (artefakt.spezial_apport) arcanovi_special_w += 4;
                    if (WDA && artefakt.spezial_ferngespuer) { arcanovi_special_w += 2; arcanovi_special_w_asp += artefakt.spezial_ferngespuer_asp; };
                    if (WDA && artefakt.spezial_resistent) arcanovi_special_w += 4;
                    if (WDA && artefakt.spezial_reperatur) arcanovi_special_w += 5;
                    if (WDA && artefakt.spezial_reversalis) { arcanovi_special_w += 2; arcanovi_special_w_asp += 7; }
                    if (WDA && artefakt.spezial_variablerausloeser) arcanovi_special_w += 2;
                    if (WDA && artefakt.spezial_verschleierung) arcanovi_special_w += 3;
                    if (WDA && artefakt.spezial_verzehrend) arcanovi_special_w_asp -= Round(artefakt.spezial_verzehrend_var / 10);

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
                        case Artefakt.ArtefaktType.TEMP: pasp = Round(Math.Floor((Math.Floor((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20)) / 2) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.NORMAL: pasp = Round(Math.Floor((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.RECHARGE: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 15) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.MATRIX: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.SEMI: pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 10) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.AUX: if (WDA) pasp = Round(Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 15) * artefakt.material.pasp_mod); break;
                        case Artefakt.ArtefaktType.SPEICHER: pasp = Round(Math.Floor((magic_asp + arcanovi_asp + arcanovi_special_asp) / 10) * artefakt.material.pasp_mod) + Round(dice.W6 / 2); break;
                        default: break;
                    }
                    if (pasp <= 0 && !(artefakt.typ == Artefakt.ArtefaktType.TEMP) && !(artefakt.kristalle))
                        pasp = 1;
                    if (artefakt.kristalle && pasp > 0) pasp -= 1;

                    // Erschwerniss Wirkende Zauber
                    decimal magic_erschwerniss = 2 + artefakt.material.wirkende_mod + artefakt.probe.wirkenderSpruchMod;
                    if (artefakt.gemeinschaftlich) magic_erschwerniss += 5;

                    // Nebeneffekte
                    decimal neben_probe_count = Math.Floor(pasp / 2);
                    decimal neben_count = 0;
                    decimal neben_agribaal_mod = (artefakt.agribaal > 0) ? -3 : 0;
                    for (int i = 0; i < neben_probe_count; i++)
                        if ((dice.W20 + artefakt.material.nebenwirkung_mod + artefakt.special_ort_neben + neben_agribaal_mod) <= pasp) neben_count++;
                    List<int> nebensNumbers = new List<int>();
                    int nRun = 0;
                    int ignoredNebens = 0;
                    // This is to check for doubles
                    if (optionAllesBerechnen)
                    {
                        while (neben_count > 0)
                        {
                            int number = (int)(dice.W20 + dice.W20 + artefakt.material.nebenwirkung_art_mod);
                            // check for double descr
                            bool addNumber = true;
                            foreach (int elem in nebensNumbers)
                            {
                                if (nebeneffekte.getNebeneffektDescr(WDA, elem) == nebeneffekte.getNebeneffektDescr(WDA, number))
                                {
                                    addNumber = false;
                                    break;
                                }
                            }
                            if (addNumber) nebensNumbers.Insert(nebensNumbers.Count, number);
                            else if (optionNebeneffekteNeuWuerfeln)
                                continue;
                            else
                                ignoredNebens++;
                            nRun++;
                            if (nRun >= neben_count) break;
                        }
                        nebensNumbers.Sort();
                    }

                    List<string> nebens = new List<string>();
                    foreach(int elem in nebensNumbers)
                        nebens.Add("\t" + elem + ": " + nebeneffekte.getNebeneffektDescr(WDA, elem) + "\r\n");

                    if ((arcanovi_taw - arcanovi_erschwernis >= 0))
                    {
                        if (arcanovi_taw >= 7 && artefakt.taw.magiekunde >= 7)
                        {
                            resArcanovi += ("Erstellung der Artefaktthesis benötigt " + arcanovi_zfp + " ZE (=" + arcanovi_zfp * 2 + " h)\r\n");
                            resArcanovi += ("Zu Papier bringen mit Magiekunde & Malen/Zeichnen, zusammen erschwert um " + arcanovi_zfp + "\r\n");
                        }
                        else
                            resArcanovi += ("Artefaktthesis kann nicht selber erstellt werden. TaW ARCANOVI bzw. Magiekunde zu gering.\r\n\r\n");

                        if (artefakt.agribaal == 0)
                            resArcanovi += ("Erschwernis für Arcanovi: " + arcanovi_erschwernis + "\r\n");
                        else
                            resArcanovi += ("Erschwernis für Arcanovi: " + arcanovi_erschwernis + " (erleichterung von " + agribaal_for_arcanovi + " durch Agribaal)\r\n");

                        resArcanovi += ("Erforderliche Arcanovi ZfP*: " + arcanovi_zfp + "\r\n");
                        if (!(artefakt.typ == Artefakt.ArtefaktType.SPEICHER))
                        {
                            resArcanovi += ("Bester Fall: " + arcanovi_count + " Arcanovi für " + arcanovi_asp + " AsP  (" + arcanovi_taw_new + " ZfP* je Arcanovi)\r\n");
                            if (artefakt.agribaal == 0)
                                resArcanovi += ("Erschwernis wirkende Sprüche: " + magic_erschwerniss + "\r\n");
                            else
                                resArcanovi += ("Erschwernis wirkende Sprüche: " + (magic_erschwerniss - agribaal_zfp) + "(erleichterung von " + agribaal_zfp + " durch Agribaal)\r\n");

                            resArcanovi += ("Arcanovi ZfP* zur weiteren Verwendung: " + arcanovi_zfpLeft + " wobei " + 2*arcanovi_taw + " = 2*ZfW maximal erlaubt sind\r\n");
                            resArcanovi += ("AsP für wirkende Sprüche: " + magic_asp + "\r\n");
                        }
                        else
                        {
                            resArcanovi += ("speicherbare AsP: " + magic_asp + "\r\n");
                        }

                        string sArcanoviSpecialAsP = "";
                        string sArcanoviSpecialDiv = "";
                        if (arcanovi_special_w_asp > 0)
                            sArcanoviSpecialAsP = " + " + arcanovi_special_w_asp;
                        if (artefakt.sf.ringkunde)
                            sArcanoviSpecialDiv = "/ 2";
                        if (artefakt.sf.ringkunde)
                            resArcanovi += ("AsP gesamt: " + (magic_asp + arcanovi_asp) + " + (" + arcanovi_special_w + " W6" + sArcanoviSpecialAsP + ") " + sArcanoviSpecialDiv + " + " + artefakt.probe.superBig_asp_w + " W20 = " + (magic_asp + arcanovi_asp + arcanovi_special_asp) + "\r\n");
                        else
                            resArcanovi += ("AsP gesamt: " + (magic_asp + arcanovi_asp) + " + " + arcanovi_special_w + " W6" + sArcanoviSpecialAsP + sArcanoviSpecialDiv + " + " + artefakt.probe.superBig_asp_w + " W20 = " + (magic_asp + arcanovi_asp + arcanovi_special_asp) + "\r\n");

                        if (!(artefakt.typ == Artefakt.ArtefaktType.SPEICHER) || WDA)
                            resArcanovi += ("pAsP gesamt: " + pasp + "\r\n");
                        else resArcanovi += ("pAsP gesamt: " + pasp + " (inkl. W3)\r\n");

                        //Kraftspeicher Einschränkung
                        if (optionAllesBerechnen && artefakt.typ == Artefakt.ArtefaktType.SPEICHER)
                        {
                            int number = (int)(dice.W6 + dice.W6 + arcanovi_taw - arcanovi_erschwernis);
                            resArcanovi += ("Einschränkung: " + number + ": " + (kraftspeicher.getEinschraenkungDescr(WDA, number)) + " (maximale ZfP* angenommen)\r\n");
                        }

                        //Nebens
                        resArcanovi += ("Anzahl Nebeneffektproben: " + neben_probe_count);
                        if (optionAllesBerechnen && neben_probe_count > 0)
                        {
                            resArcanovi += (" => " + (neben_count - ignoredNebens) + " Nebeneffekte\r\n");
                            for (int i = 0; i < nebens.Count; i++)
                                resArcanovi += (nebens[i]);
                            //resArcanovi += (" )\r\n");
                        }
                        else resArcanovi += "\r\n";

                        //Occupation
                        if (optionAllesBerechnen)
                        {
                            decimal occ_wurf = dice.W20;
                            decimal limbus_mod = artefakt.limbus ? -7 : 0;
                            decimal namenlos_mod = artefakt.namenlos ? -3 : 0;
                            decimal agribaal_mod = (artefakt.agribaal > 0) ? -3 : 0;
                            if ((occ_wurf + artefakt.material.occupation_mod + limbus_mod + namenlos_mod + artefakt.special_ort_occ + agribaal_mod) <= pasp)
                                resArcanovi += ("Occupation: " + occ.occupationName(dice.W20 + artefakt.material.occupation_art_mod) + "\r\n");
                            else resArcanovi += ("Occupation: keine\r\n");
                        }

                        // Zauberdurchgaenge pro Zauber:
                        if (artefakt.typ != Artefakt.ArtefaktType.SPEICHER)
                        {
                            resArcanovi += "Anzahl Zauberdurchgaenge je wirkendem Spruch: ";
                            for (int i = 0; i < magic.Count; i++)
                            {
                                resArcanovi += "Spruch" + (i + 1) + ":" + magicNumOfCasts[i] + "x";
                                if (i < magic.Count - 1) // current i ist not last i
                                    resArcanovi += "  ";
                                else
                                    resArcanovi += "\r\n";
                            }
                        }
                    }
                    else
                    {
                        resArcanovi += ("Artefakt nicht möglich. ZfW Arcanovi zu gering.");
                    }

                    // Analys

                    decimal odem_erschwernis = 0;
                    if (WDA)
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
                    if (tawMagie > 0) analys_erschwernis -= Math.Floor(tawMagie / 3);

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
                        if (artefakt.sf.rep == SF.SFType.ACH && optionAchSave) analys_asp = 8;
                        if (artefakt.sf.kraftkontrolle) analys_asp -= (1 + analys_count);
                        if (artefakt.sf.rep == SF.SFType.ACH && optionAchSave)
                            analys_asp += (analys_count - 1) * 2;
                        else
                            analys_asp += (analys_count - 1) * 3;

                        resAnalys += ("ODEM erschwert um " + odem_erschwernis + " (maximal " + odem_zfpstar + " ZfP*)\r\n");
                        resAnalys += ("ANALYS erschwert um " + txt_analys_erschwernis + "\r\n");
                        resAnalys += ("Bester Fall: Vollständige Entschlüsselung nach " + analys_count + " ANALYS\r\n");
                        resAnalys += ("Kosten für ODEM & ANALYS: " + analys_asp + "AsP\r\n");
                    }
                    else
                    {
                        resAnalys += ("Artefakt nicht analysierbar. TaW ANALYS zu gering.");
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

                    resDestructibo += ("Erschwernis DESTRUCTIBO: " + destruct_erschwernis + "\r\n");

                    // Destructibo Einstimmung
                    decimal destruct_einstimmung = Math.Floor(artefakt.taw.analys / 4);
                    resDestructibo += ("Maximal " + (destruct_einstimmung * 4) + " Stunden Einstimmung\r\n");
                    destruct_erschwernis -= destruct_einstimmung;

                    decimal destruct_analys_asp = 0;
                    if (artefakt.taw.destructibo - destruct_erschwernis >= 0)
                        resDestructibo += ("Bester Fall: 0 ANALYS\r\n");
                    else if (Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3) > 0)
                    {
                        decimal destruct_analys_count = Math.Ceiling((destruct_erschwernis - artefakt.taw.destructibo) / Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3));
                        destruct_analys_asp = 10;
                        if (artefakt.sf.rep == SF.SFType.ACH && optionAchSave) destruct_analys_asp = 8;
                        if (artefakt.sf.kraftkontrolle) destruct_analys_asp -= 2;
                        if (artefakt.sf.rep == SF.SFType.ACH && optionAchSave)
                            destruct_analys_asp += (destruct_analys_count - 1) * 2;
                        else
                            destruct_analys_asp += (destruct_analys_count - 1) * 3;

                        resDestructibo += ("Bester Fall: " + destruct_analys_count + " ANALYS für insg. " + destruct_analys_asp + " AsP\r\n");

                        destruct_erschwernis -= Math.Floor(destruct_analys_count * (artefakt.taw.analys - analys_erschwernis) / 3);
                    }
                    if (artefakt.taw.destructibo - destruct_erschwernis >= 0 || Math.Floor((artefakt.taw.analys - analys_erschwernis) / 3) > 0)
                    {
                        resDestructibo += ("DESTRUCTIBO Gesamterschwernis: " + destruct_erschwernis + "\r\n");
                        resDestructibo += ("Gesamt-AsP Kosten: " + (destruct_analys_asp + (magic_asp + arcanovi_asp + arcanovi_special_asp)) + "\r\n");
                        decimal destruct_pasp = Round((magic_asp + arcanovi_asp + arcanovi_special_asp) / 20);
                        if (destruct_pasp <= 0) destruct_pasp = 1;
                        resDestructibo += ("pAsP Kosten: " + destruct_pasp + "\r\n");
                    }
                    else
                        resDestructibo += ("Zerstörung nicht möglich TaW DESTRUCTIBO bzw. ANALYS zu gering.\r\n");

                }
            }
            if (resArcanovi != resultArcanovi) resultArcanovi = resArcanovi;
            if (resAnalys != resultAnalys) resultAnalys = resAnalys;
            if (resDestructibo != resultDestructibo) resultDestructibo = resDestructibo;

        }

        #endregion

        #region PlugIn Functions

        private uint getValueInAttribute(XmlAttributeCollection attributes)
        {
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.Name == "value")
                    return Convert.ToUInt32(attrib.Value);
            }
            return 0;
        }

        private string getVariantInAttribute(XmlAttributeCollection attributes)
        {
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.Name == "variante")
                    return (attrib.Value);
            }
            return "";
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
            bool kraftkontrolle = false;
            bool vielLadung = false;
            bool stapeleffekt = false;
            bool hyper = false;
            bool matrixgeber = false;
            bool semiI = false;
            bool semiII = false;
            bool aux = false;
            bool kraftspeicher = false;

            bool isMag = false;
            bool isAch = false;
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList sonderNodes = xmlDoc.GetElementsByTagName("sonderfertigkeit");
            foreach (XmlNode sonderNode in sonderNodes)
            {
                foreach (XmlAttribute val in sonderNode.Attributes)
                {
                    if (val.Name == "name")
                    {
                        if (val.Value == "Kraftkontrolle")
                            kraftkontrolle = true;
                        if (val.Value == "Vielfache Ladungen")
                            vielLadung = true;
                        if (val.Value == "Stapeleffekt")
                            stapeleffekt = true;
                        if (val.Value == "Hypervehemenz")
                            hyper = true;
                        if (val.Value == "Matrixgeber")
                            matrixgeber = true;
                        if (val.Value == "Semipermanenz I")
                            semiI = true;
                        if (val.Value == "Semipermanenz II")
                            semiII = true;
                        if (val.Value == "Kraftspeicher")
                            kraftspeicher = true;
                        if (val.Value == "Auxiliator")
                            aux = true;
                        if (val.Value == "Repräsentation: Magier")
                            isMag = true;
                        if (val.Value == "Repräsentation: Kristallomant")
                            isAch = true;
                    }
                }
            }

            // Default: Magier
            if (!isMag && !isAch)
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

            XmlNodeList heldNode = xmlDoc.GetElementsByTagName("held");
            if (heldNode.Count > 0)
            {
                foreach (XmlAttribute attrb in heldNode[0].Attributes)
                {
                    if (attrb.Value == "name")
                        name = attrb.Value;
                }
            }

            XmlNodeList talentNodes = xmlDoc.GetElementsByTagName("talent");
            foreach (XmlNode talentNode in talentNodes)
            {
                foreach (XmlAttribute val in talentNode.Attributes)
                {
                    if (val.Value == "Magiekunde")
                        magiekunde = getValueInAttribute(talentNode.Attributes);
                }
            }

            XmlNodeList zauberNodes = xmlDoc.GetElementsByTagName("zauber");
            foreach (XmlNode zauberNode in zauberNodes)
            {
                foreach (XmlAttribute val in zauberNode.Attributes)
                {
                    if (val.Value == "Analys Arkanstruktur")
                        analys = getValueInAttribute(zauberNode.Attributes);
                    if (val.Value == "Arcanovi Artefakt" && getVariantInAttribute(zauberNode.Attributes) == "")
                        arcanovi = getValueInAttribute(zauberNode.Attributes);
                    if (val.Value == "Arcanovi Artefakt" && getVariantInAttribute(zauberNode.Attributes) == "Matrixgeber")
                        arcanovi_matrix = getValueInAttribute(zauberNode.Attributes);
                    if (val.Value == "Arcanovi Artefakt" && getVariantInAttribute(zauberNode.Attributes) == "Semipermanenz")
                        arcanovi_semi = getValueInAttribute(zauberNode.Attributes);
                    if (val.Value == "Odem Arcanum")
                        odem = getValueInAttribute(zauberNode.Attributes);
                    if (val.Value == "Destructibo Arcanitas")
                        destructibo = getValueInAttribute(zauberNode.Attributes);
                }
            }

            return plugInHero(name, (isMag ? SF.SFType.OTHER : SF.SFType.ACH), kraftkontrolle, vielLadung, stapeleffekt, hyper, matrixgeber, semiI, semiII, false, kraftspeicher, aux, arcanovi, arcanovi_matrix, arcanovi_semi, odem, analys, destructibo, magiekunde);
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
            bool sfKraftspeicher,
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
            this.sfRepresentation = (int)representation;
            this.sfKraftkontrolle = sfKraftkontrolle;
            this.sfVielfacheLadung = sfVielfacheLadung;
            this.sfStapeleffekt = sfStapeleffekt;
            this.sfHypervehemenz = sfHypervehemenz;
            this.sfMatrixgeber = sfMatrixgeber;
            this.sfSemipermanenz1 = sfSemipermI;
            this.sfSemipermanenz2 = sfSemipermII;
            this.sfRingkunde = sfRingkunde;
            this.sfKraftspeicher = sfKraftspeicher;
            this.sfAuxiliator = sfAuxiliator;

            this.tawArcanovi = (int)tawArcanovi;
            this.tawArcanoviMatrix = (int)tawArcanoviMatrix;
            this.tawArcanoviSemipermanenz = (int)tawArcanoviSemi;
            this.tawAnalys = (int)tawAnalys;
            this.tawDestructibo = (int)tawDestructibo;
            this.tawMagiekunde = (int)tawMagiekunde;
            this.tawOdem = (int)tawOdem;

            this.heldName = name;

            return true;
        }
        public bool plugInHero(
            SF.SFType representation,
            bool sfKraftkontrolle,
            bool sfVielfacheLadung,
            bool sfStapeleffekt,
            bool sfHypervehemenz,
            bool sfMatrixgeber,
            bool sfSemipermI,
            bool sfSemipermII,
            bool sfRingkunde,
            bool sfKraftspeicher,
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
            return plugInHero("", representation, sfKraftkontrolle, sfVielfacheLadung, sfStapeleffekt, sfHypervehemenz, sfMatrixgeber, sfSemipermI, sfSemipermII, sfRingkunde, sfKraftspeicher, sfAuxiliator, tawArcanovi, tawArcanoviMatrix, tawArcanoviSemi, tawOdem, tawAnalys, tawDestructibo, tawMagiekunde);
        }

        #endregion

    }
}
