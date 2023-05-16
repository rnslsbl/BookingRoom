using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Model;

namespace BookingRoom.View;
    public class EducationView
    {
    public void ReadEducation(Education education)
    {
        Console.WriteLine("Id: " + education.Id);
        Console.WriteLine("Major: " + education.Major);
        Console.WriteLine("Degree: " + education.Degree);
        Console.WriteLine("Gpa: " + education.Gpa);
        Console.WriteLine("ID University : " + education.University_Id);
    }

    public void ReadEducation(List<Education> educations)
    {
        foreach (var education in educations)
        {
            ReadEducation(education);
        }
    }

    public void ReadEducation(string message)
    {
        Console.WriteLine(message);
    }





   

       

}


