using DatabaseConnection.Models;

namespace DatabaseConnection.Views;

public class RegionView
{
    public void GetId(Region region)
    {
        Console.WriteLine("Id: " + region.Id + ", Name: " + region.Name);
    }

    public void GetAll(List<Region> region)
    {
        foreach (Region regions in region)
        {
            Console.WriteLine("Id: " + regions.Id + ", Name: " + regions.Name);
        }
    }

    public void MenuGetId()
    {
        Console.Write("Masukkan id region: ");
    }
    public void MenuUpdateForId()
    {
        Console.Write("Masukkan id region yang ingin diupdate: ");
    }
    public void MenuUpdateForRegion()
    {
        Console.Write("Masukkan nama region: ");
    }
    public void MenuDeleteForId()
    {
        Console.Write("Masukkan id region yang ingin dihapus: ");
    }
    public void MenuInsertForRegion()
    {
        Console.Write("Masukkan inputan Region: ");
    }

    public void Menu()
    {
        Console.WriteLine("1. Tampil semua isi tabel region");
        Console.WriteLine("2. Tampil isi tabel region berdasarkan ID");
        Console.WriteLine("3. Insert isi");
        Console.WriteLine("4. Update isi");
        Console.WriteLine("5. Hapus isi");
        Console.WriteLine("6. Exit");
        Console.Write("Pilihan: ");
    }
}
