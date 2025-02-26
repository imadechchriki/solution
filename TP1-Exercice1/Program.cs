using System;

namespace TP_1_Exercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repertoire monRepertoire = new Repertoire("Documents");

            monRepertoire.Ajouter(new Fichier("rapport", "pdf", 1500));
            monRepertoire.Ajouter(new Fichier("presentation", "pptx", 2200));
            monRepertoire.Ajouter(new Fichier("article", "pdf", 800));
            monRepertoire.Ajouter(new Fichier("budget", "xlsx", 450));

            Console.WriteLine("=== État initial du répertoire ===");
            monRepertoire.Afficher();

            string nomRecherche = "rapport";
            int index = monRepertoire.Rechercher(nomRecherche);
            Console.WriteLine($"\nRecherche du fichier '{nomRecherche}': {(index != -1 ? $"Trouvé à l'indice {index}" : "Non trouvé")}");

            Console.WriteLine("\n=== Recherche des fichiers PDF ===");
            monRepertoire.RechercherPdf();

            string ancienNom = "rapport";
            string nouveauNom = "rapport_final";
            Console.WriteLine($"\n=== Renommage de '{ancienNom}' en '{nouveauNom}' ===");
            monRepertoire.Renommer(ancienNom, nouveauNom);

            Console.WriteLine("\n=== Modification de la taille du fichier 'article' ===");
            monRepertoire.Modifier("article", 950);

            string nomSuppression = "budget";
            Console.WriteLine($"\n=== Suppression du fichier '{nomSuppression}' ===");
            monRepertoire.Supprimer(nomSuppression);

            Console.WriteLine("\n=== État final du répertoire ===");
            monRepertoire.Afficher();

            Console.WriteLine($"\nTaille totale du répertoire: {monRepertoire.GetTaille():F2} MO");

            Console.ReadKey();
        }
    }
}