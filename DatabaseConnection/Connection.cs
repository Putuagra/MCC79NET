using System.Data.SqlClient;

namespace DatabaseConnection
{
    public class Connection
    {
        string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;

        public SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}


