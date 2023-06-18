using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class CountryController
{
    Country country = new Country();
    private Handling _handling = new Handling();
    private CountryView _CountryView = new CountryView();
    private InputView _InputView = new InputView();
    public void GetById()
    {
        _CountryView.MenuGetId();
        string inputan = _InputView.InputString();
        Country countries = country.GetById(inputan);
        _CountryView.GetId(countries);
    }

    public void Update()
    {
        _CountryView.MenuUpdateId();
        string idInput = _InputView.InputString();
        _CountryView.MenuUpdateCountry();
        string countryInput = _InputView.InputString();
        _CountryView.MenuUpdateRegionId();
        int regionId = _InputView.InputInt();
        int isUpdateSuccess = country.Update(idInput, countryInput, regionId);
        if (isUpdateSuccess > 0)
        {
            _handling.SuccessUpdate();
        }
        else
        {
            _handling.FailUpdate();
        }
    }

    public void Delete()
    {

        _CountryView.MenuDeleteId();
        string idInput = _InputView.InputString();
        int isDeleteSuccess = country.Delete(idInput);
        if (isDeleteSuccess > 0)
        {
            _handling.SuccessDelete();
        }
        else
        {
            _handling.FailDelete();
        }
    }

    public void Insert()
    {
        _CountryView.MenuInsertId();
        string idCountry = _InputView.InputString();
        _CountryView.MenuInsertCountry();
        string countryInput = _InputView.InputString();
        _CountryView.MenuUpdateRegionId();
        int idInput = _InputView.InputInt();
        int isUpdateSuccess = country.Insert(idCountry, countryInput, idInput);
        if (isUpdateSuccess > 0)
        {
            _handling.SuccessInsert();
        }
        else
        {
            _handling.FailInsert();
        }
    }

    public void GetAll()
    {
        List<Country> countries = country.GetAll();
        _CountryView.GetAll(countries);
    }
    public void Menu()
    {
        _CountryView.Menu();
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
                    _handling.ConsoleClear();
                    GetById();
                    break;
                case 3:
                    _handling.ConsoleClear();
                    Insert();
                    break;
                case 4:
                    _handling.ConsoleClear();
                    Update();
                    break;
                case 5:
                    _handling.ConsoleClear();
                    Delete();
                    break;
                case 6:
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
