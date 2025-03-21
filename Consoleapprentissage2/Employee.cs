namespace Consoleapprentissage2;

using System;

public class Employee
{
    public string Nom { get; set; }
    public double Salary { get; set; }
    public string Poste { get; set; }
    public DateTime Date { get; set; }

    public Employee(string nom, double salary, string poste, DateTime date)
    {
        Nom = nom;
        Salary = salary;
        Poste = poste;
        
    }
    
}