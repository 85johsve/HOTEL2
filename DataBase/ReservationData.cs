using Dapper;
using MySqlConnector;
using System.Data;

class ReservationData 
{
    
    MySqlConnection connection;

    public ReservationData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
      public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }
     public List<Reservation> GetReservationData()
    {
        var getResData = connection.Query<Reservation> (@"SELECT rooms.room_id, rooms.roomType_id, rooms.roomStatus_id, rooms.room_price, reservations.reservation_id, reservations.date_in, reservations.date_out, reservations.customer_id, reservations.employee_id, reservations.reservation_date
FROM `rooms`
LEFT JOIN reservations ON rooms.room_id = reservations.room_id").ToList();
        return getResData;
    }
    public void MakeReservationCustomer(int customer_id, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out)
    {
        var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    }

    public void MakeReservationEmployee(int customer_id, int employee_id, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out)
    {
        var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `employee_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id},{employee_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    }

    //     public List<Reservation> ReturnReservationVerification()
    // {
    //     var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    // }

  
    
}