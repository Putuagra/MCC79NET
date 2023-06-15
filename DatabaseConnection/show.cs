namespace DatabaseConnection;

public class show
{
    Region reg = new Region();
    Country ctr = new Country();
    Location location = new Location();
    Jobs jobs = new Jobs();
    departments depts = new departments();
    Employees emp = new Employees();
    Histories histories = new Histories();
    Linq linq = new Linq();
    public void GetRegionByIdShow()
    {
        Console.Write("Masukkan id region: ");
        string inputan = Console.ReadLine();
        int.TryParse(inputan, out int number);
        List<Region> regions = reg.GetRegionById(number);
        foreach (Region region in regions)
        {
            Console.WriteLine("Id: " + region.Id + ", Name: " + region.Name);
        }
        Console.ReadKey();
        menuRegion();
    }
    public void UpdateRegionShow()
    {
        Console.Write("Masukkan id region yang ingin diupdate: ");
        string idInput = Console.ReadLine();
        int.TryParse(idInput, out int number);
        Console.Write("Masukkan nama region: ");
        string regionInput = Console.ReadLine();
        int isUpdateSuccess = reg.UpdateRegion(number, regionInput);
        if (isUpdateSuccess > 0)
        {
            Console.WriteLine("Data berhasil diupdate");
        }
        else
        {
            Console.WriteLine("Data gagal diupdate");
        }
        Console.ReadKey();
        menuRegion();
    }

    public void DeleteRegionShow()
    {

        Console.Write("Masukkan id region yang ingin dihapus: ");
        string idInput = Console.ReadLine();
        int.TryParse(idInput, out int number);
        int isDeleteSuccess = reg.DeleteRegion(number);
        if (isDeleteSuccess > 0)
        {
            Console.WriteLine("Data berhasil dihapus");
        }
        else
        {
            Console.WriteLine("Data gagal dihapus");
        }
        Console.ReadKey();
        menuRegion();
    }
    public void ShowAllRegion()
    {
        List<Region> regions = reg.GetAllRegions();
        Console.WriteLine("");
        foreach (Region region in regions)
        {
            Console.WriteLine("Id: " + region.Id + ", Name: " + region.Name);
        }
        Console.ReadKey();
        menuRegion();
    }

    public void InsertRegionShow()
    {
        Console.Write("Masukkan inputan Region: ");
        string regionInput = Console.ReadLine();
        int isUpdateSuccess = reg.InsertRegion(regionInput);
        if (isUpdateSuccess > 0)
        {
            Console.WriteLine("Data berhasil diupdate");
        }
        else
        {
            Console.WriteLine("Data gagal diupdate");
        }
        Console.ReadKey();
        menuRegion();
    }

    public void GetCountryByIdShow()
    {
        Console.Write("Masukkan id country: ");
        string inputan = Console.ReadLine();
        List<Country> countries = ctr.GetCountryById(inputan);
        foreach (Country count in countries)
        {
            Console.WriteLine("Id: " + count.id + ", Name: " + count.name + ", Region_id: " + count.region_id);
        }
        Console.ReadKey();
        menuCountries();
    }

    public void UpdateCountryShow()
    {
        Console.Write("Masukkan id country yang ingin diupdate: ");
        string idInput = Console.ReadLine();
        Console.Write("Masukkan nama country: ");
        string countryInput = Console.ReadLine();
        Console.Write("Masukkan region id: ");
        string regionId = Console.ReadLine();
        int.TryParse(regionId, out int number);
        int isUpdateSuccess = ctr.UpdateCountry(idInput, countryInput, number);
        if (isUpdateSuccess > 0)
        {
            Console.WriteLine("Data berhasil diupdate");
        }
        else
        {
            Console.WriteLine("Data gagal diupdate");
        }
        Console.ReadKey();
        menuCountries();
    }

    public void DeleteCountryShow()
    {

        Console.Write("Masukkan id country yang ingin dihapus: ");
        string idInput = Console.ReadLine();
        int isDeleteSuccess = ctr.DeleteCountry(idInput);
        if (isDeleteSuccess > 0)
        {
            Console.WriteLine("Data berhasil dihapus");
        }
        else
        {
            Console.WriteLine("Data gagal dihapus");
        }
        Console.ReadKey();
        menuCountries();
    }

