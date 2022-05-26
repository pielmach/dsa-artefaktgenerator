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

namespace ArtefaktGenerator
{
    public class Occupation
    {
        private List<string> map = new List<string>();
        private List<string> besessen_map = new List<string>();

        private Random rand = new Random();

        public Occupation()
        {
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Besessen");
            map.Add("Besessen");
            map.Add("Besessen");
            map.Add("Besessen");

            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Dschinn");
            besessen_map.Add("Dschinn");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Niederer Dämon");
            besessen_map.Add("Niederer Dämon");
            besessen_map.Add("Gehörnter Dämon");
            besessen_map.Add("Gehörnter Dämon");
        }
        public string occupationName(decimal wurf)
        {
            string res = "";
            res += map[(int)wurf];
            if (wurf >= 17)
                res += " (" + (besessen_map[rand.Next(1, 20)]) + ")";
            return res;
        }
    }
}
