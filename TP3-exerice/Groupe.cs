namespace TP3_exerice;

public class Groupe
{
    private string nom;
    private List<Etudiant> etudiants;

    public Groupe(string nom)
    {
        this.nom = nom;
        this.etudiants = new List<Etudiant>();
    }

    public string Nom { get { return nom; } }
    public List<Etudiant> Etudiants { get { return etudiants; } }

    public void Ajouter_etudiant(Etudiant etudiant)
    {
        etudiants.Add(etudiant);
        Console.WriteLine($"Étudiant {etudiant.Nom} ajouté au groupe {nom}");
    }

    public void Afficher_grp()
    {
        Console.WriteLine($"Groupe: {nom}");
        Console.WriteLine("Liste des étudiants:");
        foreach (var etudiant in etudiants)
        {
            etudiant.Afficher_etd();
        }
    }
}