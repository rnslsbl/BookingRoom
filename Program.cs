using BookingRoom;
using BookingRoom.Controller;
using BookingRoom.Model;
using BookingRoom.View;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Channels;
using System.Transactions;
using BookingRoom.Context;

namespace BookingRoom;
public class Program
{
    private static UniversityController universityController = new();
    private static EducationController educationController = new();
    private static EmployeeController employeeController = new();
    private static ProfillingController profilingController = new();
    private static MenuView menuView = new MenuView();

    public static void Main()
    {
        int pilihan;
        
            menuView.Menu();
            Console.Write("Pilihan: ");
            pilihan = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("---------------------------------------");

            switch (pilihan)
            {
                //university
                case 1:
                    menuView.Crud();
                    int tabel = Convert.ToInt32(Console.ReadLine());
                    CrudUniversity(tabel);
                    break;

                //education
                case 2:
                    menuView.Crud();
                    int tabel1 = Convert.ToInt32(Console.ReadLine());
                    CrudEducation(tabel1);
                    break;

                case 3:
                    InsertAll();
                    break;

                case 4:
                    Linq();
                    break;

                case 5:
                employeeController.GetAll();
                break;

                case 6:
                profilingController.GetAll();
                break;

                case 7:
                return;
                break;

                default:
                    Console.WriteLine("Salah Input Number");
                    break;
            }
        } 
    

    public static void CrudUniversity(int aksi1)
    {
        switch (aksi1)
        {
            case 1:
                Console.WriteLine("---------------------------------------");
                var createUniv = new University();
                Console.Write("Masukkan Nama Universitas : ");
                string nama = Console.ReadLine();
                createUniv.Name = nama;
                universityController.Insert(createUniv);
                break;

            case 2:
                universityController.GetAll();
                break;

            case 3:
                var byIdUniv = new University();
                Console.Write("Masukkan Id untuk dicari : ");
                byIdUniv.Id = Convert.ToInt32(Console.ReadLine());
                byIdUniv.GetIdUniversity(byIdUniv);
                break;

            case 4:
                Console.WriteLine("---------------------------------------");
                var updateUniv = new University();
                Console.Write("\nMasukkan ID Universitas : ");
                int id = Convert.ToInt32(Console.ReadLine());
                updateUniv.Id = id;

                Console.Write("Masukkan Nama Universitas : ");
                var name = Console.ReadLine();
                updateUniv.Name = name;
                universityController.Update(updateUniv);
                break;

            case 5:
                Console.WriteLine("---------------------------------------");
                var deleteUniv = new University();
                Console.Write("Masukkan ID : ");
                int idUniv = Convert.ToInt32(Console.ReadLine());
                deleteUniv.Id = idUniv;

                universityController.Delete(deleteUniv);
                break;

            default:
                Console.WriteLine("Salah Input Number");
                break;
        }
    }

    public static void CrudEducation(int aksi2)
    {
        switch (aksi2)
        {
            case 1:
                Console.WriteLine("---------------------------------------");
                var education = new Education();
                Console.Write("Masukkan Major : ");
                education.Major = Console.ReadLine();

                Console.Write("Masukkan Degree : ");
                education.Degree = Console.ReadLine();

                Console.Write("Masukkan GPA : ");
                education.Gpa = Console.ReadLine();

                Console.Write("University ID : ");
                education.University_Id = Convert.ToInt32(Console.ReadLine());

                educationController.Create(education);
                break;

            case 2:
                educationController.GetAll();
                break;

            case 3:
                var byIdEd = new Education();
                Console.Write("Masukkan Id untuk dicari : ");
                byIdEd.Id = Convert.ToInt32(Console.ReadLine());
                byIdEd.GetIdEducation(byIdEd);
                break;

            case 4:
                Console.WriteLine("---------------------------------------");
                var updateEdu = new Education();
                Console.Write("\nMasukkan ID  : ");
                updateEdu.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Major : ");
                updateEdu.Major = Console.ReadLine();
                Console.Write("Degree : ");
                updateEdu.Degree = Console.ReadLine();
                Console.Write("GPA =  ");
                updateEdu.Gpa = Console.ReadLine();
                Console.Write("Universty Id : ");
                updateEdu.University_Id = Convert.ToInt32(Console.ReadLine());

                educationController.Update(updateEdu);
                break;

            case 5:
                Console.WriteLine("---------------------------------------");
                var deleteEdu = new Education();
                Console.Write("Masukkan ID : ");
                int idEdu = Convert.ToInt32(Console.ReadLine());
                deleteEdu.Id = idEdu;
                educationController.Delete(deleteEdu);
                break;

            default:
                Console.WriteLine("Salah Input Number");
                break;
        }
    }

    
    public static void InsertAll()
    {
        var employee = new Employee();
        var profiling = new Profiling();
        var education = new Education();
        var university = new University();

        Console.Write("NIK : ");
        var nik = Console.ReadLine();
        employee.Nik = nik;

        Console.Write("First Name : ");
        employee.First_Name = Console.ReadLine();

        Console.Write("Last Name : ");
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

        Console.Write("Major : ");
        education.Major = Console.ReadLine();

        Console.Write("Degree : ");
        education.Degree = Console.ReadLine();

        Console.Write("GPA : ");
        education.Gpa = Console.ReadLine();

        Console.Write("University Name : ");
        university.Name = Console.ReadLine();

        employeeController.Insert(employee);
        universityController.Insert(university);

        education.University_Id = university.GetUnivId();
        education.InsertEducation(education);
        educationController.Create(education);
        profiling.Employee_Id = employee.GetEmpId(nik);
        profiling.Employee_Id = employee.GetEmpId(nik);
        profiling.Education_Id = education.GetEduId();
        profilingController.Insert(profiling);
    }

    public static void Linq()
    {
        var education = new Education();
        var employee = new Employee();
        var profiling = new Profiling();
        var university = new University();

        var education1 = education.GetEducation();
        var employee1 = employee.GetEmployee();
        var profiling1 = profiling.GetProfiling();
        var university1 = university.GetUniversity();

        var getAll = from emp in employee1
                     join p in profiling1 on emp.Id equals p.Employee_Id
                     join ed in education1 on p.Education_Id equals ed.Id
                     join u in university1 on ed.University_Id equals u.Id
                     select new
                     {
                         NIK = emp.Nik,
                         Fullname = emp.First_Name + " " + emp.Last_Name,
                         emp.Birthdate,
                         emp.Gender,
                         emp.Hiring_Date,
                         emp.Email,
                         emp.Phone_Number,
                         ed.Major,
                         ed.Degree,
                         ed.Gpa,
                         Univesity = u.Name
                     };

        foreach (var item in getAll)
        {
            Console.WriteLine($"NIK\t\t= {item.NIK}");
            Console.WriteLine($"Fullname\t= {item.Fullname}");
            Console.WriteLine($"Birthdate\t= {item.Birthdate}");
            Console.WriteLine($"Gender\t\t= {item.Gender}");
            Console.WriteLine($"HiringDate\t= {item.Hiring_Date}");
            Console.WriteLine($"Email\t\t= {item.Email}");
            Console.WriteLine($"PhoneNumber\t= {item.Phone_Number}");
            Console.WriteLine($"Major\t\t= {item.Major}");
            Console.WriteLine($"Degree\t\t= {item.Degree}");
            Console.WriteLine($"GPA\t\t= {item.Gpa}");
            Console.WriteLine($"Univesity\t= {item.Univesity}"); ;
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}



    






