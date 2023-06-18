using BasicAuth.Models;

namespace BasicAuth.Views;

public class MenuView
{
    public void TampilUser(List<User> tampil)
    {
        int i = 1;
        foreach (User user in tampil)
        {
            Console.WriteLine("========================");
            Console.WriteLine("ID: " + i);
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.Username);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("========================");
            i++;
        }
    }

    public void TampilAdmin(List<Admin> tampil)
    {
        int i = 1;
        foreach (Admin user in tampil)
        {
            Console.WriteLine("========================");
            Console.WriteLine("ID: " + i);
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.UserName);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("========================");
            i++;
        }
    }

    public void SearchUser(List<User> tampil)
    {
        foreach (User user in tampil)
        {
            Console.WriteLine("========================");
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.Username);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("========================");
        }
    }
    public void SearchAdmin(List<Admin> tampil)
    {
        foreach (Admin user in tampil)
        {
            Console.WriteLine("========================");
            Console.WriteLine("Name: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.UserName);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("========================");
        }
    }
    public void PesanUpdate()
    {
        Console.WriteLine("Data sudah diperbarui");
    }

    public void PesanHapus()
    {
        Console.WriteLine("Data sudah dihapus");
    }
    public string CreateAdmin()
    {
        string pesan = "Admin Success to Created!!!";
        return pesan;
    }
    public string CreateUser()
    {
        string pesan = "User Success to Created!!!";
        return pesan;
    }
    public void GanjilGenap()
    {
        Console.WriteLine("");
        Console.WriteLine("=====================================");
        Console.WriteLine("           MENU GANJIL GENAP     ");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
        Console.WriteLine("3. Logout");
        Console.WriteLine("-------------------------------------");
        Console.Write("Pilihan: ");
    }
    public void LoginCase()
    {
        Console.WriteLine("==LOGIN==");
        Console.Write("Login (USER/ADMIN): ");
    }
    public void Bilangan()
    {
        Console.Write("Masukkan Bilangan yang ingin di cek : ");
    }
    public void CheckGanjilGenap(string pilihan)
    {
        Console.WriteLine(pilihan);
    }
    public void PilihGanjilGenap()
    {
        Console.Write("Pilih (Ganjil/Genap): ");
    }
    public void InputLimit()
    {
        Console.Write("Masukkan Limit: ");
    }
}
