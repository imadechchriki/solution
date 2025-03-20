namespace ConsoleApp11;

public class Fichier
{
    public String Nom { get; set; }
    public String Extension { get; set; }
    public float Taille { get; set; }

    public Fichier(String nom, String extension, float taille)
    {
        Nom = nom;
        Extension = extension;
        Taille = taille;
    }
    
    
    public override  string ToString()
    {
        return $"{Nom} : {Extension} : {Taille} KO";
    }
    
}