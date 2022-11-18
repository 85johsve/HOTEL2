using Dapper;
using MySqlConnector;

public class CustomerManager
{

    // private List<Customer> customers;
    CustomerData newCustomerData = new();

    public int AddCustomer(string fname, string lname, int phone, string email, string city, string country, string address)
    {
        int insertCustomerID = newCustomerData.InsertCustomer(fname, lname, phone, email, city, country, address);

        return insertCustomerID;
    }

    public Customer SearchCustomerById(int sCustomerId)
    {
        
         return newCustomerData.GetCustomerById(sCustomerId);
       
    }

    public List<Customer> ShowAllCustomers()
    {
       
        return newCustomerData.GetCustomerList();
        
    }

    public void RemoveCustomerById(int rCustomerId)
    {
        newCustomerData.DeleteCustomerById(rCustomerId);
    }

    public bool CustomerLogInNameId(int id,string fname )
    {
       //return newCustomerData.IsValidUser(fname,id);
       return newCustomerData.GetCustomerLogInNameId(id,fname);
    }

    public string CustomerLogInPass(int id)
    {
         return newCustomerData.GetCustomerLogInPass(id);
    }
}