using Dapper;
using MySqlConnector;
using System.Data;
class PaymentData
{
     MySqlConnection connection;
   
    public PaymentData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
     public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }

    public List<Payment> GetPaymentList()
    {
        Open();
        var payments = connection.Query<Payment>($"SELECT payment_id, customer_fname,customer_lname,payment_date, payment_amount, bankInfor, reservation_id, payment_name FROM payments INNER JOIN customers ON customers.customer_id = payments.customer_id;").ToList();
        
        return payments;
    }

    public int InsertPayment(int customerID, DateTime date, double amount, int reservationID,string name,string bank)
    {
        Open();
        //int id, 
        var r = new DynamicParameters();
        //r.Add("@payment_id", paymentID);
        r.Add("@customer_id", customerID);
        r.Add("@payment_date", date);
        r.Add("@payment_amount", amount);
        r.Add("@reservation_id", reservationID);
        r.Add("@payment_name", name);
        r.Add("@bankInfor",bank);
        string sql = $@"INSERT INTO payments (customer_id, payment_date,payment_amount,reservation_id,payment_name,bankInfor) VALUES ( @customer_id, @payment_date,@payment_amount,@reservation_id,@payment_name,@bankInfor); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();

        return Id;
    }

    public void DeletePayment(int number)
    {
      Open();
       var deletePayment = connection.Query<Payment>($"DELETE FROM `payments` WHERE number=@payment_id");      
    }

     public Payment GetPayment(int idNr)
    {
      Open();
       var payment = connection.QuerySingle<Payment>($"SELECT payment_id, customer_fname,customer_lname,payment_date, payment_amount, bankInfor, reservation_id, payment_name FROM payments INNER JOIN customers ON customers.customer_id = payments.customer_id WHERE payment_id = {idNr};");
 
    return payment;      
    }
}