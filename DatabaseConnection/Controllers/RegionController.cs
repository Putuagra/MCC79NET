using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class RegionController
{
    private Region _region = new Region();
    private Handling _handling = new Handling();
    private RegionView _RegionView = new RegionView();
    private InputView _InputView = new InputView();

    public void GetById()
    {
        _RegionView.MenuGetId();
        int id = _InputView.InputInt();
        var regions = _region.GetById(id);
        _RegionView.GetId(regions);
    }
    public void Update()
    {
        _RegionView.MenuUpdateForId();
        int IdInput = _InputView.InputInt();
        _RegionView.MenuUpdateForRegion();
        string RegionInput = _InputView.InputString();
        int isUpdateSuccess = _region.Update(IdInput, RegionInput);
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
        _RegionView.MenuDeleteForId();
        int IdInput = _InputView.InputInt();
        int isDeleteSuccess = _region.Delete(IdInput);
        if (isDeleteSuccess > 0)
        {
            _handling.SuccessDelete();
        }
        else
        {
            _handling.FailDelete();
        }
    }
    public void GetAll()
    {
        List<Region> regions = _region.GetAll();
        _RegionView.GetAll(regions);
    }

    public void Insert()
    {
        _RegionView.MenuInsertForRegion();
        string RegionInput = _InputView.InputString();
        int isUpdateSuccess = _region.Insert(RegionInput);
        if (isUpdateSuccess > 0)
        {
            _handling.SuccessInsert();
        }
        else
        {
            _handling.FailInsert();
        }
    }
    public void Menu()
    {
        _RegionView.Menu();
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
            _handling.ConsoleClear();
            _handling.SwitchDefault();
        }
    }
}
