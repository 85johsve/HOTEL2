using Dapper;
using MySqlConnector;
class EmployeeData 
{
    private List<Employee> employees;
    EmployeeData newEmployeeData= new();
    MySqlConnection connection;


    public EmployeeData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }

    public List<Employee> GetEmployeeList()
    {
        var employees = connection.Query<Employee>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
        return employees;

    }
    
    public int InsertEmployee(int jobTitleId, string employeeFName, string employeeLName, int employeePhone, string employeeEmail)
    {
        //int id, 
        var e = new DynamicParameters();
        e.Add("@jobTitle_id", jobTitleId);
        e.Add("@employee_fname", employeeFName);
        e.Add("@employee_lname", employeeLName);
        e.Add("@employee_phone", employeePhone);
        e.Add("@employee_email", employeeEmail);
        string sql = $@"INSERT INTO employees (jobTitle_id, employee_fname, employee_lname, employee_phone, employee_email) VALUES (@jobTitle_id,@employee_fname,@employee_lname,@employee_phone,@employee_email); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, e).First();

        return Id;



    }

   
}