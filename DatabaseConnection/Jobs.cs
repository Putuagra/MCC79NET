using System.Data.SqlClient;

namespace DatabaseConnection;

public class Jobs
{
    /*string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;*/
    SqlConnection connection = Connection.GetConnection();
    public string id { get; set; }
    public string title { get; set; }
    public int min_salary { get; set; }
    public int max_salary { get; set; }

    public List<Jobs> GetAllJobs()
    {
        var jobs = new List<Jobs>();

        try
        {
            //SqlConnection connection = Connection.GetConnection();
            //connection = new SqlConnection(connectionString);
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_jobs";

            //membuka koneksi
            //connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var job = new Jobs();
                    job.id = reader.GetString(0); //index 0 dari db
                    job.title = reader.GetString(1); //index 1 dari db
                    if (reader.IsDBNull(2))
                    {
                        job.min_salary = 0;
                    }
                    else
                    {
                        job.min_salary = reader.GetInt32(2);
                    }
                    if (reader.IsDBNull(3))
                    {
                        job.max_salary = 0;
                    }
                    else
                    {
                        job.max_salary = reader.GetInt32(3);
                    }
                    //job.min_salary = reader.GetInt32(2);
                    //job.max_salary = reader.GetInt32(3);
                    jobs.Add(job);
                }
            }
            else
            {
                Console.WriteLine("Data not found");
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
