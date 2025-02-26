namespace GestionProjet
{
    // Classe représentant une consommation de café
    class ConsommationCafe
    {
        public int NoSemaine { get; set; }
        public int ProgrammeurID { get; set; }
        public int NbTasses { get; set; }

        public ConsommationCafe(int noSemaine, int programmeurID, int nbTasses)
        {
            NoSemaine = noSemaine;
            ProgrammeurID = programmeurID;
            NbTasses = nbTasses;
        }
    }
}