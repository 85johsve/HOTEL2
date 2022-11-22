using Dapper;
using MySqlConnector;
public class Room
{
    public int room_id { get; set; }
    public int roomType_id { get; set; }
    public string? roomType_name { get; set; }
    public int roomStatus_id { get; set; }
    public string? roomStatus_name { get; set; }
    public double room_price { get; set; }

    public override string ToString()
    {
        return $"Room: " + room_id + " " + roomType_name + " " + roomStatus_name + " " + room_price + "Kr";
    }
}