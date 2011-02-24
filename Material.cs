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
    public class Material
    {
        public string name;
        public decimal arcanovi_mod = 0;
        public decimal wirkende_mod = 0;
        public decimal asp_mod = 0;
        public decimal pasp_mod = 1;
        public decimal occupation_mod = 0;
        public decimal occupation_art_mod = 0;
        public decimal nebenwirkung_mod = 0;
        public decimal nebenwirkung_art_mod = 0;

        public Material()
        {
            this.name = "kein";
        }

        public Material(string name)
        {
            this.name = name;
        }

        public Material(
            string name, 
            decimal arcanovi_mod, 
            decimal wirkende_mod, 
            decimal asp_mod, 
            decimal pasp_mod, 
            decimal occupation_mod,
            decimal occupation_art_mod,
            decimal nebenwirkung_mod,
            decimal nebenwirkung_art_mod
            )
        {
            this.name = name;
            this.arcanovi_mod = arcanovi_mod;
            this.wirkende_mod = wirkende_mod;
            this.asp_mod = asp_mod;
            this.pasp_mod = pasp_mod;
            this.occupation_mod = occupation_mod;
            this.occupation_art_mod = occupation_art_mod;
            this.nebenwirkung_mod = nebenwirkung_mod;
            this.nebenwirkung_art_mod = nebenwirkung_art_mod;
        }
    }
}
