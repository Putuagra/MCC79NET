using System.Data.SqlClient;

namespace DatabaseConnection.Contexts;

public class AllConnection
{
    private static string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}


