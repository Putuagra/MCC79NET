public class program
{
    static void Menu()
    {
        Console.WriteLine("");
        Console.WriteLine("=====================================");
        Console.WriteLine("           MENU GANJIL GENAP     ");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
        Console.WriteLine("3. Exit");
        Console.WriteLine("-------------------------------------");
        Console.Write("Pilihan: ");
        int number;
        string userInput = Console.ReadLine();
        int.TryParse(userInput, out number);
        while (number != 3)
        {
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
                        Console.WriteLine(EvenOddCheck(pilihan));
                    }
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
                        PrintEvenOdd(ganjil, inputGaGe);
                    }
                    else if (inputGaGe.ToUpper() == "GENAP")
                    {
                        Console.Write("Masukkan Limit: ");
                        string inputGenap = Console.ReadLine();
                        int genap;
                        int.TryParse(inputGenap, out genap);
                        PrintEvenOdd(genap, inputGaGe);
                    }
                    else { Console.WriteLine("Pilihan tidak valid"); }
                    break;
                case 3:
                    Console.WriteLine("Terima kasih");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("=====================================");
            Console.WriteLine("           MENU GANJIL GENAP     ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-------------------------------------");
            Console.Write("Pilihan: ");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out number);
        }
    }
    static void PrintEvenOdd(int limit, string choiche)
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

    static string EvenOddCheck(int input)
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

    public static void Main(string[] args)
    {
        Menu();
    }
}