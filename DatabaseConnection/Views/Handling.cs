namespace DatabaseConnection.Views;

public class Handling
{

    public void NotFound()
    {
        Console.WriteLine("Data not found");
    }

    public void SuccessInsert()
    {
        Console.WriteLine("Data berhasil diinsert");
    }
    public void SuccessUpdate()
    {
        Console.WriteLine("Data berhasil diupdate");
    }
    public void SuccessDelete()
    {
        Console.WriteLine("Data berhasil dihapus");
    }

    public void FailInsert()
    {
        Console.WriteLine("Data gagal diinsert");
    }
    public void FailUpdate()
    {
        Console.WriteLine("Data gagal diupdate");
    }
    public void FailDelete()
    {
        Console.WriteLine("Data gagal didelete");
    }

    public void SwitchDefault()
    {
        Console.WriteLine("ERROR : Input Not Valid");
    }

    public void ConsoleClear()
    {
        Console.Clear();
    }
}
