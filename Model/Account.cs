using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Model;

public class Account
{
    public int Employee_Id { get; set; }
    public string Password { get; set; }
    public bool Is_Deleted { get; set; }
    public string Otp { get; set; }
    public bool Is_Used { get; set; }
    public DateTime Expired_Time { get; set; }
}

