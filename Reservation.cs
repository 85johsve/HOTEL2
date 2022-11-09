class Reservation
{
    RoomManager roomManager = new();

    public Room BookRoom(int number)
    {
        Room bookingRoom = null;
        foreach (Room room in roomManager.ShowAvailableRoom())
        {
            if (room.RoomID == number)
            {
                bookingRoom = room;
                return bookingRoom;
            }
        }
        return null;
    }

}