class Reservation
{
    public int reservation_id {get; set;}
    public int customer_id {get; set;}
    public int employee_id {get; set;}
    public int room_id {get; set;}
    public int reservation_date {get; set;}
    public int date_in {get; set;}
    public int date_out {get; set;}
    public int date_range {get; set;}
    
    RoomManager roomManager = new();

    public Room BookRoom(int number)  //BookRoom should get list directly from DB and after booking it should update DB /j
    {
        Room bookingRoom = null;
        foreach (Room room in roomManager.ShowAvailableRoom())
        {
            if (room.room_id == number)
            {
                bookingRoom = room;
                return bookingRoom;
            }
        }
        return null;
    }

}