using BookingRoom.Context;
using BookingRoom.Model;
using BookingRoom.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;

    public class UniversityView
    {
        public void ReadUniversity(University university)
        {
            Console.WriteLine("Id: " + university.Id);
                Console.WriteLine("Name: " + university.Name);
        }

    public void ReadUniversity(List<University> universities)
    {
        foreach (var university in universities)
        {
            ReadUniversity(university);
        }
    }

    public void ReadUniversity(string message)
    {
        Console.WriteLine(message);
    }



}



    

