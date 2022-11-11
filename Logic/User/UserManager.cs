using Dapper;
using MySqlConnector;

class userManager
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

    public int AddCustomer(string customer_fname, string customer_lname, int customer_phone, string customer_email, string customer_city, string customer_country, string customer_address)
    {
        int InsertCustomerID= newCustomerData.InsertCustomer (customer_fname, customer_lname, customer_phone, customer_email, customer_city, customer_country, customer_address);     

        return InsertCustomerID;  
    
        // using (var connection = new MySqlConnection("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"))
        // {
            
        //     Console.WriteLine("First name: "); //LÄGGA DETTA I PROGRAM
        //     string addCustomerFName = Console.ReadLine();
        //     Console.WriteLine("Last name: ");
        //     string addCustomerLName = Console.ReadLine();
        //     Console.WriteLine("Phone: ");
        //     int addCustomerPhone = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Email: ");
        //     string addCustomerEmail = Console.ReadLine();
        //     Console.WriteLine("City: ");
        //     string addCustomerCity = Console.ReadLine();
        //     Console.WriteLine("Country: ");
        //     string addCustomerCountry = Console.ReadLine();
        //     Console.WriteLine("Address: ");
        //     string addCustomerAddress = Console.ReadLine();
        //     var customer = connection.Query<Customer>($"INSERT INTO customers(customer_fname, customer_lname, customer_phone, customer_email, customer_city, customer_country, customer_address)VALUES ('{addCustomerFName}', '{addCustomerLName}''{addCustomerPhone}','{addCustomerEmail}','{addCustomerCity}','{addCustomerCountry}','{addCustomerCity}',);").ToList();
        //     Console.WriteLine("Customer has been added!");
        // }
    }
    public void UpdateCustomer()
    {

    }
    // public void List<Customer> ShowAllCustomers()
    // {

    // }
    
    // public void List<Customer> DeleteCustomer()
    // {

    // }
}