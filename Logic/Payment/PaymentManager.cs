using Dapper;
using MySqlConnector;
public class PaymentManger
{
     //private List<Payment> payments;
    PaymentData newPaymentData = new();
    

     public List<Payment> ShowAllPayments()
    {  
            return newPaymentData.GetPaymentList();  
    }


    public Payment SearchPaymentByPaymentId(int sPaymentId)
    {
            return newPaymentData.GetPaymentById(sPaymentId); 
    }

    public int AddPayment( int cID, DateTime date, double amount, double roompay, double otherpay, int rID,string name,string bank)
    {
       
        int InsertPaymentID = newPaymentData.InsertPayment(cID, date, amount,roompay,otherpay, rID,name,bank);

        return InsertPaymentID;
    }

    public void RemovePaymentById(int rPaymentId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newPaymentData.DeletePaymentById(rPaymentId);
    }

    public Payment SearchPaymentByReservId(int sReservId)
    {
            return newPaymentData.GetPaymentById(sReservId); 
    }




    // public Payment PaymentCaculation()
    // {
        
    // }
}