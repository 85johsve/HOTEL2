public class UserInput
{

    public  RoomManager roomManager = new();
    public  CustomerManager customerManager = new();
    public  EmployeeManager employeeManager = new();
    public  PaymentManger paymentManager = new();
    public  ReservationData reservationData = new();
    public  ReservationManager reviewManager = new();
    
    
    public  bool employeeIsLoggedIn;
    public bool managerIsLoggedIn;
    public bool customerIsLoggedIn;
}