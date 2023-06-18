namespace BasicAuth.Views;

public class InputView
{
    public string InputString()
    {
        string inputan = Console.ReadLine();
        return inputan;
    }
    public int InputInt()
    {
        int inputan = int.Parse(Console.ReadLine());
        return inputan;
    }
}
