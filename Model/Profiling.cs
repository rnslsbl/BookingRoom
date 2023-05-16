using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using BookingRoom.Context;

namespace BookingRoom.Model;
public class Profiling
{
    public string Employee_Id { get; set; }
    public int Education_Id { get; set; }


    public List<Profiling> GetProfiling()
    {
        var pro = new List<Profiling>();
        using var connection = MyConnection.Get(); 
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
    }


    public int InsertProfiling(Profiling profiling)
    {
        int result = 0;
        using var connection = MyConnection.Get();
        connection.Open();

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


