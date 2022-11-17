using Dapper;
using MySqlConnector;
using System.Data;
class DataConnection
{
     MySqlConnection connection;
   
    public  DataConnection()
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
}