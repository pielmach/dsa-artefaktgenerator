using System.Xml;

namespace ArtefaktGenerator
{
    public class Held
    {
        public string name;
        public string xml;

        public Held(string xml)
        {

            XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(xml);

            XmlNodeList heldNode = xmlDoc.GetElementsByTagName("held");
            if (heldNode.Count > 0)
            {
                foreach (XmlAttribute attrb in heldNode[0].Attributes)
                {
                    if (attrb.Name == "name")
                        this.name = attrb.Value;
                }
            }
            else
                this.name = "Der Namenlose";

            this.xml = xml;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
