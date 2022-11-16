using Dapper;
using MySqlConnector;
internal class Program
{

    static RoomManager roomManager = new();
    static CustomerManager customerManager = new();
    static EmployeeManager employeeManager = new();
    static PaymentManger paymentManager = new();
    static ReservationData myResData = new();
    static ReservationManager myResManager = new();
    static ReviewManager reviewManager = new();
    static int customerID { get; set; }
    //static int employeeID {get; set; }

    static bool isLogIn = true;

    private static void Main(string[] args)
    {

        //TEST GET TIMESPAN OF RESERVATION NR1
       // Console.WriteLine(myResManager.GetTimeSpan(1));
        
        foreach ( string c in Enum.GetNames(typeof (MenuChoiceUser )) )
        Console.WriteLine( "{0,-11}= {1}", c, Enum.Format( typeof (MenuChoiceUser ) , Enum.Parse(typeof (MenuChoiceUser ) , c), "d"));
        Console.WriteLine("Select one of the options:");
        int input =int.Parse(Console.ReadLine ());
        MenuChoiceUser choice=(MenuChoiceUser )input ;
        switch (choice)
        {
            case MenuChoiceUser.Employee:
            
                 if (GetEmployeeLogIn())
                {
                    GetEmployeeMenu();
                }
                break;

            case MenuChoiceUser.Customer:
                if (GetCustomerLogIn())
                {
                    GetCustomerMenu(); ;
                }
                break;

            case MenuChoiceUser.Manager:
                if (GetCustomerLogIn())
                {
                    GetManagerMenu();
                }
                break;

            default:
                break;

        }
    }

    private static void GetEmployeeMenu()
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceEmployee choice = EmployeeEnumSwitch();

