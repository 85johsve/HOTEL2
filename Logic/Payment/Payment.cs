public class Payment
{
    public int payment_id{get;set;}
    public int customer_id{get;set;}
    public DateTime payment_date{get;set;}
    public double payment_amount{get;set;}// need to be insert from C#
    public int reservation_id{get;set;}
    public string? payment_name{get;set;}//user need to write down for example, room, texi, or food---
    public double payment_roomPay{get;set;}
    public double payment_otherProducts{get;set;}
    public string? bankInfor{get;set;}
    public string? customer_fname{get;set;} 
    public string? customer_lname{get;set;} 

    //payment_date DATE,  //payment_roomPay DOUBLE//payment_otherProducts DOUBLE






     public override string ToString()
     {
        return $" \nPayment Id: " +payment_id + "\nReservation Nr: "+ reservation_id+ "\nPayment Detial:" + payment_name + "\n Other product payment: "+ payment_otherProducts + "Kr" + "\n Total room payment: " + payment_roomPay + "Kr" + "\nTotal : " + payment_amount + "Kr"+"\nPayment Date: "+ payment_date  + "\nCustomer Name: "+ customer_fname+" "+ customer_lname+ "\nBankInfor: " + bankInfor + "\nHotellet \nTel:033-133366\nAllégatan 13 \nBorås\n";
     }
}