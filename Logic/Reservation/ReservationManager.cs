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

    public void UpdateReservationDate(int reservation_id, DateTime date_in, DateTime date_out, double date_range, double newTotalPay)
    {

        newReservationData.UpdateReservationDate(reservation_id, date_in, date_out, date_range, newTotalPay);
    }

    public void UpdateReservationRoom(int reservation_id,int room_id)
    {
        newReservationData.UpdateReservationRoom(reservation_id,room_id);
    }

     public int GetRoomIdByReservId(int reservation_id)
    {
        return newReservationData.GetRoomByReservId(reservation_id);
    }

    
    public int GetReservationIdByRoomId(int roomId)
    {
        return newReservationData.GetReservIdByRoomId(roomId);
    }

    public double GetTimeSpanByDates(DateTime dateIn, DateTime dateOut)
    {
        timeSpan = dateOut - dateIn;
        double numberOfDays = timeSpan.TotalDays;
        return numberOfDays;
    }

    public void EmployeeBookRoom(int employeeId)
    {
        Console.WriteLine("Book room");


        int customerIdBooking = TryGetInt("Enter customer ID: ");
        int employeeIdBooking = employeeId;
        Console.WriteLine("Enter a from-date: ");
        DateTime dateIn;
        do
        {
            if (DateTime.TryParse(Console.ReadLine(), out dateIn))
            {
                Console.WriteLine("you choosed: " + dateIn);
                break;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
        } while (true);


        Console.WriteLine("Enter a to-date: ");
        DateTime dateOut;
        do
        {
            if (DateTime.TryParse(Console.ReadLine(), out dateOut))
            {
                Console.WriteLine("you choosed: " + dateOut);
                break;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
        } while (true);

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
        double roomSelectedPrice = 0;
        double totalPay;
        bool reservateRoom = false;
        int roomSelected = TryGetInt("Choose room to book:");
        foreach (var hh in availabeRooms)
        {
            if (hh.room_id == roomSelected)
            {
                roomSelectedPrice = hh.room_price;
            }
        }
        totalPay = roomSelectedPrice * date_range;
        foreach (var room in availabeRooms)
        {
            if (roomSelected == room.room_id)
            {
                reservateRoom = true;
            }

        }

        if (reservateRoom == true)
        {
                Console.WriteLine("new reservation id: " + newReservationData.MakeReservation(customerIdBooking, employeeIdBooking, roomSelected, todaysDate, dateIn, dateOut, date_range, totalPay));
                Console.WriteLine($"You have booked room nr {roomSelected} from: {dateIn} to: {dateOut}.");
                Console.ReadKey();
                Console.Clear();
            
        }
    }

    public void CustomerBookRoom(int CustomerId)
    {
        Console.WriteLine("Book room");
        int customerIdBooking = CustomerId;
        int employee_id = 0;
        DateTime userDateIn;
        DateTime userDateOut;

        Console.WriteLine("Enter a from-date: ");

        while (true)
        {

            if (DateTime.TryParse(Console.ReadLine(), out userDateIn))
            {
                Console.WriteLine("you choosed: " + userDateIn);
                break;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");

            }
        }


        while (true)
        {
            Console.WriteLine("Enter a to-date: ");
            if (DateTime.TryParse(Console.ReadLine(), out userDateOut))
            {
                Console.WriteLine("you choosed: " + userDateOut);
                break;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
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
        double date_range = GetTimeSpanByDates(userDateIn, userDateOut);
        double roomSelectedPrice = 0;
        double totalPay;
        bool reservateRoom = false;
        int roomSelected = TryGetInt("Choose room to book:");
        foreach (var hh in availabeRooms)
        {
            if (hh.room_id == roomSelected)
            {
                roomSelectedPrice = hh.room_price;
            }
        }
        totalPay = roomSelectedPrice * date_range;
        foreach (var room in availabeRooms)
        {
            if (roomSelected == room.room_id)
            {
                reservateRoom = true;
            }
        }

        if (reservateRoom == true)
        {
            Console.WriteLine("new reservation id: " + newReservationData.MakeReservation(customerIdBooking, employee_id, roomSelected, todaysDate, userDateIn, userDateOut, date_range, totalPay));
            Console.WriteLine($"You have booked room nr {roomSelected} from: {userDateIn} to: {userDateOut}.");
            Console.ReadKey();
            Console.Clear();


        }
    }

    public Reservation SearchReservationById(int sReservationId)
    {
        return newReservationData.GetSingleReservationById(sReservationId);
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

    public double CalculatingTotalRoomPay(int id) 
    {

        return newReservationData.GetRoomPrice(id) * GetTimeSpanById(id);//insert into reservation 

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