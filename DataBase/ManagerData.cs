using Dapper;
using MySqlConnector;

class ManagerData 
{
    
    MySqlConnection connection;
    ManagerData newManagerData = new();
    // public void Manager()
    // {
        
    // }

    public ManagerData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
}