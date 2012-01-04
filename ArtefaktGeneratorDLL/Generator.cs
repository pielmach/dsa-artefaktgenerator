using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefaktGenerator
{
    public class Generator
    {
        static Generator _instance = null;
        string lastWho = "";


        private Generator() { }

        public static Generator instance() 
        {
            if (_instance == null)
                _instance = new Generator();
            return _instance; 
        }

        public void NotifyChange(string who)
        {
            if (lastWho != "") lastWho = who;
        }

        public void FireChange(string who)
        {
            if (lastWho == who) generate();
        }

        public void generate()
        {

        }
    }
}
