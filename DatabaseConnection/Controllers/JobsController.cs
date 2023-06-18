using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class JobsController
{
    private Jobs _jobs = new Jobs();
    private Handling _handling = new Handling();
    private JobsView _JobsView = new JobsView();
    private InputView _InputView = new InputView();
    public void GetAll()
    {
        List<Jobs> JobList = _jobs.GetAll();
        _JobsView.GetAll(JobList);
    }
    public void Menu()
    {
        _JobsView.Menu();
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
