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
    public string ?roomType_name { get; set; }
    public int roomStatus_id { get; set; }
    public string? roomStatus_name { get; set; }
    public double room_price { get; set; }
    


    public override string ToString()
    {
        return $"Reservation: " + reservation_id + " " + customer_id + " " + employee_id + " " + room_id + " " + reservation_date + " " + date_in + " " + date_out;

    }
    

}