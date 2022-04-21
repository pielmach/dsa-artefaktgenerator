using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace ArtefaktGenerator
{
    public static class LadeHelden
    {
        private const string HELD_EINSTELLUNGEN_XML_PATH = "/.heldEinstellungen4_1.xml";
        private const string HELDEN_ZIP_PATH = "/helden/helden.zip.hld";

        public static List<Held> LadeHeldenFromDefaultPath()
        {
            string home = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ?
                Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            string heldenZipPath = null;

            string einstellungenXmlFile = home + HELD_EINSTELLUNGEN_XML_PATH;
            if (File.Exists(einstellungenXmlFile))
            {
                string einstellungenXml = ReadFile(einstellungenXmlFile);
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
                return null;
            }

            return LadeHeldenFromFile(heldenZipPath);
        }

        public static List<Held> LadeHeldenFromFile(string filename)
        {
            List<Held> list = new();

            if (filename.EndsWith(".xml"))
            {
                Held held = new(File.ReadAllText(filename,System.Text.Encoding.UTF8));
                list.Add(held);
            }
            else if (filename.EndsWith(".zip.hld") || filename.EndsWith(".zip"))
            {
                using ZipArchive zip = ZipFile.OpenRead(filename);
                foreach (ZipArchiveEntry e in zip.Entries)
                {
                    if (e.FullName.EndsWith(".xml"))
                    {
                        using StreamReader reader = new(e.Open());
                        string xml = reader.ReadToEnd();
                        Held held = new(xml);
                        list.Add(held);
                    }
                }
            }

            return list;
        }

        private static string ReadFile(string filename)
        {
            StreamReader myFile = new(filename, System.Text.Encoding.Default);
            try
            {
                return myFile.ReadToEnd();
            }
            finally
            {
                myFile.Close();
            }
        }
    }
}
