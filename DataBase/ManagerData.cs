using Dapper;
using MySqlConnector;
using System.Data;

class ManagerData 
{
    
    MySqlConnection connection;
    ManagerData newManagerData = new();

    public ManagerData()
    {
        connection = new MySqlConnection(("Server=13.51.47.91;Database=hotelmg;Uid=root;Pwd=i-077e801baa9e32977;"));
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