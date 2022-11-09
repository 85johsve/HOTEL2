using Dapper;
using MySqlConnector;

// dotnet add package dapper
// dotnet add package mysqlconnector
class RoomManager
{
    private List<Room> rooms;
     Database newDatabase = new Database();
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

    public List<Room> AddRoom(int id1, int typeID1, int statusID1,double price1)   //needs to update DB directly /j
    {
       List<Room> addRooms = new();
        bool input = true;
        while (input)
        {
        
             addRooms.Add(newRoomData.InsertRoom(int id1, int typeID1, int s));
        }

       return addRooms;
    }



    public void RemoveRoom(Room removeRoom)     //needs to update DB directly /j
    {
        rooms.Remove(removeRoom);
    }
}