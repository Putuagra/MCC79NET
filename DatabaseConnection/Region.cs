using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }

    /*string connectionString = "Data Source=DESKTOP-0GM6MAB\\MSSQLSERVER01;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
    SqlConnection connection;*/
    SqlConnection connection = Connection.GetConnection();

    public List<Region> GetAllRegions()
    {
        var region = new List<Region>();
        try
        {
            //connection = new SqlConnection(connectionString);
            //instance command
            SqlConnection connection = Connection.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions";

            //membuka koneksi
            //onnection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var reg = new Region();
                    reg.Id = reader.GetInt32(0); //index 0 dari db
                    reg.Name = reader.GetString(1); //index 1 dari db
                    region.Add(reg);
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
        return region;
    }
    public int InsertRegion(string name)
    {
        int result = 0;
        //connection = new SqlConnection(connectionString);

        //connection.Open();
        SqlConnection connection = Connection.GetConnection();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into tb_m_regions (name) values (@region_name)";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@region_name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(pName);

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

    public List<Region> GetRegionById(int id)
    {
        var region = new List<Region>();
        try
        {
            //connection = new SqlConnection(connectionString);
            //instance command
            SqlConnection connection = Connection.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @id";

            //membuka koneksi
            //connection.Open();
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pName);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var reg = new Region();
                    reg.Id = reader.GetInt32(0); //index 0 dari db
                    reg.Name = reader.GetString(1); //index 1 dari db
                    region.Add(reg);
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
        return region;
    }

    public int UpdateRegion(int id, string nama)
    {
        int result = 0;
        /*connection = new SqlConnection(connectionString);

        connection.Open();*/
        SqlConnection connection = Connection.GetConnection();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update tb_m_regions set name = @region_name where id = @id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@region_name";
            pName.Value = nama;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pName);
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
    public int DeleteRegion(int id)
    {
        int result = 0;
        /*connection = new SqlConnection(connectionString);

        connection.Open();*/
        SqlConnection connection = Connection.GetConnection();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from tb_m_regions where id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

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


