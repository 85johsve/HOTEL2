class RoomManager
{
    private List<Room> rooms;

    public RoomManager()
    {
        // get list from database?
    }

    public List<Room> ShowAvailableRoom()
    {
        List<Room> availableRooms = new();
        foreach (Room room in rooms)
        {
            if (room.RoomStatusID ==2)// this Available need to be changed to Enum later
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }

    public Room BookRoom(int number)
    {
        Room bookingRoom = null;
        foreach (Room room in ShowAvailableRoom())
        {
            if (room.RoomID == number)
            {
                bookingRoom = room;
                return bookingRoom;
            }
        }
        return null;
    }

    public void AddRoom(Room newRoom)
    {
        rooms.Add(newRoom);
    }

    public void RemoveRoom(Room removeRoom)
    {
        rooms.Remove(removeRoom);
    }
}