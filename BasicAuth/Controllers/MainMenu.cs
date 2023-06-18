using BasicAuth.Models;
using BasicAuth.Views;

namespace BasicAuth.Controllers
{
    public class MainMenu
    {
        private Show show1 = new();
        private List<User> list = new();
        private List<Admin> list2 = new List<Admin>(){
            new Admin("Ramon","Salazar","admin", "admin", "Admin")
        };
        private Auth auth = new();
        private User user1 = new();
        private Admin adm1 = new();
        private MainMenuView _MainMenu = new MainMenuView();
        private InputView _InputView = new InputView();
        private HandlingView _HandlingView = new HandlingView();
        private CrudView _CrudView = new CrudView();
        private MenuView _MenuView = new MenuView();

        public void Home()
        {
            bool isFinish = false;
            while (!isFinish)
            {
                try
                {
                    _MainMenu.Home();
                    int number = _InputView.InputInt();
                    switch (number)
                    {
                        case 1:
                            _MainMenu.Login();
                            string login = _InputView.InputString();
                            if (login.ToLower() == "admin")
                            {
                                _MainMenu.InputUname();
                                string InputUname = _InputView.InputString();
                                _MainMenu.InputPassword();
                                string InputPass = _InputView.InputString();
                                if (auth.LoginAdm(list2, InputUname, InputPass) == true)
                                {
                                    Console.Clear();
                                    Menu();
                                }
                                else
                                {
                                    _HandlingView.InvalidUnamePass();
                                }
                            }
                            else if (login.ToLower() == "user")
                            {
                                _MainMenu.InputUname();
                                string InputUname = _InputView.InputString();
                                _MainMenu.InputPassword();
                                string InputPass = _InputView.InputString();
                                if (auth.Login(list, InputUname, InputPass) == true)
                                {
                                    Console.Clear();
                                    GanjilGenap();
                                }
                                else
                                {
                                    _HandlingView.InvalidUnamePass();
                                }
                            }
                            else
                            {
                                _HandlingView.InvalidInput();
                            }
                            break;
                        case 2:
                            isFinish = true;
                            break;
                        default:
                            _HandlingView.InvalidPilihan();
                            break;
                    }
                }
                catch (Exception)
                {
                    _HandlingView.SwitchDefault();
                }
            }
        }
        public void Menu()
        {
            bool isFinish = false;
            while (!isFinish)
            {
                try
                {
                    _MainMenu.MenuAdmin();
                    int number = _InputView.InputInt();
                    switch (number)
                    {
                        case 1:
                            CaseShowCreate(list, list2);
                            break;
                        case 2:
                            CaseShow(list, list2);
                            break;
                        case 3:
                            CaseSearch(list, list2);
                            break;
                        case 4:
                            CaseLogin(list, list2);
                            break;
                        case 5:
                            //System.Environment.Exit(5);
                            //Home();
                            isFinish = true;
                            break;
                        default:
                            _HandlingView.InvalidPilihan();
                            break;
                    }
                }
                catch (Exception)
                {
                    _HandlingView.SwitchDefault();
                }
            }
        }
        public void CaseCreate(List<User> list)
        {
            Console.Clear();
            _CrudView.Firstname();
            string inputFirst = auth.CekNamaDepan(_InputView.InputString());
            _CrudView.LastName();
            string inputLast = auth.CekNamaDepan(_InputView.InputString());
            _CrudView.Password();
            string inputPass = auth.CekPass(_InputView.InputString());
            User user1 = new(inputFirst, inputLast, inputPass);
            _CrudView.CaseCreate(show1.CreateUser(list, user1));
        }

        public void CaseCreate(List<Admin> list)
        {
            Console.Clear();
            _CrudView.Firstname();
            string inputFirst = auth.CekNamaDepan(_InputView.InputString());
            _CrudView.LastName();
            string inputLast = auth.CekNamaDepan(_InputView.InputString());
            _CrudView.Password();
            string inputPass = auth.CekPass(_InputView.InputString());
            Admin user1 = new(inputFirst, inputLast, inputPass);
            _CrudView.CaseCreate(show1.CreateAdmin(list, user1));
        }

