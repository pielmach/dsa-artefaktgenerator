using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Ionic.Zip;

namespace ArtefaktGeneratorApp
{
    class LadeHelden
    {
        private const string HELD_EINSTELLUNGEN_XML_PATH = "/.heldEinstellungen4_1.xml";
        private const string HELDEN_ZIP_PATH = "/helden/helden.zip.hld";

        public List<Held> heldenList;

        public LadeHelden()
        {
            string home = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ?
                Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            string heldenZipPath = null;

            string einstellungenXmlFile = home + HELD_EINSTELLUNGEN_XML_PATH;
            if (File.Exists(einstellungenXmlFile))
            {
                string einstellungenXml = readFile(einstellungenXmlFile);
                Match m = Regex.Match(einstellungenXml, "<pfad customPfad=\"(.+)\" name=\"heldenPfad\"/>");
                if (m.Success)
                {
                    heldenZipPath = m.Groups[1].Value;
                }
            }

            if (heldenZipPath == null)
            {
                // use default path
                heldenZipPath = home + HELDEN_ZIP_PATH;
            }

            if (!File.Exists(heldenZipPath))
            {
                return;
            }

            this.heldenList = readHelden(heldenZipPath);
        }

        private static string readFile(String filename)
        {
            StreamReader myFile = new StreamReader(filename, System.Text.Encoding.Default);
            try
            {
                return myFile.ReadToEnd();
            }
            finally
            {
                myFile.Close();
            }
        }

        private static List<Held> readHelden(String filename)
        {
            List<Held> list = new List<Held>();

            using (ZipFile zip = ZipFile.Read(filename))
            {
                foreach (ZipEntry e in zip)
                {
                    if (e.FileName.EndsWith(".xml"))
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            e.Extract(stream);
                            stream.Seek(0, SeekOrigin.Begin);
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string xml = reader.ReadToEnd();
                                Held held = new Held(xml);
                                list.Add(held);
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}
