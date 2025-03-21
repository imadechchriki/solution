namespace Consoleapprentissage2;


using System.Collections.Generic;







public class GestionEmployes
{
 private List<Employee> employees = new List<Employee>();

 public void AjouterEmployee(Employee employee)
 {
  employees.Add(employee);
 }


 public void SuprimerEmployee(Employee employee)
 {
  employees.Remove(employee);
 }

 public double calculerSalaire()
 {
  return employees.Sum(e => e.Salary);
 }


 public double calculerSalareMoyenne()
 {
  if (employees.Count == 0) return 0;
  return employees.Average(e => e.Salary);
 }


 public List<Employee> getEmployees()
 {
  return employees;
 }
    

    
}