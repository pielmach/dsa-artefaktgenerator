namespace ArtefaktGenerator
{
    public class SF
    {
        public enum SFType : short { ACH = 0, OTHER = 1 };

        public SFType rep = SFType.OTHER;

        public bool kraftkontrolle = false;

        public bool vielfacheLadung = false;

        public bool matrix = false;

        public bool auxiliator = false;

        public bool stapel = false;

        public bool hyper = false;

        public bool semi1 = false;

        public bool semi2 = false;

        public bool ringkunde = false;

        public bool kraftspeicher = false;
    }
}
