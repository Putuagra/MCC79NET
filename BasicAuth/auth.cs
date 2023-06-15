using System.Text.RegularExpressions;


namespace BasicAuth
{
    public class Auth
    {
        public string CekNamaDepan(string nama)
        {
            while (nama.Length < 2 && nama != null)
            {
                Console.WriteLine("");
                Console.WriteLine("Name has to be at least consisting 2 characters or more.");
                Console.Write("First Name: ");
                nama = Console.ReadLine();
            }
            return nama;
        }

        public string CekNamaBelakang(string nama)
        {
            while (nama.Length < 2 && nama != null)
            {
                Console.WriteLine("");
                Console.WriteLine("Name has to be at least consisting 2 characters or more.");
                Console.Write("Last Name: ");
                nama = Console.ReadLine();
            }
            return nama;
        }

        public string CekPass(string pass)
        {
            bool isValid = CheckPasswordRequirements(pass);
            while (isValid == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Password must have at least 8 characters ");
                Console.WriteLine("with at least one Capital letter, at least one lower case letter and at least one number.");
                Console.Write("Password: ");
                pass = Console.ReadLine();
                isValid = CheckPasswordRequirements(pass);
            }
            return pass;
        }
        bool CheckPasswordRequirements(string password)
        {

            Regex pass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return pass.IsMatch(password);
        }

        public bool Login(List<User> login, string username, string password)
        {
            bool status = false;
            for (int i = 0; i < login.Count; i++)
            {
                if (username == login[i].uname && password == login[i].pass)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }

        public bool LoginAdm(List<Admin> login, string username, string password)
        {
            bool status = false;
            for (int i = 0; i < login.Count; i++)
            {
                if (username == login[i].uname && password == login[i].pass)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }

        public bool cekId(List<User> cekId, int id)
        {
            bool status = false;
            for (int i = 0; i < cekId.Count; i++)
            {
                if (id > 0 && id <= cekId.Count)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }
        public bool cekId(List<Admin> cekId, int id)
        {
            bool status = false;
            for (int i = 0; i < cekId.Count; i++)
            {
                if (id > 0 && id <= cekId.Count)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }
        public void PrintEvenOdd(int limit, string choiche)
        {
            if (choiche.ToUpper() == "GANJIL")
            {
                if (limit > 0)
                {
                    Console.WriteLine("Print bilangan 1 - " + limit);
                    for (int i = 1; i <= limit; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write($"{i}, ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input Limit Tidak Valid");
                }
            }
            else if (choiche.ToUpper() == "GENAP")
            {
                if (limit > 0)
                {
                    Console.WriteLine("Print bilangan 1 - " + limit);
                    for (int i = 1; i <= limit; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write($"{i}, ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input Limit Tidak Valid");
                }
            }
            else { Console.WriteLine("Input pilihan tidak valid"); }
        }

        public string EvenOddCheck(int input)
        {
            string status;
            if (input > 0)
            {
                if (input % 2 == 0)
                {
                    status = "Genap";
                }
                else
                {
                    status = "Ganjil";
                }
            }
            else
            {
                status = "Invalid Input";
            }
            return status;
        }
    }
}
