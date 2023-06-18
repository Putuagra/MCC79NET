using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class HistoriesController
{
    private Histories _histories = new Histories();
    private Handling _handling = new Handling();
    private HistoriesView _HistoriesView = new HistoriesView();
    private InputView _InputView = new InputView();
    public void GetAll()
    {
        List<Histories> history = _histories.GetAll();
        _HistoriesView.GetAll(history);
    }
    public void Menu()
    {
        _HistoriesView.Menu();
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
