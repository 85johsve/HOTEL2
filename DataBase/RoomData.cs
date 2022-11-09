using Dapper;
using MySqlConnector;
class RoomData:Database
{
    Database roomdb = new Database();
    MySqlConnection connection;
    

     public RoomData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
        
    }

     public List<Room> GetRoomList()
  {
    var rooms = connection.Query<Room>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
    return rooms;
    
  }   

  public void InsertRoom(int id, int typeID, int statusID, double price)
  {
    
  var InsertRoom = connection.Query<Room> ("INSERT INTO `rooms`(`room_id`, `roomType_id`, `roomStatus_id`, `room_price`) VALUES ('id','typeID','statusID','price')");
  
  }
}