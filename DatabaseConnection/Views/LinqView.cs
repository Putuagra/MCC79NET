using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class LinqView
{
    public void soal1(List<UserSoal1> linq)
    {
        foreach (var item in linq)
        {
            Console.WriteLine($" ID: {item.Id}, " +
                $"Full Name: {item.FullName}, " +
                $"Email: {item.Email}, " +
                $"Phone: {item.PhoneNumber}, " +
                $"Salary: {item.Salary}, " +
                $"DepartmentName: {item.DepartmentName}, " +
                $"Street Address: {item.Location}, " +
                $"Country Name: {item.CountryName}, " +
                $"Region Name: {item.RegionName}");
            Console.WriteLine();
        }
    }
    public void soal2(List<UserSoal2> linq)
    {
        foreach (var item in linq)
        {
            Console.WriteLine($" Department Name: {item.DepartmentName}, " +
                $"Total Employee: {item.TotalEmployee}, " +
                $"Min Salary: {item.MinSalary}, " +
                $"Max Salary: {item.MaxSalary}, " +
                $"Average Salary: {item.AverageSalary}");
            Console.WriteLine();
        }
    }
    public void Menu()
    {
        Console.WriteLine("1. Soal 1");
        Console.WriteLine("2. Soal 2");
        Console.WriteLine("3. Exit");
        Console.Write("Inputan: ");
    }
}
