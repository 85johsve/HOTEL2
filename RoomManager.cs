class RoomManager
{
     private List<Room> rooms ;


   

    public List<Room> ShowAvailableRoom()
    {
        List<Room> availableRooms =new();
      return availableRooms ;
    }

    public Room BookRoom(int number)
    {
        Room bookingRoom = null;
       foreach(Room room in ShowAvailableRoom())
       {
          if (room.RoomID == number )
          {
            bookingRoom=room;
            return bookingRoom;
          }
       }
       return null;
    }

     public void AddRoom()
    {

    }

    public void RemoveRoom()
    {

    }
}