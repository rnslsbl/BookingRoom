using BookingRoom.Model;
using BookingRoom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Controller; 
    public class EducationController
    {
    private Education _education = new Education();

    public void GetAll()
    {
        var results = _education.GetEducation();
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

    public void Update(Education education)
    {
        
        var results = _education.UpdateEducation(education);
        var view = new EducationView();
        if (results > 0)
        {
            Console.WriteLine("Update success");
        }
        else
        {
            Console.WriteLine("Update Failed");
        }

    }
    public void Delete(Education education)
    {
        var results = _education.DeleteEducation(education);
        var view = new EducationView();
        if (results > 0)
        {
            Console.WriteLine("Delete success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
        }

    }

    public void Create(Education education)
    {

        var results = _education.InsertEducation(education);
        var view = new EducationView();
        if (results > 0)
        {
            Console.WriteLine("Insert success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
        }
    }
        public void GetIdEducation()
        {
            var education = new Education();
            Console.Write("Masukkan Id untuk dicari : ");
            education.Id = Convert.ToInt32(Console.ReadLine());
            education.GetIdEducation(education);

        }
    }


