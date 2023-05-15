using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace BookingRoom;

public class Education
{

    public int Id { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public string Gpa { get; set; }
    public int University_Id { get; set; }


    //get universities
    private static readonly string connectionString =
"Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

public static List<Education> GetEducation()
{
    var educations = new List<Education>();
    using SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tb_m_educations";
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var education = new Education();
                education.Id = reader.GetInt32(0);
                education.Major = reader.GetString(1);
                education.Degree = reader.GetString(2);
                education.Gpa = reader.GetString(3);
                education.University_Id = reader.GetInt32(4);
                educations.Add(education);
            }
            return educations;
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
    return new List<Education>();
}

    //get by id
    public static List<Education> GetIdEducation(Education education)
    {
        var educations = new List<Education>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_educations where id=@id";

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Size = 20;
            pId.Value = education.Id;

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
                return educations;

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
        return new List<Education>();
    }


    // INSERT

    public static int InsertEducation(Education education)
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
        command.CommandText = "INSERT INTO tb_m_educations(Major, Degree, Gpa, University_Id) VALUES (@Major, @Degree, @Gpa, @universityId)";
        command.Transaction = transaction;

        // Membuat parameter
        var pMajor = new SqlParameter();
        pMajor.ParameterName = "@Major";
        pMajor.SqlDbType = SqlDbType.VarChar;
        pMajor.Size = 50;
        pMajor.Value = education.Major;

        var pDegree = new SqlParameter();
        pDegree.ParameterName = "@Degree";
        pDegree.SqlDbType = SqlDbType.VarChar;
        pDegree.Size = 50;
        pDegree.Value = education.Degree;

        var pGpa = new SqlParameter();
        pGpa.ParameterName = "@Gpa";
        pGpa.SqlDbType = SqlDbType.VarChar;
        pGpa.Size = 50;
        pGpa.Value = education.Gpa;

        var pUniversityId = new SqlParameter();
        pUniversityId.ParameterName = "@universityId";
        pUniversityId.SqlDbType = SqlDbType.Int;
        pUniversityId.Size = 20;
        pUniversityId.Value = education.University_Id;

        // Menambahkan parameter ke command
        command.Parameters.Add(pMajor);
        command.Parameters.Add(pDegree);
        command.Parameters.Add(pGpa);
        command.Parameters.Add(pUniversityId);

        // Menjalankan command
        result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}


// UPDATE
public static int UpdateEducation(Education education)
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
        command.CommandText = "Update tb_m_educations set Major= @Major, Degree=@degree, Gpa=@gpa, University_Id=@University_Id WHERE Id=@Id";
        command.Transaction = transaction;

        // Membuat parameter id
        var pId = new SqlParameter();
        pId.ParameterName = "@Id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Size = 20;
        pId.Value = education.Id;

        // Membuat parameter
        var pMajor = new SqlParameter();
        pMajor.ParameterName = "@Major";
        pMajor.SqlDbType = SqlDbType.VarChar;
        pMajor.Size = 50;
        pMajor.Value = education.Major;

        var pDegree = new SqlParameter();
        pDegree.ParameterName = "@Degree";
        pDegree.SqlDbType = SqlDbType.VarChar;
        pDegree.Size = 50;
        pDegree.Value = education.Degree;

        var pGpa = new SqlParameter();
        pGpa.ParameterName = "@Gpa";
        pGpa.SqlDbType = SqlDbType.VarChar;
        pGpa.Size = 50;
        pGpa.Value = education.Gpa;

        var pUniversityId = new SqlParameter();
        pUniversityId.ParameterName = "@University_Id";
        pUniversityId.SqlDbType = SqlDbType.Int;
        pUniversityId.Size = 20;
        pUniversityId.Value = education.University_Id;

        // Menambahkan parameter ke command
        command.Parameters.Add(pId);
        command.Parameters.Add(pMajor);
        command.Parameters.Add(pDegree);
        command.Parameters.Add(pGpa);
        command.Parameters.Add(pUniversityId);

        // Menjalankan command
        result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}

//DELETE

public static int DeleteEducation(Education education)
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
        command.CommandText = "DELETE FROM tb_m_educations where id=@id";
        command.Transaction = transaction;

        // Membuat parameter id
        var pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Size = 20;
        pId.Value = education.Id;

        // Menambahkan parameter ke command
        command.Parameters.Add(pId);

        // Menjalankan command
        result = command.ExecuteNonQuery();
        transaction.Commit();

        return result;

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
    }

    return result;
}


//CRUD

public static void CreateEducation()
{
    var education = new Education();
        Console.Write("Masukkan Major : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa : ");
        education.Gpa = Console.ReadLine();
        Console.WriteLine("Masukkan ID University : ");
        education.University_Id = Convert.ToInt32(Console.ReadLine());
    var result = Education.InsertEducation(education);
/*    if (result > 0)
    {
        Console.WriteLine("Insert success.");
    }
    else
    {
        Console.WriteLine("Insert failed.");
    }*/
}

    public static void CreateNewEducation()
    {
        var education = new Education();
        Console.Write("Masukkan Major : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa : ");
        education.Gpa = Console.ReadLine();
        var result = Education.InsertEducation(education);
        /*if (result > 0)
        {
            Console.WriteLine("Insert success.");
        }
        else
        {
            Console.WriteLine("Insert failed.");
        }*/
    }

    public static void ReadEducation()
{
    var results = GetEducation();
    foreach (var result in results)
    {
        Console.WriteLine("Id: " + result.Id);
        Console.WriteLine("Major: " + result.Major);
        Console.WriteLine("Degree: " + result.Degree);
        Console.WriteLine("Gpa: " + result.Gpa);
        Console.WriteLine("ID University : " + result.University_Id);
    }
}
public static void UpdateEducation()
{
    var education = new Education();
        Console.Write("Masukkan Id : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan Major Baru : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree Baru : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa Baru : ");
        education.Gpa = Console.ReadLine();
        Console.Write("Masukkan ID University : ");
        education.University_Id = Convert.ToInt32(Console.ReadLine());
    var result = Education.UpdateEducation(education);
/*    if (result > 0)
    {
        Console.WriteLine("Update success.");
    }
    else
    {
        Console.WriteLine("Update failed.");
    }*/

}
public static void DeleteEducation()
{
    var education = new Education();
        Console.Write("Masukkan ID yang ingin dihapus : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
    var result = Education.DeleteEducation(education);
/*    if (result > 0)
    {
        Console.WriteLine("Delete success.");
    }
    else
    {
        Console.WriteLine("Delete failed.");
    }*/
}
    public static void GetIdEducation()
    {
        var education = new Education();
        Console.Write("Masukkan Id untuk dicari : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
        GetIdEducation(education);

    }
}





