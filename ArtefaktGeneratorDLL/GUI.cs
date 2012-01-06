using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ArtefaktGenerator
{
    public class GUI : INotifyPropertyChanged
    {
        private Artefakt artefakt = new Artefakt();
        private List<Zauber> magic = new List<Zauber>();

        #region Options
        public bool WDA
        {
            get { return artefakt.regelbasis == Artefakt.Regelbasis.WDA; }
            set { 
                if (value) 
                {
                    extraKristalleVisible = false;
                    extraKristalle = false;
                    artefakt.regelbasis = Artefakt.Regelbasis.WDA;
                    sfAuxiliatorVisible = true;

                    spezialFerngespuerVisible = true;
                    spezialResistenzVisible = true;
                    spezialSelbstreparaturVisible = true;
                    spezialUmkehrtalismanVisible = true;
                    spezialVariablerAusloeserVisible = true;
                    spezialVerschleierungVisible = true;
                    spezialVerzehrendVisible = true;
                }
                else
                {
                    if (sfRepresentation == (int)SF.SFType.ACH)
                        extraKristalleVisible = true;
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
                }
            }
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
                if (artefakt.sf.rep == SF.SFType.ACH && !WDA)
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
                }
                else
                {
                    sfHypervehemenzEnabled = false;
                    sfHypervehemenz = false;
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
                RaisePropertyChanged("sfHypervehemenz");
            }
        }
        public bool _sfHypervehemenzEnabled;
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
                }
                else
                {
                    sfSemipermanenz2Enabled = false;
                    sfSemipermanenz2 = false;
                    artefakttypSemipermanenzEnabled = false;
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
        public bool semi2_enabled;
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
        public bool _sfAuxiliatorEnabled;
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
        public bool _sfAuxiliatorVisible;
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
            set { artefakt.taw.arcanovi = (decimal)value; RaisePropertyChanged("tawArcanovi"); }
        }
        public int tawArcanoviMatrix
        {
            get { return (int)artefakt.taw.arcanovi_matrix; }
            set { artefakt.taw.arcanovi_matrix = (decimal)value; RaisePropertyChanged("tawArcanoviMatrix"); }
        }
        public bool _tawArcanoviMatrixEnabled;
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
        public bool _tawArcanoviSemipermanenzEnabled;
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
                if (artefakt.typ == Artefakt.ArtefaktType.MATRIX)
                    artefakttypMatrixVisible = true;
                else artefakttypMatrixVisible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.SEMI)
                    artefakttypSemipermanenzVisible = true;
                else artefakttypSemipermanenzVisible = false;
                if (artefakt.typ == Artefakt.ArtefaktType.AUX)
                    artefakttypAuxiliatorVisible = true;
                else artefakttypAuxiliatorVisible = false;

                RaisePropertyChanged("artefakttyp"); 
            }
        }

        public int artefakttypTemp
        {
            get { return (int)artefakt.temp_typ; }
            set { artefakt.temp_typ = (Artefakt.TempType)value; RaisePropertyChanged("artefakttypTemp"); }
        }
        public bool _artefakttypTempVisible;
        public bool artefakttypTempVisible
        {
            get { return _artefakttypTempVisible; }
            set { _artefakttypTempVisible = value; RaisePropertyChanged("artefakttypTempVisible"); }
        }

        public int artefakttypMatrix
        {
            get { return (int)artefakt.matrix_typ; }
            set { artefakt.matrix_typ = (Artefakt.MatrixType)value; RaisePropertyChanged("artefakttypMatrix"); }
        }
        public bool _artefakttypMatrixVisible;
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
        public bool _artefakttypSemipermanenzVisible;
        public bool artefakttypSemipermanenzVisible
        {
            get { return _artefakttypSemipermanenzVisible; }
            set { _artefakttypSemipermanenzVisible = value; RaisePropertyChanged("artefakttypSemipermanenzVisible"); }
        }
        public bool _artefakttypSemipermanenzEnabled;
        public bool artefakttypSemipermanenzEnabled
        {
            get { return _artefakttypSemipermanenzEnabled; }
            set { _artefakttypSemipermanenzEnabled = value; RaisePropertyChanged("artefakttypSemipermanenzEnabled"); }
        }

        public int artefakttypAuxiliator
        {
            get { return (int)artefakt.aux_typ; }
            set { artefakt.aux_typ = (Artefakt.MatrixType)value; RaisePropertyChanged("artefakttypAuxiliator"); }
        }
        public bool _artefakttypAuxiliatorVisible;
        public bool artefakttypAuxiliatorVisible
        {
            get { return _artefakttypAuxiliatorVisible; }
            set { _artefakttypAuxiliatorVisible = value; RaisePropertyChanged("artefakttypAuxiliatorVisible"); }
        }
        public bool _artefakttypAuxiliatorEnabled;
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
        public bool _spezialResistenzVisible;
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
        public bool _spezialSelbstreparaturVisible;
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
        public bool _spezialFerngespuerVisible;
        public bool spezialFerngespuerVisible
        {
            get { return _spezialFerngespuerVisible; }
            set { _spezialFerngespuerVisible = value; RaisePropertyChanged("spezialFerngespuerVisible"); }
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
        public bool _spezialUmkehrtalismanVisible;
        public bool spezialUmkehrtalismanVisible
        {
            get { return _spezialUmkehrtalismanVisible; }
            set { _spezialUmkehrtalismanVisible = value; RaisePropertyChanged("spezialUmkehrtalismanVisible"); }
        }

        public bool spezialVariablerAusloeser
        {
            get { return artefakt.spezial_variablerausloeser; }
            set { artefakt.spezial_variablerausloeser = value; RaisePropertyChanged("spezialVariablerAusloeser"); }
        }
        public bool _spezialVariablerAusloeserVisible;
        public bool spezialVariablerAusloeserVisible
        {
            get { return _spezialVariablerAusloeserVisible; }
            set { _spezialVariablerAusloeserVisible = value; RaisePropertyChanged("spezialVariablerAusloeserVisible"); }
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
        public bool _spezialVerschleierungVisible;
        public bool spezialVerschleierungVisible
        {
            get { return _spezialVerschleierungVisible; }
            set { _spezialVerschleierungVisible = value; RaisePropertyChanged("spezialVerschleierungVisible"); }
        }

        public bool spezialVerzehrend
        {
            get { return artefakt.spezial_verzehrend; }
            set { artefakt.spezial_verzehrend = value; RaisePropertyChanged("spezialVerzehrend"); }
        }
        public bool _spezialVerzehrendVisible;
        public bool spezialVerzehrendVisible
        {
            get { return _spezialVerzehrendVisible; }
            set { _spezialVerzehrendVisible = value; RaisePropertyChanged("spezialVerzehrendVisible"); }
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

        public int _extraExtraGross;
        public int extraExtraGross
        {
            get { return _extraExtraGross; }
            set { 
                _extraExtraGross = value;
                RaisePropertyChanged("extraExtraGross"); 
            }
        }

        //Material


        public bool extraKristalle
        {
            get { return artefakt.kristalle; }
            set { artefakt.kristalle = value; RaisePropertyChanged("extraKristalle"); }
        }
        public bool _extraKristalleVisible;
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
        public int probeGroesse
        {
            get { return (int)artefakt.probe.groesse; }
            set { artefakt.probe.groesse = (decimal)value; RaisePropertyChanged("probeGroesse"); }
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
        #endregion

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion
    }
}
