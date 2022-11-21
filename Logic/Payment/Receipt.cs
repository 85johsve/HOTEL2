public class Receipt
{
    public DateTime print_date{get;set;}
<<<<<<< HEAD
    public  int receipt_nr{get;set;}
   // Reservation reservation {get;set;}
    Payment payment {get;set;}
    protected static int fake_ID= 0001;
    

   public Receipt(DateTime printDate, Payment pay)
   {
    this.print_date = printDate;
    this.receipt_nr = fake_ID++;
    this.payment = pay;
=======
    public static int receipt_nr{get;set;}
    Reservation reservation =new();
    Payment payment = new();
    public string? otherproducts_name;

   public Receipt(DateTime printDate)
   {
>>>>>>> c1aaaf5d42415d2156619fb8d8a784062973230c
    
   }

    public override string ToString()
    {
<<<<<<< HEAD
        return $@"Date: " + print_date + "\nReceipt Nr: "  + payment ;
=======
        return $@"Date: " + print_date + "\nReceipt Nr: " + receipt_nr +reservation + payment + otherproducts_name ;
>>>>>>> c1aaaf5d42415d2156619fb8d8a784062973230c
    }


}