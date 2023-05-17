using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using BookingRoom.Context;

namespace BookingRoom.Model;

public class Education
{

    public int Id { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public string Gpa { get; set; }
    public int University_Id { get; set; }


    //get universities

    public List<Education> GetEducation()
    {
        var educations = new List<Education>();
        using SqlConnection connection = MyConnection.Get();
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
    public List<Education> GetIdEducation(Education education)
    {
        var educations = new List<Education>();
        using SqlConnection connection = MyConnection.Get();
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
                    Console.WriteLine("Major Name: " + reader.GetString(1));
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

    public int InsertEducation(Education education)
    {
        int result = 0;
        using var connection = MyConnection.Get();
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
    public int UpdateEducation(Education education)
    {
        int result = 0;
        using var connection = MyConnection.Get();
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

    public int DeleteEducation(Education education)
    {
        int result = 0;
        using var connection = MyConnection.Get();
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
    public int GetEduId()
    {
        using var connection = MyConnection.Get();
        connection.Open();

        var command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

        int id = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return id;
    }
}








