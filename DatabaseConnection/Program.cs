using DatabaseConnection.Controllers;

namespace DatabaseConnection;

public class DatabaseConnection
{
    public static void Main(string[] args)
    {
        MainMenu menu = new MainMenu();
        menu.menu();
    }
}