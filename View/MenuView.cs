using BookingRoom.Model;
using BookingRoom.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;

public class MenuView
{
    private static EducationController educationController = new();
    private static UniversityController universityController = new();
    private static ProfillingController profillingController = new();

    public static void Menu()
    {
        Console.WriteLine("Rona Salsabila");
        Console.WriteLine("======================================");
        Console.WriteLine("\t        MENU     ");
        Console.WriteLine("======================================");
        Console.WriteLine("1. UNIVERSITY");
        Console.WriteLine("2. EDUCATION");
        Console.WriteLine("3. INSERT MERGE");
        Console.WriteLine("4. SHOW ALL (LINQ) ");
        Console.WriteLine("5. SHOW EMPLOYEE");
        Console.WriteLine("6. SHOW PROFILING");
        Console.WriteLine("7. Exit");

        Console.WriteLine("--------------------------------------");
        Console.Write("Pilihan : ");
        string pilihan = Console.ReadLine();

        switch (pilihan)
        {
            case "1":
                Console.WriteLine("--------------------------------------");
                Console.Write("\nPILIHAN AKSI\n");
                Console.WriteLine("1. Create\n2. Read\n3. Read by Id\n4. Update\n5. Delete");
                Console.Write("Pilih: ");
                string aksi = Console.ReadLine();
                var university = new University();
                var univ = new UniversityController();
                switch (aksi)
                {
                    case "1":
                        univ.CreateUniversity();
                        break;
                    case "2":
                        univ.GetAll();
                        break;
                    case "3":
                        univ.GetIdUniversity();
                        break;
                    case "4":
                        univ.UpdateUniversity();
                        break;
                    case "5":
                        univ.DeleteUniversity();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                break;


            case "2":
                Console.WriteLine("--------------------------------------");
                Console.Write("\nPILIHAN AKSI\n");
                Console.WriteLine("1. Create \n2. Read \n3. Read by Id\n4. Update \n5. Delete");
                Console.Write("Pilih: ");
                string aksi2 = Console.ReadLine();

                var education = new Education();
                var edu = new EducationController();
                switch (aksi2)
                {
                    case "1":
                        edu.CreateEducation();
                        break;

                    case "2":
                        edu.GetAll();
                        break;

                    case "3":
                        edu.GetIdEducation();
                        break;

                    case "4":
                        edu.UpdateEducation();
                        
                        break;
                    case "5":
                        edu.DeleteEducation();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                break;

            case "3":
               /* var employee = new Employee();
                var emp = new EmployeeController();*/
                PrintOutEmployee();

                break;

            case "4":
                Linq();
                break;

            case "5":
                var profil = new ProfilingView();
                var profiling = new Profiling();
                profil.ReadProfiling(profiling);
                break;

            case "6":
                return;
                break;

            default:
                Console.Write("Invalid Input!!!");
                break;
        }
    }

    public static void Linq()
    {

        var dataEmployee = new Employee();
        var dataProfiling = new Profiling();
        var dataEducation = new Education();
        var dataUniversity = new University();
        var employee1 = dataEmployee.GetEmployee();
        var profiling1 = dataProfiling.GetProfiling();
        var education1 = dataEducation.GetEducation();
        var university1 = dataUniversity.GetUniversity();

        var all = from emp in employee1
                  join p in profiling1 on emp.Id equals p.Employee_Id
                  join ed in education1 on p.Education_Id equals ed.Id
                  join u in university1 on ed.University_Id equals u.Id
                  select new
                  {
                      NIK = emp.Nik,
                      Fullname = emp.First_Name + " " + emp.Last_Name,
                      emp.Birthdate,
                      emp.Gender,
                      HiringDate = emp.Hiring_Date,
                      emp.Email,
                      PhoneNumber = emp.Phone_Number,
                      ed.Major,
                      ed.Degree,
                      GPA = ed.Gpa,
                      Univesity = u.Name
                  };

        foreach (var item in all)
        {
            Console.WriteLine($"NIK\t\t= {item.NIK}");
            Console.WriteLine($"Fullname\t= {item.Fullname}");
            Console.WriteLine($"Birthdate\t= {item.Birthdate}");
            Console.WriteLine($"Gender\t\t= {item.Gender}");
            Console.WriteLine($"HiringDate\t= {item.HiringDate}");
            Console.WriteLine($"Email\t\t= {item.Email}");
            Console.WriteLine($"PhoneNumber\t= {item.PhoneNumber}");
            Console.WriteLine($"Major\t\t= {item.Major}");
            Console.WriteLine($"Degree\t\t= {item.Degree}");
            Console.WriteLine($"GPA\t\t= {item.GPA}");
            Console.WriteLine($"Univesity\t= {item.Univesity}");
            Console.WriteLine("-------------------------------------------");

        }
    }
        public static void PrintOutEmployee()
        {
            var employee1 = new Employee();
            var profiling1 = new Profiling();
            var education1 = new Education();
            var university1 = new University();

            Console.Write("NIK : ");
            var niks = Console.ReadLine();
            employee1.Nik = niks;
            Console.Write("First Name : ");
            employee1.First_Name = Console.ReadLine();
            Console.Write("Lame Name : ");
            employee1.Last_Name = Console.ReadLine();
            Console.Write("Birthdate : ");
            employee1.Birthdate = DateTime.Parse(Console.ReadLine());
            Console.Write("Gender : ");
            employee1.Gender = Console.ReadLine();
            Console.Write("Hiring Date : ");
            employee1.Hiring_Date = DateTime.Parse(Console.ReadLine());
            Console.Write("Email : ");
            employee1.Email = Console.ReadLine();
            Console.Write("Phone Number : ");
            employee1.Phone_Number = Console.ReadLine();
            Console.Write("Department ID : ");
            employee1.Department_Id = Console.ReadLine();

            //InsertDataEmployee(employeeConnection);

            //EDUCATION
            Console.Write("Major : ");
            education1.Major = Console.ReadLine();
            Console.Write("Degree : ");
            education1.Degree = Console.ReadLine();
            Console.Write("GPA : ");
            education1.Gpa = Console.ReadLine();
            Console.Write("University Name : ");
            university1.Name = Console.ReadLine();

       //employee1.InsertDataEmployee(employee1);
        //universityController.CreateUniversity();

        education1.University_Id = university1.GetUnivId();
        //education1.InsertEducation(education1);
        //educationController.CreateEducation();

        profiling1.Employee_Id = employee1.GetEmpId(niks);

        profiling1.Education_Id = education1.GetEduId();
        //profillingController.Insert(profiling1);


    }
}





