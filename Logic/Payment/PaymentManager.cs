using Dapper;
using MySqlConnector;
public class PaymentManger
{
    PaymentData newPaymentData = new();

    public List<Payment> ShowAllPayments()
    {
        return newPaymentData.GetPaymentList();
    }

    public Payment SearchPaymentByPaymentId(int sPaymentId)
    {
        return newPaymentData.GetPaymentByPaymentId(sPaymentId);
    }

    public List<Payment> SearchPaymentByReservId(int sReservId)
    {
        return newPaymentData.GetPaymentByReservId(sReservId);
    }

    public int AddPayment(int cID, DateTime date, double amount, double roomPay, double otherPay, int rID, string name, string bank)
    {
        int InsertPaymentID = newPaymentData.InsertPayment(cID, date, amount, roomPay, otherPay, rID, name, bank);
        return InsertPaymentID;
    }

    public void RemovePaymentById(int rPaymentId)   
    {
        newPaymentData.DeletePaymentById(rPaymentId);
    }

}