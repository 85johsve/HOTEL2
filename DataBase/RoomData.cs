using Dapper;
using MySqlConnector;
using System.Data;
class RoomData
{


    MySqlConnection connection;

    public RoomData()
    {
        connection = new MySqlConnection(("Server=13.51.47.91;Database=hotelmg;Uid=root;Pwd=i-077e801baa9e32977;"));
    }

    public void Open()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        catch (Exception e)
        {
            throw new FieldAccessException();
        }
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

    public void CheckInRoomStatus(string roomToCheckIn, string newRoomCheckInStatus)
    {
        var updateRoom = connection.Query<Room>($"UPDATE rooms SET roomStatus_id=1 WHERE room_id = {roomToCheckIn};");
    }

    public void CheckOutRoomStatus(string roomToCheckOut, string newRoomCheckOutStatus)
    {
        var updateRoom = connection.Query<Room>($"UPDATE rooms SET roomStatus_id=2 WHERE room_id = {roomToCheckOut};");
    }

    public int InsertRoom(int typeID, int statusID, double price)
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@roomType_id", typeID);
        r.Add("@roomStatus_id", statusID);
        r.Add("@room_price", price);
        string sql = $@"INSERT INTO rooms (roomType_id, roomStatus_id, room_price) VALUES (@roomType_id,@roomStatus_id,@room_price); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }

    public void DeleteRoomById(int number)
    {
        Open();
        var deleteRoom = connection.Query<Room>($"DELETE FROM rooms WHERE room_id = {number};");
    }

    public Room GetRoomById(int idNr)
    {
        Open();
        var room = connection.QuerySingle<Room>($"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) WHERE room_id = {idNr};");
        return room;
    }


}