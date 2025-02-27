namespace TP3_exerice;


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Test du système de gestion des ressources humaines =====\n");

        // Création des instances
        RessourcesHumaines rh = new RessourcesHumaines();

        // Test du Singleton Directeur
        Console.WriteLine("Test du pattern Singleton pour la classe Directeur:");
        Directeur directeur1 = Directeur.getInstance(1, "Alaoui", "Mohammed", "B001", 20000, 5000);
        Console.WriteLine("Premier directeur créé: " + directeur1.ToString());
        
        // Tentative de création d'un second directeur
        Directeur directeur2 = Directeur.getInstance(2, "Benani", "Ahmed", "B002", 25000, 6000);
        
        // Création du personnel administratif
        Administratif admin1 = new Administratif(3, "Chakir", "Fatima", "A101", 12000);
        Administratif admin2 = new Administratif(4, "Dahmani", "Karim", "A102", 11500);
        
        // Création des enseignants
        Enseignant ens1 = new Enseignant(5, "El Fassi", "Samir", "E201", 15000, "PA", 210, 3000);
        Enseignant ens2 = new Enseignant(6, "Ghali", "Leila", "E202", 17000, "PH", 195, 3500);
        Enseignant ens3 = new Enseignant(7, "Hassani", "Omar", "E203", 19000, "PES", 220, 4000);
        
        // Création des groupes
        Groupe g1 = new Groupe("Informatique_1A");
        Groupe g2 = new Groupe("Informatique_2A");
        Groupe g3 = new Groupe("Génie_Civil_1A");
        
        // Création des étudiants
        Etudiant etd1 = new Etudiant(101, "Idrissi", "Youssef", "1ère année", 14.5);
        Etudiant etd2 = new Etudiant(102, "Jamai", "Sanaa", "1ère année", 16.2);
        Etudiant etd3 = new Etudiant(103, "Kamali", "Hamza", "1ère année", 13.7);
        Etudiant etd4 = new Etudiant(104, "Lahlou", "Amal", "2ème année", 15.9);
        Etudiant etd5 = new Etudiant(105, "Mansouri", "Nabil", "2ème année", 14.3);
        
        Console.WriteLine("\n===== Test de la méthode Afficher_etd() =====");
        etd1.Afficher_etd();
        
        Console.WriteLine("\n===== Test de la méthode Ajouter_etudiant() =====");
        g1.Ajouter_etudiant(etd1);
        g1.Ajouter_etudiant(etd2);
        g1.Ajouter_etudiant(etd3);
        g2.Ajouter_etudiant(etd4);
        g2.Ajouter_etudiant(etd5);
        g3.Ajouter_etudiant(etd3); // Un étudiant peut appartenir à plusieurs groupes
        
        Console.WriteLine("\n===== Test de la méthode Afficher_grp() =====");
        g1.Afficher_grp();
        
        Console.WriteLine("\n===== Test de la méthode Ajouter_groupe() =====");
        ens1.Ajouter_groupe(g1);
        ens1.Ajouter_groupe(g2);
        ens2.Ajouter_groupe(g3);
        
        // Test de l'indexeur pour accéder aux groupes d'un enseignant
        Console.WriteLine("\n===== Test de l'indexeur pour accéder aux groupes =====");
        var groupe = ens1["Informatique_1A"];
        if (groupe != null)
        {
            Console.WriteLine($"Groupe trouvé via indexeur: {groupe.Nom}");
            groupe.Afficher_grp();
        }
        
        // Ajout du personnel à la liste GRH
        rh.AjouterPersonnel(directeur1);
        rh.AjouterPersonnel(admin1);
        rh.AjouterPersonnel(admin2);
        rh.AjouterPersonnel(ens1);
        rh.AjouterPersonnel(ens2);
        rh.AjouterPersonnel(ens3);
        
        Console.WriteLine("\n===== Test de la méthode Afficher_Enseignants() =====");
        rh.Afficher_Enseignants();
        
        Console.WriteLine("\n===== Test de la méthode Rechercher_Ens() =====");
        int position = rh.Rechercher_Ens(6);
        if (position != -1)
        {
            Console.WriteLine($"Enseignant trouvé à la position {position}:");
            Enseignant enseignantTrouve = rh.GetEnseignant(position);
            enseignantTrouve.Afficher_ens();
        }
        else
        {
            Console.WriteLine("Enseignant non trouvé.");
        }
        
        // Test d'un code qui n'existe pas
        position = rh.Rechercher_Ens(99);
        Console.WriteLine($"Recherche d'un enseignant inexistant (code 99): position = {position}");
        
        Console.WriteLine("\n===== Test de la méthode Calculer_Salaire() =====");
        foreach (var personnel in rh.Personnel)
        {
            Console.WriteLine($"{personnel.GetType().Name} {personnel.Nom}: Salaire = {personnel.Calculer_Salaire()} DH");
        }
        
        Console.WriteLine("\n===== Test de la méthode Afficher_ens() =====");
        ens1.Afficher_ens();
        
        Console.WriteLine("\nTests terminés.");
    }
}