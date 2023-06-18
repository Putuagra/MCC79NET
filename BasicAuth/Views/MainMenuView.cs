namespace BasicAuth.Views;

public class MainMenuView
{
    public void Home()
    {
        Console.WriteLine("==LOGIN==");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Exit");
        Console.Write("Input: ");
    }
    public void Login()
    {
        Console.Write("Login User/Admin: ");
    }
    public void InputUname()
    {
        Console.Write("Input Username: ");
    }
    public void InputPassword()
    {
        Console.Write("Input Password: ");
    }
    public void MenuAdmin()
    {
        Console.WriteLine("==BASIC AUTHENTICATION==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Logout");
        Console.Write("Input: ");
    }

}
