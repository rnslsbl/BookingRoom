using BookingRoom.Model;
using BookingRoom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Controller
{
    public class UniversityController
    {
        private University _university = new University();

        public void GetAll()
        {
            var results = _university.GetUniversity();
            var view = new UniversityView();
            if (results.Count == 0)
            {
                view.ReadUniversity("Data Tidak Ditemukan");
            }
            else
            {
                view.ReadUniversity(results);
            }
        }


        public void Insert(University university)
        {
            var results = _university.InsertUniversity(university);
            var view = new UniversityView();

            if (results > 0)
            {
                Console.WriteLine("Insert success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }
        }

        public void Update(University university)
        {

            var results = _university.UpdateUniversity(university);
            var view = new UniversityView();
            if (results > 0)
            {
                Console.WriteLine("Update success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
        }

        public void Delete(University university)
        {
            var results = _university.DeleteUniversity(university);
            var view = new UniversityView();
            if (results > 0)
            {
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }
        public void Create(University university)
        {
            var result = _university.InsertUniversity(university);
            var view = new UniversityView();
            if (result == 0)
            {
                view.ReadUniversity("Insert University Failed");
            }
            else
            {
                view.ReadUniversity("Insert University Success");
            }
        }
    }
}
  


