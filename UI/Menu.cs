class Menu
{
    public RoomManager roomManager = new();
    public CustomerManager customerManager = new();
    public EmployeeManager employeeManager = new();
    public PaymentManger paymentManager = new();
    public ReservationData reservationData = new();
    public ReservationManager reservationManager = new();
    public ReviewManager reviewManager = new();
    public UserInput userInput = new();
    public int customerID { get; set; }


    public void GetEmployeeMenu(int employeeId)
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceEmployee choice = EmployeeEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Employee Menu *********\n ");
            switch (choice)
            {
                case MenuChoiceEmployee.ShowRooms:
                    userInput.PrintAllRooms();
                    break;

                case MenuChoiceEmployee.ShowAvailableRooms:
                    userInput.PrintAvailableRooms();
                    break;

                case MenuChoiceEmployee.ShowReservations:
                    userInput.PrintAllReservations();
                    break;

                case MenuChoiceEmployee.SearchRoom:
                    userInput.SearchRoomByIdInput();
                    break;

                case MenuChoiceEmployee.AddRoom:
                    userInput.AddRoomInput();
                    break;

                case MenuChoiceEmployee.RemoveRoom:
                    userInput.RemoveRoomByIdInput();
                    break;

                case MenuChoiceEmployee.UpdateRoomStatus:
                    userInput.UpdateRoomStatusInput();
                    break;

                case MenuChoiceEmployee.MakingReservation:
                    reservationManager.EmployeeBookRoom(employeeId);
                    break;

                case MenuChoiceEmployee.ShowSingleReservation:
                    userInput.ShowSingleReservationByIdInput();

                    break;

                case MenuChoiceEmployee.CheckIn: //need change room status
                    userInput.EmployeeReservationUpdate(employeeId);
                    break;

                case MenuChoiceEmployee.CheckOut: //need change room status
                                                  //     userInput.EmployeeCheckOutUpdate(employeeId);
                                                  //     break;


                    Console.ReadLine();
                    break;

                case MenuChoiceEmployee.ShowPaymentOption:
                    quit = userInput.PaymentChoiceInput(quit);
                    break;

                case MenuChoiceEmployee.UpdateReservationDate:
                    userInput.EmployeeReservationUpdate(employeeId);
                    break;

                case MenuChoiceEmployee.ReadReviews:
                    userInput.PrintAllReviews();
                    break;

                case MenuChoiceEmployee.RemoveReview:
                    userInput.RemoveReviewByIdInput();
                    break;

                case MenuChoiceEmployee.Quit:

                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }

    public void GetCustomerMenu(int customerId)
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceCustomer CustomerChoice = CustomerEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Customer Menu *********\n ");
            switch (CustomerChoice)
            {

                case MenuChoiceCustomer.ShowRooms:
                    userInput.PrintAllRooms();
                    break;

                case MenuChoiceCustomer.ShowAvailableRooms:
                    userInput.PrintAvailableRooms();
                    break;

                case MenuChoiceCustomer.BookRoom://not working properlly
                    reservationManager.CustomerBookRoom(customerId);
                    break;

                case MenuChoiceCustomer.ReadReviews:
                    userInput.PrintAllReviews();
                    break;

                case MenuChoiceCustomer.WriteReview:
                    userInput.WriteReviewInput();
                    break;

                case MenuChoiceCustomer.Quit:
                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }

    public void GetManagerMenu()
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            MenuChoiceManager ManagerChoice = ManagerEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Manager Menu *********\n ");
            switch (ManagerChoice)
            {
                case MenuChoiceManager.ShowRooms: 
                    userInput.PrintAllRooms();
                    break;

                case MenuChoiceManager.AddRoom: 
                    userInput.AddRoomInput();
                    break;

                case MenuChoiceManager.RemoveRoom:        
                    userInput.RemoveRoomByIdInput();
                    break;

                case MenuChoiceManager.AddEmployee:
                    userInput.AddEmployeeInput();
                    break;

                case MenuChoiceManager.RemoveEmployee:
                    userInput.RemoveEmployeeByIdInput();
                    break;

                case MenuChoiceManager.SearchEmployee: // works but without the job title name
                    userInput.SearchEmployeeByIdInput();
                    break;

                case MenuChoiceManager.ShowEmployees: 
                    userInput.PrintAllEmployees();
                    break;

                case MenuChoiceManager.AddCustomer: 
                    userInput.AddCustomerInput();
                    break;

                case MenuChoiceManager.RemoveCustomer: 
                    userInput.RemoveCustomerByIdInput();
                    break;

                case MenuChoiceManager.SearchCustomer: 
                    userInput.SearchCustomerByIdInput();
                    break;

                case MenuChoiceManager.ShowCustomers: 
                    userInput.PrintAllCustomers();
                    break;

                case MenuChoiceManager.Quit: 
                    quit = userInput.QuitMessage();
                    Environment.Exit(0);

                    break;

                default:
                    break;
            }
        }
    }

    public MenuChoiceEmployee EmployeeEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceEmployee)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceEmployee), Enum.Parse(typeof(MenuChoiceEmployee), c), "d"));
        MenuChoiceEmployee choice = (MenuChoiceEmployee)userInput.TryGetInt("Select one of the options:");
        return choice;
    }

    public RegisterLoginChoiceUser RegisterLoginSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(RegisterLoginChoiceUser)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(RegisterLoginChoiceUser), Enum.Parse(typeof(RegisterLoginChoiceUser), c), "d"));
        Console.WriteLine("Select one of the options:");
        int registerLoginInput = int.Parse(Console.ReadLine());
        RegisterLoginChoiceUser choice = (RegisterLoginChoiceUser)registerLoginInput;
        return choice;
    }

    public MenuChoiceCustomer CustomerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));
        MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)userInput.TryGetInt("Select one of the options:");
        return CustomerChoice;
    }

    public MenuChoiceManager ManagerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceManager)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceManager), Enum.Parse(typeof(MenuChoiceManager), c), "d"));
        MenuChoiceManager ManagerChoice = (MenuChoiceManager)userInput.TryGetInt("Select one of the options:");
        return ManagerChoice;
    }

    public MenuChoiceUser MenuChoiceUserEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceUser)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceUser), Enum.Parse(typeof(MenuChoiceUser), c), "d"));
        MenuChoiceUser choice = (MenuChoiceUser)userInput.TryGetInt("Select one of the options:");
        return choice;
    }
}


public enum MenuChoiceEmployee
{
    ShowRooms = 1,
    ShowAvailableRooms,
    SearchRoom,
    AddRoom,
    RemoveRoom,
    UpdateRoomStatus,
    MakingReservation,
    ShowReservations,
    ShowSingleReservation,
    UpdateReservationDate,
    CheckIn,
    CheckOut,
    ShowPaymentOption,
    ReadReviews,
    RemoveReview,
    Quit,
}
public enum MenuChoiceCustomer
{
    ShowRooms = 1,
    ShowAvailableRooms,
    BookRoom,
    ReadReviews,
    WriteReview,
    Quit,
}
public enum MenuChoiceManager
{
    ShowRooms = 1,
    AddRoom,
    RemoveRoom,
    AddEmployee,
    RemoveEmployee,
    SearchEmployee,
    ShowEmployees,
    AddCustomer,
    RemoveCustomer,
    SearchCustomer,
    ShowCustomers,
    Quit,
}

public enum MenuChoiceUser
{
    Employee = 1,
    NewCustomer,
    CustomerLogIn,
    Manager,
    Quit,
}

public enum RegisterLoginChoiceUser
{
    Register = 1,
    LogIn
}

