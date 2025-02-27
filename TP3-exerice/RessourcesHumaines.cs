namespace TP3_exerice;

public class RessourcesHumaines : IRessourcesHumaines
{
    private List<Personnel> GRH;

    public RessourcesHumaines()
    {
        GRH = new List<Personnel>();
    }

    public void AjouterPersonnel(Personnel p)
    {
        GRH.Add(p);
    }

    public void Afficher_Enseignants()
    {
        Console.WriteLine("Liste des enseignants:");
        bool enseignantsTrouves = false;
        
        foreach (var personnel in GRH)
        {
            if (personnel is Enseignant)
            {
                Enseignant enseignant = (Enseignant)personnel;
                enseignantsTrouves = true;
                enseignant.Afficher_ens();
                Console.WriteLine();
            }
        }
        
        if (!enseignantsTrouves)
        {
            Console.WriteLine("Aucun enseignant trouvé.");
        }
    }

    public int Rechercher_Ens(int code)
    {
        for (int i = 0; i < GRH.Count; i++)
        {
            if (GRH[i] is Enseignant && GRH[i].Code == code)
            {
                return i;
            }
        }
        return -1;
    }

    public Enseignant GetEnseignant(int index)
    {
        if (index >= 0 && index < GRH.Count && GRH[index] is Enseignant)
        {
            return (Enseignant)GRH[index];
        }
        return null;
    }

    public List<Personnel> Personnel 
    { 
        get { return GRH; } 
    }
}