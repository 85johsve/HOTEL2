using Dapper;
using MySqlConnector;
public class Room
{
    public int room_id { get; set; }
    public int roomType_id { get; set; }
    public string ?roomType_name { get; set; }
    public int roomStatus_id { get; set; }
    public string? roomStatus_name { get; set; }
    public double room_price { get; set; }
    // need a Enum RoomStatus= CheckIn, CheckOut seem as table ? 
    enum RoomStatus
    {
        CheckedIn=1,
        CheckOut,
        Reserved,
        NotInUse,   //named "Not in Use" in DB

    }

    // public Room(int roomID, string roomType_name, string roomStatus_name, double roomPrice)
    // {
    //     RoomID = roomID;
    //     RoomType_name = roomType_name;
    //     RoomStatus_name = roomStatus_name;
    //     RoomPrice = roomPrice;
    // }

    public override string ToString()
    {
        return "Room: " + room_id + " " + roomType_name + " " + roomStatus_name + " " + room_price;
    }
}