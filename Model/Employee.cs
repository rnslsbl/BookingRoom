using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Context;

namespace BookingRoom.Model;

public class Employee
{
    public string Id { get; set; }
    public string Nik { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }
    public DateTime Hiring_Date { get; set; }
    public string Email { get; set; }
    public string Phone_Number { get; set; }
    public string Department_Id { get; set; }


    public List<Employee> GetEmployee()
    {
        var employees = new List<Employee>();
        using SqlConnection connection = MyConnection.Get();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_employees";
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.Id = reader[0].ToString();
                    employee.Nik = reader.GetString(1);
                    employee.First_Name = reader.GetString(2);
                    employee.Last_Name = reader.GetString(3);
                    employee.Birthdate = reader.GetDateTime(4);
                    employee.Gender = reader.GetString(5);
                    employee.Hiring_Date = reader.GetDateTime(6);
                    employee.Email = reader.GetString(7);
                    employee.Phone_Number = reader.GetString(8);
                    employee.Department_Id = reader.GetString(9);
                    employees.Add(employee);
                }
                return employees;
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
        return new List<Employee>();

    }


    // INSERT : Employee
    public int InsertDataEmployee(Employee employees)
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
            command.CommandText = "INSERT INTO tb_m_employees(nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id) VALUES (@nik, @first_name, @last_name, @birthdate, @gender, @hiring_date, @email, @phone_number, @department_id)";
            command.Transaction = transaction;

            //int employeeId = (int)command.ExecuteScalar();
            // Membuat parameter
            var pNik = new SqlParameter();
            pNik.ParameterName = "@nik";
            pNik.SqlDbType = SqlDbType.VarChar;
            pNik.Size = 6;
            pNik.Value = employees.Nik;

            var pFname = new SqlParameter();
            pFname.ParameterName = "@first_name";
            pFname.SqlDbType = SqlDbType.VarChar;
            pFname.Size = 50;
            pFname.Value = employees.First_Name;

            var pLname = new SqlParameter();
            pLname.ParameterName = "@last_name";
            pLname.SqlDbType = SqlDbType.VarChar;
            pLname.Size = 50;
            pLname.Value = employees.Last_Name;

            var pBdate = new SqlParameter();
            pBdate.ParameterName = "@birthdate";
            pBdate.SqlDbType = SqlDbType.DateTime;
            pBdate.Value = employees.Birthdate;

            var pGender = new SqlParameter();
            pGender.ParameterName = "@gender";
            pGender.SqlDbType = SqlDbType.VarChar;
            pGender.Size = 10;
            pGender.Value = employees.Gender;

            var pHdate = new SqlParameter();
            pHdate.ParameterName = "@hiring_date";
            pHdate.SqlDbType = SqlDbType.DateTime;
            pHdate.Value = employees.Hiring_Date;

            var pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Size = 50;
            pEmail.Value = employees.Email;

            var pPnumber = new SqlParameter();
            pPnumber.ParameterName = "@phone_number";
            pPnumber.SqlDbType = SqlDbType.VarChar;
            pPnumber.Size = 50;
            pPnumber.Value = employees.Phone_Number;

            var pDid = new SqlParameter();
            pDid.ParameterName = "@department_id";
            pDid.SqlDbType = SqlDbType.VarChar;
            pDid.Size = 4;
            pDid.Value = employees.Department_Id;

            // Menambahkan parameter ke command
            command.Parameters.Add(pNik);
            command.Parameters.Add(pFname);
            command.Parameters.Add(pLname);
            command.Parameters.Add(pBdate);
            command.Parameters.Add(pGender);
            command.Parameters.Add(pHdate);
            command.Parameters.Add(pEmail);
            command.Parameters.Add(pPnumber);
            command.Parameters.Add(pDid);

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

    public string GetEmpId(string Nik)
    {
        using SqlConnection connection = MyConnection.Get();
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT id FROM tb_m_employees WHERE nik=(@Nik)", connection);

        var pNik2 = new SqlParameter();
        pNik2.ParameterName = "@Nik";
        pNik2.Value = Nik;
        command.Parameters.Add(pNik2);

        string lastEmpId = Convert.ToString(command.ExecuteScalar());
        connection.Close();

        return lastEmpId;
    }

}






