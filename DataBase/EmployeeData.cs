using Dapper;
using MySqlConnector;
class EmployeeData : Database
{
    Database employeedb = new Database();
    MySqlConnection connection;


    public EmployeeData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }
}