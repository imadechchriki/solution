using System;

namespace TP_1_Exercice1
{
    public class Repertoire
    {
        public string Nom { get; set; }
        public int Nbr_fichiers { get; private set; }
        private Fichier[] fichiers;

        public Repertoire(string nom)
        {
            Nom = nom;
            Nbr_fichiers = 0;
            fichiers = new Fichier[30];
        }

        public void Afficher()
        {
            Console.WriteLine($"Répertoire: {Nom}");
            Console.WriteLine($"Nombre de fichiers: {Nbr_fichiers}");
            Console.WriteLine("Liste des fichiers:");
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                Console.WriteLine($"{i + 1}. {fichiers[i]}");
            }
        }

        public int Rechercher(string nom)
        {
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Nom == nom)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Ajouter(Fichier fichier)
        {
            if (Nbr_fichiers < 30)
            {
                fichiers[Nbr_fichiers] = fichier;
                Nbr_fichiers++;
                return true;
            }
            Console.WriteLine("Le répertoire est plein, impossible d'ajouter un fichier.");
            return false;
        }

        public void RechercherPdf()
        {
            Console.WriteLine("Fichiers PDF dans le répertoire:");
            bool trouve = false;
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Extension.ToLower() == "pdf")
                {
                    Console.WriteLine(fichiers[i]);
                    trouve = true;
                }
            }
            if (!trouve)
            {
                Console.WriteLine("Aucun fichier PDF trouvé.");
            }
        }

        public bool Supprimer(string nom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                for (int i = index; i < Nbr_fichiers - 1; i++)
                {
                    fichiers[i] = fichiers[i + 1];
                }
                fichiers[Nbr_fichiers - 1] = null;
                Nbr_fichiers--;
                return true;
            }
            Console.WriteLine($"Le fichier '{nom}' n'existe pas.");
            return false;
        }

        public bool Renommer(string ancienNom, string nouveauNom)
        {
            int index = Rechercher(ancienNom);
            if (index != -1)
            {
                fichiers[index].Nom = nouveauNom;
                return true;
            }
            Console.WriteLine($"Le fichier '{ancienNom}' n'existe pas.");
            return false;
        }

        public bool Modifier(string nom, float nouvelleTaille)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Taille = nouvelleTaille;
                return true;
            }
            Console.WriteLine($"Le fichier '{nom}' n'existe pas.");
            return false;
        }

        public float GetTaille()
        {
            float tailleTotale = 0;
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                tailleTotale += fichiers[i].Taille;
            }
            return tailleTotale / 1024; // Conversion KO → MO
        }
    }
}
