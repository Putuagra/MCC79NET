using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Employees
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int? Salary { get; set; }
    public decimal? CommissionPct { get; set; }
    public int? ManagerId { get; set; }
    public string JobId { get; set; }
    public int DepartmentId { get; set; }
    private Handling _handling = new Handling();

    public List<Employees> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var Employee = new List<Employees>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_employees";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var employee = new Employees();
                    employee.Id = reader.GetInt32(0); //index 0 dari db
                    employee.FirstName = reader.GetString(1); //index 1 dari db
                    employee.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    //emp.last_name = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4);
                    //emp.phone_number = reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    //emp.salary = reader.GetInt32(6);
                    employee.Salary = reader.IsDBNull(6) ? null : reader.GetInt32(6);
                    employee.CommissionPct = reader.IsDBNull(7) ? null : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? null : reader.GetInt32(8);
                    //emp.manager_id = reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);
                    Employee.Add(employee);
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
        return Employee;
    }
}
