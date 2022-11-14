using Dapper;
using MySqlConnector;
class PaymentData
{
     MySqlConnection connection;
   


    public PaymentData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }

    public List<Payment> GetPaymentList()
    {
        var payments = connection.Query<Payment>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
        return payments;

    }

    public int InsertPayment(int typeID, int statusID, double price)
    {
        //int id, 
        var r = new DynamicParameters();
        r.Add("@roomType_id", typeID);
        r.Add("@roomStatus_id", statusID);
        r.Add("@room_price", price);
        string sql = $@"INSERT INTO rooms (roomType_id, roomStatus_id, room_price) VALUES (@roomType_id,@roomStatus_id,@room_price); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();

        return Id;



    }

    public void DeletePayment(int number)
    {
      
       var deletePayment = connection.Query<Payment>($"DELETE FROM `rooms` WHERE number=@room_id");
        
    }

     public Payment GetPayment(int idNr)
    {
      
       var payment = connection.QuerySingle<Payment>($"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) WHERE room_id = {idNr};");
 
    return payment;
        
    }
}