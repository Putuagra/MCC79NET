using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class LocationController
{
    private Location _location = new Location();
    private Handling _handling = new Handling();
    private LocationView _LocationView = new LocationView();
    private InputView _InputView = new InputView();
    public void GetAll()
    {
        List<Location> LocationList = _location.GetAll();
        _LocationView.GetAll(LocationList);
    }
    public void Menu()
    {
        _LocationView.Menu();
        int number = _InputView.InputInt();
        try
        {
            switch (number)
            {
                case 1:
                    _handling.ConsoleClear();
                    GetAll();
                    break;
                case 2:
                    break;
                default:
                    _handling.SwitchDefault();
                    break;
            }
        }
        catch (Exception)
        {
            _handling.SwitchDefault();
        }
    }
}
