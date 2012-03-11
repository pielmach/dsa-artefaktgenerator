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
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;



namespace ArtefaktGenerator
{
    [XmlRootAttribute(ElementName = "Artefakt", IsNullable = false)]
    public class Artefakt
    {
        public string heldName = "";

        public SF sf = new SF();

        public TaW taw = new TaW();

        public Probe probe = new Probe();

        public Analys analys = new Analys();

        public Destructibo destructibo = new Destructibo();

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

        public decimal agribaal = 0;

        public decimal special_ort_occ = 0;

        public decimal special_ort_neben = 0;

        public decimal loads = 1;

        public Material material = new Material("kein");

        public bool kristalle = false;

        public string occupation_name = "keine";

        public enum Regelbasis : short { WDA = 0, SRD = 1 };

        public Regelbasis regelbasis = Regelbasis.WDA;

        public bool debugMode = true;
    }
}
