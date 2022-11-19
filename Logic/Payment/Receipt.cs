public class Receipt
{
    public DateTime print_date{get;set;}
    public static int receipt_nr{get;set;}
    Reservation reservation =new();
   

    public override string ToString()
    {
        return $@"Date: " + print_date + "\nReceipt Nr: " + receipt_nr ;
    }
}