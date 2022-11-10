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

     public int AddRoom(int roomID,int typeID, int statusID, double price)   

    {
          
          int InsertRoomID= newRoomData.InsertRoom (roomID,typeID, statusID, price);     
     
     return InsertRoomID;     // print out the room?
    }


    // public List<Room> AddRooms(int id1, int typeID1, int statusID1,double price1)   //needs to update DB directly /j
    // {
    //     List<Room> AddRooms=new();
    //     bool input = true;
    //     while (input)
    //     {
        
    //          rooms.Add(newRoomData.InsertRoom ('int id1','int typeID1','statusID','price'));
    //     }

    //    return AddRooms;
    // }

  

    public void RemoveRoom(int idNumber)    
    {
        newRoomData.DeleteRoom( idNumber);
    }
}