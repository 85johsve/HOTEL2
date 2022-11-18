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

    
     public List<Reservation> ShowAllReservations()
    {
        return newReservationData.GetReservationList();
    }   

    public double GetTimeSpanById(int reservation_id)
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

    public double GetTimeSpanByDates(DateTime dateIn, DateTime dateOut)
    {
        timeSpan = dateOut - dateIn; 
        numberOfDays = timeSpan.TotalDays;
        return numberOfDays;
    }

    public void CustomerBookRoom()
    {
        Console.WriteLine("Book room");

        int customerIdBooking = 1;
        Console.WriteLine("Enter a from-date: ");
        DateTime dateIn;
        if (DateTime.TryParse(Console.ReadLine(), out dateIn))
        {
            Console.WriteLine("you choosed: " + dateIn);
        }
        else
        {
            Console.WriteLine("You have entered an incorrect value.");
        }


        Console.WriteLine("Enter a to-date: ");
        DateTime dateOut;
        if (DateTime.TryParse(Console.ReadLine(), out dateOut))
        {
            Console.WriteLine("you choosed: " + dateOut);
        }
        else
        {
            Console.WriteLine("You have entered an incorrect value.");
        }
        Console.ReadLine();

        List<Reservation> dateInList = new();
        List<Reservation> dateInOut = new();
        List<Reservation> availabeRooms = new();
        foreach (var item in newReservationData.GetReservationData())
        {
            if (dateIn > item.date_in)
            {
                dateInList.Add(item);
            }
        }

        foreach (var listItem in dateInList)
        {
            if (dateIn > listItem.date_out)
            {
                bool add_it = true;
                foreach (var room in availabeRooms)
                {
                    if (room.room_id == listItem.room_id)
                    {
                        add_it = false;
                        break;
                    }
                }
                if (add_it)
                    availabeRooms.Add(listItem);
            }
        }

        foreach (var item in newReservationData.GetReservationData())
        {

            if (dateIn < item.date_in)
            {
                dateInOut.Add(item);
            }
        }

        foreach (var item in dateInOut)
        {
            if (dateOut < item.date_in)
            {
                bool add_it = true;
                foreach (var room in availabeRooms)
                {
                    if (room.room_id == item.room_id)
                    {
                        add_it = false;
                        break;
                    }
                }
                if (add_it)
                    availabeRooms.Add(item);
            }
        }

        foreach (var gg in availabeRooms)
        {
            Console.WriteLine("room nr: " + gg.room_id);
        }
        DateTime todaysDate = DateTime.Now;
        double date_range = GetTimeSpanByDates(dateIn, dateOut);
        Console.WriteLine("Choose room to book: ");
        int roomSelected = Int32.Parse(Console.ReadLine());
        newReservationData.MakeReservationCustomer(customerIdBooking, roomSelected, todaysDate, dateIn, dateOut, date_range);
        Console.WriteLine($"You have booked room nr {roomSelected} from: {dateIn} to: {dateOut}.");
        Console.ReadKey();
        Console.Clear();
    }

    public void EmployeeBookRoom()
    {
        Console.WriteLine("Book room");
        int customerIdBooking = 1;
        int employee_id = 1;
        
        Console.WriteLine("Enter a from-date: ");

        DateTime userDateIn;
        if (DateTime.TryParse(Console.ReadLine(), out userDateIn))
        {
            Console.WriteLine("you choosed: " + userDateIn);
        }
        else
        {
            Console.WriteLine("You have entered an incorrect value.");
        }


        Console.WriteLine("Enter a to-date: ");
        DateTime userDateOut;
        if (DateTime.TryParse(Console.ReadLine(), out userDateOut))
        {
            Console.WriteLine("you choosed: " + userDateOut);
        }
        else
        {
            Console.WriteLine("You have entered an incorrect value.");
        }
        Console.ReadLine();

        List<Reservation> dateInList = new();
        List<Reservation> dateInOut = new();
        List<Reservation> availabeRooms = new();
        foreach (var item in newReservationData.GetReservationData())
        {
            if (userDateIn > item.date_in)
            {
                dateInList.Add(item);
            }
        }

        foreach (var listItem in dateInList)
        {
            if (userDateIn > listItem.date_out)
            {
                bool add_it = true;
                foreach (var room in availabeRooms)
                {
                    if (room.room_id == listItem.room_id)
                    {
                        add_it = false;
                        break;
                    }
                }
                if (add_it)
                    availabeRooms.Add(listItem);
            }
        }

        foreach (var item in newReservationData.GetReservationData())
        {

            if (userDateIn < item.date_in)
            {
                dateInOut.Add(item);
            }
        }

        foreach (var item in dateInOut)
        {
            if (userDateOut < item.date_in)
            {
                bool add_it = true;
                foreach (var room in availabeRooms)
                {
                    if (room.room_id == item.room_id)
                    {
                        add_it = false;
                        break;
                    }
                }
                if (add_it)
                    availabeRooms.Add(item);
            }
        }

        foreach (var gg in availabeRooms)
        {
            Console.WriteLine("room nr: " + gg.room_id);
        }
        DateTime todaysDate = DateTime.Now;
        double date_range = GetTimeSpanByDates(dateIn, dateOut);
        Console.WriteLine("Choose room to book: ");
        int roomSelected = Int32.Parse(Console.ReadLine());
        newReservationData.MakeReservationEmployee(customerIdBooking, employee_id, roomSelected, todaysDate, userDateIn, userDateOut, date_range);
        Console.WriteLine($"You have booked room nr {roomSelected} from: {userDateIn} to: {userDateOut}.");
        Console.ReadKey();
        Console.Clear();
    }

     public Reservation SearchReservationById(int sReservationId)
    {
        return newReservationData.GetSingleReservationById(sReservationId);
    }

    

    public int TryGetInt(string prompt)
    {

        Console.WriteLine(prompt);
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            return id;
        }
        return 0;
    }
}