using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Model;

public class Booking
{
    public int Id { get; set; }
    public DateTime Start_Date { get; set; }
    public DateTime End_Date { get; set; }
    public string Remarks { get; set; }
    public int Room_Id { get; set; }
    public int Employee_Id { get; set; }
}

