using BookingRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;
    public class EmployeeView
    {
    private static Employee _employee = new Employee();
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

    
    
}


