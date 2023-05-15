using BookingRoom;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Channels;
using System.Transactions;

namespace BasicConnection;
public class Program
{
    private static readonly string connectionString =
    "Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

    static void Main()
    {
        /*   SqlConnection connection = new SqlConnection(connectionString);

           try
           {
               connection.Open();
               Console.WriteLine("Connection opened successfully.");
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
           }
           finally
           {
               connection.Close();
               Console.WriteLine("Connection closed successfully.");
           }*/

        Menu();
    }
    static void Menu()
    {
        Console.WriteLine("Rona Salsabila");
        Console.WriteLine("======================================");
        Console.WriteLine("\t        MENU     ");
        Console.WriteLine("======================================");
        Console.WriteLine("1. UNIVERSITY");
        Console.WriteLine("2. EDUCATION");
        Console.WriteLine("3. INSERT MERGE");
        Console.WriteLine("4. Exit");
        Console.WriteLine("--------------------------------------");
        Console.Write("Pilihan : ");
        string pilihan = Console.ReadLine();

        switch (pilihan)
        {
            case "1":
                Console.WriteLine("--------------------------------------");
                Console.Write("\nPILIHAN AKSI\n");
                Console.WriteLine("- Create\n- Read\n- Update\n- Delete");
                Console.Write("Pilih: ");
                string aksi = Console.ReadLine();
                Console.WriteLine("--------------------------------------");
                if (aksi.ToLower() == "create")
                {
                    University.CreateUniversity();
                }
                else if (aksi.ToLower() == "read")
                {
                    University.GetIdUniversity();
                    Console.WriteLine("ALL DATA");
                    University.ReadUniversity();
                }
                else if (aksi.ToLower() == "update")
                {
                    University.UpdateUniversity();
                }
                else if (aksi.ToLower() == "delete")
                {
                    University.DeleteUniversity();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                break;


            case "2":
                Console.WriteLine("--------------------------------------");
                Console.Write("\nPILIHAN AKSI\n");
                Console.WriteLine("1. Create \n2. Read \n3. Update \n4. Delete");
                string aksi2 = Console.ReadLine();
                if (aksi2.ToLower() == "create")
                {
                    Education.CreateEducation();
                }
                else if (aksi2.ToLower() == "read")
                {
                    University.GetIdUniversity();
                    Console.WriteLine("ALL DATA");
                    Education.ReadEducation();
                }
                else if (aksi2.ToLower() == "update")
                {
                    Education.UpdateEducation();
                }
                else if (aksi2.ToLower() == "delete")
                {
                    Education.DeleteEducation();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                break;

            case "3":
                //InsertMerger();
                Employee.PrintOutEmployee();
                break;

            case "4":
                return;
                break;

            default:
                Console.Write("Invalid Input!!!");
                break;
        }
    }

   /* public static void gabung()
    {
        Employee.CreateEmployee();
        University.CreateUniversity();
        Education.CreateNewEducation();
        Profiling.CreateProfiling();
    }*/

        //Store Procedure
        public static int InsertDataMerge(Employee employee, University university, Education education)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "exec sp_insert_data @nik, @first_name, @last_name, @birthdate, @gender, @hiring_date, @email, @phone_number, @department_id, @major, @degree, @gpa, @university_name";
            command.Transaction = transaction;

            var pNik = new SqlParameter();
            pNik.ParameterName = "@nik";
            pNik.SqlDbType = SqlDbType.VarChar;
            pNik.Size = 6;
            pNik.Value = employee.Nik;

            var pFname = new SqlParameter();
            pFname.ParameterName = "@first_name";
            pFname.SqlDbType = SqlDbType.VarChar;
            pFname.Size = 50;
            pFname.Value = employee.First_Name;

            var pLname = new SqlParameter();
            pLname.ParameterName = "@last_name";
            pLname.SqlDbType = SqlDbType.VarChar;
            pLname.Size = 50;
            pLname.Value = employee.Last_Name;

            var pBdate = new SqlParameter();
            pBdate.ParameterName = "@birthdate";
            pBdate.SqlDbType = SqlDbType.DateTime;
            pBdate.Value = employee.Birthdate;

            var pGender = new SqlParameter();
            pGender.ParameterName = "@gender";
            pGender.SqlDbType = SqlDbType.VarChar;
            pGender.Size = 10;
            pGender.Value = employee.Gender;

            var pHdate = new SqlParameter();
            pHdate.ParameterName = "@hiring_date";
            pHdate.SqlDbType = SqlDbType.DateTime;
            pHdate.Value = employee.Hiring_Date;

            var pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Size = 50;
            pEmail.Value = employee.Email;

            var pPnumber = new SqlParameter();
            pPnumber.ParameterName = "@phone_number";
            pPnumber.SqlDbType = SqlDbType.VarChar;
            pPnumber.Size = 50;
            pPnumber.Value = employee.Phone_Number;

            var pDid = new SqlParameter();
            pDid.ParameterName = "@department_id";
            pDid.SqlDbType = SqlDbType.VarChar;
            pDid.Size = 4;
            pDid.Value = employee.Department_Id;

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

            var pName = new SqlParameter();
            pName.ParameterName = "@university_name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Size = 50;
            pName.Value = university.Name;

            command.Parameters.Add(pNik);
            command.Parameters.Add(pFname);
            command.Parameters.Add(pLname);
            command.Parameters.Add(pBdate);
            command.Parameters.Add(pGender);
            command.Parameters.Add(pHdate);
            command.Parameters.Add(pEmail);
            command.Parameters.Add(pPnumber);
            command.Parameters.Add(pDid);
            command.Parameters.Add(pMajor);
            command.Parameters.Add(pDegree);
            command.Parameters.Add(pGpa);
            command.Parameters.Add(pName);

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
    //Show SP
    public static void InsertMerger()
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

        var education = new Education();
        Console.Write("Masukkan Major : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa : ");
        education.Gpa = Console.ReadLine();

        var university = new University();
        Console.Write("Masukkan Nama Universitas : ");
        university.Name = Console.ReadLine();

        var result = InsertDataMerge(employee, university, education);
       /* if (result > 0)
        {
            Console.WriteLine("Insert success.");
        }
        else
        {

            Console.WriteLine("Insert failed.");
        }*/
    }
    //Basic Insert
        

        }
    


    
        

  