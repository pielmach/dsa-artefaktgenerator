using System.ComponentModel;

namespace ArtefaktGenerator
{
    public class DasArtefakt
    {
        public int compatibility = 2;
        public Artefakt artefakt;
        public BindingList<Zauber> zauber;

        public DasArtefakt()
        {
        }

        public DasArtefakt(Artefakt artefakt, BindingList<Zauber> magic)
        {
            this.artefakt = artefakt;
            this.zauber = magic;
        }
    }
}
