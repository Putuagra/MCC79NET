using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;


public class Departments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? LocationId { get; set; }
    public int? ManagerId { get; set; }
    private Handling _handling = new Handling();

    public List<Departments> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var department = new List<Departments>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_departments";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var departments = new Departments();
                    departments.Id = reader.GetInt32(0); //index 0 dari db
                    departments.Name = reader.GetString(1); //index 1 dari db
                    departments.LocationId = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                    //dept.location_id = reader.GetInt32(2);
                    departments.ManagerId = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                    //dept.manager_id = reader.GetInt32(3);
                    department.Add(departments);
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
        return department;
    }
}
