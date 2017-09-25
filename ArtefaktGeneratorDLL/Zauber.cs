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

namespace ArtefaktGenerator
{
    public class Zauber
    {
        public string name;
        public string komp;
        //public decimal load;
        public decimal staple;
        public decimal asp;
        public bool eigene_rep;
        public decimal numOfCasts; // Semipermanent bei zB 3 mal pro Monat muss 3*2=6 mal der Zauber gesprochen werden (2 für Monat. Kann durch SF SemiP2 verbessert werden)

        public override string ToString()
        {
            return name + "\t" + komp + "\t" + staple + "\t" + asp + "\t" + (eigene_rep ? "eigene" : "fremde");// + "\t" + numOfCasts;
        }
    }
}
