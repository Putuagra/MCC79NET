using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class EmployeesView
{
    public void GetAll(List<Employees> employees)
    {
        foreach (Employees employee in employees)
        {
            Console.WriteLine("Id: " + employee.Id + ", First Name: " + employee.FirstName + ", Last Name: " + employee.LastName + ", Email: " + employee.Email + ", Phone Number: " + employee.PhoneNumber + ", Hire Date: " + employee.HireDate + ", Salary: " + employee.Salary + ", Comission: " + employee.CommissionPct + ", Manager Id: " + employee.ManagerId + ", Job Id: " + employee.JobId + "Department Id: " + employee.DepartmentId);
            Console.WriteLine("");
        }
    }
    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel employees");
        Console.WriteLine("2. Exit");
        Console.WriteLine("Pilihan: ");
    }
}
