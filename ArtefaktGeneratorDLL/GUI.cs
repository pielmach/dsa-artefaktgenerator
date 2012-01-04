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
        public bool sfMatrixgeber
        {
            get
            {
                return artefakt.sf.matrix;
            }
            set
            {
                artefakt.sf.matrix = value;
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
                if (value) sfSemipermanenz2Enabled = true;
                else sfSemipermanenz2Enabled = false;
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
        [System.NonSerialized]
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
            get
            {
                return artefakt.sf.auxiliator;
            }
            set
            {
                artefakt.sf.auxiliator = value;
                RaisePropertyChanged("sfAuxiliator");
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
            set { artefakt.typ = (Artefakt.ArtefaktType)value; RaisePropertyChanged("artefakttyp"); }
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
