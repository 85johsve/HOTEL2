class Reservation
{
    RoomManager roomManager = new();

    public Room BookRoom(int number)  //BookRoom should get list directly from DB and after booking it should update DB /j
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