﻿using System.Xml.Serialization;

namespace ArtefaktGenerator
{
    [XmlRootAttribute(ElementName = "Artefakt", IsNullable = false)]
    public class Artefakt
    {
        public string heldName = "";

        public SF sf = new();

        public TaW taw = new();

        public Probe probe = new();

        public Analys analys = new();

        public Destructibo destructibo = new();

        public enum ArtefaktType : short { TEMP = 0, NORMAL = 1, RECHARGE = 2, MATRIX = 3, SEMI = 4, AUX = 5, SPEICHER = 6 };

        public ArtefaktType typ = ArtefaktType.NORMAL;

        public enum TempType : short { TAG = 0, WOCHE = 1, MONAT = 2 };

        public TempType temp_typ = TempType.WOCHE;

        public enum SemiType : short { TAG = 0, WOCHE = 1, MONAT = 2, JAHR = 3 };

        public SemiType semi_typ = SemiType.MONAT;

        public enum MatrixType : short { LABIL = 0, STABIL = 1, SEHRSTABIL = 2, UNEMPFINDLICH = 3 };

        public MatrixType matrix_typ = MatrixType.SEHRSTABIL;

        public MatrixType aux_typ = MatrixType.SEHRSTABIL;

        public decimal kraftspeicher_asp = 10;

        public bool aux_merkmal = false;

        public bool spezial_siegel = false;

        public bool spezial_unzerbrechlich = false;

        public bool spezial_gespuer = false;

        public bool spezial_apport = false;

        public bool spezial_ferngespuer = false;

        public decimal spezial_ferngespuer_komp = 1;

        public decimal spezial_ferngespuer_asp = 1;

        public bool spezial_resistent = false;

        public bool spezial_reperatur = false;

        public bool spezial_reversalis = false;

        public bool spezial_variablerausloeser = false;

        public decimal spezial_variablerausloeser_var = 0;

        public bool spezial_verschleierung = false;

        public bool spezial_verzehrend = false;

        public decimal spezial_verzehrend_var = 1;

        public bool nebeneffekte = true;

        public bool occupation = true;

        public bool limbus = false;

        public bool namenlos = false;

        public bool gemeinschaftlich = false;

        public decimal agribaal = 0;

        public decimal special_ort_occ = 0;

        public decimal special_ort_neben = 0;

        public decimal special_additional_arcanovi = 0;

        public decimal loads = 1;

        public Material material = new("kein");

        public bool kristalle = false;

        public string occupation_name = "keine";

        public enum Regelbasis : short { WDA = 0, SRD = 1 };

        public Regelbasis regelbasis = Regelbasis.WDA;

        public bool debugMode = true;
    }
}
