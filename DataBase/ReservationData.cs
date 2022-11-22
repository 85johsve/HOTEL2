using Dapper;
using MySqlConnector;
using System.Data;

public class ReservationData
{

    MySqlConnection connection;

    public ReservationData()
    {
        connection = new MySqlConnection(("Server=13.51.47.91;Database=hotelmg;Uid=root;Pwd=i-077e801baa9e32977;"));
    }
    public void Open()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        catch (Exception e)
        {

            throw new FieldAccessException();
        }
    }
    public List<Reservation> GetReservationData()
    {
        var getResData = connection.Query<Reservation>(@"SELECT rooms.room_id, rooms.roomType_id, rooms.roomStatus_id, rooms.room_price, reservations.reservation_id, reservations.date_in, reservations.date_out, reservations.customer_id, reservations.employee_id, reservations.reservation_date
        FROM `rooms`
        LEFT JOIN reservations ON rooms.room_id = reservations.room_id").ToList();
        return getResData;
    }
    public List<Reservation> GetReservationList()
    {
        var getRes = connection.Query<Reservation>("SELECT * FROM `reservations`;").ToList();
        return getRes;
    }


    public int MakeReservation(int customer_id, int employeeIdBooking, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out, double date_range, double totalPay)
    {
        
        // var makeReservation = connection.Query<Reservation>($"INSERT INTO `reservations`(`customer_id`, `employee_id`, `room_id`, `reservation_date`, `date_in`, `date_out`, date_range, reservation_totalpay) VALUES ('{customer_id}',  '{employeeIdBooking}', '{room_id}', '{reservation_date}','{date_in}','{date_out}', {date_range}, {totalPay}) SELECT LAST_INSERT_ID() ");
        string sql = $"INSERT INTO `reservations`(`customer_id`, `employee_id`, `room_id`, `reservation_date`, `date_in`, `date_out`, date_range, reservation_totalpay) VALUES ('{customer_id}',  '{employeeIdBooking}', '{room_id}', '{reservation_date}','{date_in}','{date_out}', {date_range}, {totalPay}); SELECT LAST_INSERT_ID() ";
        int id = connection.QuerySingle<int>(sql);
        return id;
    }


    // public void MakeReservationEmployee(int customer_id, int employee_id, int room_id, DateTime reservation_date, DateTime date_in, DateTime date_out, double date_range)
    // {
    //     var makeReservation = connection.Query<Reservation>($"INSERT INTO `reservations`( `customer_id`, `employee_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id},{employee_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}', {date_range})");

    // }



    public void UpdateReservationDate(int reservation_id, DateTime date_in, DateTime date_out,double date_range, double newTotalPay)
    {
        var updateReservation = connection.Query<Reservation>($"UPDATE `reservations` SET `date_in`='{date_in}',`date_out`='{date_out}', `date_range`={date_range}, `reservation_totalpay`={newTotalPay} WHERE reservations.reservation_id = {reservation_id};");
    }

    public void UpdateReservationRoom(int reservation_id, int room_id)
    {
        var updateReservation = connection.Query<Reservation>($"UPDATE `reservations` SET room_id= {room_id} WHERE reservations.reservation_id ={reservation_id};");
    }


    // public void UpdateReservationDateOut(int reservation_id, DateTime date_out, double date_range)
    // {
    //     var updateReservation = connection.Query<Reservation>($"UPDATE `reservations` SET `date_out`='{date_out}', `date_range`={date_range} WHERE reservations.reservation_id = {reservation_id};");
    // }


    public Reservation GetSingleReservationById(int reservation_id)
    {
        var getSingleResrvation = connection.QuerySingle<Reservation>($@"SELECT reservation_id, customer_fname,customer_lname,employee_id,rooms.room_id,roomType_name,room_price, reservation_date, date_in, date_out,date_range,reservation_totalpay FROM(((reservations INNER JOIN customers ON customers.customer_id = reservations.customer_id)INNER JOIN rooms ON rooms.room_id = reservations.room_id)INNER JOIN roomtype ON roomtype.roomType_id=rooms.roomType_id)WHERE reservations.reservation_id = {reservation_id};");
        return getSingleResrvation;
    }

    public List<Reservation> GetTimeSpanData(int reservation_id)
    {
        var getTimeSpan = connection.Query<Reservation>($"SELECT * FROM `reservations`WHERE reservations.reservation_id = {reservation_id};").ToList();
        return getTimeSpan;
    }

    public double GetRoomPrice(int reservation_id) // this is is working now Tina
    {
        var result = connection.QuerySingle<Reservation> ($"SELECT room_price FROM  reservations INNER JOIN rooms ON reservations.room_id = rooms.room_id WHERE reservations.reservation_id = {reservation_id};");
        return result.room_price;
    }

    // public double ReadRoomPrice(int reservation_id)  // this is something we could try but still figuring out how to use it 
    // {

    //     string mySelectQuery = $"SELECT room_price FROM  reservations INNER JOIN rooms ON reservations.room_id = rooms.room_id WHERE reservations.reservation_id = {reservation_id};";
    //     // (MySqlConnection myConnection = new MySqlConnection(myConnString);)
    //     MySqlCommand myCommand = new MySqlCommand(mySelectQuery, connection);
    //     Open();
    //     MySqlDataReader myReader = myCommand.ExecuteReader();
    //     // (Always call Read before accessing data.)
    //     Reservation reservation = new();
    //     // reservation.room_price = Convert.ToDouble(myReader["Room Price"]);
    //     // while (myReader.Read())
    //     // {
    //     //     Console.WriteLine(myReader.GetInt32(0) + ", " + myReader.GetString(3));//here we need to change according to out need
    //     // }
    //     // MySqlCommand cmd = new MySqlCommand("SELECT room_price FROM  reservations INNER JOIN rooms ON reservations.room_id = rooms.room_id WHERE reservations.reservation_id = {reservation_id}", connection);
    //     MySqlDataReader reader = myCommand.ExecuteReader();

    //     if (reader.HasRows)
    //     {
    //         while (reader.Read())
    //         {
               
    //           reservation.room_price = double.Parse(reader.GetString("Price"));
    //         }
    //     }
    //     //return reservation_id;
    //     // (always call Close when done reading.)
    //     myReader.Close();
    //     // (Close the connection when done with it.)
    //     connection.Close();
    //     return reservation.room_price;
    
    // }






    //SELECT date_in,date_out FROM `reservations` WHERE reservation_id = 1;
    //     public List<Reservation> ReturnReservationVerification()
    // {
    //     var makeReservation = connection.Query<Reservation> ($"INSERT INTO `reservations`( `customer_id`, `room_id`, `reservation_date`, `date_in`, `date_out`) VALUES ({customer_id}, {room_id}, '{reservation_date}','{date_in}','{date_out}')");

    // }



}