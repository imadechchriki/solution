using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Ecole
{
    internal class Eleve
    {
        private int id;
        private string nom;
        private string prenom;
        private string ville;
        private string specialite;

        public Eleve(int id=0, string nom=null, string prenom=null, string ville=null, string specialite=null)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.ville = ville;
            this.specialite = specialite;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Nom { get { return nom;  } set { nom = value;  }  }
        public string Prenom { get {return prenom; } set { prenom = value; } }  
        public string Ville { get { return ville; } set { ville = value; } }    
        public string Specialite { get { return specialite; } set { specialite = value; } }

        public Dictionary<string, object> ObjToDico()
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {  if(p.Name =="Id" && Int32.Parse(p.GetValue(this).ToString())!=0)
                dico["id"] = p.GetValue(this);
               else
                if (p.Name!="Id"&&p.GetValue(this)!=null)
                dico[p.Name] = p.GetValue(this);
            }

            return dico;
        }



    }
}
