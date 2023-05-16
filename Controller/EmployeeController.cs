using BookingRoom.Model;
using BookingRoom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Controller;
    public class EmployeeController
    {
        private static Employee _employee = new Employee();

        public void GetAll()
        {
            var results = _employee.GetEmployee();
            var view = new EmployeeView();
            
            if (results.Count == 0)
            {
                view.ReadEmployee("Data Tidak Ditemukan");
            }
            else
            {
                view.ReadEmployee(results);
            }
        }

        public void Insert(Employee employees)
        {
            var result = _employee.InsertDataEmployee(employees);
            var view = new EmployeeView();
            if (result == 0)
            {
                view.ReadEmployee("Insert Employee Failed");
            }
            else
            {
                view.ReadEmployee("Insert Employee Success");
            }
        }
    }


