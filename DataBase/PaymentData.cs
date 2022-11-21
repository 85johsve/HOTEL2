using Dapper;
using MySqlConnector;
using System.Data;
class PaymentData
{
     MySqlConnection connection;
   
    public PaymentData()
    {
        connection = new MySqlConnection(("Server=13.51.47.91;Database=hotelmg;Uid=root;Pwd=i-077e801baa9e32977;"));
    }
     public void Open()
    {
         try
        {
           if(connection.State != ConnectionState.Open)
            connection.Open(); 
        }
        catch (Exception e)
        {
            
            throw new FieldAccessException();
        }
    }

    public List<Payment> GetPaymentList()
    {
        Open();
        var payments = connection.Query<Payment>($"SELECT payment_id, customer_fname,customer_lname,payment_date, payment_amount, bankInfor, reservation_id, payment_name FROM payments INNER JOIN customers ON customers.customer_id = payments.customer_id;").ToList();
        
        return payments;
    }

    public int InsertPayment(int customerID, DateTime date, double amount,double roompay, double otherpay, int reservationID,string name,string bank)   // this amount = room total + others(since )
    {
        Open();
        //int id, 
        var r = new DynamicParameters();
        //r.Add("@payment_id", paymentID);
        r.Add("@customer_id", customerID);
        r.Add("@payment_date", date);
        r.Add("@payment_amount", amount);
         r.Add("@payment_roomPay", roompay);
          r.Add("@payment_otherotherProducts", otherpay);
        r.Add("@reservation_id", reservationID);
        r.Add("@payment_name", name);
        r.Add("@bankInfor",bank);

        string sql = $@"INSERT INTO payments (customer_id, payment_date,payment_amount,reservation_id,payment_name,payment_roomPay,payment_otherProducts,bankInfor) VALUES ( @customer_id, @payment_date,@payment_amount,@reservation_id,@payment_name,@payment_roomPay,@payment_otherProducts,@bankInfor); SELECT LAST_INSERT_ID() ";

        int Id = connection.Query<int>(sql, r).First();

        return Id;
    }

    public void DeletePaymentById(int number)
    {
      Open();
       var deletePayment = connection.Query<Payment>($"DELETE FROM `payments` WHERE payment_id={number}");      
    }

     public Payment GetPaymentById(int idNr) //when we check out, that is when we pay, we need to calculate the payment_amount,this amount is including everything, room ,otherproducts. that means we need to insert the roomtotl pay here. 
    {
      Open();
       var payment = connection.QuerySingle<Payment>($"SELECT payment_id, customer_fname,customer_lname,payment_date, payment_amount, bankInfor, reservation_id, payment_name FROM payments INNER JOIN customers ON customers.customer_id = payments.customer_id WHERE payment_id = {idNr};");
 
    return payment;      
    }

     public Payment GetPaymentByReservId(int idNr) //when we check out, that is when we pay, we need to calculate the payment_amount,this amount is including everything, room ,otherproducts. that means we need to insert the roomtotl pay here. 
    {
      Open();
       var payment = connection.QuerySingle<Payment>($"SELECT payment_id, customer_fname,customer_lname,payment_date, payment_amount, bankInfor, reservation_id, payment_name FROM payments INNER JOIN customers ON customers.customer_id = payments.customer_id WHERE reservation_id = {idNr};");
 
    return payment;      
    }
}