        public void CaseShowCreate(List<User> list, List<Admin> listAdm)
        {
            _CrudView.UserAdmin();
            string CekInput = _InputView.InputString();
            if (CekInput.ToLower() == "admin")
            {
                CaseCreate(listAdm);
            }
            else if (CekInput.ToLower() == "user")
            {
                CaseCreate(list);
            }
            else
            {
                _HandlingView.InvalidInput();
            }
        }

        public void CaseShow(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            _CrudView.CaseShow(list, listAdm);
            menuOnShow(list, listAdm);
        }

        public void CaseSearch(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            _CrudView.CaseSearch();
            string inputName = _InputView.InputString();
            List<User> users = new();
            List<Admin> admin = new();
            for (int i = 0; i < list.Count; i++)
            {
                users.Clear();
                if (list[i].FirstName.ToLower().Contains(inputName.ToLower()) || list[i].LastName.ToLower().Contains(inputName.ToLower()))
                {
                    users.Add(list[i]);
                    show1.TampilSearch(users);
                }
            }
            for (int i = 0; i < listAdm.Count; i++)
            {
                admin.Clear();
                if (listAdm[i].FirstName.ToLower().Contains(inputName.ToLower()) || listAdm[i].LastName.ToLower().Contains(inputName.ToLower()))
                {
                    admin.Add(listAdm[i]);
                    show1.TampilSearch(admin);
                }
            }
        }

