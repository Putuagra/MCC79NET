using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class LocationView
{
    public void GetAll(List<Location> locations)
    {
        foreach (Location location in locations)
        {
            Console.WriteLine("Id: " + location.Id + ", Street Address: " + location.StreetAddress + ", Postal Code: " + location.PostalCode + ", City: " + location.City + ", State Province: " + location.StateProvince + ", Country Id: " + location.CountryId);
        }
    }
    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel location");
        Console.WriteLine("2. Exit");
        Console.Write("Pilihan: ");
    }
}
