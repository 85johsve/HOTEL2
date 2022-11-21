public class Receipt
{
    public DateTime print_date{get;set;}

    public  int receipt_nr{get;set;}
   // Reservation reservation {get;set;}
    //Payment payment {get;set;}
    protected static int fake_ID= 11111;
    //List<Payment> payments{get;set;}
    

   public Receipt(DateTime printDate)//,List<Payment>pays
   {
    this.print_date = printDate;
    this.receipt_nr = fake_ID++;
    //this.payments = pays;

   }

    public override string ToString()
    {

        return $@"Date: " + print_date + "\nReceipt Nr: "  + fake_ID  ;

      

    }


}