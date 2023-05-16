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
        private University university = new University();

        public void GetAll()
        {
            var results = university.GetUniversity();
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
        public void GetIdUniversity()
        {
            var university = new University();
            Console.Write("Masukkan Id untuk dicari : ");
            university.Id = Convert.ToInt32(Console.ReadLine());
            university.GetIdUniversity(university);
        }

            public void CreateUniversity()
        {
            var university = new University();
            Console.Write("Masukkan Nama : ");
            university.Name = Console.ReadLine();
            var results = university.InsertUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Insert success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }
        }

        public void UpdateUniversity()
        {
            var university = new University();
            Console.Write("Masukkan Id : ");
            university.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Baru: ");
            university.Name = Console.ReadLine();
            var results = university.UpdateUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Update success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
        }

        public void DeleteUniversity()
        {
            var university = new University();
            Console.Write("Masukkan Id untuk dihapus : ");
            university.Id = Convert.ToInt32(Console.ReadLine());
            var results = university.DeleteUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }
        
        }
    }


