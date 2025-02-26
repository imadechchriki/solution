using System;

namespace TP_1_Exercice1
{
    public class Fichier
    {
        public string Nom { get; set; }
        public string Extension { get; set; }
        public float Taille { get; set; } // en KO

        public Fichier(string nom, string extension, float taille)
        {
            Nom = nom;
            Extension = extension;
            Taille = taille;
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Extension: {Extension}, Taille: {Taille} KO";
        }
    }
}