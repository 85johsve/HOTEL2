using Dapper;
using MySqlConnector;

class CustomerManager
{
    
    private List<Customer> customers;
    CustomerData newCustomerData= new();
 


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