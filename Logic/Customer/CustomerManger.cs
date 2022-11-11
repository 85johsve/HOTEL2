using Dapper;
using MySqlConnector;

class CustomerManager
{
    
   // private List<Customer> customers;
    CustomerData newCustomerData= new();

 
     

    public int AddCustomer(string fname, string lname, int phone, string email, string city, string country, string address)
    {
        int insertCustomerID= newCustomerData.InsertCustomer (fname, lname, phone, email, city, country, address);     

        return insertCustomerID;  
    }
    public Customer SearchCustomer(int number)
    {
         return newCustomerData.GetCustomer(number);
    }
    public List<Customer> ShowAllCustomers()
    {
      return newCustomerData.GetCustomerList();
    }
    
    // public void List<Customer> DeleteCustomer()
    // {

    // }
}