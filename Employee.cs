using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom;

public class Employee
{
    public int Id { get; set; }
    public string Nik { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }
    public DateTime Hiring_Date { get; set; }
    public string Email { get; set; }
    public string Phone_Number { get; set; }
    public string Department_Id { get; set; }

    private static readonly string connectionString =
    "Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

    // INSERT : Employee
    public static int InsertDataEmployee(Employee employees)
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


    public static void CreateEmployee()
    {
        var employee = new Employee();
        Console.Write("Masukkan NIK : ");
        employee.Nik = Console.ReadLine();
        Console.Write("Masukkan First Name : ");
        employee.First_Name = Console.ReadLine();
        Console.Write("Masukkan Last Name : ");
        employee.Last_Name = Console.ReadLine();
        Console.Write("Masukkan Birthdate : ");
        employee.Birthdate = DateTime.Parse(Console.ReadLine());
        Console.Write("Masukkan Gender : ");
        employee.Gender = Console.ReadLine();
        Console.Write("Masukkan Hiring Date : ");
        employee.Hiring_Date = DateTime.Parse(Console.ReadLine());
        Console.Write("Masukkan Email : ");
        employee.Email = Console.ReadLine();
        Console.Write("Masukkan Phone Number : ");
        employee.Phone_Number = Console.ReadLine();
        Console.Write("Masukkan Department Id : ");
        employee.Department_Id = Console.ReadLine();


        var result = InsertDataEmployee(employee);
        /* if (result > 0)
         {
             Console.WriteLine("Insert success.");
         }
         else
         {
             Console.WriteLine("Insert failed.");
         }*/
    }


    public static string GetEmpId(string Nik)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
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

    public static int GetUnivEduId(int choice)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        if (choice == 1)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_universities ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
        else
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }
    public static void PrintOutEmployee()
    {
        var employee = new Employee();
        var profiling = new Profiling();
        var education = new Education();
        var university = new University();

        Console.Write("NIK : ");
        var niks = Console.ReadLine();
        employee.Nik = niks;

        Console.Write("First Name : ");
        employee.First_Name = Console.ReadLine();

        Console.Write("Lame Name : ");
        employee.Last_Name = Console.ReadLine();

        Console.Write("Birthdate : ");
        employee.Birthdate = DateTime.Parse(Console.ReadLine());

        Console.Write("Gender : ");
        employee.Gender = Console.ReadLine();

        Console.Write("Hiring Date : ");
        employee.Hiring_Date = DateTime.Parse(Console.ReadLine());

        Console.Write("Email : ");
        employee.Email = Console.ReadLine();

        Console.Write("Phone Number : ");
        employee.Phone_Number = Console.ReadLine();

        Console.Write("Department ID : ");
        employee.Department_Id = Console.ReadLine();

        InsertDataEmployee(employee);


        //EDUCATION
        Console.Write("Major : ");
        education.Major = Console.ReadLine();

        Console.Write("Degree : ");
        education.Degree = Console.ReadLine();

        Console.Write("GPA : ");
        education.Gpa = Console.ReadLine();

        Console.Write("University Name : ");
        university.Name = Console.ReadLine();

        University.InsertUniversity(university);

        education.University_Id = GetUnivEduId(1);
        Education.InsertEducation(education);

        profiling.Employee_Id = GetEmpId(niks);
        profiling.Education_Id = GetUnivEduId(2);
        var result = Profiling.InsertProfiling(profiling);

        if (result > 0)
        {
            Console.WriteLine("Insert success.");
        }
        else
        {
            Console.WriteLine("Insert failed.");
        }

    }
}



