using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionProjet
{
    // Classe représentant un projet
    class Projet
    {
        public string Code { get; set; }
        public string Sujet { get; set; }
        public int Duree { get; set; } // en semaines
        public List<Programmeur> Programmeurs { get; private set; }
        public List<ConsommationCafe> ConsommationsCafe { get; private set; }

        public Projet(string code, string sujet, int duree)
        {
            Code = code;
            Sujet = sujet;
            Duree = duree;
            Programmeurs = new List<Programmeur>();
            ConsommationsCafe = new List<ConsommationCafe>();
        }

        public bool AjouterProgrammeur(Programmeur programmeur)
        {
            if (Programmeurs.Any(p => p.ID == programmeur.ID))
            {
                Console.WriteLine($"Un programmeur avec l'ID {programmeur.ID} existe déjà.");
                return false;
            }

            Programmeurs.Add(programmeur);
            Console.WriteLine($"Programmeur {programmeur.Prenom} {programmeur.Nom} ajouté avec succès.");
            return true;
        }

        public Programmeur RechercherProgrammeur(int id)
        {
            return Programmeurs.FirstOrDefault(p => p.ID == id);
        }

        public void AfficherProgrammeur(int id)
        {
            Programmeur programmeur = RechercherProgrammeur(id);
            if (programmeur != null)
                Console.WriteLine(programmeur);
            else
                Console.WriteLine($"Aucun programmeur trouvé avec l'ID {id}.");
        }

        public void AfficherListeProgrammeurs()
        {
            if (Programmeurs.Count == 0)
            {
                Console.WriteLine("Aucun programmeur dans le projet.");
                return;
            }

            Console.WriteLine("Liste des programmeurs :");
            foreach (var programmeur in Programmeurs)
            {
                Console.WriteLine(programmeur);
            }
        }

        public bool SupprimerProgrammeur(int id)
        {
            Programmeur programmeur = RechercherProgrammeur(id);
            if (programmeur != null)
            {
                Programmeurs.Remove(programmeur);
                ConsommationsCafe.RemoveAll(c => c.ProgrammeurID == id);
                Console.WriteLine($"Programmeur {programmeur.Prenom} {programmeur.Nom} supprimé avec succès.");
                return true;
            }
            Console.WriteLine($"Aucun programmeur trouvé avec l'ID {id}.");
            return false;
        }

        public bool AjouterConsommationCafe(int programmeurID, int semaine, int nbTasses)
        {
            if (RechercherProgrammeur(programmeurID) == null)
            {
                Console.WriteLine($"Aucun programmeur trouvé avec l'ID {programmeurID}.");
                return false;
            }

            if (semaine <= 0 || semaine > Duree)
            {
                Console.WriteLine($"La semaine {semaine} est invalide. Le projet dure {Duree} semaines.");
                return false;
            }

            var consommationExistante = ConsommationsCafe.FirstOrDefault(c => 
                c.ProgrammeurID == programmeurID && c.NoSemaine == semaine);

            if (consommationExistante != null)
            {
                consommationExistante.NbTasses = nbTasses;
                Console.WriteLine($"Consommation mise à jour pour le programmeur ID {programmeurID}, semaine {semaine}.");
            }
            else
            {
                ConsommationsCafe.Add(new ConsommationCafe(semaine, programmeurID, nbTasses));
                Console.WriteLine($"Consommation ajoutée pour le programmeur ID {programmeurID}, semaine {semaine}.");
            }
            return true;
        }

        public bool ChangerBureau(int programmeurID, int nouveauBureau)
        {
            Programmeur programmeur = RechercherProgrammeur(programmeurID);
            if (programmeur != null)
            {
                programmeur.Bureau = nouveauBureau;
                Console.WriteLine($"Bureau du programmeur {programmeur.Prenom} {programmeur.Nom} changé à {nouveauBureau}.");
                return true;
            }
            Console.WriteLine($"Aucun programmeur trouvé avec l'ID {programmeurID}.");
            return false;
        }

        public void AfficherConsommationTotaleSemaine(int semaine)
        {
            if (semaine <= 0 || semaine > Duree)
            {
                Console.WriteLine($"La semaine {semaine} est invalide. Le projet dure {Duree} semaines.");
                return;
            }

            int totalTasses = ConsommationsCafe
                .Where(c => c.NoSemaine == semaine)
                .Sum(c => c.NbTasses);

            Console.WriteLine($"Nombre total de tasses de café consommées en semaine {semaine} : {totalTasses}");
        }
    }
}
