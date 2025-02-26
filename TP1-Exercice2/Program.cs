using System;

namespace GestionProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Projet monProjet = new Projet("PROJ001", "Application de suivi de consommation de café", 12);
            
            monProjet.AjouterProgrammeur(new Programmeur(1, "ECHCHRIKI", "IMAD", 205));
            monProjet.AjouterProgrammeur(new Programmeur(2, "OUAIL", "ELOUAD", 123));
            monProjet.AjouterProgrammeur(new Programmeur(3, "TAHA", "NAYA", 501));
            monProjet.AjouterProgrammeur(new Programmeur(4, "MOUAD", "DAHBI", 678));


            Console.WriteLine("\n=== Liste initiale des programmeurs ===");
            monProjet.AfficherListeProgrammeurs();

            monProjet.AjouterConsommationCafe(1, 1, 4);
            monProjet.AjouterConsommationCafe(2, 1, 6);
            monProjet.AjouterConsommationCafe(3, 1, 6);
            monProjet.AjouterConsommationCafe(4, 1, 1);


            Console.WriteLine("\n=== Consommation totale par semaine ===");
            monProjet.AfficherConsommationTotaleSemaine(1);
        }
    }
}