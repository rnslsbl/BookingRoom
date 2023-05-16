using BookingRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;
    public class EmployeeView
    {
    public void ReadEmployee(Employee employee)
    {      
            Console.WriteLine("Id: " + employee.Id);
            Console.WriteLine("Nik: " + employee.Nik);
            Console.WriteLine("First Name: " + employee.First_Name);
            Console.WriteLine("Last Name: " + employee.Last_Name);
            Console.WriteLine("Birthdate : " + employee.Birthdate);
            Console.WriteLine("Gender: " + employee.Gender);
            Console.WriteLine("Hiring Date : " + employee.Hiring_Date);
            Console.WriteLine("Email: " + employee.Email);
            Console.WriteLine("Phone Number: " + employee.Phone_Number);
            Console.WriteLine("Department Id: " + employee.Department_Id);
            Console.WriteLine("\n");
        }

    public void ReadEmployee(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            ReadEmployee(employee);
        }
    }

    public void ReadEmployee(string message)
    {
        Console.WriteLine(message);
    }

    public void CreateEmployee()
    {
        var employees = new Employee();
        Console.Write("Masukkan NIK : ");
        employees.Nik = Console.ReadLine();
        Console.Write("Masukkan First Name : ");
        employees.First_Name = Console.ReadLine();
        Console.Write("Masukkan Last Name : ");
        employees.Last_Name = Console.ReadLine();
        Console.Write("Masukkan Birthdate : ");
        employees.Birthdate = DateTime.Parse(Console.ReadLine());
        Console.Write("Masukkan Gender : ");
        employees.Gender = Console.ReadLine();
        Console.Write("Masukkan Hiring Date : ");
        employees.Hiring_Date = DateTime.Parse(Console.ReadLine());
        Console.Write("Masukkan Email : ");
        employees.Email = Console.ReadLine();
        Console.Write("Masukkan Phone Number : ");
        employees.Phone_Number = Console.ReadLine();
        Console.Write("Masukkan Department Id : ");
        employees.Department_Id = Console.ReadLine();
        employees.InsertDataEmployee(employees);

    }
}


