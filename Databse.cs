using Dapper;
using MySqlConnector;
class Databse
{
      MySqlConnection connection;



    public Database()
    {
        connection = new MySqlConnection(("Server=localhost;Database=videoteket;Uid=Tina;Pwd=123456;"));
        
    }

    // public Database()
    // {
    //     connection = new MySqlConnection(("Server=localhost;Database=Hotelmg;Uid=Tina;Pwd=123456;"));
    // }



    
}