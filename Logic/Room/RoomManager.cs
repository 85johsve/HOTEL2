using Dapper;
using MySqlConnector;

// dotnet add package dapper
// dotnet add package mysqlconnector
class RoomManager
{
    private List<Room> rooms;
     RoomData newRoomData= new();

    public RoomManager()
    {
        // get list from database?
    }
    
    public List<Room> ShowAllRooms()
    {

        return newRoomData.GetRoomList();
    }

    public List<Room> ShowAvailableRoom()
    {
        List<Room> availableRooms = new();
        foreach (Room room in newRoomData.GetRoomList())
        {
            if (room.roomStatus_name == "CheckOut")// this Available need to be changed to Enum later
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }


     public Room AddRoom(int id, int typeID, int statusID, double price)   //needs to update DB 

    {
          Room insertRoom = new ();
        
            newRoomData.InsertRoom (id, typeID, statusID, price);
           

        return insertRoom;
    }
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



//     public void RemoveRoom(int number)     //needs to update DB directly /j
//     {
//         rooms.Remove(newRoomData.DeleteRoom(int number));
//     }
// }