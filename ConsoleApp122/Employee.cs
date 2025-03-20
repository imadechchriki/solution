using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp122.obj;

public class Employee
{
   //les attributs 
    public string name { get; set; }
    public double salary { get; set; }
    public string PostedBy { get; set; }
    public DateTime dateEmbauche { get; set; }

//constructeur
    public Employee(string nom, double Salary, string PostedBy, DateTime DateEmbauche)
    {
        name = nom;
        salary = Salary;
        PostedBy = PostedBy;
        dateEmbauche = DateEmbauche;
    }
    
    
    
    
}
    
    
