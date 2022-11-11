using Dapper;
using MySqlConnector;

class EmployeeManager
{

    // private List<Customer> customers;
    // CustomerData newCustomerData= new();
    EmployeeData newEmployeeData=new();
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
    
    
        public void RemoveEmployee(int idNumber)
        {
            newEmployeeData.DeleteEmployee(idNumber);
        }
}