    public void InsertCountriesShow()
    {
        Console.Write("Masukkan Id country: ");
        string idCountry = Console.ReadLine();
        Console.Write("Masukkan inputan country: ");
        string countryInput = Console.ReadLine();
        Console.Write("Masukkan region id: ");
        string idInput = Console.ReadLine();
        int.TryParse(idInput, out int number);
        int isUpdateSuccess = ctr.InsertCountry(idCountry, countryInput, number);
        if (isUpdateSuccess > 0)
        {
            Console.WriteLine("Data berhasil diupdate");
        }
        else
        {
            Console.WriteLine("Data gagal diupdate");
        }
        Console.ReadKey();
        menuCountries();
    }

    public void ShowAllCountry()
    {
        List<Country> countries = ctr.GetAllCountry();
        Console.WriteLine("");
        foreach (Country count in countries)
        {
            Console.WriteLine("Id: " + count.id + ", Name: " + count.name + ", Region_id: " + count.region_id);
        }
        Console.ReadKey();
        menuCountries();
    }
    public void ShowAllHistories()
    {
        List<Histories> history = histories.GetAllHistories();
        Console.WriteLine("");
        foreach (Histories histo in history)
        {
            Console.WriteLine("Start Date: " + histo.start_date + ", Employee Id: " + histo.employee_id + ", End Date: " + histo.end_date + ", Department Id: " + histo.department_id + ", Job Id: " + histo.job_id);
        }
        Console.ReadKey();
        menuHistories();
    }
    public void ShowAllDepatment()
    {
        List<departments> dept = depts.GetAllDepartment();
        Console.WriteLine("");
        foreach (departments dpt in dept)
        {
            Console.WriteLine("Id: " + dpt.id + ", Name: " + dpt.name + ", Location Id: " + dpt.location_id + ", Manager Id: " + dpt.manager_id);
        }
        Console.ReadKey();
        menuDepartment();
    }
    public void ShowAllJobs()
    {
        List<Jobs> jbs = jobs.GetAllJobs();
        Console.WriteLine("");
        foreach (Jobs job in jbs)
        {
            Console.WriteLine("Id: " + job.id + ", Title: " + job.title + ", Min Salary: " + job.min_salary + ", Max Salary: " + job.max_salary);
        }
        Console.ReadKey();
        menuJobs();
    }
    public void ShowAllLocation()
    {
        List<Location> loc = location.GetAllLocation();
        Console.WriteLine("");
        foreach (Location loct in loc)
        {
            Console.WriteLine("Id: " + loct.id + ", Street Address: " + loct.street_address + ", Postal Code: " + loct.postal_code + ", City: " + loct.city + ", State Province: " + loct.state_province + ", Country Id: " + loct.country_id);
        }
        Console.ReadKey();
        menuLocation();
    }
    public void ShowAllEmployees()
    {
        List<Employees> employees = emp.GetAllEmployees();
        Console.WriteLine("");
        foreach (Employees employ in employees)
        {
            Console.WriteLine("Id: " + employ.id + ", First Name: " + employ.first_name + ", Last Name: " + employ.last_name + ", Email: " + employ.email + ", Phone Number: " + employ.phone_number + ", Hire Date: " + employ.hire_date + ", Salary: " + employ.salary + ", Comission: " + employ.commission_pct + ", Manager Id: " + employ.manager_id + ", Job Id: " + employ.job_id + "Department Id: " + employ.department_id);
            Console.WriteLine("");
        }
        menuEmployee();
    }

