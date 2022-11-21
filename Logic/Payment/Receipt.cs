public class Receipt
{
    public DateTime print_date{get;set;}
    public  int receipt_nr{get;set;}
    Reservation reservation {get;set;}
    Payment payment {get;set;}
    public string? otherproducts_name;
    protected static int fake_ID= 0001;
    

   public Receipt(DateTime printDate,Reservation booking, Payment pay, string others)
   {
    this.print_date = printDate;
    this.receipt_nr = fake_ID++;
    this.reservation = booking;
    this.payment = pay;
    this.otherproducts_name = others;
   }

    public override string ToString()
    {
        return $@"Date: " + print_date + "\nReceipt Nr: " + receipt_nr +reservation + payment + otherproducts_name ;
    }


}