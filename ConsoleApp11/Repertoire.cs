namespace ConsoleApp11;

public class Repertoire
{
    public String Nom { get; set; }
    private int Nbr_fichiers;
    private Fichier[] fichiers;

    public Repertoire(String nom)
    {
        Nom = nom;
        Nbr_fichiers = 0;
        fichiers = new Fichier[30];
    }

    public void Afficher()
    {
        Console.WriteLine("repertoire : {Nom}");
        if (Nbr_fichiers == 0)
        {
            Console.WriteLine("Aucun fichier.");
            return;
        }

        for (int i = 0; i < Nbr_fichiers; i++)
        {
            Console.WriteLine(fichiers[i]);
        }

    }

    public int Rechercher(string nom)
    {
        for (int i = 0; i < Nbr_fichiers; i++)
        {
            if (fichiers[i].Nom == nom)
                return i;
        }

        return -1;

    }

    public void ajouterFichier(Fichier fichier)
    {
        if (Nbr_fichiers < 30)
        {
            fichiers[Nbr_fichiers++] = fichier;
            Console.WriteLine("le fichier bient ajouter");
        }
        else
        {


            Console.WriteLine("le reprtoire est plein");


        }
    }

    public void RechercherPDF()
    {
        bool found = false;
        for (int i = 0; i < Nbr_fichiers; i++)
        {
            if (fichiers[i].Extension.ToLower() == ".pdf")
            {
                Console.WriteLine(fichiers[i]);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("reprtoire n'est pas extension");
        }
    }

    public void SupprimerFichier(string nom)
    {
        int index = Rechercher(nom);
        if (index != -1)
        {
            for (int i = index; i < Nbr_fichiers - 1; i++)
            {
                fichiers[i] = fichiers[i + 1];
            }

            fichiers[--Nbr_fichiers] = null;
            Console.WriteLine("Fichier supprimer");
        }
        else
        {
            Console.WriteLine("reprtoire n'est pas extension");
        }
    }


public void Renommer(string ancien, string nom)
{
    int index = Rechercher(ancien);
    if (index != -1)
    {
        fichiers[index].Nom = nom;
        Console.WriteLine("Fichier renommer");
    }
    else
    {
        Console.WriteLine("reprtoire n'est pas extension");
    }
}

public float Get



}

