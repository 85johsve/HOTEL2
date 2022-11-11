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

    

<<<<<<< HEAD
    public int AddEmployee(int jobTitle_id, string employee_fname, string employee_lname, int employee_phone, string employee_email)
     {
         int InsertEmployeeID= newEmployeeData.InsertEmployee (jobTitle_id, employee_fname, employee_lname, employee_phone, employee_email);     
         return InsertEmployeeID; 
     } 
    
    //     using (var connection = new MySqlConnection("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"))
    //     {
            
    //         Console.WriteLine("Job Title ID: "); //LÄGGA DETTA I PROGRAM
    //         int addJobTitleId = int.Parse(Console.ReadLine());
    //         Console.WriteLine("First name: ");
    //         string addEmployeeFName = Console.ReadLine();
    //         Console.WriteLine("Last name: ");
    //         string addEmployeeLName = Console.ReadLine();
    //         Console.WriteLine("Phone: ");
    //         int addEmployeePhone = int.Parse(Console.ReadLine());
    //         Console.WriteLine("Email: ");
    //         string addEmployeeEmail = Console.ReadLine();
    //         var employee = connection.Query<Employee>($@"INSERT INTO employees(jobTitle_id, employee_fname, 
    //         employee_lname, employee_phone, employee_email)VALUES ('{addJobTitleId}', '{addEmployeeFName}'
    //         '{addEmployeeLName}','{addEmployeePhone}','{addEmployeeEmail}',);").ToList();
    //         Console.WriteLine("Employee has been added!");
    //     }

    public int AddEmployee(int jobId, string fname, string lname, int phone, string email)
    {
        int InsertEmployeeID= newEmployeeData.InsertEmployee (jobId, fname, lname, phone, email);     
        return InsertEmployeeID;  
    
        
>>>>>>> 10fc4ad4f095a2462ea6a605913581fc231f984a
    
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