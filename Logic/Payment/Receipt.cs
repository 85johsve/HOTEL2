public class Receipt
{
    public DateTime print_date{get;set;}

    public  int receipt_nr{get;set;}
   // Reservation reservation {get;set;}
    Payment payment {get;set;}
    protected static int fake_ID= 0001;
    

   public Receipt(DateTime printDate, Payment pay)
   {
    this.print_date = printDate;
    this.receipt_nr = fake_ID++;
    this.payment = pay;

   }

    public override string ToString()
    {

        return $@"Date: " + print_date + "\nReceipt Nr: "  + payment ;

      

    }


}