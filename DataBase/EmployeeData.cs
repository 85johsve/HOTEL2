using Dapper;
using MySqlConnector;
using System.Data;
class EmployeeData 
{
    private List<Employee> employees;
    //EmployeeData newEmployeeData= new();
    MySqlConnection connection;


    public EmployeeData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }
     public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }

    public List<Employee> GetEmployeeList()
    {
        Open();
        var employees = connection.Query<Employee>("SELECT * FROM employees;").ToList();
        //var employees = connection.Query<Employee>("SELECT employee_id,jobTitle_id,employee-fname,employee_lname,employee_phone, employee_email, jobTitle_name FROM (employees INNER JOIN jobtitles ON employees.jobTitle_name=jobtitle.jobtitle_name);").ToList();
        return employees;
    }
    
    public int InsertEmployee(int jobTitleId, string employeeFName, string employeeLName, int employeePhone, string employeeEmail)
    { 
        Open();
        var e = new DynamicParameters();
        e.Add("@jobTitle_id", jobTitleId);
        e.Add("@employee_fname", employeeFName);
        e.Add("@employee_lname", employeeLName);
        e.Add("@employee_phone", employeePhone);
        e.Add("@employee_email", employeeEmail);
        string sql = $@"INSERT INTO employees (jobTitle_id, employee_fname, employee_lname, employee_phone, employee_email) 
        VALUES (@jobTitle_id,@employee_fname,@employee_lname,@employee_phone,@employee_email); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, e).First();

        return Id;

    }
  
    public void DeleteEmployee(int number)
    {
        Open();
        var deleteEmployee = connection.Query<Employee>($"DELETE FROM employees WHERE employee_id = {number};");
    }


    // public Employee SearchEmployee(string searchId) 
    // {
    //     var employee = connection.QuerySingle<Employee>($@"SELECT  jobTitle_name, employee_fname, employee_lname,employee_phone, employee_email FROM employees
    //     INNER JOIN jobtitles ON jobtitles.jobTitle_id=employees.jobTitle_id
    //     WHERE employee_id={searchId}");
    //     return employee;
    // }

    public Employee GetEmployee(int eIdNr)
    {
       Open();
        var employee = connection.QuerySingle<Employee>($"SELECT * FROM employees WHERE employee_id  ={eIdNr};");
 
        return employee;
        
    }
    

   
}