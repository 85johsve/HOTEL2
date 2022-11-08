using Dapper;
using MySqlConnector;
public class Room
{
    public int RoomID { get; set; }
    public int RoomTypeID { get; set; }
    public int RoomStatusID { get; set; }
    public double RoomPrice { get; set; }
    // need a Enum RoomStatus= CheckIn, CheckOut seem as table ? 

    public Room(int roomID, int roomTypeID, int roomStatusID, double roomPrice)
    {
        RoomID = roomID;
        RoomTypeID = roomTypeID;
        RoomStatusID = roomStatusID;
        RoomPrice = roomPrice;
    }

    public override string ToString()
    {
        return "Room: " + RoomID + " " + RoomTypeID + " " + RoomStatusID + " " + RoomPrice;
    }
}