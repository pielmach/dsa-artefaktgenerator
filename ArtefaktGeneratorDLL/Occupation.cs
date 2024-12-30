using System;
using System.Collections.Generic;

namespace ArtefaktGenerator
{
    public class Occupation
    {
        private List<string> map = new List<string>();
        private List<string> besessen_map = new List<string>();

        private Random rand = new Random();

        public Occupation()
        {
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Schwacher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Gewöhnlicher Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Starker Astralgeist");
            map.Add("Besessen");
            map.Add("Besessen");
            map.Add("Besessen");
            map.Add("Besessen");

            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Mindergeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Elementargeist");
            besessen_map.Add("Dschinn");
            besessen_map.Add("Dschinn");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Geist");
            besessen_map.Add("Niederer Dämon");
            besessen_map.Add("Niederer Dämon");
            besessen_map.Add("Gehörnter Dämon");
            besessen_map.Add("Gehörnter Dämon");
        }
        public string occupationName(decimal wurf)
        {
            string res = "";
            res += map[(int)wurf];
            if (wurf >= 17)
                res += " (" + (besessen_map[rand.Next(1, 20)]) + ")";
            return res;
        }
    }
}
