using Dapper;
using MySqlConnector;
public class PaymentManger
{
     //private List<Payment> payments;
    PaymentData newPaymentData = new();
    Receipt receipt = new();

     public List<Payment> ShowAllPayments()
    {  
            return newPaymentData.GetPaymentList();  
    }


    public Payment SearchPaymentByPaymentId(int sPaymentId)
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

<<<<<<< HEAD
    public Payment SearchPaymentByReservId(int sReservId)
    {
            return newPaymentData.GetPaymentById(sReservId); 
    }




=======
>>>>>>> c1aaaf5d42415d2156619fb8d8a784062973230c
    // public Payment PaymentCaculation()
    // {
        
    // }
}