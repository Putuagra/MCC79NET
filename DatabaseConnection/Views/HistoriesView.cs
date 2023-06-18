using DatabaseConnection.Models;

namespace DatabaseConnection.Views
{
    public class HistoriesView
    {
        public void GetAll(List<Histories> histories)
        {
            foreach (Histories history in histories)
            {
                Console.WriteLine("Start Date: " + history.StartDate + ", Employee Id: " + history.EmployeeId + ", End Date: " + history.EndDate + ", Department Id: " + history.DepartmentId + ", Job Id: " + history.JobId);
            }
        }
        public void Menu()
        {
            Console.WriteLine("1. Tampil semua isi tabel histories");
            Console.WriteLine("2. Exit");
            Console.Write("Pilihan: ");
        }
    }
}
