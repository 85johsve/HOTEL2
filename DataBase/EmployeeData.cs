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
        connection = new MySqlConnection(("Server=13.51.47.91;Database=hotelmg;Uid=root;Pwd=i-077e801baa9e32977;"));
    }

    public void Open()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        catch (Exception e)
        {

            throw new FieldAccessException();
        }
    }

    public List<Employee> GetEmployeeList()
    {
        Open();
        var employees = connection.Query<Employee>("SELECT * FROM employees;").ToList();
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

    public void DeleteEmployeeById(int number)
    {
        Open();
        var deleteEmployee = connection.Query<Employee>($"DELETE FROM employees WHERE employee_id = {number};");
    }

    public Employee GetEmployeeById(int eIdNr)
    {
        Open();
        var employee = connection.QuerySingle<Employee>($"SELECT * FROM employees WHERE employee_id  ={eIdNr};");

        return employee;
    }

    public bool GetEmployeeLogInNameId(int accountNr, string pass)
    {
        Open();
        string sql = $@"select * from employees where employee_fname = '{pass}' and employee_id={accountNr};";
        var result = connection.Query<Customer>(sql);
        if (result.Count() > 0)
            return true;
        else
            return false;
    }

    public bool GetManagerLogInNameId(int accountNr, string pass)
    {
        Open();
        string sql = $@"SELECT * FROM employees INNER JOIN jobtitles ON employees.jobTitle_id = jobtitles.jobTitle_id WHERE jobTitle_name = 'Manager' AND employee_fname='{pass}' AND employee_id={accountNr};";
        var result = connection.Query<Customer>(sql);
        if (result.Count() > 0)
            return true;
        else
            return false;
    }
}