        public void CaseLogin(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            _MenuView.LoginCase();
            string login = _InputView.InputString();
            if (login.ToLower() == "user")
            {
                _CrudView.Username();
                string inputUname = _InputView.InputString();
                _CrudView.Password();
                string inputPass = _InputView.InputString();
                if (auth.Login(list, inputUname, inputPass) == true)
                {
                    _CrudView.LoginUser(list, inputUname, inputPass);
                }
                else
                {
                    _HandlingView.InvalidUnamePass();
                }
            }
            else if (login.ToLower() == "admin")
            {
                _CrudView.Username();
                string inputUname = _InputView.InputString();
                _CrudView.Password();
                string inputPass = _InputView.InputString();
                if (auth.LoginAdm(listAdm, inputUname, inputPass) == true)
                {
                    _CrudView.LoginAdmin(listAdm, inputUname, inputPass);
                }
                else
                {
                    _HandlingView.InvalidUnamePass();
                }
            }
            else
            {
                _HandlingView.InvalidInput();
            }
        }
        public void menuOnShow(List<User> list, List<Admin> listAdm)
        {
            _CrudView.MenuEditDelete();
            int number = _InputView.InputInt();
            switch (number)
            {
                case 1:
                    _CrudView.UpdateUserAdmin();
                    string CekInput = _InputView.InputString();
                    if (CekInput.ToLower() == "user")
                    {
                        _CrudView.UpdateId();
                        string idEdit = _InputView.InputString();
                        int edit;
                        while (!int.TryParse(idEdit, out edit))
                        {
                            _CrudView.isInteger();
                            idEdit = _InputView.InputString();
                        }
                        if (auth.cekId(list, edit) == true)
                        {
                            _CrudView.Firstname();
                            string inputFirst = _InputView.InputString();
                            user1.FirstName = auth.CekNamaDepan(inputFirst);
                            _CrudView.LastName();
                            string inputLast = _InputView.InputString();
                            user1.LastName = auth.CekNamaDepan(inputLast);
                            _CrudView.Password();
                            string inputPass = _InputView.InputString();
                            user1.Password = auth.CekPass(inputPass);
                            show1.EditUser(list, user1, edit);
                        }
                        else
                        {
                            _HandlingView.IdNotFound();
                        }
                    }
                    else if (CekInput.ToLower() == "admin")
                    {
                        _CrudView.UpdateId();
                        int edit;
                        string idEdit = _InputView.InputString();
                        while (!int.TryParse(idEdit, out edit))
                        {
                            _CrudView.isInteger();
                            idEdit = _InputView.InputString();
                        }
                        if (auth.cekId(listAdm, edit) == true)
                        {
                            _CrudView.Firstname();
                            string inputFirst = _InputView.InputString();
                            adm1.FirstName = auth.CekNamaDepan(inputFirst);
                            _CrudView.LastName();
                            string inputLast = _InputView.InputString();
                            adm1.LastName = auth.CekNamaDepan(inputLast);
                            _CrudView.Password();
                            string inputPass = _InputView.InputString();
                            adm1.Password = auth.CekPass(inputPass);
                            show1.EditUser(listAdm, adm1, edit);
                        }
                        else
                        {
                            _HandlingView.IdNotFound();
                        }
                    }
                    else
                    {
                        _HandlingView.InvalidInput();
                    }
                    break;
                case 2:
                    _CrudView.DeleteUserAdmin();
                    string CekInput2 = _InputView.InputString();
                    if (CekInput2.ToLower() == "user")
                    {
                        _CrudView.DeleteId();
                        int delete;
                        string idDelete = _InputView.InputString();
                        while (!int.TryParse(idDelete, out delete))
                        {
                            _CrudView.isInteger();
                            idDelete = _InputView.InputString();
                        }
                        show1.DeleteUser(list, delete);
                    }
                    else if (CekInput2.ToLower() == "admin")
                    {
                        _CrudView.DeleteId();
                        int delete;
                        string idDelete = _InputView.InputString();
                        while (!int.TryParse(idDelete, out delete))
                        {
                            _CrudView.isInteger();
                            idDelete = Console.ReadLine();
                        }
                        show1.DeleteUser(listAdm, delete);
                    }
                    else
                    {
                        _HandlingView.InvalidInput();
                    }
                    break;
                case 3:
                    break;
                default:
                    _HandlingView.InvalidPilihan();
                    break;
            }
        }
        public void GanjilGenap()
        {
            bool isFinish = false;
            while (!isFinish)
            {
                try
                {
                    _MenuView.GanjilGenap();
                    int number = _InputView.InputInt();
                    switch (number)
                    {
                        case 1:
                            _MenuView.Bilangan();
                            string inputAngka = _InputView.InputString();
                            int pilihan;
                            int.TryParse(inputAngka, out pilihan);
                            if (!int.TryParse(inputAngka, out pilihan))
                            {
                                _HandlingView.InvalidNumber();
                            }
                            else
                            {
                                _MenuView.CheckGanjilGenap(auth.EvenOddCheck(pilihan));
                            }
                            break;
                        case 2:
                            _MenuView.PilihGanjilGenap();
                            string inputGaGe = _InputView.InputString();
                            if (inputGaGe.ToUpper() == "GANJIL")
                            {
                                _MenuView.InputLimit();
                                string inputGanjil = _InputView.InputString();
                                int ganjil;
                                int.TryParse(inputGanjil, out ganjil);
                                auth.PrintEvenOdd(ganjil, inputGaGe);
                            }
                            else if (inputGaGe.ToUpper() == "GENAP")
                            {
                                _MenuView.InputLimit();
                                string inputGenap = _InputView.InputString();
                                int genap;
                                int.TryParse(inputGenap, out genap);
                                auth.PrintEvenOdd(genap, inputGaGe);
                            }
                            else { _HandlingView.InvalidPilihan(); }
                            break;
                        case 3:
                            isFinish = true;
                            break;
                        default:
                            _HandlingView.InvalidPilihan();
                            break;
                    }
                }
                catch (Exception)
                {
                    _HandlingView.SwitchDefault();
                }
            }
        }
    }
}
