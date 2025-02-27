namespace TP3_exerice;

public class Etudiant : Personne
{
    private string niveau;
    private double moyenneAnnuelle;

    public Etudiant(int code, string nom, string prenom, string niveau, double moyenneAnnuelle)
        : base(code, nom, prenom)
    {
        this.niveau = niveau;
        this.moyenneAnnuelle = moyenneAnnuelle;
    }

    public string Niveau { get { return niveau; } }
    public double MoyenneAnnuelle { get { return moyenneAnnuelle; } }

    public void Afficher_etd()
    {
        Console.WriteLine($"Étudiant: {base.ToString()}, Niveau: {niveau}, Moyenne annuelle: {moyenneAnnuelle}");
    }
}
