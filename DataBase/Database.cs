using Dapper;
using MySqlConnector;
class Database
{
      MySqlConnection connection;



    public Database()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
        
    }

    

   public List<Customer> GetCustomerList()
  {
    var customers=connection.Query<Customer>("SELECT customer_id,customer_fname,customer_lname,customer_phone,customer_email,customer_city,customer_country,customer_address FROM customers;").ToList();
    return customers;
  } 

    



    
}