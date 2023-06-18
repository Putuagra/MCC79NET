using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers;

public class LinqController
{
    Departments department = new();
    Employees employees = new();
    Location location = new();
    Region region = new();
    Country country = new();
    private LinqView _LinqView = new LinqView();
    private InputView _InputView = new InputView();
    private Handling _handling = new Handling();

    public List<UserSoal1> Soal1()
    {
        var soal1 = (from e in employees.GetAll()
                     join d in department.GetAll() on e.DepartmentId equals d.Id
                     join l in location.GetAll() on d.LocationId equals l.Id
                     join c in country.GetAll() on l.CountryId equals c.Id
                     join r in region.GetAll() on c.RegionId equals r.Id
                     select new UserSoal1
                     {
                         Id = e.Id,
                         FullName = e.FirstName + " " + e.LastName,
                         Email = e.Email,
                         PhoneNumber = e.PhoneNumber,
                         Salary = (int)e.Salary,
                         DepartmentName = d.Name,
                         Location = l.StreetAddress,
                         CountryName = c.Name,
                         RegionName = r.Name
                     }).Take(5).ToList();
        return soal1;
    }
    public void GetSoal1()
    {
        List<UserSoal1> Soal1List = Soal1();
        _LinqView.soal1(Soal1List);
    }

    public void Soal1MethodSyntax()
    {
        var soal1 = employees.GetAll()
    .Join(department.GetAll(), e => e.DepartmentId, d => d.Id, (e, d) => new { Employee = e, Department = d })
    .Join(location.GetAll(), ed => ed.Department.LocationId, l => l.Id, (ed, l) => new { ed.Employee, ed.Department, Location = l })
    .Join(country.GetAll(), edl => edl.Location.CountryId, c => c.Id, (edl, c) => new { edl.Employee, edl.Department, edl.Location, Country = c })
    .Join(region.GetAll(), edlc => edlc.Country.RegionId, r => r.Id, (edlc, r) => new { edlc.Employee, edlc.Department, edlc.Location, edlc.Country, Region = r })
    .Select(e => new UserSoal1
    {
        Id = e.Employee.Id,
        FullName = e.Employee.FirstName + " " + e.Employee.LastName,
        Email = e.Employee.Email,
        PhoneNumber = e.Employee.PhoneNumber,
        Salary = (int)e.Employee.Salary,
        DepartmentName = e.Department.Name,
        Location = e.Location.StreetAddress,
        CountryName = e.Country.Name,
        RegionName = e.Region.Name
    })
    .Take(5)
    .ToList();
        /*foreach (var item in soal1)
        {
            Console.WriteLine($" ID: {item.Id}, " +
                $"Full Name: {item.FullName}, " +
                $"Email: {item.Email}, " +
                $"Phone: {item.PhoneNumber}, " +
                $"Salary: {item.Salary}, " +
                $"DepartmentName: {item.DepartmentName}, " +
                $"Street Address: {item.Location}, " +
                $"Country Name: {item.CountryName}, " +
                $"Region Name: {item.RegionName}");
            Console.WriteLine();
        }*/
    }

    public List<UserSoal2> Soal2()
    {
        var soal2 = (from e in employees.GetAll()
                     join d in department.GetAll() on e.DepartmentId equals d.Id
                     group e by d.Name into DGroup
                     /*let TotalECount = DGroup.Count()*/
                     where DGroup.Count() > 3
                     select new UserSoal2
                     {
                         DepartmentName = DGroup.Key,
                         TotalEmployee = DGroup.Count(),
                         MinSalary = (int)DGroup.Min(e => e.Salary),
                         MaxSalary = (int)DGroup.Max(e => e.Salary),
                         AverageSalary = (int)DGroup.Average(e => e.Salary)
                     }).ToList();
        /*foreach (var item in soal2)
        {
            Console.WriteLine($" Department Name: {item.DepartmentName}, " +
                $"Total Employee: {item.TotalEmployee}, " +
                $"Min Salary: {item.MinSalary}, " +
                $"Max Salary: {item.MaxSalary}, " +
                $"Average Salary: {item.AverageSalary}");
            Console.WriteLine();
        }*/
        return soal2;
    }

    public void GetSoal2()
    {
        List<UserSoal2> Soal2List = Soal2();
        _LinqView.soal2(Soal2List);
    }

    public void Soal2MethodSyntax()
    {
        var soal2 = employees.GetAll()
    .Join(department.GetAll(), e => e.DepartmentId, d => d.Id, (e, d) => new { Employee = e, Department = d })
    .GroupBy(ed => ed.Department.Name)
    .Where(Dgroup => Dgroup.Count() > 3)
    .Select(Dgroup => new UserSoal2
    {
        DepartmentName = Dgroup.Key,
        TotalEmployee = Dgroup.Count(),
        MinSalary = (int)Dgroup.Min(e => e.Employee.Salary),
        MaxSalary = (int)Dgroup.Max(e => e.Employee.Salary),
        AverageSalary = (int)Dgroup.Average(e => e.Employee.Salary)
    })
    .ToList();
        /*foreach (var item in soal2)
        {
            Console.WriteLine($" Department Name: {item.DepartmentName}, " +
                $"Total Employee: {item.TotalEmployee}, " +
                $"Min Salary: {item.MinSalary}, " +
                $"Max Salary: {item.MaxSalary}, " +
                $"Average Salary: {item.AverageSalary}");
            Console.WriteLine();
        }*/
    }

    public void Menu()
    {
        _LinqView.Menu();
        int number = _InputView.InputInt();
        try
        {
            switch (number)
            {
                case 1:
                    _handling.ConsoleClear();
                    GetSoal1();
                    break;
                case 2:
                    _handling.ConsoleClear();
                    GetSoal2();
                    break;
                case 3:
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
