namespace DatabaseConnection.Views;

public class InputView
{
    public int InputInt()
    {
        int inputan = int.Parse(Console.ReadLine());
        return inputan;
    }
    public string InputString()
    {
        string inputan = Console.ReadLine();
        return inputan;
    }
}
