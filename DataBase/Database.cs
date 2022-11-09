using Dapper;
using MySqlConnector;
class Database:IDataBase
{
      MySqlConnection connection;



    public Database()
    {
        connection = new MySqlConnection(("Server=localhost;Database=videoteket;Uid=Tina;Pwd=123456;"));
        
    }

     public List<Room> GetRoomList()
  {
    var rooms = connection.Query<Room>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.rommStatus_id=roomstatus.roomStatus_id) ;").ToList();
    return rooms;
    
  }   

   public List<Customer> GetCustomerList()
  {
    var customers=connection.Query<Customer>("SELECT customer_id,customer_fname,customer_lname,customer_phone,customer_email,customer_city,customer_country,customer_address FROM customers;").ToList();
    return customers;
  } 

    



    
}