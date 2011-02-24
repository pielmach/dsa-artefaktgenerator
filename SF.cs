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
    public class SF
    {
        public enum SFType : short { ACH = 0, OTHER = 1 };

        public SFType rep = SFType.OTHER;

        public bool kraftkontrolle = false;

        public bool vielfacheLadung = false;

        public bool matrix = false;

        public bool stapel = false;

        public bool hyper = false;

        public bool semi1 = false;

        public bool semi2 = false;

        public bool ringkunde = false;
    }
}
