using BookingRoom;
using BookingRoom.Controller;
using BookingRoom.Model;
using BookingRoom.View;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Channels;
using System.Transactions;
using BookingRoom.Context;

namespace BookingRoom;
public class Program
{

    public static void Main()
    {
        using var connection = MyConnection.Get();
        MenuView.Menu();

    }
}

    






