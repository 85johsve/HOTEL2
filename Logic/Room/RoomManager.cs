using Dapper;
using MySqlConnector;

// dotnet add package dapper
// dotnet add package mysqlconnector
class RoomManager
{
    private List<Room> rooms;
     RoomData newRoomData= new();

    
    public List<Room> ShowAllRooms()
    {

        return  newRoomData.GetRoomList();
    }

    public List<Room> ShowAvailableRoom()
    {
        List<Room> availableRooms = new();
        foreach (Room room in newRoomData.GetRoomList())
        {
            if (room.roomStatus_name == "CheckOut")
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }
    public void UpdateRoomStatusID(string roomToUpdate, string newRoomStatus)
    {
        newRoomData.UpdateRoomStatus(roomToUpdate, newRoomStatus);
    }

     public int AddRoom(int typeID, int statusID, double price)   

    { 
          
          int InsertRoomID= newRoomData.InsertRoom (typeID, statusID, price);     
     
     return InsertRoomID;     
    }

    public void RemoveRoom(int idNumber)    
    {
        newRoomData.DeleteRoom( idNumber);
    }
}