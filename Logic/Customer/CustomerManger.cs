using Dapper;
using MySqlConnector;

class CustomerManager
{

    // private List<Customer> customers;
    CustomerData newCustomerData = new();

    public int AddCustomer(string fname, string lname, int phone, string email, string city, string country, string address)
    {
        int insertCustomerID = newCustomerData.InsertCustomer(fname, lname, phone, email, city, country, address);

        return insertCustomerID;
    }

    public Customer SearchCustomer(int sCustomerId)
    {
        if (newCustomerData.GetCustomer(sCustomerId) != null)
        {
            return newCustomerData.GetCustomer(sCustomerId);
        }
        return null;
    }

    public List<Customer> ShowAllCustomers()
    {
        if (newCustomerData.GetCustomerList() != null)
        {
            return newCustomerData.GetCustomerList();
        }
        return null;
    }

    public void RemoveCustomer(int rCustomerId)
    {
        newCustomerData.DeleteCustomer(rCustomerId);
    }
}