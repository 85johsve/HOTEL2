using Dapper;
using MySqlConnector;
public class Room
{
    public int RoomID { get; set; }
    public int RoomTypeID { get; set; }
    public int RoomStatusID { get; set; }
    public double RoomPrice { get; set; }
    private List<Room> rooms;
    //should we put this list in only the room manager?

    public Room(int roomID, int roomTypeID, int roomStatusID, double roomPrice)
    {
        RoomID = roomID;
        RoomTypeID = roomTypeID;
        RoomStatusID = roomStatusID;
        RoomPrice = roomPrice;
    }

    // we need a overide StringToString(to pint out the room values)
}