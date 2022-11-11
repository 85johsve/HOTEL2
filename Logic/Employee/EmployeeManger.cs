using Dapper;
using MySqlConnector;

class EmployeeManager
{
    private List<Employee> employees;
    EmployeeData newEmployeeData= new();
    private List<Customer> customers;
    CustomerData newCustomerData= new();
 

    public int AddEmployee(int jobTitle_id, string employee_fname, string employee_lname, int employee_phone, string employee_email)
    {
        int InsertEmployeeID= newEmployeeData.InsertEmployee (jobTitle_id, employee_fname, employee_lname, employee_phone, employee_email);     
        return InsertEmployeeID;  
    
        using (var connection = new MySqlConnection("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"))
        {
            
            Console.WriteLine("Job Title ID: "); //LÄGGA DETTA I PROGRAM
            int addJobTitleId = int.Parse(Console.ReadLine());
            Console.WriteLine("First name: ");
            string addEmployeeFName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string addEmployeeLName = Console.ReadLine();
            Console.WriteLine("Phone: ");
            int addEmployeePhone = int.Parse(Console.ReadLine());
            Console.WriteLine("Email: ");
            string addEmployeeEmail = Console.ReadLine();
            var employee = connection.Query<Employee>($"INSERT INTO employees(jobTitle_id, employee_fname, employee_lname, employee_phone, employee_email)VALUES ('{addJobTitleId}', '{addEmployeeFName}''{addEmployeeLName}','{addEmployeePhone}','{addEmployeeEmail}',);").ToList();
            Console.WriteLine("Employee has been added!");
        }
    }

    public void UpdateEmployee()
    {
        
    }
    // public List<Employee> GetEmployeeList()
    // {
    //     // EmployeeData.employees = connection.Query<Employee>("SELECT * FROM employees;").ToList();
    //     // return employees;

    // }
    
    public void RemoveEmployee(int idNumber)
    {
        //newEmployeeData.DeleteEmployee(int idNumber);
    }
}