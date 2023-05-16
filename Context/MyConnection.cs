using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookingRoom.Context;

public class MyConnection
{
    private static readonly string connectionString =
    "Data Source=DESKTOP-TQVRSD8;Database = db_booking_room;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

    public static SqlConnection Get()
    {
        var connection = new SqlConnection(connectionString);
        /*try
        {
            connection.Open();
            Console.WriteLine("Connection Open!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in connection" + e.Message);
        }
        finally
        {
            connection.Close();
        }*/


        return new SqlConnection(connectionString);
    }
}