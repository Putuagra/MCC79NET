using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class EmployeesController
{
    private Employees _employees = new Employees();
    private Handling _handling = new Handling();
    private EmployeesView _EmployeesView = new EmployeesView();
    private InputView _InputView = new InputView();
    public void GetAll()
    {
        List<Employees> EmployeeList = _employees.GetAll();
        _EmployeesView.GetAll(EmployeeList);
    }
    public void Menu()
    {
        _EmployeesView.Menu();
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
        catch (Exception ex)
        {
            _handling.SwitchDefault();
        }
    }
}
