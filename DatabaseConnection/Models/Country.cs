using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    private Handling _handling = new Handling();

    public List<Country> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var country = new List<Country>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Country = new Country();
                    Country.Id = reader.GetString(0); //index 0 dari db
                    Country.Name = reader.GetString(1); //index 1 dari db
                    Country.RegionId = reader.GetInt32(2);
                    country.Add(Country);
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
        return country;
    }

    public int Insert(string Id, string Name, int RegionId)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into tb_m_countries (id, name, region_id) values (@id,@country_name, @region_id)";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = Id;
            pId.SqlDbType = SqlDbType.VarChar;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@country_name";
            pName.Value = Name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = RegionId;
            pRegionId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pId);
            command.Parameters.Add(pName);
            command.Parameters.Add(pRegionId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
        connection.Close();
        return result;
    }

    public Country GetById(string Id)
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var country = new Country();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";

            //membuka koneksi
            //connection.Open();
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = Id;
            pName.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(pName);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                country.Id = reader.GetString(0); //index 0 dari db
                country.Name = reader.GetString(1); //index 1 dari db
                country.RegionId = reader.GetInt32(2);
            }
            else
            {
                country = new Country();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return country;
    }

    public int Update(string Id, string Nama, int RegionId)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update tb_m_countries set name = @country_name, region_id = @region_id where id = @id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@country_name";
            pName.Value = Nama;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = Id;
            pId.SqlDbType = SqlDbType.VarChar;

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = RegionId;
            pRegionId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pName);
            command.Parameters.Add(pId);
            command.Parameters.Add(pRegionId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
        connection.Close();
        return result;
    }
    public int Delete(string Id)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from tb_m_countries where id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = Id;
            pId.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(pId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
        connection.Close();
        return result;
    }
}
