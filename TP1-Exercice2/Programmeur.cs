using System;

namespace GestionProjet
{
    // Classe représentant un programmeur
    class Programmeur
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Bureau { get; set; }

        public Programmeur(int id, string nom, string prenom, int bureau)
        {
            ID = id;
            Nom = nom;
            Prenom = prenom;
            Bureau = bureau;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nom: {Nom}, Prénom: {Prenom}, Bureau: {Bureau}";
        }
    }
}