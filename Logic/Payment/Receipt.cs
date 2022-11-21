public class Receipt
{
    public DateTime print_date{get;set;}
    public static int receipt_nr{get;set;}
    Reservation reservation =new();
    Payment payment = new();
    public string? otherproducts_name;

   public Receipt(DateTime printDate)
   {
    
   }

    public override string ToString()
    {
        return $@"Date: " + print_date + "\nReceipt Nr: " + receipt_nr +reservation + payment + otherproducts_name ;
    }


}