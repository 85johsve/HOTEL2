using Dapper;
using MySqlConnector;
class RoomData
{
    Database roomdb = new Database();
    MySqlConnection connection;
    // string roomToUpdate;
    // string newRoomStatus;


    public RoomData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }

    public List<Room> GetRoomList()
    {
        var rooms = connection.Query<Room>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
        return rooms;

    }

    public void UpdateRoomStatus(string roomToUpdate, string newRoomStatus)
    {
        var updateRoom = connection.Query<Room>($"UPDATE rooms SET roomStatus_id={newRoomStatus} WHERE room_id = {roomToUpdate};");

    }

    public int InsertRoom(int typeID, int statusID, double price)
    {
        //int id, 
        var r = new DynamicParameters();
        r.Add("@roomType_id", typeID);
        r.Add("@roomStatus_id", statusID);
        r.Add("@room_price", price);
        string sql = $@"INSERT INTO rooms (roomType_id, roomStatus_id, room_price) VALUES (@roomType_id,@roomStatus_id,@room_price); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();

        return Id;



    }

    public void DeleteRoom(int number)
    {

        var DeleteRoom = connection.Query<Room>($"DELETE FROM `rooms` WHERE room_id = {number}");
    }


}