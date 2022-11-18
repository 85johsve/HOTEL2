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
    static bool employeeIsLoggedIn;
    //static int employeeID {get; set; }

    static bool managerIsLoggedIn;
    static bool customerIsLoggedIn;

    private static void Main(string[] args)
    {
        //TEST GET TIMESPAN OF RESERVATION NR1
        // Console.WriteLine(myResManager.GetTimeSpan(1));
        Console.WriteLine("\n********* Main Menu *********\n ");
        MenuChoiceUser choice = MenuChoiceUserEnumSwitch();
        Console.Clear();
        switch (choice)
        {
            case MenuChoiceUser.Employee:

                GetEmployeeLogIn();
                if (employeeIsLoggedIn)
                {
                    GetEmployeeMenu();
                    break;
                }
                else
                {
                   MenuChoiceUserEnumSwitch();
                }
                break;
             case MenuChoiceUser.NewCustomer:
                AddCustomerInput();
                GetCustomerLogIn();
                if (customerIsLoggedIn)
                {
                    GetCustomerMenu();
                      break;
                }
                else
                {
                   MenuChoiceUserEnumSwitch();
                }
                break;

            case MenuChoiceUser.CustomerLogIn:
                //RegisterOrLoginChoice();
                GetCustomerLogIn();
                 if (customerIsLoggedIn)
                {
                     GetCustomerMenu();
                      break;
                }
                else
                {
                   MenuChoiceUserEnumSwitch();
                }
                break;

            case MenuChoiceUser.Manager:
            GetManagerLogIn();
                if (managerIsLoggedIn)
                {
                    GetManagerMenu();
                     break;
                }
                else
                {
                   MenuChoiceUserEnumSwitch();
                }
                break;

            case MenuChoiceUser.Quit:
                Environment.Exit(0);
                break;

            default:
                break;

        }
    }

    private static MenuChoiceUser MenuChoiceUserEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceUser)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceUser), Enum.Parse(typeof(MenuChoiceUser), c), "d"));
        // Console.WriteLine("Select one of the options:");
        // int input = int.Parse(Console.ReadLine());
        MenuChoiceUser choice = (MenuChoiceUser)TryGetInt("Select one of the options:");// Tina. use TryGetInt for input
        return choice;
    }

    private static void GetEmployeeMenu()
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceEmployee choice = EmployeeEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Employee Menu *********\n ");
            switch (choice)
            {
                case MenuChoiceEmployee.ShowRooms://is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceEmployee.ShowAvailableRooms://is done Tina!
                    PrintAvailableRooms();
                    break;

                case MenuChoiceEmployee.ShowReservations:
                    Console.Clear();
                    foreach (var item in myResData.GetReservationList())
                    {
                        Console.WriteLine(item);

                    }
                    Console.ReadKey();
                    break;

                case MenuChoiceEmployee.SearchRoom://is done Tina!
                    SearchRoomByIdInput();
                    break;

                case MenuChoiceEmployee.BookRoom://is done Tina!
                    myResManager.EmployeeBookRoom();
                    break;

                case MenuChoiceEmployee.CheckIn: //is done! Jessica
                    EmployeeCheckInUpdate();
                    break;

                case MenuChoiceEmployee.CheckOut: //is done! Jessica
                    EmployeeCheckOutUpdate();
                    break;

                case MenuChoiceEmployee.AddRoom: //is done Tina!
                    AddRoomInput();
                    break;

                case MenuChoiceEmployee.RemoveRoom://is done TINA!        
                    RemoveRoomByIdInput();
                    break;

                case MenuChoiceEmployee.Receipt: //is done Jessica!
                    quit = ReceiptOptionInput(quit);
                    break;

                case MenuChoiceEmployee.Payment://is done! Jessica
                    quit = PaymentChoiceInput(quit);
                    break;

                case MenuChoiceEmployee.UpdateRoom://is done! Jessica
                    RoomUpdateInput();
                    break;

                case MenuChoiceEmployee.UpdateReservationDate:// is done! Johan
                    ReservationUpdateInput();
                    break;

                case MenuChoiceEmployee.ReadReviews: // is done! Jessica
                    PrintAllReviews();
                    break;


                case MenuChoiceEmployee.RemoveReview: //is done Jessica
                    RemoveReviewByIdInput();
                    break;

                case MenuChoiceEmployee.Quit: //is done! Jessica
                    quit = QuitMessage();
                    break;

                default:
                    break;
            }
        }
    }

    private static void GetCustomerMenu()
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceCustomer CustomerChoice = CustomerEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Customer Menu *********\n ");
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

    private static void GetManagerMenu()   // ID = 2 PASSWORD = 2
    {
        bool quit = false;
        while (!quit)
        {
            MenuChoiceManager ManagerChoice = ManagerEnumSwitch();
            Console.Clear();
            Console.WriteLine("\n********* Manager Menu *********\n ");
            switch (ManagerChoice)
            {
                case MenuChoiceManager.ShowRoom: //is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceManager.AddRoom: //is done Tina!
                    AddRoomInput();
                    break;

                case MenuChoiceManager.RemoveRoom:   //is done Tina!     
                    RemoveRoomByIdInput();
                    break;

                case MenuChoiceManager.AddEmployee:// is done Tina!
                    AddEmployeeInput();
                    break;

                case MenuChoiceManager.RemoveEmployee:// is done! Jessica
                    RemoveEmployeeByIdInput();
                    break;

                case MenuChoiceManager.SearchEmployee: // works but without the job title name
                    SearchEmployeeByIdInput();
                    break;

                case MenuChoiceManager.ShowEmployees: // is done! Jessica
                    PrintAllEmployees();
                    break;

                case MenuChoiceManager.AddCustomer: // is done Tina!
                    AddCustomerInput();
                    break;

                case MenuChoiceManager.RemoveCustomer: // is done Tina
                    RemoveCustomerByIdInput();
                    break;

                case MenuChoiceManager.SearchCustomer: //is done Tina!
                    SearchCustomerByIdInput();
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

    // private static void RegisterOrLoginChoice()
    // {
    //     RegisterLoginChoiceUser choice = RegisterLoginSwitch();
    //     Console.Clear();
    //     switch (choice)
    //     {
    //         case RegisterLoginChoiceUser.Register:
    //             AddCustomerInput();
    //             if (GetCustomerLogIn())
    //             {
    //                 GetCustomerMenu();
    //                 //Warning. You will be logged in even if you insert wrong log in.
    //             }
    //             else
    //             {
    //                 GetCustomerLogIn();
    //             }
    //             break;
    //         case RegisterLoginChoiceUser.LogIn:
    //             if (GetCustomerLogIn())
    //             {
    //                 GetCustomerMenu();
    //             }
    //             else
    //             {
    //                 return;
    //             }
    //             break;

    //     }
    // }

    private static void EmployeeCheckOutUpdate()
    {
        Console.WriteLine("Update room status to Checked out");
        foreach (var item in roomManager.ShowAllRooms())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Choose room to check out: ");
        string roomToCheckOut = Console.ReadLine();
        string newRoomCheckOutStatus = "2";
        roomManager.CheckOutRoomStatusID(roomToCheckOut, newRoomCheckOutStatus);
        Console.WriteLine("Room status has now changed to Checked Out!");
    }

    private static void EmployeeCheckInUpdate()
    {
        Console.WriteLine("Update room status to Checked in");
        foreach (var item in roomManager.ShowAllRooms())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Choose room to check in: ");
        string roomToCheckIn = Console.ReadLine();
        string newRoomCheckInStatus = "1";
        roomManager.CheckInRoomStatusID(roomToCheckIn, newRoomCheckInStatus);
        Console.WriteLine("Room status has now changed to Checked in!");
    }

    private static void RemoveReviewByIdInput()
    {
        Console.Clear();
        Console.WriteLine("********* Remove review by Id ********* ");
        try
        {
            reviewManager.RemoveReviewById(TryGetInt("Review Id to be removed:"));
            Console.WriteLine("The review has been removed!");
        }
        catch (System.Exception)
        {
            throw new FieldAccessException();
        }
        Console.ReadLine();
    }

    private static void WriteReviewInput()
    {
        Console.Clear();
        Console.WriteLine("********* Write Review ********* ");
        // Console.WriteLine("Enter account number:");
        // int customerId = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter reservation number:");
        // int reservationId = int.Parse(Console.ReadLine());
        // Console.WriteLine("Write your review:");
        // string review = Console.ReadLine();
        // Console.WriteLine("Review Id:");
        Console.WriteLine("Your Review Id: " + reviewManager.WriteReview(TryGetInt("Enter account number:"), TryGetInt("Enter reservation number:"), GetString("Write your review: \n")));
        Console.ReadLine();
    }

    private static void PrintAllReviews()
    {
        Console.Clear();
        Console.WriteLine("********* All Reviews ********* ");
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

    private static bool ReceiptOptionInput(bool quit)
    {
        Console.Clear();
        Console.WriteLine("********* Receipt option ********* ");
        AddPaymentInput();
        Console.WriteLine("Do you want a receipt? Y/N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            SearchPaymentByIdInput();
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
        Console.Clear();
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
            SearchPaymentByIdInput();
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
        Console.WriteLine("\n******* Remove a payment ********\n");
        Console.WriteLine("Payment Id to be removed: ");
        if (int.TryParse(Console.ReadLine(), out int rPaymentId))
        {
            paymentManager.RemovePaymentById(rPaymentId);
        }
        else
        {
            Console.WriteLine("Input prayment ID number!");
        }
    }

    private static void SearchPaymentByIdInput()
    {
        Console.WriteLine("\n******* Search a payment by Id ********\n");
        Console.WriteLine("Searching Payment ID: ");
        if (int.TryParse(Console.ReadLine(), out int searchPaymentId))
        {

            try
            {
                if (paymentManager.SearchPaymentById(searchPaymentId) != null)
                {
                    Console.WriteLine(paymentManager.SearchPaymentById(searchPaymentId));
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

    private static void SearchEmployeeByIdInput()
    {
        Console.WriteLine("\n******* Search Employee by Id ********\n");
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

        Console.WriteLine("\n******* Add a payment ********\n");
        Console.WriteLine("Payment date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Added new payment ID: ");
        Console.WriteLine(paymentManager.AddPayment(TryGetInt("Customer ID: "), date, GetDouble("Payment amount:"), TryGetInt("Reservation ID: "), GetString("Payment name: "), GetString("Bank information")));
        Console.ReadLine();
    }

    private static void RemoveEmployeeByIdInput()
    {
        Console.WriteLine("\n******* Remove a employee by Id ********\n");
        Console.WriteLine("Employee Id: ");
        int deleteEmployeeId = int.Parse(Console.ReadLine());
        employeeManager.RemoveEmployeeById(deleteEmployeeId);
        Console.WriteLine("Employee has been removed!");
        Console.ReadLine();
    }

    private static void PrintAllCustomers()
    {
        Console.WriteLine("\n******* Show all customers ********\n");
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

    private static void SearchCustomerByIdInput()
    {
        Console.WriteLine("\n******* Search customer by Id ********\n");
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
        Console.WriteLine("\n******* All Employees ********\n");
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
        Console.WriteLine("\n******* All Payments ********\n");// is done!
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
        Console.WriteLine("\n******* All Rooms ********\n");
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
        Console.WriteLine("\n******* All Available Rooms ********\n");
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

    private static void RoomUpdateInput()  //GETSTRING DOES NOT WORK
    {
        // TryGetInt("Room Id: ");
        // GetString("Choose room to update: ");
        Console.WriteLine("\n******* Update room status ********\n");

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

    private static void ReservationUpdateInput()
    {
        Console.WriteLine("\n******* Update Reservation ********\n");
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
            Reservation myRoom = myResData.GetSingleReservationById(resID);
            double newDateTime = myResManager.GetTimeSpanByDates(userDateIn, myRoom.date_out);
            myResData.UpdateReservationDateIn(resID, userDateIn, newDateTime);
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

            Reservation myRoom = myResData.GetSingleReservationById(resID);
            double newDateTime = myResManager.GetTimeSpanByDates(myRoom.date_in, userDateOut);
            myResData.UpdateReservationDateOut(resID, userDateOut, newDateTime);
            Console.WriteLine($"You have updated reservation nr {resID} New check out date: {userDateOut}.");
            Console.ReadKey();
        }
    }

    private static void RemoveRoomByIdInput()
    {
        Console.WriteLine("\n******* Remove room by Id ********\n");
        roomManager.RemoveRoomById(TryGetInt("Room Id: "));
        Console.WriteLine("Room has been deleted!");
        Console.ReadLine();
    }

    private static void SearchRoomByIdInput()
    {
        Console.WriteLine("\n******* Search room by Id ********\n");
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

    private static void GetCustomerLogIn()
    {
        Console.Clear();
        Console.WriteLine("********* Customer Log In ********* ");
        int temp = 0;
        while (temp < 3)
        {
            int id =TryGetInt("Please enter your ID: ");
            string name=GetString("Enter First Name:\n");
            if  (customerManager.CustomerLogInNameId(id, name))
            {          
               customerIsLoggedIn =true ;  
               break;                          
            }      
           else 
            {

               if(temp<2)
               Console.Write("\nLoggin unsucced, try again!\n");
               
               else
               Console.Write("\nNO more try. Bye!\n");
            }
            temp++;


         
        }
    }

    private static void GetEmployeeLogIn()
    {
        Console.Clear();
        Console.WriteLine("*********Employee Log In ********* ");
         int temp = 0;
        while (temp < 3)
        {
            int id =TryGetInt("Please enter your ID: ");
            string name=GetString("Enter First Name:\n");
            if  (employeeManager.EmployeeLogInNameId(id, name))
            {          
               employeeIsLoggedIn =true ;  
               break;                          
            }      
           else 
            {

               if(temp<2)
               Console.Write("\nLoggin unsucced, try again!\n");
               
               else
               Console.Write("\nNO more try. Bye!\n");
            }
            temp++;


         
        }
    }

    private static void GetManagerLogIn()
    {
        Console.Clear();
        Console.WriteLine("********* Manager Log In ********* ");
         int temp = 0;
        while (temp < 3)
        {
            int id =TryGetInt("Please enter your ID: ");
            string name=GetString("Enter First Name:\n");
            if  (employeeManager.ManagerLogInNameId(id, name))
            {          
               managerIsLoggedIn =true ;  
               break;                          
            }      
           else 
            {
               if(temp<2)
               Console.Write("\nLoggin unsucced, try again!\n");      
               else
               Console.Write("\nNO more try. Bye!\n");
            }
            temp++;


         
        }
    }

    private static MenuChoiceEmployee EmployeeEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceEmployee)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceEmployee), Enum.Parse(typeof(MenuChoiceEmployee), c), "d"));
        MenuChoiceEmployee choice = (MenuChoiceEmployee)TryGetInt("Select one of the options:");
        return choice;
    }

    private static RegisterLoginChoiceUser RegisterLoginSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(RegisterLoginChoiceUser)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(RegisterLoginChoiceUser), Enum.Parse(typeof(RegisterLoginChoiceUser), c), "d"));

        Console.WriteLine("Select one of the options:");
        int registerLoginInput = int.Parse(Console.ReadLine());
        RegisterLoginChoiceUser choice = (RegisterLoginChoiceUser)registerLoginInput;
        return choice;
    }

    private static MenuChoiceCustomer CustomerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));
        MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)TryGetInt("Select one of the options:");
        return CustomerChoice;
    }

    private static MenuChoiceManager ManagerEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceManager)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceManager), Enum.Parse(typeof(MenuChoiceManager), c), "d"));
        MenuChoiceManager ManagerChoice = (MenuChoiceManager)TryGetInt("Select one of the options:");
        return ManagerChoice;
    }

    private static void AddRoomInput()//Tina, put in one Console.Write()
    {   // do not need room id, it will return added room id.
        Console.WriteLine("********* Add Room ********* ");
        Console.WriteLine("price");
        double p = double.Parse(Console.ReadLine());
        //Console.WriteLine("Added room ID:");
        Console.WriteLine("Added room ID: " + roomManager.AddRoom(TryGetInt("TYPE ID: "), TryGetInt("STATUS ID"), p));
        Console.ReadLine();
    }

    private static void AddEmployeeInput()//Tina, change the formation, put all in one Console.Write()
    {
        Console.WriteLine("********* Add Employee ********* ");
        Console.WriteLine("Added employee ID: " + employeeManager.AddEmployee(TryGetInt("Job Title ID: "), GetString("First name"), GetString("Last name"), TryGetInt("Phone: "), GetString("Email: ")));
        // Console.WriteLine("Added customer ID: "))
        // int addEId = employeeManager.AddEmployee(TryGetInt("Job Title ID: "), GetString("First name"), GetString("Last name"), TryGetInt("Phone: "), GetString("Email: "));
        // Console.WriteLine("Added customer ID: ");
        // Console.WriteLine(addEId);
        Console.ReadLine();
    }

    private static void AddCustomerInput()//Tina, change the formation, put all in one Console.Write()
    {
        Console.WriteLine("*********\n Register New Customer \n********* ");
        Console.WriteLine("Added customer ID: " + customerManager.AddCustomer(GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: "), GetString("City: "), GetString("Country: "), GetString("Address: ")));
        // int addId = customerManager.AddCustomer(GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: "), GetString("City: "), GetString("Country: "), GetString("Address: "));
        // Console.WriteLine("Added customer ID: ");
        // Console.WriteLine(addId);
        Console.ReadLine();
    }

    private static void RemoveCustomerByIdInput()
    {
        Console.WriteLine("********* Remove customer by Id ********* ");
        customerManager.RemoveCustomerById(TryGetInt("Customer Id: "));
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
        quit = true;
        return quit;
    }

    static int TryGetInt(string prompt)
    {
        int input = 0;
        while (input < 3)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
                //break;
            }
            else
            {
                if (input < 2)
                {
                    Console.WriteLine("Try again");
                }

                else
                {
                    Console.WriteLine("No more try! Press enter to return to menu");
                }
                input++;
            }
        }
        return 0;
    }

    public static string GetString(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    public static double GetDouble(string message)
    {
        int input = 0;
        while (input < 3)
        {
            Console.WriteLine(message);
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
                //break;
            }
            else
            {
                if (input < 2)
                {
                    Console.WriteLine("Try again");
                }

                else
                {
                    Console.WriteLine("No more try! Press enter to return to menu");
                }
                input++;
            }
        }
        return 0;
    }

    // public static DateTime GetDate(string message)
    // {   
    //         Console.WriteLine(message);
    //         if(DateTime.TryParse(Console.ReadLine(), out DateTime number))
    //         return number;       
    // }   
}





