using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection;

public class Country
{
    public string id { get; set; }
    public string name { get; set; }
    public int region_id { get; set; }

    //string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection = Connection.GetConnection();

    public List<Country> GetAllCountry()
    {
        var country = new List<Country>();
        try
        {
            //connection = new SqlConnection(connectionString);
            //SqlConnection connection = Connection.GetConnection();
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries";

            //membuka koneksi
            //connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var count = new Country();
                    count.id = reader.GetString(0); //index 0 dari db
                    count.name = reader.GetString(1); //index 1 dari db
                    count.region_id = reader.GetInt32(2);
                    country.Add(count);
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
        return country;
    }

    public int InsertCountry(string id, string name, int reg_id)
    {
        int result = 0;
        SqlConnection connection = Connection.GetConnection();
        //connection = new SqlConnection(connectionString);

        //connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into tb_m_countries (id, name, region_id) values (@id,@country_name, @region_id)";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@country_name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = reg_id;
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

    public List<Country> GetCountryById(string id)
    {
        var country = new List<Country>();
        try
        {
            //connection = new SqlConnection(connectionString);
            //instance command
            SqlConnection connection = Connection.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";

            //membuka koneksi
            //connection.Open();
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(pName);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var count = new Country();
                    count.id = reader.GetString(0); //index 0 dari db
                    count.name = reader.GetString(1); //index 1 dari db
                    count.region_id = reader.GetInt32(2);
                    country.Add(count);
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
        return country;
    }

    public int UpdateCountry(string id, string nama, int region_id)
    {
        int result = 0;
        SqlConnection connection = Connection.GetConnection();
        //connection = new SqlConnection(connectionString);

        //connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update tb_m_countries set name = @country_name, region_id = @region_id where id = @id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@country_name";
            pName.Value = nama;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.Value = region_id;
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
    public int DeleteCountry(string id)
    {
        int result = 0;
        //connection = new SqlConnection(connectionString);

        SqlConnection connection = Connection.GetConnection();
        //connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from tb_m_countries where id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
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
