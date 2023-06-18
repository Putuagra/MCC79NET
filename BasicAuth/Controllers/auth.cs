using BasicAuth.Models;
using BasicAuth.Views;
using System.Text.RegularExpressions;

namespace BasicAuth.Controllers;

public class Auth
{
    private AuthView _AuthView = new AuthView();
    private InputView _InputView = new InputView();
    private EvenOddView _EvenOddView = new EvenOddView();
    public string CekNamaDepan(string nama)
    {
        while (nama.Length < 2 && nama != null)
        {
            _AuthView.SyaratNama();
            nama = _InputView.InputString();
        }
        return nama;
    }

    public string CekNamaBelakang(string nama)
    {
        while (nama.Length < 2 && nama != null)
        {
            _AuthView.SyaratNama();
            nama = _InputView.InputString();
        }
        return nama;
    }

    public string CekPass(string pass)
    {
        bool isValid = CheckPasswordRequirements(pass);
        while (isValid == false)
        {
            _AuthView.SyaratPassword();
            pass = _InputView.InputString();
            isValid = CheckPasswordRequirements(pass);
        }
        return pass;
    }
    bool CheckPasswordRequirements(string password)
    {

        Regex pass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        return pass.IsMatch(password);
    }

    public bool Login(List<User> login, string username, string password)
    {
        bool status = false;
        for (int i = 0; i < login.Count; i++)
        {
            if (username == login[i].Username && password == login[i].Password)
            {
                status = true;
                break;
            }
        }
        return status;
    }

    public bool LoginAdm(List<Admin> login, string username, string password)
    {
        bool status = false;
        for (int i = 0; i < login.Count; i++)
        {
            if (username == login[i].UserName && password == login[i].Password)
            {
                status = true;
                break;
            }
        }
        return status;
    }

    public bool cekId(List<User> cekId, int id)
    {
        bool status = false;
        for (int i = 0; i < cekId.Count; i++)
        {
            if (id > 0 && id <= cekId.Count)
            {
                status = true;
                break;
            }
        }
        return status;
    }
    public bool cekId(List<Admin> cekId, int id)
    {
        bool status = false;
        for (int i = 0; i < cekId.Count; i++)
        {
            if (id > 0 && id <= cekId.Count)
            {
                status = true;
                break;
            }
        }
        return status;
    }
    public void PrintEvenOdd(int limit, string choiche)
    {
        if (choiche.ToUpper() == "GANJIL")
        {
            if (limit > 0)
            {
                _EvenOddView.PrintLimit(limit);
                for (int i = 1; i <= limit; i++)
                {
                    if (i % 2 != 0)
                    {
                        _EvenOddView.PrintBilangan(i);
                    }
                }
            }
            else
            {
                _EvenOddView.InvalidInputLimit();
            }
        }
        else if (choiche.ToUpper() == "GENAP")
        {
            if (limit > 0)
            {
                _EvenOddView.PrintLimit(limit);
                for (int i = 1; i <= limit; i++)
                {
                    if (i % 2 == 0)
                    {
                        _EvenOddView.PrintBilangan(i);
                    }
                }
            }
            else
            {
                _EvenOddView.InvalidInputLimit();
            }
        }
        else { _EvenOddView.InvalidInputPilihan(); }
    }

    public string EvenOddCheck(int input)
    {
        string status;
        if (input > 0)
        {
            if (input % 2 == 0)
            {
                status = "Genap";
            }
            else
            {
                status = "Ganjil";
            }
        }
        else
        {
            status = "Invalid Input";
        }
        return status;
    }
}
