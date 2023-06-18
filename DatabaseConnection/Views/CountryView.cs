using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class CountryView
{
    public void GetId(Country country)
    {
        Console.WriteLine("Id: " + country.Id + ", Name: " + country.Name + ", Region_id: " + country.RegionId);
    }

    public void GetAll(List<Country> country)
    {
        foreach (Country countries in country)
        {
            Console.WriteLine("Id: " + countries.Id + ", Name: " + countries.Name + ", Region_id: " + countries.RegionId);
        }
    }

    public void MenuGetId()
    {
        Console.Write("Masukkan id country: ");
    }


    public void MenuUpdateId()
    {
        Console.Write("Masukkan id country yang ingin diupdate: ");
    }

    public void MenuUpdateCountry()
    {
        Console.Write("Masukkan nama country: ");
    }
    public void MenuUpdateRegionId()
    {
        Console.Write("Masukkan region id: ");
    }

    public void MenuDeleteId()
    {
        Console.Write("Masukkan id country yang ingin dihapus: ");
    }
    public void MenuInsertCountry()
    {
        Console.Write("Masukkan inputan country: ");
    }
    public void MenuInsertId()
    {
        Console.Write("Masukkan Id country: ");
    }
    public void MenuInsertRegionId()
    {
        Console.Write("Masukkan region id: ");
    }
    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel countries");
        Console.WriteLine("2. Tampil isi tabel countries berdasarkan ID");
        Console.WriteLine("3. Insert isi");
        Console.WriteLine("4. Update isi");
        Console.WriteLine("5. Hapus isi");
        Console.WriteLine("6. Exit");
        Console.Write("Pilihan: ");
    }
}
