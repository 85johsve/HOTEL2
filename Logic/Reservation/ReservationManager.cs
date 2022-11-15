using Dapper;
using MySqlConnector;

public class ReservationManager
{
    private List<Reservation> reservations;
    ReservationData newReservationData = new();
        private TimeSpan timeSpan;
        private DateTime dateIn;
        private DateTime dateOut;
        public double numberOfDays;

    public double GetTimeSpan(int reservation_id)
    {
        
        foreach (var item in newReservationData.GetTimeSpanData(reservation_id))
        {
            dateIn = item.date_in;
            dateOut = item.date_out;
        }
        timeSpan = dateOut - dateIn; 
        numberOfDays = timeSpan.TotalDays;
        return numberOfDays;
    }
}