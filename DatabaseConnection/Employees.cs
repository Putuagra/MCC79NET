using System.Data.SqlClient;

namespace DatabaseConnection;

public class Employees
{
    string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;

    public int id { get; set; }
    public string first_name { get; set; }
    public string? last_name { get; set; }
    public string email { get; set; }
    public string? phone_number { get; set; }
    public DateTime hire_date { get; set; }
    public int? salary { get; set; }
    public decimal? commission_pct { get; set; }
    public int? manager_id { get; set; }
    public string job_id { get; set; }
    public int department_id { get; set; }

    public List<Employees> GetAllEmployees()
    {
        var Employee = new List<Employees>();
        try
        {
            connection = new SqlConnection(connectionString);
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_employees";

            //membuka koneksi
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var emp = new Employees();
                    emp.id = reader.GetInt32(0); //index 0 dari db
                    emp.first_name = reader.GetString(1); //index 1 dari db
                    if (reader.IsDBNull(2))
                    {
                        emp.last_name = null;
                    }
                    else
                    {
                        emp.last_name = reader.GetString(2);
                    }
                    //emp.last_name = reader.GetString(2);
                    emp.email = reader.GetString(3);
                    if (reader.IsDBNull(4))
                    {
                        emp.phone_number = null;
                    }
                    else
                    {
                        emp.phone_number = reader.GetString(4);
                    }
                    //emp.phone_number = reader.GetString(4);
                    emp.hire_date = reader.GetDateTime(5);
                    //emp.salary = reader.GetInt32(6);
                    if (reader.IsDBNull(6))
                    {
                        emp.salary = 0;
                    }
                    else
                    {
                        emp.salary = reader.GetInt32(6);
                    }
                    if (reader.IsDBNull(7))
                    {
                        emp.commission_pct = null;
                    }
                    else
                    {
                        emp.commission_pct = reader.GetDecimal(7);
                    }
                    if (reader.IsDBNull(8))
                    {
                        emp.manager_id = 0;
                    }
                    else
                    {
                        emp.manager_id = reader.GetInt32(8);
                    }
                    //emp.manager_id = reader.GetInt32(8);
                    emp.job_id = reader.GetString(9);
                    emp.department_id = reader.GetInt32(10);
                    Employee.Add(emp);
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
        return Employee;
    }
}
