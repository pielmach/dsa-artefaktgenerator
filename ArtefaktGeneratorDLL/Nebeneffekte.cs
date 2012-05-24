using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefaktGenerator
{
    public struct Interval : IComparable<Interval>
    {
        public int min;
        public int max;

        public int CompareTo(Interval obj)
        {
            if (obj.min > this.max && obj.max > this.max) return 1;
            if (obj.min < this.min && obj.min < this.max) return -1;
            return 0;
        }
    }

    class Nebeneffekte
    {
        private SortedList<Interval,string> srd = new SortedList<Interval, string>();
        private SortedList<Interval,string> wda = new SortedList<Interval, string>();

        public Nebeneffekte()
        {
            wda.Add(new Interval { min = 1, max = 3 }, "Anwendung: Saugt Anwender in Matrix");
            wda.Add(new Interval { min = 4, max = 5 }, "Artefakt Phasenverschoben; Bei 6 auf W6 verfügbar");
            wda.Add(new Interval { min = 6, max = 7 }, "IGNISPHAERO nach letzter Anwendung; pAsP W Schaden");
            wda.Add(new Interval { min = 8, max = 9 }, "Nachteil Pechmagnet");
            wda.Add(new Interval { min = 10, max = 10 }, "Strukturpunkte / 2");
            wda.Add(new Interval { min = 11, max = 11 }, "Nachteil Schlafstörungen I");
            wda.Add(new Interval { min = 12, max = 12 }, "Anwendung: 1W6 SR extrem heiß/kalt");
            wda.Add(new Interval { min = 13, max = 13 }, "Anwendung: Nur nachts/tagsüber");
            wda.Add(new Interval { min = 14, max = 14 }, "Anwendung: 1W6 SP (evtl. mehr)");
            wda.Add(new Interval { min = 15, max = 15 }, "Nachteil Einbildungen/Wahvorstellungen; Andere Personen Gier/Goldgier -pAsP");
            wda.Add(new Interval { min = 16, max = 16 }, "Verlegt; 1W6 Aktionen - W20 SR zum auffinden");
            wda.Add(new Interval { min = 17, max = 17 }, "Pulsieren");
            wda.Add(new Interval { min = 18, max = 19 }, "Ständig heiß/kalt");
            wda.Add(new Interval { min = 20, max = 20 }, "Artefakt wird immer gefunden");
            wda.Add(new Interval { min = 21, max = 21 }, "Anwendung: Nur durch Erschaffer (bzw. LO)");
            wda.Add(new Interval { min = 22, max = 22 }, "Schimmernde Aura");
            wda.Add(new Interval { min = 23, max = 25 }, "Anwendung: Leuchtende Aura");
            wda.Add(new Interval { min = 26, max = 27 }, "Artefakt immer sauber");
            wda.Add(new Interval { min = 28, max = 28 }, "SCHLEIER d. UNWISSENHEIT (pAsP*2 ZfP*)");
            wda.Add(new Interval { min = 29, max = 29 }, "WIDERWILLE (außer Besitzer)");
            wda.Add(new Interval { min = 30, max = 32 }, "ZAUBERKLINGE GEISTERSPEER");
            wda.Add(new Interval { min = 33, max = 34 }, "Vorteil Glück");
            wda.Add(new Interval { min = 35, max = 38 }, "Unzerbrechlich");
            wda.Add(new Interval { min = 39, max = 40 }, "Apport (pAsP Meilen)");

            srd.Add(new Interval { min = 1, max = 3 }, "Artefakt Phasenverschoben; Bei 6 auf W6 verfügbar");
            srd.Add(new Interval { min = 4, max = 5 }, "Anwendung: Saugt Anwender in Matrix");
            srd.Add(new Interval { min = 6, max = 7 }, "IGNISPHAERO nach letzter Anwendung");
            srd.Add(new Interval { min = 8, max = 9 }, "Nachteil Pechmagnet");
            srd.Add(new Interval { min = 10, max = 10 }, "Artefakt einfach zu zerstören");
            srd.Add(new Interval { min = 11, max = 11 }, "Nachteil Alpträume & Schlafstörungen");
            srd.Add(new Interval { min = 12, max = 12 }, "Anwendung: 1W6 SR extrem heiß/kalt");
            srd.Add(new Interval { min = 13, max = 13 }, "Anwendung: Nur nachts/tagsüber");
            srd.Add(new Interval { min = 14, max = 14 }, "Anwendung: 1W6 SP (evtl. mehr)");
            srd.Add(new Interval { min = 15, max = 15 }, "Nachteil Einbildungen/Wahvorstellungen; Andere Personen Goldgier -pAsP");
            srd.Add(new Interval { min = 16, max = 16 }, "Artefakt verlegt sich selbst");
            srd.Add(new Interval { min = 17, max = 17 }, "Pulsieren");
            srd.Add(new Interval { min = 18, max = 19 }, "Ständig heiß/kalt");
            srd.Add(new Interval { min = 20, max = 20 }, "Artefakt wird immer gefunden");
            srd.Add(new Interval { min = 21, max = 21 }, "Anwendung: Nur durch Erschaffer (bzw. LO)");
            srd.Add(new Interval { min = 22, max = 22 }, "Schimmernde Aura");
            srd.Add(new Interval { min = 23, max = 25 }, "Anwendung: Leuchtende Aura");
            srd.Add(new Interval { min = 26, max = 27 }, "Artefakt immer sauber");
            srd.Add(new Interval { min = 28, max = 28 }, "SCHLEIER d. UNWISSENHEIT (pAsP*2 ZfP*)");
            srd.Add(new Interval { min = 29, max = 29 }, "WIDERWILLE (außer Besitzer)");
            srd.Add(new Interval { min = 30, max = 32 }, "ZAUBERKLINGE GEISTERSPEER");
            srd.Add(new Interval { min = 33, max = 34 }, "Vorteil Glück");
            srd.Add(new Interval { min = 35, max = 38 }, "Unzerbrechlich");
            srd.Add(new Interval { min = 39, max = 40 }, "Apport (pAsP Meilen)");
        }

        public string getNebeneffektDescr(bool wda, int dice)
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
