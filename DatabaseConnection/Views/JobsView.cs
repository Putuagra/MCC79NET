using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class JobsView
{
    public void GetAll(List<Jobs> jobs)
    {
        foreach (Jobs job in jobs)
        {
            Console.WriteLine("Id: " + job.Id + ", Title: " + job.Title + ", Min Salary: " + job.MinSalary + ", Max Salary: " + job.MaxSalary);
        }
    }
    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel jobs");
        Console.WriteLine("2. Exit");
        Console.Write("Pilihan: ");
    }
}
