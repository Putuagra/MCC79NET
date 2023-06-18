namespace BasicAuth.Views;

public class EvenOddView
{
    public void PrintBilangan(int i)
    {
        Console.Write($"{i}, ");
    }

    public void PrintLimit(int limit)
    {
        Console.WriteLine("Print bilangan 1 - " + limit);
    }

    public void InvalidInputLimit()
    {
        Console.WriteLine("Input Limit Tidak Valid");
    }

    public void InvalidInputPilihan()
    {
        Console.WriteLine("Input pilihan tidak valid");
    }
}
