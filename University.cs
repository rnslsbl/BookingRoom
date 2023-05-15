using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace BookingRoom;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; }


//get universities
private static readonly string connectionString =
"Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

public static List<University> GetUniversity()
{
    var universities = new List<University>();
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tb_m_universities";
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
            
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var university = new University();
                university.Id = reader.GetInt32(0);
                university.Name = reader.GetString(1);
                universities.Add(university);
            }
            return universities;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }
    return new List<University>();
}

//get id 5

public static List<University> GetIdUniversity(University university)
{
    var universities = new List<University>();
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tb_m_universities where id=@id";

        var pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Size = 20;
        pId.Value = university.Id;

        command.Parameters.Add(pId);
        connection.Open();


        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id: " + reader.GetInt32(0));
                Console.WriteLine("Name: " + reader.GetString(1));
            }
            return universities;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        connection.Close();
    }
    return new List<University>();
}

   
    // INSERT

    public static int InsertUniversity(University university)
{
    int result = 0;
    using var connection = new SqlConnection(connectionString);
    connection.Open();
        
        SqlTransaction transaction = connection.BeginTransaction();
    try
    {
        // Command melakukan insert
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO tb_m_universities(name) VALUES (@name)";
            
            command.Transaction = transaction;

        // Membuat parameter
        var pName = new SqlParameter();
        pName.ParameterName = "@name";
        pName.SqlDbType = SqlDbType.VarChar;
        pName.Size = 50;
        pName.Value = university.Name;

        // Menambahkan parameter ke command
        command.Parameters.Add(pName);

        // Menjalankan command
        result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}


// UPDATE
public static int UpdateUniversity(University university)
{
    int result = 0;
    using var connection = new SqlConnection(connectionString);
    connection.Open();
    SqlTransaction transaction = connection.BeginTransaction();
    try
    {
        // Command melakukan insert
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Update tb_m_universities set Name= @name where id=@id";
        command.Transaction = transaction;

            // Membuat parameter id
        var pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Size = 20;
        pId.Value = university.Id;

        //Membuat parameter name
        var pName = new SqlParameter();
        pName.ParameterName = "@name";
        pName.SqlDbType = SqlDbType.VarChar;
        pName.Size = 50;
        pName.Value = university.Name;

            // Menambahkan parameter ke command
            
            command.Parameters.Add(pName);
            
            
            command.Parameters.Add(pId);

            // Menjalankan command
            result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}

//DELETE

public static int DeleteUniversity(University university)
{
    int result = 0;
    using var connection = new SqlConnection(connectionString);
    connection.Open();

    SqlTransaction transaction = connection.BeginTransaction();
    try
    {
        // Command melakukan delete
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM tb_m_universities where id=@id";
        command.Transaction = transaction;

        // Membuat parameter id
        var pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Size = 20;
        pId.Value = university.Id;

        // Menambahkan parameter ke command
        command.Parameters.Add(pId);

        // Menjalankan command
        result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        //Console.WriteLine(e.Message);
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}
//CRUD

public static void CreateUniversity()
{
    var university = new University();
        Console.Write("Masukkan Nama : ");
        university.Name = Console.ReadLine();
    var result = InsertUniversity(university);


/*    if (result > 0)
    {
        Console.WriteLine("Insert success.");
    }
    else
    {
        Console.WriteLine("Insert failed.");
    }*/

}
public static void ReadUniversity()
{
    var results = GetUniversity();
    foreach (var result in results)
    {
        Console.WriteLine("Id: " + result.Id);
        Console.WriteLine("Name: " + result.Name);
    }

}

public static void UpdateUniversity()
{
    var university = new University();
        Console.Write("Masukkan Id : ");
        university.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan Nama Baru: ");
        university.Name = Console.ReadLine();
    var result = UpdateUniversity(university);
    /*if (result > 0)
    {
        Console.WriteLine("Update success.");
    }
    else
    {
        Console.WriteLine("Update failed.");
    }
*/

}
    public static void DeleteUniversity()
    {
        var university = new University();
        Console.Write("Masukkan Id untuk dihapus : ");
        university.Id = Convert.ToInt32(Console.ReadLine());

        var result = DeleteUniversity(university);
 /*       if (result > 0)
        {
            Console.WriteLine("Delete success.");
        }
        else
        {
            Console.WriteLine("Delete failed.");
        }*/
    }
     public static void GetIdUniversity()
    {
        var university = new University();
        Console.Write("Masukkan Id untuk dicari : ");
        university.Id = Convert.ToInt32(Console.ReadLine()); 
        GetIdUniversity(university);
            
    }
}


