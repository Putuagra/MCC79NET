using DatabaseConnection.Contexts;
using DatabaseConnection.Views;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    private Handling _handling = new Handling();

    public List<Region> GetAll()
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var region = new List<Region>();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var regions = new Region();
                    regions.Id = reader.GetInt32(0); //index 0 dari db
                    regions.Name = reader.GetString(1); //index 1 dari db
                    region.Add(regions);
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
        return region;
    }
    public int Insert(string Name)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into tb_m_regions (name) values (@region_name)";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@region_name";
            pName.Value = Name;
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

    public Region GetById(int Id)
    {
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        var regions = new Region();
        try
        {
            //instance command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @id";

            //membuka koneksi
            //connection.Open();
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = Id;
            pName.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(pName);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                regions.Id = reader.GetInt32(0); //index 0 dari db
                regions.Name = reader.GetString(1); //index 1 dari db
            }
            else
            {
                regions = new Region();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();
        return regions;
    }

    public int Update(int Id, string Nama)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update tb_m_regions set name = @region_name where id = @id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@region_name";
            pName.Value = Nama;
            pName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = Id;
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
    public int Delete(int Id)
    {
        int result = 0;
        SqlConnection connection = AllConnection.GetConnection();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from tb_m_regions where id = @id";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = Id;
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


