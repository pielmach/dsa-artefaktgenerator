using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArtefaktGenerator
{
    public class Held
    {
        public string name;
        public string xml;

        public Held(string xml)
        {
            Match m = Regex.Match(xml, "<held key=\".*\" name=\"(.+)\">");
            if (m.Success)
            {
                this.name = m.Groups[1].Value;
            }
            else
            {
                this.name = "(unbekannt)";
            }

            this.xml = xml;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
