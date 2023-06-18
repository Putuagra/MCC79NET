using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class MainMenu
{
    private Handling _handling = new Handling();
    private MenuView _MenuView = new MenuView();
    private InputView _InputView = new InputView();
    bool isFinish = false;
    public void menu()
    {
        while (!isFinish)
        {
            try
            {
                _MenuView.Menu();
                int number = _InputView.InputInt();
                switch (number)
                {
                    case 1:
                        new RegionController().Menu();
                        break;
                    case 2:
                        new CountryController().Menu();
                        break;
                    case 3:
                        new DepartmentController().Menu();
                        break;
                    case 4:
                        new EmployeesController().Menu();
                        break;
                    case 5:
                        new JobsController().Menu();
                        break;
                    case 6:
                        new LocationController().Menu();
                        break;
                    case 7:
                        new HistoriesController().Menu();
                        break;
                    case 8:
                        new LinqController().Menu();
                        break;
                    case 9:
                        isFinish = true;
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
}
