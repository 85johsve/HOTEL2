using Dapper;
using MySqlConnector;
using System.Data;
class RoomData
{
    
    MySqlConnection connection;
    // string roomToUpdate;
    // string newRoomStatus;


    public RoomData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }

     public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }

    public List<Room> GetRoomList()
    {
         Open();
        var rooms = connection.Query<Room>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
        return rooms;

    }

    public void UpdateRoomStatus(string roomToUpdate, string newRoomStatus)
    {
         Open();
        var updateRoom = connection.Query<Room>($"UPDATE rooms SET roomStatus_id={newRoomStatus} WHERE room_id = {roomToUpdate};");

    }

    public int InsertRoom(int typeID, int statusID, double price)
    {
         Open();//int id, 
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
        Open();
        var deleteRoom = connection.Query<Room>($"DELETE FROM rooms WHERE room_id = {number};");

    }

     public Room GetRoom(int idNr)
    {
        Open();
       var room = connection.QuerySingle<Room>($"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) WHERE room_id = {idNr};");
 
    return room;
        
    }


}