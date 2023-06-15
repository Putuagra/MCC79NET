using System.Data.SqlClient;

namespace DatabaseConnection;


public class departments
{
    string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;
    public int id { get; set; }
    public string name { get; set; }
    public int? location_id { get; set; }
    public int? manager_id { get; set; }

    public List<departments> GetAllDepartment()
    {
        var department = new List<departments>();
        try
        {
            connection = new SqlConnection(connectionString);
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_departments";

            //membuka koneksi
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dept = new departments();
                    dept.id = reader.GetInt32(0); //index 0 dari db
                    dept.name = reader.GetString(1); //index 1 dari db
                    if (reader.IsDBNull(2))
                    {
                        dept.location_id = 0;
                    }
                    else
                    {
                        dept.location_id = reader.GetInt32(2);
                    }
                    //dept.location_id = reader.GetInt32(2);
                    if (reader.IsDBNull(3))
                    {
                        dept.manager_id = 0;
                    }
                    else
                    {
                        dept.manager_id = reader.GetInt32(3);
                    }
                    //dept.manager_id = reader.GetInt32(3);
                    department.Add(dept);
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
        return department;
    }
}
