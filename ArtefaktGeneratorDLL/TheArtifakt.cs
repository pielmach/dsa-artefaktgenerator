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
    public class DasArtefakt
    {
        public int compatibility = 2;
        public Artefakt artefakt;
        public List<Zauber> zauber;

        public DasArtefakt()
        {
        }

        public DasArtefakt(Artefakt artefakt, List<Zauber> magic)
        {
            this.artefakt = artefakt;
            this.zauber = magic;
        }
    }
}
