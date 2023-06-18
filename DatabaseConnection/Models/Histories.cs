using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Histories
{
    public DateTime StartDate { get; set; }
    public int EmployeeId { get; set; }
    public DateTime? EndDate { get; set; }
    public int DepartmentId { get; set; }
    public string JobId { get; set; }
    private Handling _handling = new Handling();

    public List<Histories> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var histories = new List<Histories>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_tr_histories";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var history = new Histories();
                    history.StartDate = reader.GetDateTime(0); //index 0 dari db
                    history.EmployeeId = reader.GetInt32(1); //index 1 dari db
                    history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);
                    histories.Add(history);
                }
            }
            else
            {
                _handling.NotFound();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return histories;
    }
}
