using System.Collections.Generic;

namespace ArtefaktGenerator
{
    public class Kraftspeicher
    {
        private SortedList<Interval, string> srd = new SortedList<Interval, string>();
        private SortedList<Interval, string> wda = new SortedList<Interval, string>();

        public Kraftspeicher()
        {
            wda.Add(new Interval { min = 3, max = 3 }, "Anwendung: Raubt 1W6 pAsP");
            wda.Add(new Interval { min = 4, max = 6 }, "Anwendung: Nur Neumond; Aufladen: Nur Vollmond");
            wda.Add(new Interval { min = 7, max = 9 }, "Matrixleck; -1W3 AsP pro Tag");
            wda.Add(new Interval { min = 10, max = 12 }, "Anwendung: 6 auf W6 kollabierung; W6 Monate kaputt");
            wda.Add(new Interval { min = 13, max = 15 }, "Anwendung: Nur nachts/tagsüber");
            wda.Add(new Interval { min = 16, max = 19 }, "Anwendung: Max. 1W20 AsP pro SR");
            wda.Add(new Interval { min = 20, max = 200 }, "keine");


            srd.Add(new Interval { min = 3, max = 4 }, "Anwendung: Raubt 1W6 pAsP");
            srd.Add(new Interval { min = 5, max = 7 }, "Anwendung: Nur Neumond; Aufladen: Nur Vollmond");
            srd.Add(new Interval { min = 8, max = 10 }, "Matrixleck; -1W3 AsP pro Tag");
            srd.Add(new Interval { min = 11, max = 13 }, "Anwendung: 6 auf W6 kollabierung; W6 Monate kaputt");
            srd.Add(new Interval { min = 14, max = 19 }, "Anwendung: Nur nachts/tagsüber");
            srd.Add(new Interval { min = 20, max = 23 }, "Anwendung: Max. 1W20 AsP pro SR");
            srd.Add(new Interval { min = 24, max = 200 }, "keine");
        }

        public string getEinschraenkungDescr(bool wda, int dice)
        {
            SortedList<Interval, string> l = (wda ? this.wda : this.srd);

            foreach (var pair in l)
            {
                if (dice >= pair.Key.min && dice <= pair.Key.max)
                    return pair.Value;
            }
            return "";
        }
    }
}
