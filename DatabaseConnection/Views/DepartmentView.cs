using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class DepartmentView
{
    public void GetAll(List<Departments> departments)
    {
        foreach (Departments department in departments)
        {
            Console.WriteLine("Id: " + department.Id + ", Name: " + department.Name + ", Location Id: " + department.LocationId + ", Manager Id: " + department.ManagerId);
        }
    }
    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel department");
        Console.WriteLine("2. Exit");
        Console.WriteLine("Pilihan: ");
    }
}
