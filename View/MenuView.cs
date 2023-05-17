using BookingRoom.Model;
using BookingRoom.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;

public class MenuView
{
    public void Menu()
    {
        Console.WriteLine("Rona Salsabila");
        Console.WriteLine("\n======================================");
        Console.WriteLine("\t        MENU     ");
        Console.WriteLine("======================================");
        Console.WriteLine("1. University (CRUD)");
        Console.WriteLine("2. Education (CRUD)");
        Console.WriteLine("3. Insert All");
        Console.WriteLine("4. Show Data Using LINQ ");
        Console.WriteLine("5. Read Employee's Data");
        Console.WriteLine("6. Read Profiling's Data");
        Console.WriteLine("7. Exit");

        Console.WriteLine("--------------------------------------");
    }
    public void Crud()
    {
        Console.Write("\nPILIHAN AKSI\n");
        Console.WriteLine("1. Create\n2. Read\n3. Read by Id\n4. Update\n5. Delete");
        Console.Write("Pilih: ");
    }
   
}







