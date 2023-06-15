namespace BasicAuth
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

        public void Home()
        {
            Console.WriteLine("==LOGIN==");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.Write("Input: ");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int number);
            switch (number)
            {
                case 1:
                    Console.Write("Login User/Admin: ");
                    string login = Console.ReadLine();
                    if (login.ToLower() == "admin")
                    {
                        Console.Write("Input Username: ");
                        string InputUname = Console.ReadLine();
                        Console.Write("Input Password: ");
                        string InputPass = Console.ReadLine();
                        if (auth.LoginAdm(list2, InputUname, InputPass) == true)
                        {
                            Console.Clear();
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("Username atau Password Tidak Salah");
                            Kembali();
                            Home();
                        }
                    }
                    else if (login.ToLower() == "user")
                    {
                        Console.Write("Input Username: ");
                        string InputUname = Console.ReadLine();
                        Console.Write("Input Password: ");
                        string InputPass = Console.ReadLine();
                        if (auth.Login(list, InputUname, InputPass) == true)
                        {
                            Console.Clear();
                            MenuGaGe();
                        }
                        else
                        {
                            Console.WriteLine("Username atau Password Tidak Salah");
                            Kembali();
                            Home();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inputan Tidak Ditemukan");
                        Kembali();
                        Home();
                    }
                    break;
                case 2:
                    System.Environment.Exit(5);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    Kembali();
                    Home();
                    break;
            }

        }
        public void Menu()
        {
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Logout");
            Console.Write("Input: ");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int number);
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
                    Console.Clear();
                    Home();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    KembaliMenu();
                    break;
            }
        }
        public void CaseCreate(List<User> list)
        {
            Console.Clear();
            Console.Write("First Name: ");
            string inputFirst = auth.CekNamaDepan(Console.ReadLine());
            Console.Write("Last Name: ");
            string inputLast = auth.CekNamaDepan(Console.ReadLine());
            Console.Write("Password: ");
            string inputPass = auth.CekPass(Console.ReadLine());
            User user1 = new(inputFirst, inputLast, inputPass);
            Console.WriteLine(show1.CreateUser(list, user1));
            KembaliMenu();
        }

        public void CaseCreate(List<Admin> list)
        {
            Console.Clear();
            Console.Write("First Name: ");
            string inputFirst = auth.CekNamaDepan(Console.ReadLine());
            Console.Write("Last Name: ");
            string inputLast = auth.CekNamaDepan(Console.ReadLine());
            Console.Write("Password: ");
            string inputPass = auth.CekPass(Console.ReadLine());
            Admin user1 = new(inputFirst, inputLast, inputPass);
            Console.WriteLine(show1.CreateAdmin(list, user1));
            KembaliMenu();
        }

        public void CaseShowCreate(List<User> list, List<Admin> listAdm)
        {
            Console.Write("Buat User/Admin: ");
            string CekInput = Console.ReadLine();
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
                Console.WriteLine("Inputan Tidak Ditemukan");
            }
            KembaliMenu();
        }

        public void CaseShow(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            Console.WriteLine("==========USER==========");
            show1.Tampil(list);
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.WriteLine("=========ADMIN==========");
            show1.Tampil(listAdm);
            Console.WriteLine("========================");
            menuOnShow(list, listAdm);
            KembaliMenu();
        }

        public void CaseSearch(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama: ");
            string inputName = Console.ReadLine();
            List<User> users = new();
            List<Admin> admin = new();
            for (int i = 0; i < list.Count; i++)
            {
                users.Clear();
                if (list[i].Fname.ToLower().Contains(inputName.ToLower()) || list[i].Lname.ToLower().Contains(inputName.ToLower()))
                {
                    users.Add(list[i]);
                    show1.TampilSearch(users);
                }
            }
            for (int i = 0; i < listAdm.Count; i++)
            {
                admin.Clear();
                if (listAdm[i].Fname.ToLower().Contains(inputName.ToLower()) || listAdm[i].Lname.ToLower().Contains(inputName.ToLower()))
                {
                    admin.Add(listAdm[i]);
                    show1.TampilSearch(admin);
                }
            }
            KembaliMenu();
        }

        public void CaseLogin(List<User> list, List<Admin> listAdm)
        {
            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("Login (USER/ADMIN): ");
            string login = Console.ReadLine();
            if (login.ToLower() == "user")
            {
                Console.Write("Username: ");
                string inputUname = Console.ReadLine();
                Console.Write("Password: ");
                string inputPass = Console.ReadLine();
                if (auth.Login(list, inputUname, inputPass) == true)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (inputUname == list[i].uname && inputPass == list[i].pass)
                        {
                            Console.WriteLine("Login " + list[i].Fname + " " + list[i].Lname + " Berhasil");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Username atau Password Tidak Ditemukan");
                }
            }
            else if (login.ToLower() == "admin")
            {
                Console.Write("Username: ");
                string inputUname = Console.ReadLine();
                Console.Write("Password: ");
                string inputPass = Console.ReadLine();
                if (auth.LoginAdm(listAdm, inputUname, inputPass) == true)
                {
                    for (int i = 0; i < listAdm.Count; i++)
                    {
                        if (inputUname == listAdm[i].uname && inputPass == listAdm[i].pass)
                        {
                            Console.WriteLine("Login " + listAdm[i].Fname + " " + listAdm[i].Lname + " Berhasil");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Username atau Password Tidak Ditemukan");
                }
            }
            else
            {
                Console.WriteLine("Inputan Tidak Ditemukan");
            }
            KembaliMenu();
        }
        public void menuOnShow(List<User> list, List<Admin> listAdm)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.Write("Input: ");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int number);
            switch (number)
            {
                case 1:
                    Console.Write("Ubah User/Admin: ");
                    string CekInput = Console.ReadLine();
                    if (CekInput.ToLower() == "user")
                    {
                        Console.Write("Id Yang Ingin Diubah : ");
                        int edit;
                        string idEdit = Console.ReadLine();
                        while (!int.TryParse(idEdit, out edit))
                        {
                            Console.WriteLine("Inputan Bukan Angka");
                            Console.Write("Id Yang Ingin Diubah : ");
                            idEdit = Console.ReadLine();
                        }
                        if (auth.cekId(list, edit) == true)
                        {
                            Console.Write("First Name: ");
                            string inputFirst = Console.ReadLine();
                            user1.Fname = auth.CekNamaDepan(inputFirst);
                            Console.Write("Last Name: ");
                            string inputLast = Console.ReadLine();
                            user1.Lname = auth.CekNamaDepan(inputLast);
                            Console.Write("Password: ");
                            string inputPass = Console.ReadLine();
                            user1.pass = auth.CekPass(inputPass);
                            show1.EditUser(list, user1, edit);
                        }
                        else
                        {
                            Console.WriteLine("ID Tidak Ditemukan");
                        }
                    }
                    else if (CekInput.ToLower() == "admin")
                    {
                        Console.Write("Id Yang Ingin Diubah : ");
                        int edit;
                        string idEdit = Console.ReadLine();
                        while (!int.TryParse(idEdit, out edit))
                        {
                            Console.WriteLine("Inputan Bukan Angka");
                            Console.Write("Id Yang Ingin Diubah : ");
                            idEdit = Console.ReadLine();
                        }
                        if (auth.cekId(listAdm, edit) == true)
                        {
                            Console.Write("First Name: ");
                            string inputFirst = Console.ReadLine();
                            adm1.Fname = auth.CekNamaDepan(inputFirst);
                            Console.Write("Last Name: ");
                            string inputLast = Console.ReadLine();
                            adm1.Lname = auth.CekNamaDepan(inputLast);
                            Console.Write("Password: ");
                            string inputPass = Console.ReadLine();
                            adm1.pass = auth.CekPass(inputPass);
                            show1.EditUser(listAdm, adm1, edit);
                        }
                        else
                        {
                            Console.WriteLine("ID Tidak Ditemukan");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inputan Tidak Ditemukan");
                    }
                    KembaliMenu();
                    break;
                case 2:
                    Console.Write("Hapus User/Admin: ");
                    string CekInput2 = Console.ReadLine();
                    if (CekInput2.ToLower() == "user")
                    {
                        Console.Write("Id Yang Ingin Dihapus :");
                        int delete;
                        string idDelete = Console.ReadLine();
                        while (!int.TryParse(idDelete, out delete))
                        {
                            Console.WriteLine("Inputan Bukan Angka");
                            Console.Write("Id Yang Ingin Dihapus :");
                            idDelete = Console.ReadLine();
                        }
                        show1.DeleteUser(list, delete);
                    }
                    else if (CekInput2.ToLower() == "admin")
                    {

                        Console.Write("Id Yang Ingin Dihapus :");
                        int delete;
                        string idDelete = Console.ReadLine();
                        while (!int.TryParse(idDelete, out delete))
                        {
                            Console.WriteLine("Inputan Bukan Angka");
                            Console.Write("Id Yang Ingin Dihapus :");
                            idDelete = Console.ReadLine();
                        }
                        show1.DeleteUser(listAdm, delete);
                    }
                    else
                    {
                        Console.WriteLine("Inputan Tidak Ditemukan");
                    }
                    KembaliMenu();
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    KembaliMenu();
                    break;
            }
        }

        public void Kembali()
        {
            Console.WriteLine("");
            Console.WriteLine("Ketik apapun untuk kembali");
            Console.ReadKey();
            Console.Clear();
        }
        public void KembaliMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Ketik apapun untuk kembali");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public void KembaliGaGe()
        {
            Console.WriteLine("");
            Console.WriteLine("Ketik apapun untuk kembali");
            Console.ReadKey();
            Console.Clear();
            MenuGaGe();
        }

        public void MenuGaGe()
        {
            Console.WriteLine("");
            Console.WriteLine("=====================================");
            Console.WriteLine("           MENU GANJIL GENAP     ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
            Console.WriteLine("3. Logout");
            Console.WriteLine("-------------------------------------");
            Console.Write("Pilihan: ");
            int number;
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out number);
            switch (number)
            {
                case 1:
                    Console.Write("Masukkan Bilangan yang ingin di cek : ");
                    string inputAngka = Console.ReadLine();
                    int pilihan;
                    int.TryParse(inputAngka, out pilihan);
                    if (!int.TryParse(inputAngka, out pilihan))
                    {
                        Console.WriteLine("Inputan Bukan Angka");
                    }
                    else
                    {
                        Console.WriteLine(auth.EvenOddCheck(pilihan));
                    }
                    KembaliGaGe();
                    break;
                case 2:
                    Console.Write("Pilih (Ganjil/Genap): ");
                    string inputGaGe = Console.ReadLine();
                    if (inputGaGe.ToUpper() == "GANJIL")
                    {
                        Console.Write("Masukkan Limit: ");
                        string inputGanjil = Console.ReadLine();
                        int ganjil;
                        int.TryParse(inputGanjil, out ganjil);
                        auth.PrintEvenOdd(ganjil, inputGaGe);
                    }
                    else if (inputGaGe.ToUpper() == "GENAP")
                    {
                        Console.Write("Masukkan Limit: ");
                        string inputGenap = Console.ReadLine();
                        int genap;
                        int.TryParse(inputGenap, out genap);
                        auth.PrintEvenOdd(genap, inputGaGe);
                    }
                    else { Console.WriteLine("Pilihan tidak valid"); }
                    KembaliGaGe();
                    break;
                case 3:
                    Console.Clear();
                    Home();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    KembaliGaGe();
                    break;
            }
        }
    }
}
