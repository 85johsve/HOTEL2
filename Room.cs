using Dapper;
using MySqlConnector;
public class Room
{
    public int RoomID { get; set; }
    public int RoomTypeID { get; set; }
    public int RoomStatusID { get; set; }
    public double RoomPrice { get; set; }

    public Room()
    {
        
    }
}