    public void menu()
    {
        Console.WriteLine("TABEL");
        Console.WriteLine("1. Regions");
        Console.WriteLine("2. Countries");
        Console.WriteLine("3. Departments");
        Console.WriteLine("4. Employees");
        Console.WriteLine("5. Jobs");
        Console.WriteLine("6. Location");
        Console.WriteLine("7. Histories");
        Console.WriteLine("8. Linq");
        Console.WriteLine("9. Exit");
        Console.Write("Pilih Tabel: ");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    menuRegion();
                    break;
                case 2:
                    Console.Clear();
                    menuCountries();
                    break;
                case 3:
                    Console.Clear();
                    menuDepartment();
                    break;
                case 4:
                    Console.Clear();
                    menuEmployee();
                    break;
                case 5:
                    Console.Clear();
                    menuJobs();
                    break;
                case 6:
                    Console.Clear();
                    menuLocation();
                    break;
                case 7:
                    Console.Clear();
                    menuHistories();
                    break;
                case 8:
                    MenuLinq();
                    break;
                case 9:
                    System.Environment.Exit(8);
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("ERROR : Input Not Valid");
            Console.Clear();
            Console.ReadKey();
            menu();
        }
    }
    public void menuRegion()
    {
        Console.WriteLine("1. Tampil semua isi tabel region");
        Console.WriteLine("2. Tampil isi tabel region berdasarkan ID");
        Console.WriteLine("3. Insert isi");
        Console.WriteLine("4. Update isi");
        Console.WriteLine("5. Hapus isi");
        Console.WriteLine("6. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllRegion();
                    break;
                case 2:
                    Console.Clear();
                    GetRegionByIdShow();
                    break;
                case 3:
                    Console.Clear();
                    InsertRegionShow();
                    break;
                case 4:
                    Console.Clear();
                    UpdateRegionShow();
                    break;
                case 5:
                    Console.Clear();
                    DeleteRegionShow();
                    break;
                case 6:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    menuRegion();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            menuRegion();
        }
    }

    public void menuCountries()
    {
        Console.WriteLine("1. Tampil semua isi tabel countries");
        Console.WriteLine("2. Tampil isi tabel countries berdasarkan ID");
        Console.WriteLine("3. Insert isi");
        Console.WriteLine("4. Update isi");
        Console.WriteLine("5. Hapus isi");
        Console.WriteLine("6. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllCountry();
                    break;
                case 2:
                    Console.Clear();
                    GetCountryByIdShow();
                    break;
                case 3:
                    Console.Clear();
                    InsertCountriesShow();
                    break;
                case 4:
                    Console.Clear();
                    UpdateCountryShow();
                    break;
                case 5:
                    Console.Clear();
                    DeleteCountryShow();
                    break;
                case 6:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuCountries();
                    break;
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuCountries();
        }
    }

    public void menuDepartment()
    {
        Console.WriteLine("1. Tampil semua isi tabel department");
        Console.WriteLine("2. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllDepatment();
                    break;
                case 2:
                    Console.Clear();
                    menu();
                    break;
                default:

                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuDepartment();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuDepartment();
        }
    }

    public void menuLocation()
    {
        Console.WriteLine("1. Tampil semua isi tabel location");
        Console.WriteLine("2. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllLocation();
                    break;
                case 2:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuDepartment();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuDepartment();
        }
    }

    public void menuJobs()
    {
        Console.WriteLine("1. Tampil semua isi tabel jobs");
        Console.WriteLine("2. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllJobs();
                    break;
                case 2:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuJobs();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuJobs();
        }
    }

    public void menuHistories()
    {
        Console.WriteLine("1. Tampil semua isi tabel histories");
        Console.WriteLine("2. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllHistories();
                    break;
                case 2:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuHistories();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuHistories();
        }
    }
    public void menuEmployee()
    {
        Console.WriteLine("1. Tampil semua isi tabel employees");
        Console.WriteLine("2. Exit");
        string tabel = Console.ReadLine();
        int.TryParse(tabel, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    Console.Clear();
                    ShowAllEmployees();
                    break;
                case 2:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    menuEmployee();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            menuEmployee();
        }
    }

    public void MenuLinq()
    {
        Console.Clear();
        Console.WriteLine("1. Soal 1");
        Console.WriteLine("2. Soal 2");
        Console.WriteLine("3. Exit");
        Console.Write("Inputan: ");
        string linqInput = Console.ReadLine();
        int.TryParse(linqInput, out int number);
        try
        {
            switch (number)
            {
                case 1:
                    linq.Soal1MethodSyntax();
                    Console.ReadKey();
                    Console.Clear();
                    MenuLinq();
                    break;
                case 2:
                    linq.Soal2MethodSyntax();
                    Console.ReadKey();
                    Console.Clear();
                    MenuLinq();
                    break;
                case 3:
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Console.Clear();
                    MenuLinq();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Console.Clear();
            MenuLinq();
        }
    }
}
