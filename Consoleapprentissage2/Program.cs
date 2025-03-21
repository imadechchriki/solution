// See https://aka.ms/new-console-template for more information
namespace Consoleapprentissage2;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Création de l'objet de gestion
        GestionEmployes gestion = new GestionEmployes();

        // Ajout de quelques employés
        gestion.AjouterEmployee(new Employee("Alice", 3000, "Développeur", new DateTime(2020, 1, 15)));
        gestion.AjouterEmployee(new Employee("Bob", 4500, "Manager", new DateTime(2018, 3, 10)));
        gestion.AjouterEmployee(new Employee("Claire", 3800, "Testeur", new DateTime(2021, 5, 1)));

        // Accès au directeur (Singleton)
        Directeur directeur = Directeur.getInstance();
        directeur.setGestion(gestion);

        // Affichage des infos
        Console.WriteLine("Liste des employés :");
        directeur.AfficherTousLesEmplyes();

        Console.WriteLine("\nSalaire total de l'entreprise : " + directeur.getsalairetotal());
        Console.WriteLine("Salaire moyen des employés : " + directeur.getsalairemoyen());
    }
}
