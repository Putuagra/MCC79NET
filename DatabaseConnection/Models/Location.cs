using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Location
{
    public int Id { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string City { get; set; }
    public string? StateProvince { get; set; }
    public string? CountryId { get; set; }
    private Handling _handling = new Handling();

    public List<Location> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var location = new List<Location>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_locations";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var locations = new Location();
                    locations.Id = reader.GetInt32(0); //index 0 dari db
                    locations.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                    //loc.street_address = reader.GetString(1); //index 1 dari db
                    locations.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                    //loc.postal_code = reader.GetString(2);
                    locations.City = reader.GetString(3);
                    locations.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                    //loc.state_province = reader.GetString(4);
                    locations.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);
                    //loc.country_id = reader.GetString(5);
                    location.Add(locations);
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
        return location;
    }
}
