using BasicAuth.Models;
using BasicAuth.Views;

namespace BasicAuth.Controllers;

public class Show
{
    private MenuView _MenuView = new MenuView();
    private HandlingView _HandlingView = new HandlingView();
    public void Tampil(List<User> tampil)
    {
        _MenuView.TampilUser(tampil);
    }
    public void Tampil(List<Admin> tampil)
    {
        _MenuView.TampilAdmin(tampil);
    }
    public void TampilSearch(List<User> tampil)
    {
        _MenuView.SearchUser(tampil);
    }
    public void TampilSearch(List<Admin> tampil)
    {
        _MenuView.SearchAdmin(tampil);
    }
    public void EditUser(List<User> editUser, User userEdit, int id)
    {
        editUser[id - 1].FirstName = userEdit.FirstName;
        editUser[id - 1].LastName = userEdit.LastName;
        editUser[id - 1].Username = userEdit.FirstName.Substring(0, 2) + userEdit.LastName.Substring(0, 2);
        editUser[id - 1].Password = userEdit.Password;
        _MenuView.PesanUpdate();
    }
    public void EditUser(List<Admin> editUser, Admin userEdit, int id)
    {
        editUser[id - 1].FirstName = userEdit.FirstName;
        editUser[id - 1].LastName = userEdit.LastName;
        editUser[id - 1].UserName = userEdit.FirstName.Substring(0, 2) + userEdit.LastName.Substring(0, 2);
        editUser[id - 1].Password = userEdit.Password;
        _MenuView.PesanUpdate();
    }
    public void DeleteUser(List<User> deleteUser, int id)
    {
        if (id < 0 || id > deleteUser.Count)
        {
            _HandlingView.IdNotFound();
        }
        else
        {
            deleteUser.RemoveAt(id - 1);
            _MenuView.PesanHapus();
        }
    }
    public void DeleteUser(List<Admin> deleteUser, int id)
    {
        if (id < 0 || id > deleteUser.Count)
        {
            _HandlingView.IdNotFound();
        }
        else
        {
            deleteUser.RemoveAt(id - 1);
            _MenuView.PesanHapus();
        }
    }
    public string CreateUser(List<User> createUser, User userCreate)
    {
        createUser.Add(userCreate);
        string pesan = _MenuView.CreateUser();
        return pesan;
    }

    public string CreateAdmin(List<Admin> createUser, Admin AdminCreate)
    {
        createUser.Add(AdminCreate);
        string pesan = _MenuView.CreateAdmin();
        return pesan;
    }
}
