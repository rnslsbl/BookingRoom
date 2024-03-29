﻿using BookingRoom.Model;
using BookingRoom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Controller
{
    public class ProfillingController
    {
        private Profiling _profiling = new Profiling();
        public void GetAll()
        {
            var results = _profiling.GetProfiling();
            var view = new ProfilingView();
            
            if (results.Count == 0)
            {
                view.ReadProfiling("Data Tidak Ditemukan");
            }
            else
            {
                view.ReadProfiling(results);
            }
        }
        public void Insert(Profiling profilings)
        {
            var result = _profiling.InsertProfiling(profilings);
            var view = new ProfilingView();
            if (result == 0)
            {
                view.ReadProfiling("Insert Profiling Failed");
            }
            else
            {
                view.ReadProfiling("Insert Profiling Success");
            }
        }
    }
}
