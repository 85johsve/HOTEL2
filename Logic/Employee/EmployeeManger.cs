using Dapper;
using MySqlConnector;

class EmployeeManager
{
    //private List<Employee> employees;
    EmployeeData newEmployeeData= new();
    // private List<Customer> customers;
    // CustomerData newCustomerData= new();
    public EmployeeManager()
    {
        
    }

    

    public int AddEmployee(int jobId, string fname, string lname, int phone, string email)
    {
        int InsertEmployeeID= newEmployeeData.InsertEmployee (jobId, fname, lname, phone, email);     
        return InsertEmployeeID;  
    
        
    
    }
        public List<Employee>ShowAllEmployees()
        {
            return newEmployeeData.GetEmployeeList();
        }
    
        //newEmployeeData.DeleteEmployee(int idNumber);
    
    public void RemoveEmployee(int idNumber)
    {
        //newEmployeeData.DeleteEmployee(int idNumber);
    }
}