namespace Consoleapprentissage2;

public class Directeur
{
    private static Directeur instance = null;
    private GestionEmployes gestion;

    private Directeur()
    {
    }

    public static Directeur getInstance()
    {
        if (instance == null)
        {
            instance = new Directeur();
        }

        return instance;
    }


    public void setGestion(GestionEmployes gestion)
    {
        
        this.gestion = gestion;
    }


    public double getsalairetotal()
    {
        return gestion.calculerSalaire();
    }

    public double getsalairemoyen()
    {
        return gestion.calculerSalareMoyenne();
    }

    public void AfficherTousLesEmplyes()
    {
        foreach (var emp in gestion.getEmployees())
        {
            Console.WriteLine($"Nom : {emp.Nom} , Poste : {emp.Poste}");
        }
    }
    
    
    
    
}