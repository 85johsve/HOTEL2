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


    public Payment SearchPaymentById(int sPaymentId)
    {
            return newPaymentData.GetPaymentById(sPaymentId); 
    }

    public int AddPayment( int cID, DateTime date, double amount, int rID,string name,string bank)
    {
        int InsertPaymentID = newPaymentData.InsertPayment(cID, date, amount, rID,name,bank);

        return InsertPaymentID;
    }

    public void RemovePaymentById(int rPaymentId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newPaymentData.DeletePaymentById(rPaymentId);
    }

    // public Payment PaymentCaculation()
    // {
        
    // }
}