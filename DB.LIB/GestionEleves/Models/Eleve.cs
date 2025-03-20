using System;
using System.Collections.Generic;
using System.Data;
using DB.LIB;

namespace GestionEleves
{
    public class Eleve : DAO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        

        


        public override string ToString()
        {
            return $"ID: {Id}, Nom: {Nom}, Prénom: {Prenom}, Date de naissance: {DateNaissance.ToShortDateString()}, Adresse: {Adresse}, Téléphone: {Telephone}, Email: {Email}";
        }
    }
}