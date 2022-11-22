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

    public MenuChoiceUser MenuChoiceUserEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceUser)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceUser), Enum.Parse(typeof(MenuChoiceUser), c), "d"));
        MenuChoiceUser choice = (MenuChoiceUser)userInput.TryGetInt("Select one of the options:");
        return choice;
    }

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
                case MenuChoiceEmployee.ShowRooms://is done Tina!
                    userInput.PrintAllRooms();
                    break;

                case MenuChoiceEmployee.ShowAvailableRooms://is done Tina!
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

                case MenuChoiceEmployee.UpdateRoomStatus://check in date change unsuccesses!
                    userInput.UpdateRoomStatusInput();
                    break;

                case MenuChoiceEmployee.MakingReservation://is done Tina!//Johan is going to look more into it
                    reservationManager.EmployeeBookRoom(employeeId);
                    break;

                case MenuChoiceEmployee.ShowSingleReservation:
                    userInput.ShowSingleReservationByIdInput();

                    break;

                case MenuChoiceEmployee.CheckIn: //is done! Jessica// need more checkin detail
                    userInput.EmployeeCheckInUpdate(employeeId);
                    break;

                case MenuChoiceEmployee.CheckOut: //is done! Jessica// need more checkin detail
                    userInput.EmployeeCheckOutUpdate(employeeId);
                    break;

                case MenuChoiceEmployee.ShowReceiptOptions: // need to work on receipt Nr Tina
                    quit = userInput.ReceiptOptionInput(quit); 
                 
                    
                    Console.ReadLine();
                    break;

                case MenuChoiceEmployee.ShowPaymentOption:
                    quit = userInput.PaymentChoiceInput(quit);
                    break;

                case MenuChoiceEmployee.UpdateReservationDate:// is done! Johan//need to Show more detail on the table
                    userInput.CheckInOutDateUpdateInput();
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
                case MenuChoiceManager.ShowRooms: //is done Tina!
                    userInput.PrintAllRooms();
                    break;

                case MenuChoiceManager.AddRoom: //is done Tina!
                    userInput.AddRoomInput();
                    break;

                case MenuChoiceManager.RemoveRoom:   //is done Tina!     
                    userInput.RemoveRoomByIdInput();
                    break;

                case MenuChoiceManager.AddEmployee:// is done Tina!
                    userInput.AddEmployeeInput();
                    break;

                case MenuChoiceManager.RemoveEmployee:// is done! Jessica
                    userInput.RemoveEmployeeByIdInput();
                    break;

                case MenuChoiceManager.SearchEmployee: // works but without the job title name
                    userInput.SearchEmployeeByIdInput();
                    break;

                case MenuChoiceManager.ShowEmployees: // is done! Jessica
                    userInput.PrintAllEmployees();
                    break;

                case MenuChoiceManager.AddCustomer: // is done Tina!
                    userInput.AddCustomerInput();
                    break;

                case MenuChoiceManager.RemoveCustomer: // is done Tina
                    userInput.RemoveCustomerByIdInput();
                    break;

                case MenuChoiceManager.SearchCustomer: //is done Tina!
                    userInput.SearchCustomerByIdInput();
                    break;

                case MenuChoiceManager.ShowCustomers: // is done Tina!
                    userInput.PrintAllCustomers();
                    break;

                case MenuChoiceManager.Quit: //is done!
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

    // public bool ReceiptOptionInput(bool quit)
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Receipt option ********* ");
    //     //AddPaymentInput();
    //     Console.WriteLine("Do you want a receipt? Y/N");
    //     string answer = Console.ReadLine().ToLower();
    //     if (answer == "y")
    //     {
    //         userInput.SearchPaymentByPaymentIdInput();
    //         quit = false;
    //     }
    //     else if (answer == "n")
    //     {
    //         Console.WriteLine("No receipt chosen!");
    //         quit = false;
    //     }
    //     else
    //     {
    //         Console.WriteLine("your choice does not exist!");
    //     }
    //     return quit;
    // }

    // public bool PaymentChoiceInput(bool quit)
    // {
    //     Console.Clear();
    //     Console.WriteLine("Choose your option: [1]Print all payments [2]Add payment [3]Search payment by PaymentId [4]Search payment by ReservId [5]Remove payment");
    //     string option = Console.ReadLine();
    //     if (option == "1")
    //     {
    //         userInput.PrintAllPayments();
    //         quit = false;
    //     }
    //     else if (option == "2")
    //     {
    //         userInput.AddPaymentInput(); //it does not inseart the customer Id, dont not know why Tina!
    //         quit = false;
    //     }
    //     else if (option == "3")
    //     {
    //         userInput.SearchPaymentByPaymentIdInput();
    //         quit = false;
    //     }
    //     else if (option == "4")
    //     {
    //         userInput.SearchPaymentByReservIdInput();
    //         quit = false;
    //     }
    //      else if (option == "5")
    //     {
    //         userInput.RemovePaymentInput();
    //         quit = false;
    //     }
    //     else
    //     {
    //         Console.WriteLine("Select one of the number!");
    //     }
    //     Console.ReadLine();
    //     return quit;
    // }

    // public void RemovePaymentInput()
    // {
    //     Console.WriteLine("\n******* Remove a payment ********\n");
    //     Console.WriteLine("Payment Id to be removed: ");
    //     if (int.TryParse(Console.ReadLine(), out int rPaymentId))
    //     {
    //         paymentManager.RemovePaymentById(rPaymentId);
    //         Console.WriteLine("The payment has been removed!");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Input prayment ID number!");
    //     }
    // }

    // public void ShowSingleReservationByIdInput()
    // {
    //     Console.WriteLine("******* Search Reseravtion by Id **********");
    //     int searchReservId = userInput.TryGetInt("Enter reservation id to search: ");
    //     try
    //     {
    //         if (reservationManager.SearchReservationById(searchReservId) != null)
    //         {
    //             Console.WriteLine(reservationManager.SearchReservationById(searchReservId));
    //         }
    //     }
    //     catch (Exception e)
    //     {

    //         throw new ArgumentNullException(); ;
    //     }
    //     Console.ReadLine();
    // }

    // public void PrintAllReservations()
    // {
    //     foreach (var item in reservationManager.ShowAllReservations())
    //     {
    //         Console.WriteLine(item);

    //     }
    //     Console.ReadLine();
    // }

    // public  void EmployeeCheckOutUpdate()
    // {
    //     Console.WriteLine("Update room status to Checked out");
    //     foreach (var item in roomManager.ShowAllRooms())
    //     {
    //         Console.WriteLine(item);
    //     }
    //     Console.WriteLine("Choose room to check out: ");
    //     string roomToCheckOut = Console.ReadLine();
    //     string newRoomCheckOutStatus = "2";
    //     roomManager.CheckOutRoomStatusID(roomToCheckOut, newRoomCheckOutStatus);
    //     Console.WriteLine("Room status has now changed to Checked Out!");
    //     Console.WriteLine();
    // }

    // public  void EmployeeCheckInUpdate()
    // {
    //     Console.WriteLine("Update room status to Checked in");
    //     foreach (var item in roomManager.ShowAllRooms())
    //     {
    //         Console.WriteLine(item);
    //     }
    //     Console.WriteLine("Choose room to check in: ");
    //     string roomToCheckIn = Console.ReadLine();
    //     string newRoomCheckInStatus = "1";
    //     roomManager.CheckInRoomStatusID(roomToCheckIn, newRoomCheckInStatus);
    //     Console.WriteLine("Room status has now changed to Checked in!");
    //     Console.ReadLine();
    // }

    // public  void RemoveReviewByIdInput()
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Remove review by Id ********* ");
    //     try
    //     {
    //         reviewManager.RemoveReviewById(TryGetInt("Review Id to be removed:"));
    //         Console.WriteLine("The review has been removed!");
    //     }
    //     catch (System.Exception)
    //     {
    //         throw new FieldAccessException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void WriteReviewInput()
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Write Review ********* ");
    //     Console.WriteLine("Your Review Id: " + reviewManager.WriteReview(TryGetInt("Enter account number:"), TryGetInt("Enter reservation number:"), GetString("Write your review: \n")));
    //     Console.ReadLine();
    // }

    // public  void PrintAllReviews()
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* All Reviews ********* ");
    //     try
    //     {
    //         if (reviewManager.ShowAllReviews() != null)
    //         {
    //             foreach (var item in reviewManager.ShowAllReviews())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }

    //     }
    //     catch (Exception e)
    //     {

    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  bool ReceiptOptionInput(bool quit)
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Receipt option ********* ");
    //     //AddPaymentInput();
    //     Console.WriteLine("Do you want a receipt? Y/N");
    //     string answer = Console.ReadLine().ToLower();
    //     if (answer == "y")
    //     {
    //         SearchPaymentByIdInput();
    //         quit = false;
    //     }
    //     else if (answer == "n")
    //     {
    //         Console.WriteLine("No receipt chosen!");
    //         quit = false;
    //     }
    //     else
    //     {
    //         Console.WriteLine("your choice does not exist!");

    //     }

    //     return quit;
    // }

    // public  bool PaymentChoiceInput(bool quit)
    // {
    //     Console.Clear();
    //     Console.WriteLine("Choose your option: [1]Print all payments [2]Add payment [3]Search payment [4]Remove payment");
    //     string option = Console.ReadLine();
    //     if (option == "1")
    //     {
    //         PrintAllPayments();
    //         quit = false;
    //     }
    //     else if (option == "2")
    //     {
    //         AddPaymentInput(); //it does not inseart the customer Id, dont not know why Tina!
    //         quit = false;
    //     }
    //     else if (option == "3")
    //     {
    //         SearchPaymentByIdInput();
    //         quit = false;
    //     }
    //     else if (option == "4")
    //     {
    //         RemovePaymentInput();
    //         quit = false;
    //     }
    //     else
    //     {
    //         Console.WriteLine("Select one of the number!");
    //     }
    //     Console.ReadLine();
    //     return quit;
    // }

    // public  void RemovePaymentInput()
    // {
    //     Console.WriteLine("\n******* Remove a payment ********\n");
    //     Console.WriteLine("Payment Id to be removed: ");
    //     if (int.TryParse(Console.ReadLine(), out int rPaymentId))
    //     {
    //         paymentManager.RemovePaymentById(rPaymentId);
    //         Console.WriteLine ("The payment has been removed!");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Input prayment ID number!");
    //     }
    // }

    // public  void SearchPaymentByIdInput()
    // {
    //     Console.WriteLine("\n******* Search a payment by Id ********\n");
    //     Console.WriteLine("Searching Payment ID: ");
    //     if (int.TryParse(Console.ReadLine(), out int searchPaymentId))
    //     {

    //         try
    //         {
    //             if (paymentManager.SearchPaymentById(searchPaymentId) != null)
    //             {
    //                 Console.WriteLine(paymentManager.SearchPaymentById(searchPaymentId));
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             throw new ArgumentNullException();
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Input Id number!");
    //     }
    //     Console.ReadLine();
    // }

    // public  void SearchEmployeeByIdInput()
    // {
    //     Console.WriteLine("\n******* Search Employee by Id ********\n");
    //     Console.WriteLine("Employee Id:");
    //     int searchEmployeeId = int.Parse(Console.ReadLine());
    //     try
    //     {
    //         if (employeeManager.SearchEmployee(searchEmployeeId) != null)
    //         {
    //             Console.WriteLine(employeeManager.SearchEmployee(searchEmployeeId));
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void AddPaymentInput()
    // {

    //     Console.WriteLine("\n******* Add a payment ********\n");
    //     Console.WriteLine("Payment date: ");
    //     DateTime date = DateTime.Parse(Console.ReadLine());
    //     //Console.WriteLine("Added new payment ID: ");
    //     Console.WriteLine("Added new payment ID\n " + paymentManager.AddPayment(TryGetInt("Customer ID: "), date, GetDouble("Payment amount:"), TryGetInt("Reservation ID: "), GetString("Payment name: "), GetString("Bank information")));
    //     Console.ReadLine();
    // }

    // public  void RemoveEmployeeByIdInput()
    // {
    //     Console.WriteLine("\n******* Remove a employee by Id ********\n");
    //     Console.WriteLine("Employee Id: ");
    //     int deleteEmployeeId = int.Parse(Console.ReadLine());
    //     employeeManager.RemoveEmployeeById(deleteEmployeeId);
    //     Console.WriteLine("Employee has been removed!");
    //     Console.ReadLine();
    // }

    // public  void PrintAllCustomers()
    // {
    //     Console.WriteLine("\n******* Show all customers ********\n");
    //     try
    //     {
    //         if (customerManager.ShowAllCustomers() != null)
    //         {
    //             foreach (var item in customerManager.ShowAllCustomers())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void SearchCustomerByIdInput()
    // {
    //     Console.WriteLine("\n******* Search customer by Id ********\n");
    //     Console.WriteLine("Customer Id:");
    //     int searchCustomerId = int.Parse(Console.ReadLine());
    //     try
    //     {
    //         if (customerManager.SearchCustomerById(searchCustomerId) != null)
    //         {
    //             Console.WriteLine(customerManager.SearchCustomerById(searchCustomerId));
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void PrintAllEmployees()
    // {
    //     Console.WriteLine("\n******* All Employees ********\n");
    //     try
    //     {
    //         if (employeeManager.ShowEmployees() != null)
    //         {
    //             foreach (var item in employeeManager.ShowEmployees())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void PrintAllPayments()
    // {
    //     Console.WriteLine("\n******* All Payments ********\n");// is done!
    //     try
    //     {
    //         if (paymentManager.ShowAllPayments() != null)
    //         {
    //             foreach (var item in paymentManager.ShowAllPayments())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void PrintAllRooms()
    // {
    //     Console.WriteLine("\n******* All Rooms ********\n");
    //     try
    //     {
    //         if (roomManager.ShowAllRooms() != null)
    //         {
    //             foreach (var item in roomManager.ShowAllRooms())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void PrintAvailableRooms()
    // {
    //     Console.WriteLine("\n******* All Available Rooms ********\n");
    //     try
    //     {
    //         if (roomManager.ShowAvailableRoom() != null)
    //         {
    //             foreach (var item in roomManager.ShowAvailableRoom())
    //             {
    //                 Console.WriteLine(item);
    //             }
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }

    //     Console.ReadLine();
    // }

    // public  void UpdateRoomStatusInput()  //GETSTRING DOES NOT WORK
    // {
    //     // TryGetInt("Room Id: ");
    //     // GetString("Choose room to update: ");
    //     Console.WriteLine("\n******* Update room status ********\n");

    //     foreach (var item in roomManager.ShowAllRooms())
    //     {
    //         Console.WriteLine(item);
    //     }
    //     Console.WriteLine("Choose room to update: ");
    //     string roomToUpdate = Console.ReadLine();
    //     Console.WriteLine("Choose room status: \n [1] checked in \n [2] check out \n [3] reserved \n [4] not in use");
    //     string newRoomStatus = Console.ReadLine();
    //     roomManager.UpdateRoomStatusID(roomToUpdate, newRoomStatus);
    //     Console.WriteLine("Room is updated!");
    //     Console.ReadLine();
    // }

    // public  void ReservationUpdateInput()
    // {
    //     Console.WriteLine("\n******* Update Reservation ********\n");
    //     Console.WriteLine("[1]Update check in date \n[2]Update check out date ");
    //     string choice = Console.ReadLine();
    //     if (choice == "1")
    //     {
    //         Console.Clear();
    //         foreach (var item in reservationData.GetReservationList())
    //         {
    //             Console.WriteLine(item);
    //         }
    //         Console.WriteLine("Choose reservation ID: ");
    //         int resID = Int32.Parse(Console.ReadLine());
    //         Console.WriteLine("Choose new check in date: ");
    //         DateTime userDateIn;
    //         if (DateTime.TryParse(Console.ReadLine(), out userDateIn))
    //         {
    //             Console.WriteLine("you choosed: " + userDateIn);
    //         }
    //         else
    //         {
    //             Console.WriteLine("You have entered an incorrect value.");
    //         }
    //         Reservation myRoom = reservationData.GetSingleReservationById(resID);
    //         double newDateTime = reservationManager.GetTimeSpanByDates(userDateIn, myRoom.date_out);
    //         reservationData.UpdateReservationDateIn(resID, userDateIn, newDateTime);
    //         Console.WriteLine($"You have updated reservation nr {resID} New check in date: {userDateIn}.");
    //         Console.ReadKey();

    //     }

    //     if (choice == "2")
    //     {
    //         Console.Clear();
    //         foreach (var item in reservationData.GetReservationList())
    //         {
    //             Console.WriteLine(item);
    //         }
    //         Console.WriteLine("Choose reservation ID: ");
    //         int resID = Int32.Parse(Console.ReadLine());
    //         Console.WriteLine("Choose new check out date: ");
    //         DateTime userDateOut;
    //         if (DateTime.TryParse(Console.ReadLine(), out userDateOut))
    //         {
    //             Console.WriteLine("you choosed: " + userDateOut);
    //         }
    //         else
    //         {
    //             Console.WriteLine("You have entered an incorrect value.");
    //         }

    //         Reservation myRoom = reservationData.GetSingleReservationById(resID);
    //         double newDateTime = reservationManager.GetTimeSpanByDates(myRoom.date_in, userDateOut);
    //         reservationData.UpdateReservationDateOut(resID, userDateOut, newDateTime);
    //         Console.WriteLine($"You have updated reservation nr {resID} New check out date: {userDateOut}.");
    //         Console.ReadKey();
    //     }
    // }

    // public  void RemoveRoomByIdInput()
    // {
    //     Console.WriteLine("\n******* Remove room by Id ********\n");
    //     roomManager.RemoveRoomById(TryGetInt("Room Id: "));
    //     Console.WriteLine("Room has been deleted!");
    //     Console.ReadLine();
    // }

    // public  void SearchRoomByIdInput()
    // {
    //     Console.WriteLine("\n******* Search room by Id ********\n");
    //     Console.WriteLine("Room Id: ");
    //     int searchRoomId = int.Parse(Console.ReadLine());
    //     try
    //     {
    //         if (roomManager.SearchRoomById(searchRoomId) != null)
    //         {
    //             Console.WriteLine(roomManager.SearchRoomById(searchRoomId));
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //     Console.ReadLine();
    // }

    // public  void GetCustomerLogIn()
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Customer Log In ********* ");
    //     int temp = 0;
    //     while (temp < 3)
    //     {
    //         int id =TryGetInt("Please enter your ID: ");
    //         string name=GetString("Enter First Name:\n");
    //         if  (customerManager.CustomerLogInNameId(id, name))
    //         {          
    //            customerIsLoggedIn =true ;  
    //            break;                          
    //         }      
    //        else 
    //         {
    //            if(temp<2)
    //            Console.Write("\nLoggin unsucced, try again!\n");

    //            else
    //            Console.Write("\nNO more try. Bye!\n");
    //         }
    //         temp++;

    //     }
    // }

    // public  void GetEmployeeLogIn()
    // {
    //     Console.Clear();
    //     Console.WriteLine("*********Employee Log In ********* ");
    //      int temp = 0;
    //     while (temp < 3)
    //     {
    //         int id =TryGetInt("Please enter your ID: ");
    //         string name=GetString("Enter First Name:\n");
    //         if  (employeeManager.EmployeeLogInNameId(id, name))
    //         {          
    //            employeeIsLoggedIn =true ;  
    //            break;                          
    //         }      
    //        else 
    //         {

    //            if(temp<2)
    //            Console.Write("\nLoggin unsucced, try again!\n");

    //            else
    //            Console.Write("\nNO more try. Bye!\n");
    //         }
    //         temp++;



    //     }
    // }

    // public  void GetManagerLogIn()
    // {
    //     Console.Clear();
    //     Console.WriteLine("********* Manager Log In ********* ");
    //      int temp = 0;
    //     while (temp < 3)
    //     {
    //         int id =TryGetInt("Please enter your ID: ");
    //         string name=GetString("Enter First Name:\n");
    //         if  (employeeManager.ManagerLogInNameId(id, name))
    //         {          
    //            managerIsLoggedIn =true ;  
    //            break;                          
    //         }      
    //        else 
    //         {
    //            if(temp<2)
    //            Console.Write("\nLoggin unsucced, try again!\n");      
    //            else
    //            Console.Write("\nNO more try. Bye!\n");
    //         }
    //         temp++;



    //     }
    // }


    // public  void AddRoomInput()//Tina, put in one Console.Write()
    // {   // do not need room id, it will return added room id.
    //     Console.WriteLine("********* Add Room ********* ");
    //     Console.WriteLine("price");
    //     double p = double.Parse(Console.ReadLine());
    //     //Console.WriteLine("Added room ID:");
    //     Console.WriteLine("Added room ID: " + roomManager.AddRoom(TryGetInt("TYPE ID: "), TryGetInt("STATUS ID"), p));
    //     Console.ReadLine();
    // }

    // public  void AddEmployeeInput()//Tina, change the formation, put all in one Console.Write()
    // {
    //     Console.WriteLine("********* Add Employee ********* ");
    //     Console.WriteLine("Added employee ID: " + employeeManager.AddEmployee(TryGetInt("Job Title ID: "), GetString("First name"), GetString("Last name"), TryGetInt("Phone: "), GetString("Email: ")));
    //     // Console.WriteLine("Added customer ID: "))
    //     // int addEId = employeeManager.AddEmployee(TryGetInt("Job Title ID: "), GetString("First name"), GetString("Last name"), TryGetInt("Phone: "), GetString("Email: "));
    //     // Console.WriteLine("Added customer ID: ");
    //     // Console.WriteLine(addEId);
    //     Console.ReadLine();
    // }

    // public  void AddCustomerInput()//Tina, change the formation, put all in one Console.Write()
    // {
    //     Console.WriteLine("*********\n Register New Customer \n********* ");
    //     Console.WriteLine("Added customer ID: " + customerManager.AddCustomer(GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: "), GetString("City: "), GetString("Country: "), GetString("Address: ")));
    //     // int addId = customerManager.AddCustomer(GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: "), GetString("City: "), GetString("Country: "), GetString("Address: "));
    //     // Console.WriteLine("Added customer ID: ");
    //     // Console.WriteLine(addId);
    //     Console.ReadLine();
    // }

    // public  void RemoveCustomerByIdInput()
    // {
    //     Console.WriteLine("********* Remove customer by Id ********* ");
    //     customerManager.RemoveCustomerById(TryGetInt("Customer Id: "));
    //     Console.ReadLine();
    // }

    // public  void NoTryMessage()
    // {
    //     Console.Write("\nNO more try. Bye!");
    // }

    // public  void LoginWrongMessage()
    // {
    //     Console.Write("\nLoggin unsucced, try again!");
    // }

    // public  bool QuitMessage()
    // {
    //     bool quit;
    //     Console.WriteLine("You have chosen to quit the program");
    //     quit = true;
    //     return quit;
    // }

    // public int TryGetInt(string prompt)
    // {
    //     int input = 0;
    //     while (input < 3)
    //     {
    //         Console.WriteLine(prompt);
    //         if (int.TryParse(Console.ReadLine(), out int id))
    //         {
    //             return id;
    //             //break;
    //         }
    //         else
    //         {
    //             if (input < 2)
    //             {
    //                 Console.WriteLine("Try again");
    //             }

    //             else
    //             {
    //                 Console.WriteLine("No more try! Press enter to return to menu");
    //             }
    //             input++;
    //         }
    //     }
    //     return 0;
    // }

    // public  string GetString(string prompt)
    // {
    //     Console.Write(prompt);

    //     return Console.ReadLine();
    // }

    // public  double GetDouble(string message)
    // {
    //     int input = 0;
    //     while (input < 3)
    //     {
    //         Console.WriteLine(message);
    //         if (double.TryParse(Console.ReadLine(), out double number))
    //         {
    //             return number;
    //             //break;
    //         }
    //         else
    //         {
    //             if (input < 2)
    //             {
    //                 Console.WriteLine("Try again");
    //             }

    //             else
    //             {
    //                 Console.WriteLine("No more try! Press enter to return to menu");
    //             }
    //             input++;
    //         }
    //     }
    //     return 0;
    // }

    // public static DateTime GetDate(string message)
    // {   
    //         Console.WriteLine(message);
    //         if(DateTime.TryParse(Console.ReadLine(), out DateTime number))
    //         return number;       
    // }   
}


public enum MenuChoiceEmployee
{
    ShowRooms = 1,
    ShowAvailableRooms,
    ShowReservations,
    SearchRoom,
    AddRoom,
    RemoveRoom,
    UpdateRoomStatus,
    MakingReservation,
    ShowSingleReservation,
    UpdateReservationDate,
    CheckIn,
    CheckOut,
    ShowReceiptOptions,
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

