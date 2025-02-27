namespace TP3_exerice;

public abstract class Personnel : Personne
{
    protected string bureau;
    protected double salaire;

    public Personnel(int code, string nom, string prenom, string bureau, double salaire)
        : base(code, nom, prenom)
    {
        this.bureau = bureau;
        this.salaire = salaire;
    }

    public string Bureau { get { return bureau; } }
    public double Salaire { get { return salaire; } }

    // Méthode abstraite à implémenter dans les classes dérivées
    public abstract double Calculer_Salaire();
}