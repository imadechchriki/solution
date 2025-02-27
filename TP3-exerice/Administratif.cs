namespace TP3_exerice;

public class Administratif : Personnel
{
    public Administratif(int code, string nom, string prenom, string bureau, double salaire)
        : base(code, nom, prenom, bureau, salaire)
    {
    }

    public override double Calculer_Salaire()
    {
        return salaire;
    }

    public override string ToString()
    {
        return $"Administratif: {base.ToString()}, Bureau: {bureau}, Salaire: {Calculer_Salaire()} DH";
    }
}
