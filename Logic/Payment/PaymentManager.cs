using Dapper;
using MySqlConnector;
class PaymentManger
{
     //private List<Payment> payments;
    PaymentData newPaymentData = new();

     public List<Payment> ShowAllPayments()
    {
         if (newPaymentData.GetPaymentList() != null)
        {
            return newPaymentData.GetPaymentList();
        }
        return null;
    }


    public Payment SearchPayment(int sPaymentId)
    {
        if (newPaymentData.GetPayment(sPaymentId) != null)
        {
            return newPaymentData.GetPayment(sPaymentId);
        }
        return null;
    }

    public int AddPayment( int cID, DateTime date, double amount, int rID,string name,string bank)
    {
        int InsertPaymentID = newPaymentData.InsertPayment(cID, date, amount, rID,name,bank);

        return InsertPaymentID;
    }

    public void RemovePayment(int rPaymentId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newPaymentData.DeletePayment(rPaymentId);
    }
}