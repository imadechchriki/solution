using System;
using System.Collections.Generic;
using System.Linq;


namespace TP3_exerice;

public class Directeur : Personnel
{
    private static Directeur instance = null;
    private double primeDeplacement;

    // Constructeur privé pour empêcher l'instanciation directe
    private Directeur(int code, string nom, string prenom, string bureau, double salaire, double primeDeplacement)
        : base(code, nom, prenom, bureau, salaire)
    {
        this.primeDeplacement = primeDeplacement;
    }

    // Méthode statique pour obtenir l'unique instance
    public static Directeur getInstance(int code, string nom, string prenom, string bureau, double salaire, double primeDeplacement)
    {
        if (instance == null)
        {
            instance = new Directeur(code, nom, prenom, bureau, salaire, primeDeplacement);
        }
        else
        {
            Console.WriteLine("Erreur: Le directeur a déjà été instancié.");
        }
        return instance;
    }

    public override double Calculer_Salaire()
    {
        return salaire + primeDeplacement;
    }

    public override string ToString()
    {
        return $"Directeur: {base.ToString()}, Bureau: {bureau}, Salaire: {Calculer_Salaire()} DH";
    }
}