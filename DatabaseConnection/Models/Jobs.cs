using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Jobs
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    private Handling _handling = new Handling();

    public List<Jobs> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var jobs = new List<Jobs>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_jobs";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var job = new Jobs();
                    job.Id = reader.GetString(0); //index 0 dari db
                    job.Title = reader.GetString(1); //index 1 dari db
                    job.MinSalary = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                    job.MaxSalary = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    jobs.Add(job);
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
        return jobs;
    }
}
