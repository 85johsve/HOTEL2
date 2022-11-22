public class Customer
{
    public int customer_id { get; set; }
    public string? customer_fname { get; set; }
    public string? customer_lname { get; set; }
    public string? customer_email { get; set; }
    public int customer_phone { get; set; }
    public string? customer_city { get; set; }
    public string? customer_country { get; set; }
    public string? customer_address { get; set; }


    public override string ToString()
    {
        return $"Customer: " + " " + customer_id + "\nCustomer Full Name: " + customer_fname + " " + customer_lname + "\nCustomer Email: " + customer_email + "\nCustomer Phone: " + customer_phone + "\nCustomer City: " + customer_city + "\nCustomer Country: " + customer_country + "\nCustomer Address: " + customer_address;
    }

}