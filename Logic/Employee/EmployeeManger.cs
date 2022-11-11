using Dapper;
using MySqlConnector;

class EmployeeManager
{
<<<<<<< HEAD
   // private List<Employee> employees;
=======
    //private List<Employee> employees;
>>>>>>> 10fc4ad4f095a2462ea6a605913581fc231f984a
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
    
        
    
    // }
        public List<Employee>ShowAllEmployees()
        {
            return newEmployeeData.GetEmployeeList();
        }
    
    
        public void RemoveEmployee(int idNumber)
        {
            newEmployeeData.DeleteEmployee(idNumber);
        }
}