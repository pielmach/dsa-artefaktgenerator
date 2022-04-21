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
//using System.Linq;

namespace ArtefaktGenerator
{
    public class Wuerfel
    {
        private Random rand = new Random();

        private decimal _w6 = 4m;
        private bool generatew6 = false;

        private decimal _w20 = 11m;
        private bool generatew20 = false;

        public enum Optimum : short { LOW = 0, HIGH = 1 };

        public Optimum W6_Opt = Optimum.LOW;
        public Optimum W20_Opt = Optimum.LOW;

        public decimal W6
        {
            get
            {
                if (generatew6)
                    return rand.Next(1, 6);
                else
                {
                    if (_w6 == 1)
                        return ((W6_Opt == Optimum.LOW) ? 1 : 6);
                    if (_w6 == 6)
                        return ((W6_Opt == Optimum.HIGH) ? 1 : 6);
                    return this._w6;
                }
            }
            set
            {
                if (value > 6 || value < 1)
                    generatew6 = true;
                else
                    this._w6 = value;
            }
        }

        public decimal W20
        {
            get
            {
                if (generatew20)
                    return rand.Next(1, 20);
                else
                {
                    if (_w20 == 1)
                        return ((W6_Opt == Optimum.LOW) ? 1 : 20);
                    if (_w20 == 20)
                        return ((W6_Opt == Optimum.HIGH) ? 1 : 20);
                    return this._w20;
                }
            }
            set
            {
                if (value > 20 || value < 1)
                    generatew20 = true;
                else
                    this._w20 = value;
            }
        }

    }
}
