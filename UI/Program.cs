﻿using Dapper;
using MySqlConnector;
internal class Program
{

    static RoomManager roomManager = new();
    static CustomerManager customerManager = new();
    static EmployeeManager employeeManager = new();
    static PaymentManger paymentManager = new();
    static ReservationData myResData = new();
    static int customerID { get; set; }
    static bool isLogIn = true;

    private static void Main(string[] args)
    {
        Console.WriteLine("Employee Press [1]\nCustomer Press [2]\nManager Press [3]");
        string answer = Console.ReadLine();


        if (answer == "1")
        {
            //Employee();
            Console.Clear();
            EmployeeLog();
            if (isLogIn)
            {
                GetEmployeeInput();
            }
        }
        else if (answer == "2")
        {
            // Customer();
            Console.Clear();
            CustomerLog();
            if (isLogIn)
            {
                GetCustomerInput(); ;
            }
        }
        else if (answer == "3")
        {
            // Manager(); ID = 2, PASSWORD = 2            
            Console.Clear();
            CustomerLog();
            if (isLogIn)
            {
                GetManagerInput();
            }
        }
    }


    private static void GetEmployeeInput()
    {
        bool quit = true;
        while (quit)
        {
            MenuChoiceEmployee choice = EmployeeEnumSwitch();

            switch (choice)
            {
                case MenuChoiceEmployee.ViewRooms://is done Tina!
                    PrintAllRooms();
                    break;

                case MenuChoiceEmployee.ShowAvailableRooms://is done Tina!
                    PrintAvailableRooms();
                    break;

                case MenuChoiceEmployee.SearchRoom://is done Tina!
                    SearchRoomInput();
                    break;

                case MenuChoiceEmployee.CheckIn:
                    break;

                case MenuChoiceEmployee.AddRoom: //is done Tina!
                    AddRoomMenyInput();
                    break;

                case MenuChoiceEmployee.RemoveRoom://is done TINA!        
                    RemoveRoomInput();
                    break;

                case MenuChoiceEmployee.Receipt: //Do this last?
                    PrintAllPayments();// is done Tina!


                    // Console.WriteLine("Do you want a receipt? Y/N");
                    // string answer = Console.ReadLine().ToLower();
                    // if (answer == "y")
                    // {
                    //     Console.WriteLine("Your receipt");//Console.WriteLine("Receipt\n" + "Check in date: " + date_in + "\nCheck out date: " + check_out + "\nCustomer name: " + customer_fname + customer_lname + "\nRoom: " + room_id + "\nTotal Price: " + Price +"\nHotellet\nTel: 033-106600\nAllégatan 13 \nBorås");
                    //     quit = false;
                    // }
                    // else if (answer == "n")
                    // {
                    //     Console.WriteLine("No receipt chosen!");
                    //     quit = false;
                    // }
                    // else
                    // {
                    //     Console.WriteLine("your choice does not exist!");

                    //  }
                    break;

                case MenuChoiceEmployee.Update://is done?
                    UppdateRoomInput();

                    break;

                case MenuChoiceEmployee.Quit: //is done!
                    Console.WriteLine("You have chosen to quit the program");
                    quit = false;
                    break;

                default:
                    break;
            }
        }
    }

     private static void GetCustomerInput()
    {
        bool quit = true;
        while (quit)
        {
            MenuChoiceCustomer CustomerChoice = CustomerEnumSwitch();

            switch (CustomerChoice)
            {
                case MenuChoiceCustomer.ViewRooms://is done Tina!
                     PrintAllRooms();
                    break;

                case MenuChoiceCustomer.ShowAvailableRooms:// is done Tina!
                   PrintAvailableRooms();
                    break;

                case MenuChoiceCustomer.BookRoom:

                    Console.WriteLine("Book room");

                    int customerIdBooking = customerID;
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
                    break;

                case MenuChoiceCustomer.ReadReviews:
                    Console.WriteLine("View Reviews");
                    break;

                case MenuChoiceCustomer.WriteReview:
                    Console.WriteLine("Please, Write your review, make sure to add your account:");
                    string review = Console.ReadLine();
                    break;

                case MenuChoiceCustomer.Quit:
                    Console.WriteLine("You have chosen to quit the program");
                    quit = false;
                    break;

                default:
                    break;

            }
        }
    }

       private static void GetManagerInput()   // ID = 2 PASSWORD = 2
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

                case MenuChoiceManager.RemoveEmployee:// is done!
                    RemoveEmployeeInput();
                    break;

                case MenuChoiceManager.SearchEmployee: // works but without the job title name
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
                    break;


                case MenuChoiceManager.ShowEmployees: // is done!
                    PrintAllEmployees();

                    break;

                case MenuChoiceManager.AddCustomer: // is done Tina!
                    AddCustomerInput();            
                    break;

                case MenuChoiceManager.RemoveCustomer: // is done Tina
                    RemoveCustomerInput();
                    break;

                case MenuChoiceManager.SearchCustomer: //is done Tina!
                    SearchCustomerInput();
                    break;

                case MenuChoiceManager.ShowCustomers: // is done Tina!
                    PrintAllCustomers();

                    break;

                case MenuChoiceManager.Quit: //is done!
                    Console.WriteLine("You have chosen to quit the program");
                    quit = false;
                    break;

                default:
                    break;
            }
        }
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
            if (customerManager.SearchCustomer(searchCustomerId) != null)
            {
                Console.WriteLine(customerManager.SearchCustomer(searchCustomerId));
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

    private static void RemoveRoomInput()
    {
        Console.WriteLine("Delete Room!");
        Console.WriteLine("Room Id: ");
        int deleteRoomId = int.Parse(Console.ReadLine());
        roomManager.RemoveRoom(deleteRoomId);
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
            if (roomManager.SearchRoom(searchRoomId) != null)
            {
                Console.WriteLine(roomManager.SearchRoom(searchRoomId));
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    private static void CustomerLog()
    {
        int temp = 0;
        while (temp < 3)
        {
            Customer customer = new();
            Console.WriteLine("Please enter your ID: ");
            customerID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter password");
            string customerPass = Console.ReadLine();

            if (customerID == 2 && customerPass == "2")
            {
                isLogIn = true;
                break;
            }
            else
            {
                if (temp < 2)
                    Console.Write("\nLoggin unsucced, try again!");
                else
                    Console.Write("\nNO more try. Bye!");
            }
            temp++;
        }
    }

    private static void EmployeeLog()
    {
        int temp = 0;
        while (temp < 3)
        {
            //Employee employee = new();
            int employeeID;
            string employeePass;
            try
            {
                GetEmployeeID(out employeeID, out employeePass);
            }
            catch (System.Exception)
            {

                throw;
            }

            if (employeeID == 1 && employeePass == "1")
            {
                isLogIn = true;
                break;
            }
            else
            {
                if (temp < 2)
                    LoginWrongMessage();
                else
                    NoTryMessage();
            }
            temp++;
        }
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
        customerManager.RemoveCustomer(deleteCustomerId);
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

}
