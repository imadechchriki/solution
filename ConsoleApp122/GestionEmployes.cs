namespace ConsoleApp122.obj;

public class GestionEmployes
{ 
    private List<Employee> employees = new List<Employee>();

    public void addEmployee(Employee employee)
    {
        employees.Add(employee);
        
    }

    public void SupprimerEmployee(string name)
    {
        employees.RemoveAll(e => e.name==name);
    }

    public double calculerSalaireTotal()
    {
        return employees.Sum(e => e.salary);
    }


    public double salairemoyenne()
    {
        return 
    }
    
    
    
}