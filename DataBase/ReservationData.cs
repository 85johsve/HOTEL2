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
         try
        {
           if(connection.State != ConnectionState.Open)
            connection.Open(); 
        }
        catch (Exception e)
        {
            
            throw new FieldAccessException();
        }
    }
     public List<Reservation> GetReservationData()
    {
        var getResData = connection.Query<Reservation> (@"SELECT rooms.room_id, rooms.roomType_id, rooms.roomStatus_id, rooms.room_price, reservations.reservation_id, reservations.date_in, reservations.date_out, reservations.customer_id, reservations.employee_id, reservations.reservation_date
FROM `rooms`
LEFT JOIN reservations ON rooms.room_id = reservations.room_id").ToList();
        return getResData;
    }
    public List<Reservation> GetReservationList()
    {
        var getRes = connection.Query<Reservation> ("SELECT * FROM `reservations`;").ToList();
        return getRes;
    }

    public List<Reservation> GetTimeSpanData(int reservation_id)
    {
        var getTimeSpan = connection.Query<Reservation> ($"SELECT * FROM `reservations`WHERE reservations.reservation_id = {reservation_id};").ToList();
        return getTimeSpan;
    }
    public void MakeReservationCustomer(int customer_id, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out)
    {
        var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    }

    public void MakeReservationEmployee(int customer_id, int employee_id, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out)
    {
        var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `employee_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id},{employee_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    }

    public void UpdateReservationDateIn(int reservation_id, DateTime date_in)
    {
        var updateReservation = connection.Query<Reservation> ($"UPDATE `reservations` SET `date_in`='{date_in}' WHERE reservations.reservation_id = {reservation_id};");
    }

    public void UpdateReservationDateOut(int reservation_id, DateTime date_out)
    {
        var updateReservation = connection.Query<Reservation> ($"UPDATE `reservations` SET `date_out`='{date_out}' WHERE reservations.reservation_id = {reservation_id};");
    }

    //     public List<Reservation> ReturnReservationVerification()
    // {
    //     var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");
        
    // }

  
    
}