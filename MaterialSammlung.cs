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
//using System.Linq;
using System.Text;

namespace ArtefaktGenerator
{
    public class MaterialSammlung
    {
        public List<Material> sammlung = new List<Material>();

        public MaterialSammlung(Wuerfel dice)
        {
            sammlung.Add(new Material("kein",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Mindorium",0,2,0,0.75m,-5,7,-6,0));
            sammlung.Add(new Material("Amulettmetall",-1,-1,0,0.75m,4,0,0,2));
            sammlung.Add(new Material("Arkanium",-2,-2,0,0.5m,7,0,0,4));
            sammlung.Add(new Material("Endurium",0,0,0,1,-1,0,0,0));
            //sammlung.Add(new Material("Titanium", -2, -2, 0, 0.25, +7, 0, 0, 4));
            sammlung.Add(new Material("Kupfer/Zinn/Blei/Messing/Bronze", 1, 1, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Eisen",3,2,1,1,3,0,3,0));
            sammlung.Add(new Material("Wismut/Antimon",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Silber",0,0,0,1,2,0,0,0));
            sammlung.Add(new Material("Quecksilber",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Gold",2,0,0,1,-3,2,0,0));
            sammlung.Add(new Material("Mondsilber",-1,0,0,1,0,0,-1,0));
            sammlung.Add(new Material("Toschkril/Angrak",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Elektrum",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Banchaber Blende",0,0,0,1,0,0,0,0));
            sammlung.Add(new Material("Meteoreisen",-1,0,0,1,-3,6,-3,0));
            sammlung.Add(new Material("Orichalcum",0,0,-dice.W20,1,0,0,-7,0));
            sammlung.Add(new Material("Quecksilber", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Blutulme",0,0,-dice.W6-dice.W6,1,-5,0,0,0));
            sammlung.Add(new Material("Steineiche/Eisenbaum",0,0,0,1,3,0,3,0));
            sammlung.Add(new Material("Mohagoni",0,0,0,1,-5,0,0,0));
            sammlung.Add(new Material("Geisterbuch",0,0,0,1,-3,4,0,0));
            sammlung.Add(new Material("Zyklopenzeder",0,-1,0,1,0,0,0,0));
            sammlung.Add(new Material("Bosparanie",4,0,0,1,0,0,0,0));

            //WDA
            sammlung.Add(new Material("Knochenblei",0,0,0,0,-3,0,0,0));
            sammlung.Add(new Material("Krakensilber",0,0,0,0,-3,0,0,0));
            sammlung.Add(new Material("Hölleneisen",0,0,1,0,0,0,0,0));
            sammlung.Add(new Material("Arkanoferrit", 0, 0, 0, 1, 2, 0, 0, 0));
            sammlung.Add(new Material("Gwen Petryl",0,0,-1,0,0,0,0,0));

        }
    }
}
