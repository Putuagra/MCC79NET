using System.Data.SqlClient;

namespace DatabaseConnection
{
    public class Connection
    {
        static string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}