            switch (choice)
            {
                case MenuChoiceEmployee.ShowRooms://is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceEmployee.ShowAvailableRooms://is done Tina!
                    PrintAvailableRooms();
                    break;

                case MenuChoiceEmployee.SearchRoom://is done Tina!
                    SearchRoomInput();
                    break;

                case MenuChoiceEmployee.BookRoom://is done Tina!
                    EmployeeBookRoom();
                    break;

                case MenuChoiceEmployee.CheckIn:
                    break;

                case MenuChoiceEmployee.CheckOut:
                    break;

                case MenuChoiceEmployee.AddRoom: //is done Tina!
                    AddRoomMenyInput();
                    break;

                case MenuChoiceEmployee.RemoveRoom://is done TINA!        
                    RemoveRoomInput();
                    break;

                case MenuChoiceEmployee.Receipt: //is done Jessica!
                    quit = ReceiptInput(quit);
                    break;

                case MenuChoiceEmployee.Payment://is done! Jessica
                    quit = PaymentChoiceInput(quit);
                    break;

                case MenuChoiceEmployee.UpdateRoom://is done! Jessica
                    UppdateRoomInput();
                    break;

                case MenuChoiceEmployee.UpdateReservation://please take a look /Johan
                    UpdateReservation();
                    break;

                case MenuChoiceEmployee.ReadReviews:
                    break;


                case MenuChoiceEmployee.RemoveReview:
                    break;

                case MenuChoiceEmployee.Quit: //is done!
                    quit = QuitMessage();
                    break;

                default:
                    break;
            }
        }
    }

    private static void GetCustomerMenu()
    {
        bool quit = true;
        while (quit)
        {
            MenuChoiceCustomer CustomerChoice = CustomerEnumSwitch();

            switch (CustomerChoice)
            {
                case MenuChoiceCustomer.ShowRooms://is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceCustomer.ShowAvailableRooms:// is done Tina!
                    PrintAvailableRooms();
                    break;

                case MenuChoiceCustomer.BookRoom:
                    myResManager.CustomerBookRoom();
                    break;

                case MenuChoiceCustomer.ReadReviews://is done Tina
                    PrintAllReviews();
                    break;

                case MenuChoiceCustomer.WriteReview://is done Tina
                    WriteReviewInput();
                    break;

                case MenuChoiceCustomer.Quit: // is done Tina!
                    quit = QuitMessage();
                    break;

                default:
                    break;

            }
        }
    }

    // private static void CustomerBookRoom()
    // {
    //     Console.WriteLine("Book room");

    //     int customerIdBooking = customerID;
    //     Console.WriteLine("Enter a from-date: ");
    //     DateTime userDateIn;
    //     if (DateTime.TryParse(Console.ReadLine(), out userDateIn))
    //     {
    //         Console.WriteLine("you choosed: " + userDateIn);
    //     }
    //     else
    //     {
    //         Console.WriteLine("You have entered an incorrect value.");
    //     }


    //     Console.WriteLine("Enter a to-date: ");
    //     DateTime userDateOut;
    //     if (DateTime.TryParse(Console.ReadLine(), out userDateOut))
    //     {
    //         Console.WriteLine("you choosed: " + userDateOut);
    //     }
    //     else
    //     {
    //         Console.WriteLine("You have entered an incorrect value.");
    //     }
    //     Console.ReadLine();

    //     List<Reservation> dateInList = new();
    //     List<Reservation> dateInOut = new();
    //     List<Reservation> availabeRooms = new();
    //     foreach (var item in myResData.GetReservationData())
    //     {
    //         if (userDateIn > item.date_in)
    //         {
    //             dateInList.Add(item);
    //         }
    //     }

    //     foreach (var listItem in dateInList)
    //     {
    //         if (userDateIn > listItem.date_out)
    //         {
    //             bool add_it = true;
    //             foreach (var room in availabeRooms)
    //             {
    //                 if (room.room_id == listItem.room_id)
    //                 {
    //                     add_it = false;
    //                     break;
    //                 }
    //             }
    //             if (add_it)
    //                 availabeRooms.Add(listItem);
    //         }
    //     }

    //     foreach (var item in myResData.GetReservationData())
    //     {

    //         if (userDateIn < item.date_in)
    //         {
    //             dateInOut.Add(item);
    //         }
    //     }

    //     foreach (var item in dateInOut)
    //     {
    //         if (userDateOut < item.date_in)
    //         {
    //             bool add_it = true;
    //             foreach (var room in availabeRooms)
    //             {
    //                 if (room.room_id == item.room_id)
    //                 {
    //                     add_it = false;
    //                     break;
    //                 }
    //             }
    //             if (add_it)
    //                 availabeRooms.Add(item);
    //         }
    //     }

    //     foreach (var gg in availabeRooms)
    //     {
    //         Console.WriteLine("room nr: " + gg.room_id);
    //     }
    //     DateTime todaysDate = DateTime.Now;
    //     Console.WriteLine("Choose room to book: ");
    //     int roomSelected = Int32.Parse(Console.ReadLine());
    //     myResData.MakeReservationCustomer(customerIdBooking, roomSelected, todaysDate, userDateIn, userDateOut);
    //     Console.WriteLine($"You have booked room nr {roomSelected} from: {userDateIn} to: {userDateOut}.");
    //     Console.ReadKey();
    //     Console.Clear();
    // }

    private static void EmployeeBookRoom()
    {

       
        Console.WriteLine("Book room");
        Console.WriteLine("Enter customer ID: ");
        int customerIdBooking = Int32.Parse(Console.ReadLine());
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
        foreach (var item in myResData.GetReservationData())
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

        foreach (var item in myResData.GetReservationData())
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
        Console.WriteLine("Choose room to book: ");
        int roomSelected = Int32.Parse(Console.ReadLine());
        myResData.MakeReservationCustomer(customerIdBooking, roomSelected, todaysDate, userDateIn, userDateOut);
        Console.WriteLine($"You have booked room nr {roomSelected} from: {userDateIn} to: {userDateOut}.");
        Console.ReadKey();
        Console.Clear();
    }

    private static void GetManagerMenu()   // ID = 2 PASSWORD = 2
    {
        bool quit = true;
        while (quit)
        {
            MenuChoiceManager ManagerChoice = ManagerEnumSwitch();

            switch (ManagerChoice)
            {
                case MenuChoiceManager.ShowRoom: //is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceManager.AddRoom: //is done Tina!
                    AddRoomMenyInput();
                    break;

                case MenuChoiceManager.RemoveRoom:   //is done Tina!     
                    RemoveRoomInput();
                    break;

                case MenuChoiceManager.AddEmployee:// is done Tina!
                    AddEmployeeInput();
                    break;

                case MenuChoiceManager.RemoveEmployee:// is done! Jessica
                    RemoveEmployeeInput();
                    break;

                case MenuChoiceManager.SearchEmployee: // works but without the job title name
                    SearchEmployeeInput();
                    break;

                case MenuChoiceManager.ShowEmployees: // is done! Jessica
                    PrintAllEmployees();
                    break;

                case MenuChoiceManager.AddCustomer: // is done Tina!
                    AddCustomerInput();
                    break;

                case MenuChoiceManager.RemoveCustomer: // is done Tina
                    //RemoveCustomerInput();

                    Console.WriteLine("Review Id to be removed:"); // it works on database but program keeps giving me exeption message!!!!!!

                    int removId = int.Parse(Console.ReadLine());
                    try
                    {
                        reviewManager.RemoveReviewById(removId);
                    }
                    catch (System.Exception)
                    {

                        throw new FieldAccessException();
                    }
                    Console.ReadLine();
                    break;

                case MenuChoiceManager.SearchCustomer: //is done Tina!
                    SearchCustomerInput();
                    break;

                case MenuChoiceManager.ShowCustomers: // is done Tina!
                    PrintAllCustomers();
                    break;

                case MenuChoiceManager.Quit: //is done!
                    quit = QuitMessage();
                    break;

                default:
                    break;
            }
        }
    }

    private static void WriteReviewInput()
    {
        Console.WriteLine("Enter account number:");
        int customerId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter reservation number:");
        int reservationId = int.Parse(Console.ReadLine());
        Console.WriteLine("Write your review:");
        string review = Console.ReadLine();
        Console.WriteLine("Review Id:");
        Console.WriteLine(reviewManager.WriteReview(customerID, reservationId, review));
        Console.ReadLine();
    }

    private static void PrintAllReviews()
    {
        Console.WriteLine("View Reviews");
        try
        {
            if (reviewManager.ShowAllReviews() != null)
            {
                foreach (var item in reviewManager.ShowAllReviews())
                {
                    Console.WriteLine(item);
                }
            }

        }
        catch (Exception e)
        {

            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static bool ReceiptInput(bool quit)
    {
        AddPaymentInput();
        Console.WriteLine("Do you want a receipt? Y/N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            SearchPaymentInput();
            quit = false;
        }
        else if (answer == "n")
        {
            Console.WriteLine("No receipt chosen!");
            quit = false;
        }
        else
        {
            Console.WriteLine("your choice does not exist!");

        }

        return quit;
    }

    private static bool PaymentChoiceInput(bool quit)
    {
        Console.WriteLine("Choose your option: [1]Print all payments [2]Add payment [3]Search payment [4]Remove payment");
        string option = Console.ReadLine();
        if (option == "1")
        {
            PrintAllPayments();
            quit = false;
        }
        else if (option == "2")
        {
            AddPaymentInput(); //it does not inseart the customer Id, dont not know why Tina!
            quit = false;
        }
        else if (option == "3")
        {
            SearchPaymentInput();
            quit = false;
        }
        else if (option == "4")
        {
            RemovePaymentInput();
            quit = false;
        }
        else
        {
            Console.WriteLine("Select one of the number!");
        }
        Console.ReadLine();
        return quit;
    }

    private static void RemovePaymentInput()
    {
        Console.WriteLine("Remove a payment!");
        Console.WriteLine("Payment Id to be removed: ");
        if (int.TryParse(Console.ReadLine(), out int rPaymentId))
        {
            paymentManager.RemovePayment(rPaymentId);
        }
        else
        {
            Console.WriteLine("Input prayment ID number!");
        }
    }

    private static void SearchPaymentInput()
    {
        Console.WriteLine("Search Payment!");
        Console.WriteLine("Searching Payment ID: ");
        if (int.TryParse(Console.ReadLine(), out int searchPaymentId))
        {

            try
            {
                if (paymentManager.SearchPayment(searchPaymentId) != null)
                {
                    Console.WriteLine(paymentManager.SearchPayment(searchPaymentId));
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException();
            }
        }
        else
        {
            Console.WriteLine("Input Id number!");
        }
        Console.ReadLine();
    }

    private static void SearchEmployeeInput()
    {
        Console.WriteLine("Search Employee!");
        Console.WriteLine("Employee Id:");
        int searchEmployeeId = int.Parse(Console.ReadLine());
        try
        {
            if (employeeManager.SearchEmployee(searchEmployeeId) != null)
            {
                Console.WriteLine(employeeManager.SearchEmployee(searchEmployeeId));
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void AddPaymentInput()
    {
        Console.WriteLine("Add payment!");
        Console.WriteLine("Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());
        Console.WriteLine("Payment date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Payment amount: ");
        double payAmount = double.Parse(Console.ReadLine());
        Console.WriteLine("Reservation ID: ");
        int reservationId = int.Parse(Console.ReadLine());
        Console.WriteLine("Payment name: ");
        string? paymentName = Console.ReadLine();
        Console.WriteLine("Bank information");
        string? payBankInfor = Console.ReadLine();
        Console.WriteLine("Added new payment ID: ");
        Console.WriteLine(paymentManager.AddPayment(customerID, date, payAmount, reservationId, paymentName, payBankInfor));
        Console.ReadLine();
    }

    private static void RemoveEmployeeInput()
    {
        Console.WriteLine("Delete Employee!");
        Console.WriteLine("Employee Id: ");
        int deleteEmployeeId = int.Parse(Console.ReadLine());
        employeeManager.RemoveEmployee(deleteEmployeeId);
        Console.WriteLine("Employee has been removed!");
        Console.ReadLine();
    }

    private static void PrintAllCustomers()
    {
        Console.WriteLine("Show AllCustomer!");
        try
        {
            if (customerManager.ShowAllCustomers() != null)
            {
                foreach (var item in customerManager.ShowAllCustomers())
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void SearchCustomerInput()
    {
        Console.WriteLine("Search Customer!");
        Console.WriteLine("Customer Id:");
        int searchCustomerId = int.Parse(Console.ReadLine());
        try
        {
            if (customerManager.SearchCustomerById(searchCustomerId) != null)
            {
                Console.WriteLine(customerManager.SearchCustomerById(searchCustomerId));
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void PrintAllEmployees()
    {
        Console.WriteLine("Show All Employees!");
        try
        {
            if (employeeManager.ShowEmployees() != null)
            {
                foreach (var item in employeeManager.ShowEmployees())
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void PrintAllPayments()
    {
        Console.WriteLine("All payments!");// is done!
        try
        {
            if (paymentManager.ShowAllPayments() != null)
            {
                foreach (var item in paymentManager.ShowAllPayments())
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void PrintAllRooms()
    {
        Console.WriteLine("All rooms!");
        try
        {
            if (roomManager.ShowAllRooms() != null)
            {
                foreach (var item in roomManager.ShowAllRooms())
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void PrintAvailableRooms()
    {
        Console.WriteLine("Available rooms!");
        try
        {
            if (roomManager.ShowAvailableRoom() != null)
            {
                foreach (var item in roomManager.ShowAvailableRoom())
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }

        Console.ReadLine();
    }

    private static void UppdateRoomInput()
    {
        Console.WriteLine("Update room status");
        foreach (var item in roomManager.ShowAllRooms())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Choose room to update: ");
        string roomToUpdate = Console.ReadLine();
        Console.WriteLine("Choose room status: \n [1] checked in \n [2] check out \n [3] reserved \n [4] not in use");
        string newRoomStatus = Console.ReadLine();
        roomManager.UpdateRoomStatusID(roomToUpdate, newRoomStatus);
        Console.WriteLine("Room is updated!");
    }

    private static void UpdateReservation()
    {
        Console.WriteLine("[1]Update check in date \n[2]Update check out date ");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.Clear();
            foreach (var item in myResData.GetReservationList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Choose reservation ID: ");
            int resID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Choose new check in date: ");
            DateTime userDateIn;
            if (DateTime.TryParse(Console.ReadLine(), out userDateIn))
            {
                Console.WriteLine("you choosed: " + userDateIn);
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }

            myResData.UpdateReservationDateIn(resID, userDateIn);
            Console.WriteLine($"You have updated reservation nr {resID} New check in date: {userDateIn}.");
            Console.ReadKey();

        }

        if (choice == "2")
        {
            Console.Clear();
            foreach (var item in myResData.GetReservationList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Choose reservation ID: ");
            int resID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Choose new check out date: ");
            DateTime userDateOut;
            if (DateTime.TryParse(Console.ReadLine(), out userDateOut))
            {
                Console.WriteLine("you choosed: " + userDateOut);
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }

            myResData.UpdateReservationDateOut(resID, userDateOut);
            Console.WriteLine($"You have updated reservation nr {resID} New check out date: {userDateOut}.");
            Console.ReadKey();
        }
    }

    private static void RemoveRoomInput()
    {
        Console.WriteLine("Delete Room!");
        Console.WriteLine("Room Id: ");
        int deleteRoomId = int.Parse(Console.ReadLine());
        roomManager.RemoveRoomById(deleteRoomId);
        Console.WriteLine("Room has been deleted!");
        Console.ReadLine();
    }

    private static void SearchRoomInput()
    {
        Console.WriteLine("Search Room!");
        Console.WriteLine("Room Id: ");
        int searchRoomId = int.Parse(Console.ReadLine());
        try
        {
            if (roomManager.SearchRoomById(searchRoomId) != null)
            {
                Console.WriteLine(roomManager.SearchRoomById(searchRoomId));
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static bool GetCustomerLogIn()
    {
        
            Customer customer = new();
            Console.WriteLine("Please enter your ID: ");
            customerID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter password");
            string customerPass = Console.ReadLine();

            if (customerID == 2 && customerPass == "2")
            {
                return true;         
            }
           else
           return false;
        
    }

    private static bool GetEmployeeLogIn()
    {

        int employeeID;
        string employeePass;

        GetEmployeeID(out employeeID, out employeePass);

        if (employeeID == 1 && employeePass == "1")

            return true;

        else
            return false;          
    }

    private static void GetEmployeeID(out int employeeID, out string employeePass)
    {
        Console.WriteLine("Please enter your ID: "); //For-loop i<3?
        employeeID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter password");
        employeePass = Console.ReadLine();
    }

    private static MenuChoiceEmployee EmployeeEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceEmployee)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceEmployee), Enum.Parse(typeof(MenuChoiceEmployee), c), "d"));

        Console.WriteLine("Select one of the options:");
        int employeeInput = int.Parse(Console.ReadLine());
        MenuChoiceEmployee choice = (MenuChoiceEmployee)employeeInput;
        return choice;
    }

    private static MenuChoiceCustomer CustomerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));


        Console.WriteLine("Select one of the options:");
        int CustomerInput = int.Parse(Console.ReadLine());
        MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)CustomerInput;
        return CustomerChoice;
    }

    private static MenuChoiceManager ManagerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceManager)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceManager), Enum.Parse(typeof(MenuChoiceManager), c), "d"));

        Console.WriteLine("Select one of the options:");
        int ManagerInput = int.Parse(Console.ReadLine());
        MenuChoiceManager ManagerChoice = (MenuChoiceManager)ManagerInput;
        return ManagerChoice;
    }

    private static void AddRoomMenyInput()
    {   // do not need room id, it will return added room id.
        Console.WriteLine("TYPE ID: ");
        int tid = int.Parse(Console.ReadLine());
        Console.WriteLine("STATUS ID");
        int sid = int.Parse(Console.ReadLine());
        Console.WriteLine("price");
        double p = double.Parse(Console.ReadLine());
        Console.WriteLine("Added room ID:");
        Console.WriteLine(roomManager.AddRoom(tid, sid, p));
        Console.ReadLine();
    }

    private static void AddEmployeeInput()
    {
        Console.WriteLine("Add employee!");
        Console.WriteLine("Job Title ID: ");
        int addJobTitleId = int.Parse(Console.ReadLine());
        Console.WriteLine("First name");
        string addEmployeeFname = Console.ReadLine();
        Console.WriteLine("Last name");
        string addEmployeeLName = Console.ReadLine();
        Console.WriteLine("Phone: ");
        int addEmployeePhone = int.Parse(Console.ReadLine());
        Console.WriteLine("Email: ");
        string addEmpoyeeEmail = Console.ReadLine();
        int addEId = employeeManager.AddEmployee(addJobTitleId, addEmployeeFname, addEmployeeLName, addEmployeePhone, addEmpoyeeEmail);
        Console.WriteLine("Added customer ID: ");
        Console.WriteLine(addEId);
    }

    private static void AddCustomerInput()
    {
        Console.WriteLine("Add customer!");
        Console.WriteLine("First name: ");
        string? addCustomerFName = Console.ReadLine();
        Console.WriteLine("Last name: ");
        string? addCustomerLName = Console.ReadLine();
        Console.WriteLine("Phone: ");
        int addCustomerPhone = int.Parse(Console.ReadLine());
        Console.WriteLine("Email: ");
        string? addCustomerEmail = Console.ReadLine();
        Console.WriteLine("City: ");
        string? addCustomerCity = Console.ReadLine();
        Console.WriteLine("Country: ");
        string? addCustomerCountry = Console.ReadLine();
        Console.WriteLine("Address: ");
        string? addCustomerAddress = Console.ReadLine();
        int addId = customerManager.AddCustomer(addCustomerFName, addCustomerLName, addCustomerPhone, addCustomerEmail, addCustomerCity, addCustomerCountry, addCustomerAddress);
        Console.WriteLine("Added customer ID: ");
        Console.WriteLine(addId);
        Console.ReadLine();
    }

    private static void RemoveCustomerInput()
    {
        Console.WriteLine("Delete Customer!");
        Console.WriteLine("Customer Id: ");
        int deleteCustomerId = int.Parse(Console.ReadLine());
        customerManager.RemoveCustomerById(deleteCustomerId);
        Console.ReadLine();
    }

    private static void NoTryMessage()
    {
        Console.Write("\nNO more try. Bye!");
    }

    private static void LoginWrongMessage()
    {
        Console.Write("\nLoggin unsucced, try again!");
    }

    private static bool QuitMessage()
    {
        bool quit;
        Console.WriteLine("You have chosen to quit the program");
        quit = false;
        return quit;
    }

}
