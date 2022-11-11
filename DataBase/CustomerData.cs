using Dapper;
using MySqlConnector;
class CustomerData
{
   
    MySqlConnection connection;


    public CustomerData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }

     public List<Customer> GetCustomerList()
    {
        var customers = connection.Query<Customer>("SELECT * FROM customers;").ToList();
        return customers;

    }

    public int InsertCustomer(string fname, string lname, int phone, string email, string city, string country, string address)
    {
         var r = new DynamicParameters();
        r.Add("@customer_fname", fname);
        r.Add("@customer_lname", lname);
        r.Add("@customer_phone", phone);
        r.Add("@customer_email", email);
        r.Add("@customer_city", city);
        r.Add("@customer_country", country);
        r.Add("@customer_address", address);
        string sql = $@"INSERT INTO customers (customer_fname, customer_lname, customer_phone,customer_email,customer_city, customer_country, customer_address) VALUES (@customer_fname,@customer_lname,@customer_phone,@customer_email,@customer_city,@customer_country,@customer_address); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();

        return Id;
    
    }
}