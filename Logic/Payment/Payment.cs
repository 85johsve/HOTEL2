public class Payment
{
    public int payment_id{get;set;}
    public int customer_id{get;set;}
    public DateOnly payment_date{get;set;}
    public double payment_amount{get;set;}
    public int reservation_id{get;set;}
    public string? payment_name{get;set;}//user need to write down for example, room, texi, or food---
    public string? bankInfor{get;set;} 

     public override string ToString()
     {
        return $"Payment Id: " +payment_id + "\nPayment Detial:" + payment_name+"\nPayment Amount: "+ payment_amount+"Payment Date: "+payment_date+"\nReservation Nr: "+ reservation_id+"\nCustomer Id: "+customer_id+"\nBankInfor: "+bankInfor;
     }
}