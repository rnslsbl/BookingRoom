using BookingRoom.Model;
using BookingRoom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Controller; 
    public class EducationController
    {
    private Education education = new Education();

    public void GetAll()
    {
        var results = education.GetEducation();
        var view = new EducationView();
        if (results.Count == 0)
        {
            view.ReadEducation("Data Tidak Ditemukan");
        }
        else
        {
            view.ReadEducation(results);
        }
    }

    public void UpdateEducation()
    {
        var education = new Education();
        Console.Write("Masukkan Id : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan Major Baru : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree Baru : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa Baru : ");
        education.Gpa = Console.ReadLine();
        Console.Write("Masukkan ID University : ");
        education.University_Id = Convert.ToInt32(Console.ReadLine());
        var results = education.UpdateEducation(education);
        if (results > 0)
        {
            Console.WriteLine("Update success");
        }
        else
        {
            Console.WriteLine("Update Failed");
        }

    }
    public void DeleteEducation()
    {
        var education = new Education();
        Console.Write("Masukkan ID yang ingin dihapus : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
        var results = education.DeleteEducation(education);
        if (results > 0)
        {
            Console.WriteLine("Delete success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
        }

    }
    public void GetIdEducation()
    {
        var education = new Education();
        Console.Write("Masukkan Id untuk dicari : ");
        education.Id = Convert.ToInt32(Console.ReadLine());
        education.GetIdEducation(education);

    }
    public void CreateEducation()
    {
        var education = new Education();
        Console.Write("Masukkan Major : ");
        education.Major = Console.ReadLine();
        Console.Write("Masukkan Degree : ");
        education.Degree = Console.ReadLine();
        Console.Write("Masukkan Gpa : ");
        education.Gpa = Console.ReadLine();
        Console.WriteLine("Masukkan ID University : ");
        education.University_Id = Convert.ToInt32(Console.ReadLine());
        //education.InsertEducation(education);
        var results = education.InsertEducation(education); 
        if (results > 0)
        {
            Console.WriteLine("Insert success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
        }


    }
}

