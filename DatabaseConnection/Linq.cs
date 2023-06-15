namespace DatabaseConnection;

public class Linq
{
    departments department = new();
    Employees employees = new();
    Location location = new();
    Region region = new();
    Country country = new();


    public void Soal1()
    {
        var soal1 = (from e in employees.GetAllEmployees()
                     join d in department.GetAllDepartment() on e.department_id equals d.id
                     join l in location.GetAllLocation() on d.location_id equals l.id
                     join c in country.GetAllCountry() on l.country_id equals c.id
                     join r in region.GetAllRegions() on c.region_id equals r.Id
                     select new UserSoal1
                     {
                         Id = e.id,
                         FullName = e.first_name + " " + e.last_name,
                         Email = e.email,
                         PhoneNumber = e.phone_number,
                         Salary = (int)e.salary,
                         DepartmentName = d.name,
                         Location = l.street_address,
                         CountryName = c.name,
                         RegionName = r.Name
                     }).Take(5).ToList();
        foreach (var item in soal1)
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
        }
    }

    public void Soal1MethodSyntax()
    {
        var soal1 = employees.GetAllEmployees()
    .Join(department.GetAllDepartment(), e => e.department_id, d => d.id, (e, d) => new { Employee = e, Department = d })
    .Join(location.GetAllLocation(), ed => ed.Department.location_id, l => l.id, (ed, l) => new { ed.Employee, ed.Department, Location = l })
    .Join(country.GetAllCountry(), edl => edl.Location.country_id, c => c.id, (edl, c) => new { edl.Employee, edl.Department, edl.Location, Country = c })
    .Join(region.GetAllRegions(), edlc => edlc.Country.region_id, r => r.Id, (edlc, r) => new { edlc.Employee, edlc.Department, edlc.Location, edlc.Country, Region = r })
    .Select(e => new UserSoal1
    {
        Id = e.Employee.id,
        FullName = e.Employee.first_name + " " + e.Employee.last_name,
        Email = e.Employee.email,
        PhoneNumber = e.Employee.phone_number,
        Salary = (int)e.Employee.salary,
        DepartmentName = e.Department.name,
        Location = e.Location.street_address,
        CountryName = e.Country.name,
        RegionName = e.Region.Name
    })
    .Take(5)
    .ToList();
        foreach (var item in soal1)
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
        }
    }

    public void Soal2()
    {
        var soal2 = (from e in employees.GetAllEmployees()
                     join d in department.GetAllDepartment() on e.department_id equals d.id
                     group e by d.name into DGroup
                     /*let TotalECount = DGroup.Count()*/
                     where DGroup.Count() > 3
                     select new UserSoal2
                     {
                         DepartmentName = DGroup.Key,
                         TotalEmployee = DGroup.Count(),
                         MinSalary = (int)DGroup.Min(e => e.salary),
                         MaxSalary = (int)DGroup.Max(e => e.salary),
                         AverageSalary = (int)DGroup.Average(e => e.salary)
                     }).ToList();
        foreach (var item in soal2)
        {
            Console.WriteLine($" Department Name: {item.DepartmentName}, " +
                $"Total Employee: {item.TotalEmployee}, " +
                $"Min Salary: {item.MinSalary}, " +
                $"Max Salary: {item.MaxSalary}, " +
                $"Average Salary: {item.AverageSalary}");
            Console.WriteLine();
        }
    }

    public void Soal2MethodSyntax()
    {
        var soal2 = employees.GetAllEmployees()
    .Join(department.GetAllDepartment(), e => e.department_id, d => d.id, (e, d) => new { Employee = e, Department = d })
    .GroupBy(ed => ed.Department.name)
    .Where(Dgroup => Dgroup.Count() > 3)
    .Select(Dgroup => new UserSoal2
    {
        DepartmentName = Dgroup.Key,
        TotalEmployee = Dgroup.Count(),
        MinSalary = (int)Dgroup.Min(e => e.Employee.salary),
        MaxSalary = (int)Dgroup.Max(e => e.Employee.salary),
        AverageSalary = (int)Dgroup.Average(e => e.Employee.salary)
    })
    .ToList();
        foreach (var item in soal2)
        {
            Console.WriteLine($" Department Name: {item.DepartmentName}, " +
                $"Total Employee: {item.TotalEmployee}, " +
                $"Min Salary: {item.MinSalary}, " +
                $"Max Salary: {item.MaxSalary}, " +
                $"Average Salary: {item.AverageSalary}");
            Console.WriteLine();
        }
    }
}
