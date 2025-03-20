using System;
using System.Collections.Generic;
using System.Data;
using DB.LIB;

namespace GestionEleves
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application de gestion des élèves");
            Console.WriteLine("================================");

            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\nMenu principal:");
                Console.WriteLine("1. Ajouter un élève");
                Console.WriteLine("2. Modifier un élève");
                Console.WriteLine("3. Supprimer un élève");
                Console.WriteLine("4. Rechercher un élève par ID");
                Console.WriteLine("5. Afficher tous les élèves");
                Console.WriteLine("6. Rechercher des élèves par nom ou prénom");
                Console.WriteLine("0. Quitter");

                Console.Write("\nVotre choix: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterEleve();
                        break;
                    case "2":
                        ModifierEleve();
                        break;
                    case "3":
                        SupprimerEleve();
                        break;
                    case "4":
                        RechercherEleveParId();
                        break;
                    case "5":
                        AfficherTousLesEleves();
                        break;
                    case "6":
                        RechercherElevesParNomPrenom();
                        break;
                    case "0":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

            Console.WriteLine("Merci d'avoir utilisé notre application !");
        }

        static void AjouterEleve()
        {
            Console.WriteLine("\nAjout d'un nouvel élève");
            Console.WriteLine("----------------------");

            Console.Write("Nom: ");
            string nom = Console.ReadLine();

            Console.Write("Prénom: ");
            string prenom = Console.ReadLine();

            DateTime dateNaissance;
            while (true)
            {
                Console.Write("Date de naissance (JJ/MM/AAAA): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateNaissance))
                    break;
                Console.WriteLine("Format de date invalide. Veuillez réessayer.");
            }

            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();

            Console.Write("Téléphone: ");
            string telephone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            // Création de l'élève avec le constructeur par défaut
            Eleve eleve = new Eleve
            {
                Nom = nom,
                Prenom = prenom,
                DateNaissance = dateNaissance,
                Adresse = adresse,
                Telephone = telephone,
                Email = email
            };

            try
            {
                int id = eleve.insert();
                Console.WriteLine($"Élève ajouté avec succès. ID: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de l'élève: {ex.Message}");
            }
        }
        static void ModifierEleve()
        {
            Console.WriteLine("\nModification d'un élève");
            Console.WriteLine("-----------------------");

            Console.Write("ID de l'élève à modifier: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Eleve eleve = new Eleve { Id = id };

            try
            {
                eleve = (Eleve)eleve.findById();
                if (eleve == null)
                {
                    Console.WriteLine($"Aucun élève trouvé avec l'ID {id}.");
                    return;
                }

                Console.WriteLine($"Modification de l'élève: {eleve}");

                Console.Write($"Nouveau nom [{eleve.Nom}]: ");
                string nom = Console.ReadLine();
                eleve.Nom = string.IsNullOrEmpty(nom) ? eleve.Nom : nom;

                Console.Write($"Nouveau prénom [{eleve.Prenom}]: ");
                string prenom = Console.ReadLine();
                eleve.Prenom = string.IsNullOrEmpty(prenom) ? eleve.Prenom : prenom;

                Console.Write($"Nouvelle date de naissance [{eleve.DateNaissance.ToShortDateString()}] (JJ/MM/AAAA): ");
                string dateStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(dateStr) && DateTime.TryParse(dateStr, out DateTime dateNaissance))
                    eleve.DateNaissance = dateNaissance;

                Console.Write($"Nouvelle adresse [{eleve.Adresse}]: ");
                string adresse = Console.ReadLine();
                eleve.Adresse = string.IsNullOrEmpty(adresse) ? eleve.Adresse : adresse;

                Console.Write($"Nouveau téléphone [{eleve.Telephone}]: ");
                string telephone = Console.ReadLine();
                eleve.Telephone = string.IsNullOrEmpty(telephone) ? eleve.Telephone : telephone;

                Console.Write($"Nouvel email [{eleve.Email}]: ");
                string email = Console.ReadLine();
                eleve.Email = string.IsNullOrEmpty(email) ? eleve.Email : email;

                int result = eleve.update();
                Console.WriteLine($"Élève modifié avec succès. {result} ligne(s) affectée(s).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la modification de l'élève: {ex.Message}");
            }
        }

        static void SupprimerEleve()
        {
            Console.WriteLine("\nSuppression d'un élève");
            Console.WriteLine("----------------------");

            Console.Write("ID de l'élève à supprimer: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Eleve eleve = new Eleve { Id = id };

            try
            {
                eleve = (Eleve)eleve.findById();
                if (eleve == null)
                {
                    Console.WriteLine($"Aucun élève trouvé avec l'ID {id}.");
                    return;
                }

                Console.WriteLine($"Êtes-vous sûr de vouloir supprimer l'élève suivant: {eleve} (O/N)");
                string confirmation = Console.ReadLine().ToUpper();

                if (confirmation == "O")
                {
                    int result = eleve.delete();
                    Console.WriteLine($"Élève supprimé avec succès. {result} ligne(s) affectée(s).");
                }
                else
                {
                    Console.WriteLine("Suppression annulée.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression de l'élève: {ex.Message}");
            }
        }

        static void RechercherEleveParId()
        {
            Console.WriteLine("\nRecherche d'un élève par ID");
            Console.WriteLine("--------------------------");

            Console.Write("ID de l'élève à rechercher: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Eleve eleve = new Eleve { Id = id };

            try
            {
                eleve = (Eleve)eleve.findById();
                if (eleve == null)
                {
                    Console.WriteLine($"Aucun élève trouvé avec l'ID {id}.");
                    return;
                }

                Console.WriteLine($"Élève trouvé: {eleve}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la recherche de l'élève: {ex.Message}");
            }
        }

        static void AfficherTousLesEleves()
        {
            Console.WriteLine("\nListe de tous les élèves");
            Console.WriteLine("----------------------");

            Eleve eleve = new Eleve();

            try
            {
                List<object> eleves = eleve.findAll();

                if (eleves.Count == 0)
                {
                    Console.WriteLine("Aucun élève trouvé dans la base de données.");
                    return;
                }

                Console.WriteLine($"Nombre d'élèves: {eleves.Count}");

                foreach (Eleve e in eleves)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des élèves: {ex.Message}");
            }
        }

        static void RechercherElevesParNomPrenom()
        {
            Console.WriteLine("\nRecherche d'élèves par nom ou prénom");
            Console.WriteLine("-----------------------------------");

            Console.Write("Nom (ou partie du nom): ");
            string nom = Console.ReadLine();

            Console.Write("Prénom (ou partie du prénom): ");
            string prenom = Console.ReadLine();

            Eleve eleve = new Eleve { Nom = nom, Prenom = prenom };

            try
            {
                List<object> eleves = eleve.find();

                if (eleves.Count == 0)
                {
                    Console.WriteLine("Aucun élève ne correspond aux critères de recherche.");
                    return;
                }

                Console.WriteLine($"Nombre d'élèves trouvés: {eleves.Count}");

                foreach (Eleve e in eleves)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la recherche des élèves: {ex.Message}");
            }
        }
    }
}