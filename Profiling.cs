using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom;
public class Profiling
{
    public string Employee_Id { get; set; }
    public int Education_Id { get; set; }

    private static readonly string connectionString =
    "Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

   /* public static List<Profiling> GetProfilings()
    {
        var pro = new List<Profiling>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_tr_profilings";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var prof = new Profiling();
                    prof.Employee_Id = reader.GetGuid(0).ToString();
                    prof.Education_Id = reader.GetInt32(1);

                    pro.Add(prof);
                }
                return pro;
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
        return new List<Profiling>();
    }*/
    public static int InsertProfiling(Profiling profiling)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var employee = new Employee();
        var education = new Education();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@Employee_Id, @Education_Id)";
            command.Transaction = transaction;

            var pEmpId = new SqlParameter();
            pEmpId.ParameterName = "@Employee_Id";
            pEmpId.Value = profiling.Employee_Id;
            command.Parameters.Add(pEmpId);

            var pEduId = new SqlParameter();
            pEduId.ParameterName = "@Education_Id";
            pEduId.Value = profiling.Education_Id;
            command.Parameters.Add(pEduId);

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
}

    /*public static void CreateProfiling()
    {
        var profilings = new Profiling();
        Console.Write("Masukkan Employee : ");
        profilings.Employee_Id = Console.ReadLine();
        var result = InsertProfiling(profilings);
        *//*if (result > 0)
        {
            Console.WriteLine("Insert success.");
        }
        else
        {
            Console.WriteLine("Insert failed.");
        }*//*

    }
}

*/