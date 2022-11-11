public class Customer
{
  public int customer_id {get;set;}
  public string? customer_fname {get;set;}
  public string? customer_lname {get;set;}
  public string? customer_email {get;set;}
  public int customer_phone {get;set;}
   public string? customer_city {get;set;}
    public string? customer_country {get;set;}
     public string? customer_address {get;set;}

      public Customer()
    {

    }
     public override string ToString()
    {
        return $"Customer: " + customer_id + " " + customer_fname + " " + customer_lname + " " + customer_email + " " + customer_phone+ " " + customer_city+ " " + customer_country+ " " + customer_address;
    }

}