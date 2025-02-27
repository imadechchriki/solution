namespace TP3_exerice;

public class Personne
{
    protected int code;
    protected string nom;
    protected string prenom;

    public Personne(int code, string nom, string prenom)
    {
        this.code = code;
        this.nom = nom;
        this.prenom = prenom;
    }

    public int Code { get { return code; } }
    public string Nom { get { return nom; } }
    public string Prenom { get { return prenom; } }

    public override string ToString()
    {
        return $"Code: {code}, Nom: {nom}, Prénom: {prenom}";
    }
}