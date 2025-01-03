﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefaktGenerator
{
    public class MaterialSammlung
    {
        public List<Material> sammlung = new List<Material>();

        public MaterialSammlung() { }

        public List<Material> getList()
        {
            return sammlung;
        }

        private Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public Object loadMod(String pXmlizedString)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(MaterialSammlung));
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);

            return xs.Deserialize(memoryStream);
        }

        public MaterialSammlung(Wuerfel dice)
        {
            sammlung.Add(new Material("kein", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Mindorium", 0, 2, 0, 0.75m, -5, 7, -6, 0));
            sammlung.Add(new Material("Amulettmetall", -1, -1, 0, 0.75m, 4, 0, 0, 2));
            sammlung.Add(new Material("Arkanium", -2, -2, 0, 0.5m, 7, 0, 0, 4));
            sammlung.Add(new Material("Endurium", 0, 0, 0, 1, -1, 0, 0, 0));
            //sammlung.Add(new Material("Titanium", -2, -2, 0, 0.25, +7, 0, 0, 4));
            sammlung.Add(new Material("Kupfer/Zinn/Blei/Messing/Bronze", 1, 1, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Eisen", 3, 2, 1, 1, 3, 0, 3, 0));
            sammlung.Add(new Material("Wismut/Antimon", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Silber", 0, 0, 0, 1, 2, 0, 0, 0));
            sammlung.Add(new Material("Quecksilber", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Gold", 2, 0, 0, 1, -3, 2, 0, 0));
            sammlung.Add(new Material("Mondsilber", -1, 0, 0, 1, 0, 0, -1, 0));
            sammlung.Add(new Material("Toschkril/Angrak", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Elektrum", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Banchaber Blende", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Meteoreisen", -1, 0, 0, 1, -3, 6, -3, 0));
            sammlung.Add(new Material("Orichalcum", 0, 0, -dice.W20, 1, 0, 0, -7, 0));
            sammlung.Add(new Material("Quecksilber", 0, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Blutulme", 0, 0, -dice.W6 - dice.W6, 1, -5, 0, 0, 0));
            sammlung.Add(new Material("Steineiche/Eisenbaum", 0, 0, 0, 1, 3, 0, 3, 0));
            sammlung.Add(new Material("Mohagoni", 0, 0, 0, 1, -5, 0, 0, 0));
            sammlung.Add(new Material("Geisterbuch", 0, 0, 0, 1, -3, 4, 0, 0));
            sammlung.Add(new Material("Zyklopenzeder", 0, -1, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Bosparanie", 4, 0, 0, 1, 0, 0, 0, 0));

            //WDA
            sammlung.Add(new Material("Knochenblei", 0, 0, 0, 1, -3, 0, 0, 0));
            sammlung.Add(new Material("Krakensilber", 0, 0, 0, 1, -3, 0, 0, 0));
            sammlung.Add(new Material("Hölleneisen", 0, 0, 1, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Arkanoferrit", 0, 0, 0, 1, 2, 0, 0, 0));
            sammlung.Add(new Material("Gwen Petryl", 0, 0, -1, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Flüssigkeit", +3, 0, 0, 1, 0, 0, 0, 0));
            sammlung.Add(new Material("Gas", +7, 0, 0, 1, 0, 0, 0, 0));

            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("material.mod.artgen");

                string xml = reader.ReadToEnd();
                MaterialSammlung mod = (MaterialSammlung)loadMod(xml);
                for (int i = 0; i < mod.sammlung.Count; i++)
                {
                    sammlung.Add(mod.sammlung[i]);
                }
            }
            catch (System.Exception)
            {
            }


        }
    }
}
