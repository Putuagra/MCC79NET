namespace BasicAuth.Views;

public class AuthView
{
    public void SyaratNama()
    {
        Console.WriteLine("");
        Console.WriteLine("Name has to be at least consisting 2 characters or more.");
        Console.Write("First Name: ");
    }

    public void SyaratPassword()
    {
        Console.WriteLine("");
        Console.WriteLine("Password must have at least 8 characters ");
        Console.WriteLine("with at least one Capital letter, at least one lower case letter and at least one number.");
        Console.Write("Password: ");
    }
}
