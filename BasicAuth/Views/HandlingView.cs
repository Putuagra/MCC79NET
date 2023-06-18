namespace BasicAuth.Views;

public class HandlingView
{
    public void InvalidUnamePass()
    {
        Console.WriteLine("Username atau Password Salah");
    }
    public void IdNotFound()
    {
        Console.WriteLine("ID tidak ditemukan");
    }
    public void InvalidInput()
    {
        Console.WriteLine("Inputan Tidak Ditemukan");
    }
    public void InvalidPilihan()
    {
        Console.WriteLine("Pilihan tidak valid");
    }
    public void InvalidNumber()
    {
        Console.WriteLine("Inputan Bukan Angka");
    }
    public void SwitchDefault()
    {
        Console.WriteLine("ERROR : Input Not Valid");
    }
}
