using BookingRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;
public class ProfilingView
{

    public void ReadProfiling(Profiling profiling)
    {
        Console.WriteLine("Employee ID: " + profiling.Employee_Id);
        Console.WriteLine("Education ID: " + profiling.Education_Id);
    }


    public void ReadProfiling(string message)
    {
        Console.WriteLine(message);
    }


}