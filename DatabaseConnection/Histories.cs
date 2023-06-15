using System.Data.SqlClient;

namespace DatabaseConnection;

public class Histories
{
    string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;

    public DateTime start_date { get; set; }
    public int employee_id { get; set; }
    public DateTime? end_date { get; set; }
    public int department_id { get; set; }
    public string job_id { get; set; }

    public List<Histories> GetAllHistories()
    {
        var histories = new List<Histories>();
        try
        {
            connection = new SqlConnection(connectionString);
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_tr_histories";

            //membuka koneksi
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var histo = new Histories();
                    histo.start_date = reader.GetDateTime(0); //index 0 dari db
                    histo.employee_id = reader.GetInt32(1); //index 1 dari db
                    if (reader.IsDBNull(2))
                    {
                        histo.end_date = null; // Atur sebagai null jika nilainya null
                    }
                    else
                    {
                        histo.end_date = reader.GetDateTime(2);
                    }
                    histo.department_id = reader.GetInt32(3);
                    histo.job_id = reader.GetString(4);
                    histories.Add(histo);
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
        return histories;
    }
}
