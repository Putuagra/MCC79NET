using BasicAuth.Controllers;
using BasicAuth.Models;

namespace BasicAuth.Views;

public class CrudView
{
    Show show = new Show();
    public void Firstname()
    {
        Console.Write("First Name: ");
    }
    public void LastName()
    {
        Console.Write("Last Name: ");
    }
    public void Username()
    {
        Console.Write("Username: ");
    }
    public void Password()
    {
        Console.Write("Password: ");
    }
    public void UserAdmin()
    {
        Console.Write("Buat User/Admin: ");
    }
    public void CaseCreate(string show)
    {
        Console.WriteLine(show);
    }
    public void CaseShow(List<User> list, List<Admin> listAdm)
    {
        Console.WriteLine("==========USER==========");
        show.Tampil(list);
        Console.WriteLine("========================");
        Console.WriteLine("");
        Console.WriteLine("=========ADMIN==========");
        show.Tampil(listAdm);
        Console.WriteLine("========================");
    }
    public void CaseSearch()
    {
        Console.WriteLine("==Cari Akun==");
        Console.Write("Masukan Nama: ");
    }
    public void CaseLogin()
    {
        Console.WriteLine("==LOGIN==");
        Console.Write("Login (USER/ADMIN): ");
    }
    public void LoginUser(List<User> list, string InputName, string InputPass)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (InputName == list[i].Username && InputPass == list[i].Password)
            {
                Console.WriteLine("Login " + list[i].FirstName + " " + list[i].LastName + " Berhasil");
            }
        }
    }
    public void LoginAdmin(List<Admin> listAdm, string InputName, string InputPass)
    {
        for (int i = 0; i < listAdm.Count; i++)
        {
            if (InputName == listAdm[i].UserName && InputPass == listAdm[i].Password)
            {
                Console.WriteLine("Login " + listAdm[i].FirstName + " " + listAdm[i].LastName + " Berhasil");
            }
        }
    }
    public void MenuEditDelete()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("1. Edit User");
        Console.WriteLine("2. Delete User");
        Console.WriteLine("3. Back");
        Console.Write("Input: ");
    }
    public void UpdateUserAdmin()
    {
        Console.Write("Ubah User/Admin: ");
    }
    public void UpdateId()
    {
        Console.Write("Id Yang Ingin Diubah : ");
    }
    public void isInteger()
    {
        Console.WriteLine("Inputan Bukan Angka");
        Console.Write("Id : ");
    }
    public void DeleteUserAdmin()
    {
        Console.Write("Hapus User/Admin: ");
    }
    public void DeleteId()
    {
        Console.Write("Id Yang Ingin Dihapus :");
    }
}
