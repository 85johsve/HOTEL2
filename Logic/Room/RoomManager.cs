using Dapper;
using MySqlConnector;

public class RoomManager
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
            if (room.roomStatus_name == "CheckedOut")
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }

    public Room SearchRoomById(int sRoomId)
    {
        return newRoomData.GetRoomById(sRoomId);
    }

    public void UpdateRoomStatusID(int roomToUpdate, int newRoomStatus)
    {
        newRoomData.UpdateRoomStatus(roomToUpdate, newRoomStatus);
    }

    public void CheckInRoomStatusRenewByRoomId(int roomToCheckIn)
    {
        newRoomData.CheckInRoomStatus(roomToCheckIn);
    }

    public void CheckOutRoomStatusRenewByRoomId(int roomToCheckOut)
    {
        newRoomData.CheckOutRoomStatus(roomToCheckOut);
    }

    public int AddRoom(int typeID, int statusID, double price)
    {
        int InsertRoomID = newRoomData.InsertRoom(typeID, statusID, price);
        return InsertRoomID;
    }

    public void RemoveRoomById(int rRoomId) 
    {
        newRoomData.DeleteRoomById(rRoomId);
    }
}