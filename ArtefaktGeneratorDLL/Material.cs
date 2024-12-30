namespace ArtefaktGenerator
{
    public class Material
    {
        public string name;
        public decimal arcanovi_mod = 0;
        public decimal wirkende_mod = 0;
        public decimal asp_mod = 0;
        public decimal pasp_mod = 1;
        public decimal occupation_mod = 0;
        public decimal occupation_art_mod = 0;
        public decimal nebenwirkung_mod = 0;
        public decimal nebenwirkung_art_mod = 0;

        public Material()
        {
            this.name = "kein";
        }

        public Material(string name)
        {
            this.name = name;
        }

        public Material(
            string name,
            decimal arcanovi_mod,
            decimal wirkende_mod,
            decimal asp_mod,
            decimal pasp_mod,
            decimal occupation_mod,
            decimal occupation_art_mod,
            decimal nebenwirkung_mod,
            decimal nebenwirkung_art_mod
            )
        {
            this.name = name;
            this.arcanovi_mod = arcanovi_mod;
            this.wirkende_mod = wirkende_mod;
            this.asp_mod = asp_mod;
            this.pasp_mod = pasp_mod;
            this.occupation_mod = occupation_mod;
            this.occupation_art_mod = occupation_art_mod;
            this.nebenwirkung_mod = nebenwirkung_mod;
            this.nebenwirkung_art_mod = nebenwirkung_art_mod;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
