using Dapper;
using MySqlConnector;
class PaymentManger
{
     private List<Payment> payments;
    PaymentData newPaymentData = new();
    
     public List<Payment> ShowAllPayments()
    {
        return newPaymentData.GetPaymentList();
    }


    public Payment SearchPayment(int sPaymentId)
    {
        if (newPaymentData.GetPayment(sPaymentId) != null)
        {
            return newPaymentData.GetPayment(sPaymentId);
        }
        return null;
    }

    public int AddPayment(int typeID, int statusID, double price)
    {
        int InsertPaymentID = newPaymentData.InsertPayment(typeID, statusID, price);

        return InsertPaymentID;
    }

    public void RemovePayment(int rPaymentId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newPaymentData.DeletePayment(rPaymentId);
    }
}