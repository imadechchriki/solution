namespace TP3_exerice;

public class Enseignant : Personnel
{
    private string grade;
    private int volumeHoraire;
    private Dictionary<string, Groupe> groupes;
    private double primeDeplacement;

    public Enseignant(int code, string nom, string prenom, string bureau, double salaire, string grade, int volumeHoraire, double primeDeplacement)
        : base(code, nom, prenom, bureau, salaire)
    {
        this.grade = grade;
        this.volumeHoraire = volumeHoraire;
        this.primeDeplacement = primeDeplacement;
        this.groupes = new Dictionary<string, Groupe>();
    }

    // Indexeur pour accéder aux groupes par nom
    public Groupe this[string nom]
    {
        get
        {
            if (groupes.ContainsKey(nom))
                return groupes[nom];
            else
                return null;
        }
    }

    public override double Calculer_Salaire()
    {
        double tauxHoraire;
        
        // Déterminer le taux horaire en fonction du grade
        switch (grade.ToUpper())
        {
            case "PA":
                tauxHoraire = 300;
                break;
            case "PH":
                tauxHoraire = 350;
                break;
            case "PES":
                tauxHoraire = 400;
                break;
            default:
                tauxHoraire = 300; // Valeur par défaut
                break;
        }

        // Calculer les heures supplémentaires (au-delà du volume horaire contractuel)
        int heuresSupp = Math.Max(0, volumeHoraire - 192); // Supposons 192h comme volume horaire standard annuel
        
        // Salaire de base + prime de déplacement + paiement des heures supplémentaires
        return salaire + primeDeplacement + (heuresSupp * tauxHoraire);
    }

    public void Ajouter_groupe(Groupe groupe)
    {
        if (!groupes.ContainsKey(groupe.Nom))
        {
            groupes.Add(groupe.Nom, groupe);
            Console.WriteLine($"Groupe {groupe.Nom} ajouté à l'enseignant {nom}");
        }
        else
        {
            Console.WriteLine($"Le groupe {groupe.Nom} existe déjà pour cet enseignant");
        }
    }

    public void Afficher_ens()
    {
        Console.WriteLine($"Enseignant: {base.ToString()}, Bureau: {bureau}, Grade: {grade}");
        Console.WriteLine($"Volume horaire: {volumeHoraire}h, Salaire total: {Calculer_Salaire()} DH");
        
        if (groupes.Count > 0)
        {
            Console.WriteLine("Groupes enseignés:");
            foreach (var groupe in groupes.Values)
            {
                Console.WriteLine($"- {groupe.Nom} ({groupe.Etudiants.Count} étudiants)");
            }
        }
        else
        {
            Console.WriteLine("Aucun groupe assigné");
        }
    }

    public string Grade { get { return grade; } }
    public int VolumeHoraire { get { return volumeHoraire; } }
    public Dictionary<string, Groupe> Groupes { get { return groupes; } }
}
