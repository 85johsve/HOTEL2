public class Payment
{
    public int payment_id{get;set;}
    public int customer_id{get;set;}
    public DateTime payment_date{get;set;}
    public double payment_amount{get;set;}
    public int reservation_id{get;set;}
    public string? payment_name{get;set;}//user need to write down for example, room, texi, or food---
    public string? bankInfor{get;set;}
    public string? customer_fname{get;set;} 
    public string? customer_lname{get;set;} 

     public override string ToString()
     {
        return $"Receipt \nPayment Id: " +payment_id + "\nPayment Detial:" + payment_name+"\nPayment Amount: "+ "Kr"+payment_amount+"\nPayment Date: "+ payment_date + "\nReservation Nr: "+ reservation_id + "\nCustomer Name: "+ customer_fname+" "+ customer_lname+ "\nBankInfor: " + bankInfor + "\nHotellet \nTel:033-133366\nAllégatan 13 \nBorås";
     }
}