using System.Data.SqlClient;

namespace DatabaseConnection;

public class Location
{
    string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;
    public int id { get; set; }
    public string? street_address { get; set; }
    public string? postal_code { get; set; }
    public string city { get; set; }
    public string? state_province { get; set; }
    public string? country_id { get; set; }

    public List<Location> GetAllLocation()
    {
        var location = new List<Location>();
        try
        {
            connection = new SqlConnection(connectionString);
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_locations";

            //membuka koneksi
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var loc = new Location();
                    loc.id = reader.GetInt32(0); //index 0 dari db
                    if (reader.IsDBNull(1))
                    {
                        loc.street_address = null;
                    }
                    else
                    {
                        loc.street_address = reader.GetString(1);
                    }
                    //loc.street_address = reader.GetString(1); //index 1 dari db
                    if (reader.IsDBNull(2))
                    {
                        loc.postal_code = null;
                    }
                    else
                    {
                        loc.postal_code = reader.GetString(2);
                    }
                    //loc.postal_code = reader.GetString(2);
                    loc.city = reader.GetString(3);
                    if (reader.IsDBNull(4))
                    {
                        loc.state_province = null;
                    }
                    else
                    {
                        loc.state_province = reader.GetString(4);
                    }
                    //loc.state_province = reader.GetString(4);
                    if (reader.IsDBNull(5))
                    {
                        loc.country_id = null;
                    }
                    else
                    {
                        loc.country_id = reader.GetString(5);
                    }
                    //loc.country_id = reader.GetString(5);
                    location.Add(loc);
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
        return location;
    }
}
