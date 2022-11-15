using Dapper;
using MySqlConnector;

// dotnet add package dapper
// dotnet add package mysqlconnector
class RoomManager
{
    private List<Room> rooms;
    RoomData newRoomData = new();


    public List<Room> ShowAllRooms()
    {
        return newRoomData.GetRoomList();
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

    public Room SearchRoom(int sRoomId)
    {
        if (newRoomData.GetRoom(sRoomId) != null)
        {
            return newRoomData.GetRoom(sRoomId);
        }
        return null;
    }

    public void UpdateRoomStatusID(string roomToUpdate, string newRoomStatus)
    {
        newRoomData.UpdateRoomStatus(roomToUpdate, newRoomStatus);
    }
    public void CheckInRoomStatusID(string roomToCheckIn, string newCheckInRoomStatus)
    {
        newRoomData.UpdateRoomStatus(roomToCheckIn, newCheckInRoomStatus);
    }

    public int AddRoom(int typeID, int statusID, double price)
    {
        int InsertRoomID = newRoomData.InsertRoom(typeID, statusID, price);

        return InsertRoomID;
    }

    public void RemoveRoom(int rRoomId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newRoomData.DeleteRoom(rRoomId);
    }
}