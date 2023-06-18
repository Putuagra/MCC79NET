using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class DepartmentController
{
    private Departments _departments = new Departments();
    private Handling _handling = new Handling();
    private DepartmentView _DepartmentView = new DepartmentView();
    private InputView _InputView = new InputView();
    public void GetAll()
    {
        List<Departments> department = _departments.GetAll();
        _DepartmentView.GetAll(department);
    }
    public void Menu()
    {
        _DepartmentView.Menu();
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
