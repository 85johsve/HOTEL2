public class Reservation
{
    public int reservation_id { get; set; }
    public int customer_id { get; set; }
    public int employee_id { get; set; }
    public int room_id { get; set; }
    public DateTime reservation_date { get; set; }
    public DateTime date_in { get; set; }
    public DateTime date_out { get; set; }
    public int roomType_id { get; set; }
    public string? roomType_name { get; set; }
    public int roomStatus_id { get; set; }
    public string? roomStatus_name { get; set; }
    public double room_price { get; set; }
    public string? customer_fname { get; set; }
    public string? customer_lname { get; set; }
    public double data_range { get; set; }
    public double reservation_totalpay { get; set; }

    public override string ToString()
    {
        return $"Reservation: " + reservation_id + "\nCustomer Name: " + customer_fname + " " + customer_lname + "\nEmployee Id: " + employee_id + "\nRoom Type: " + roomType_name + "\nRoom:  " + room_id + "\nPrice: " + room_price + " Kr" + "\nReservation Date:  " + reservation_date + "\nChecking in Date:  " + date_in + "\nChecking out Date:  " + date_out + "\nStaying time span: " + data_range + "\nRoom total payment: " + reservation_totalpay + "Kr";

    }
}