public class UserInput
{

    public RoomManager roomManager = new();
    public CustomerManager customerManager = new();
    public EmployeeManager employeeManager = new();
    public PaymentManger paymentManager = new();
    public ReservationData reservationData = new();
    public ReservationManager reservationManager = new();
    public ReviewManager reviewManager = new();
    public ReviewData reviewData = new();
    public bool employeeIsLoggedIn;
    public bool managerIsLoggedIn;
    public bool customerIsLoggedIn;

    public void EmployeeCheckinInput(int employeeId)
    {

        int reservid = TryGetInt("Enter reservation id: ");
        if (reservationManager.SearchReservationById(reservid) != null)
        {
            Console.WriteLine(reservationManager.SearchReservationById(reservid));
        }
        else
        {
            throw new ArgumentNullException();
        }

        Console.WriteLine("Do you want to uppdate Reservation? Y/N");
        string Answer = Console.ReadLine().ToLower();

        if (Answer == "y")
        {
            Console.WriteLine("Choose your option: [1]uppdate checking in or out date. [2]uppdate room");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Enter new checkin date: ");
                DateTime datein = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new checkout date: ");
                DateTime dateout = DateTime.Parse(Console.ReadLine());
                double range = reservationManager.GetTimeSpanByDates(datein, dateout);
                double totalPay = reservationManager.CalculatingTotalRoomPay(reservid);
                reservationManager.UpdateReservationDate(reservid, datein, dateout, range, totalPay);
                Console.ReadLine();
                Console.WriteLine("*********** Updated Reservation *********");
                Console.WriteLine(reservationManager.SearchReservationById(reservid));
                roomManager.CheckInRoomStatusRenewByRoomId(reservationManager.GetRoomIdByReservId(reservid));
                Console.WriteLine("CheckIn date is now updated");
                Console.ReadLine();
            }
            if (option == "2")
            {
                int roomid = TryGetInt("Enter the room id: ");
                reservationManager.UpdateReservationRoom(reservid, roomid);
                Console.WriteLine("Press enter to update the room status!");
                Console.WriteLine("*********** Updated Reservation *********");
                Console.WriteLine(reservationManager.SearchReservationById(reservid));
                Console.ReadLine();
                roomManager.CheckInRoomStatusRenewByRoomId(reservationManager.GetRoomIdByReservId(reservid));
                Console.WriteLine("Room status is now CheckedIn");
                Console.ReadLine();
            }
        }
        else if (Answer == "n")
        {
            roomManager.CheckInRoomStatusRenewByRoomId(reservationManager.GetRoomIdByReservId(reservid));
            Console.WriteLine("Check in done");
            Console.ReadLine();
        }

    }

    public void EmployeeCheckOutInput(int employeeId)
    {
        Console.WriteLine("Payment date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        int checkOurRoomId = TryGetInt("Enter checking out room Id: ");
        int checkOutReservId = TryGetInt("Enter Reservation Id");
        roomManager.CheckOutRoomStatusRenewByRoomId(checkOurRoomId);
        int rId = TryGetInt("Reservation ID: ");
        int cId = TryGetInt("Customer ID: ");//may not need it in future
        double roomPay = reservationManager.CalculatingTotalRoomPay(rId);
        string payname = GetString("Other products: \n");
        double otherPay = GetDouble("Payment:");
        string bank = GetString("Payment banInfor: ");
        double amount = roomPay + otherPay;
        int addedPayId = paymentManager.AddPayment(cId, date, amount, roomPay, otherPay, rId, payname, bank);
        Console.WriteLine("Payment Id: " + addedPayId);
        Console.WriteLine("Do you want a receipt? Y/N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.WriteLine("\n*********** Receipt ********\n");
            DateTime now = DateTime.Now;
            Receipt receipt = new(now);
            Console.WriteLine(receipt);
            if (paymentManager.SearchPaymentByPaymentId(addedPayId) != null)
            {
                Console.WriteLine(paymentManager.SearchPaymentByPaymentId(addedPayId));
            }
            else
            {
                throw new FieldAccessException();
            }

            Console.ReadLine();
        }
        else if (answer == "n")
        {
            Console.WriteLine("No receipt chosen!");
        }
        else
        {
            Console.WriteLine("your choice does not exist!");
        }
    }

    public void EmployeeReservationUpdate(int employeeId)
    {
        int reservid = TryGetInt("Enter reservation id: ");
        if (reservationManager.SearchReservationById(reservid) != null)
        {
            Console.WriteLine(reservationManager.SearchReservationById(reservid));
        }
        else
        {
            throw new ArgumentNullException();
        }

        Console.WriteLine("Do you want to uppdate Reservation? Y/N");
        string Answer = Console.ReadLine().ToLower();

        if (Answer == "y")
        {
            Console.WriteLine("Choose your option: [1]uppdate checking in or out date. [2]uppdate room");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Enter new checkin date: ");
                DateTime datein = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter new checkout date: ");
                DateTime dateout = DateTime.Parse(Console.ReadLine());
                double range = reservationManager.GetTimeSpanByDates(datein, dateout);
                double totalPay = reservationManager.CalculatingTotalRoomPay(reservid);
                reservationManager.UpdateReservationDate(reservid, datein, dateout, range, totalPay);
                Console.ReadLine();
                Console.WriteLine("*********** Updated Reservation *********");
                Console.WriteLine(reservationManager.SearchReservationById(reservid));
            }
            if (option == "2")
            {
                PrintAvailableRooms();
                int roomid = TryGetInt("Enter new room id: ");
                reservationManager.UpdateReservationRoom(reservid, roomid);
                Console.WriteLine("*********** Updated Reservation *********");
                Console.WriteLine(reservationManager.SearchReservationById(reservid));
                Console.ReadLine();
            }
        }
        else if (Answer == "n")
        {

        }
    }

    public void PrintAllCustomers()
    {
        Console.WriteLine("\n******* Show all customers ********\n");
        try
        {
            if (customerManager.ShowAllCustomers() != null)
            {
                foreach (var item in customerManager.ShowAllCustomers())
                {
                    Console.WriteLine(item + "\n\n");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("There are no customers!");
        }
        Console.ReadLine();
    }

    public void SearchCustomerByIdInput()
    {
        Console.WriteLine("\n******* Search customer by Id ********\n");
        int searchCustomerId = TryGetInt("Customer Id:");
        try
        {
            if (customerManager.SearchCustomerById(searchCustomerId) != null)
            {
                Console.WriteLine(customerManager.SearchCustomerById(searchCustomerId));
                Console.ReadKey();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Customer did not exist.");


        }
        Console.ReadLine();
    }

    public void RemoveCustomerByIdInput()
    {
        Console.WriteLine("********* Remove customer by Id ********* ");
        customerManager.RemoveCustomerById(TryGetInt("Customer Id: "));
        Console.WriteLine("Customer has been removed!");
        Console.ReadLine();
    }

    public void AddCustomerInput()
    {
        Console.WriteLine("*********\n Register New Customer \n********* ");
        Console.WriteLine("Added customer ID: " + customerManager.AddCustomer(GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: "), GetString("City: "), GetString("Country: "), GetString("Address: ")));
        Console.ReadLine();
    }

    public void GetManagerLogIn()
    {
        Console.Clear();
        Console.WriteLine("********* Manager Log In ********* ");
        int temp = 0;
        while (temp < 3)
        {
            int id = TryGetInt("Please enter your ID: ");
            string name = GetString("Enter First Name:\n");
            if (employeeManager.ManagerLogInNameId(id, name))
            {
                managerIsLoggedIn = true;
                break;
            }
            else
            {
                if (temp < 2)
                    Console.Write("\nLoggin unsucced, try again!\n");
                else
                    Console.Write("\nNO more try. Bye!\n");
            }
            temp++;
        }
    }

    public int GetEmployeeLogIn()
    {
        Console.Clear();
        Console.WriteLine("*********Employee Log In ********* ");
        int temp = 0;
        while (temp < 3)
        {
            int id = TryGetInt("Please enter your ID: ");
            string name = GetString("Enter First Name:\n");
            if (employeeManager.EmployeeLogInNameId(id, name))
            {
                employeeIsLoggedIn = true;
                return id;
            }
            else
            {

                if (temp < 2)
                    Console.Write("\nLoggin unsucced, try again!\n");

                else
                    Console.Write("\nNO more try. Bye!\n");
            }
            temp++;
        }
        return 0;
    }

    public int GetCustomerLogIn()
    {
        Console.Clear();
        Console.WriteLine("********* Customer Log In ********* ");
        int temp = 0;
        while (temp < 3)
        {
            int id = TryGetInt("Please enter your ID: ");
            string name = GetString("Enter First Name:\n");
            if (customerManager.CustomerLogInNameId(id, name))
            {
                customerIsLoggedIn = true;
                return id;
            }
            else
            {
                if (temp < 2)
                    Console.Write("\nLoggin unsucced, try again!\n");

                else
                    Console.Write("\nNO more try. Bye!\n");
            }
            temp++;
        }
        return 0;
    }

    public void SearchRoomByIdInput()
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

    public void UpdateRoomStatusInput()
    {
        Console.WriteLine("\n******* Update room status ********\n");

        foreach (var item in roomManager.ShowAllRooms())
        {
            Console.WriteLine(item);
        }
        int roomToUpdate = TryGetInt("Choose room to be updated: ");
        int newRoomStatus = TryGetInt("Choose room status: \n [1] checked in \n [2] check out \n [3] reserved \n [4] not in use");
        roomManager.UpdateRoomStatusID(roomToUpdate, newRoomStatus);
        Console.WriteLine("Room is updated!");
        Console.ReadLine();
    }

    public void AddRoomInput()
    {
        Console.WriteLine("********* Add Room ********* ");
        Console.WriteLine("price");
        double p = double.Parse(Console.ReadLine());
        Console.WriteLine("Added room ID: " + roomManager.AddRoom(TryGetInt("TYPE ID: "), TryGetInt("STATUS ID"), p));
        Console.ReadLine();
    }

    public void RemoveRoomByIdInput()
    {
        Console.WriteLine("\n******* Remove room by Id ********\n");
        foreach (var item in roomManager.ShowAllRooms())
        {
            Console.WriteLine(item);
        }
        if (true)
        {

        }
        roomManager.RemoveRoomById(TryGetInt("Room Id: "));
        Console.WriteLine("Room has been deleted!");
        Console.ReadLine();
    }

    public void PrintAllRooms()
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

    public void PrintAvailableRooms()
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

    public void PrintAllPayments()
    {
        Console.WriteLine("\n******* All Payments ********\n");
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

    public void AddEmployeeInput()
    {
        Console.WriteLine("********* Add Employee ********* ");
        Console.WriteLine("Added employee ID: " + employeeManager.AddEmployee(TryGetInt("Job Title ID: "), GetString("First name: "), GetString("Last name: "), TryGetInt("Phone: "), GetString("Email: ")));
        Console.ReadLine();
    }

    public void SearchEmployeeByIdInput()
    {
        Console.WriteLine("\n******* Search Employee by Id ********\n");
        int searchEmployeeId = TryGetInt("Employee Id:");
        try
        {
            if (employeeManager.SearchEmployee(searchEmployeeId) != null)
            {
                Console.WriteLine(employeeManager.SearchEmployee(searchEmployeeId));
                Console.WriteLine("Press enter to continue...");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Did not exist");
            SearchEmployeeByIdInput();
        }
        Console.ReadLine();
    }

    public void PrintAllEmployees()
    {
        Console.WriteLine("\n******* All Employees ********\n");
        try
        {
            if (employeeManager.ShowEmployees() != null)
            {
                foreach (var item in employeeManager.ShowEmployees())
                {
                    Console.WriteLine(item + " \n \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    public void RemoveEmployeeByIdInput()
    {
        Console.WriteLine("\n******* Remove a employee by Id ********\n");
        Console.WriteLine("Employee Id: ");
        int deleteEmployeeId = int.Parse(Console.ReadLine());
        employeeManager.RemoveEmployeeById(deleteEmployeeId);
        Console.WriteLine("Employee has been removed!");
        Console.ReadLine();
    }

    public void PrintAllReservations()
    {
        foreach (var item in reservationManager.ShowAllReservations())
        {
            Console.WriteLine(item);

        }
        Console.ReadLine();
    }

    public void ShowSingleReservationByIdInput()
    {
        Console.WriteLine("******* Search Reseravtion by Id **********");
        int searchReservId = TryGetInt("Enter reservation id to search: ");
        if (reservationManager.SearchReservationById(searchReservId) != null)
        {
            Console.WriteLine(reservationManager.SearchReservationById(searchReservId));
        }
        else
        {
            throw new ArgumentNullException();
        }
        Console.ReadLine();
    }

    public void RemoveReviewByIdInput()
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

    public void WriteReviewInput()
    {
        Console.Clear();
        Console.WriteLine("********* Write Review ********* ");
        Console.WriteLine("Your Review Id: " + reviewManager.WriteReview(TryGetInt("Enter account number:"), TryGetInt("Enter reservation number:"), GetString("Write your review: \n")));
        Console.ReadLine();
    }

    public void PrintAllReviews()
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

    public void AddPaymentInput()
    {
        Console.WriteLine("\n******* Add a payment ********\n");
        Console.WriteLine("Payment date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        int rId = TryGetInt("Reservation ID: ");
        int cId = TryGetInt("Customer ID: ");//may not need it in future
        double roomPay = reservationManager.CalculatingTotalRoomPay(rId);
        string payname = GetString("Other products: \n");
        double otherPay = GetDouble("Payment:");
        string bank = GetString("Payment banInfor: ");
        double amount = roomPay + otherPay;
        int addedPayId = paymentManager.AddPayment(cId, date, amount, roomPay, otherPay, rId, payname, bank);
        Console.WriteLine("Payment Id: " + addedPayId);
        Console.WriteLine("Do you want a receipt? Y/N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.WriteLine("\n*********** Receipt ********\n");
            DateTime now = DateTime.Now;
            Receipt receipt = new(now);
            Console.WriteLine(receipt);
            if (paymentManager.SearchPaymentByPaymentId(addedPayId) != null)
            {
                Console.WriteLine(paymentManager.SearchPaymentByPaymentId(addedPayId));
            }
            else
            {
                throw new FieldAccessException();
            }

            Console.ReadLine();
        }
        else if (answer == "n")
        {
            Console.WriteLine("No receipt chosen!");

        }
        else
        {
            Console.WriteLine("your choice does not exist!");

        }


    }

    public bool PaymentChoiceInput(bool quit)
    {
        Console.Clear();
        Console.WriteLine("Choose your option: [1]Print all payments [2]Add payment [3]Search payment by payment Id [4]Search paymment by Reservation ID [5]Remove payment");
        string option = Console.ReadLine();
        if (option == "1")
        {
            PrintAllPayments();
            quit = false;
        }
        else if (option == "2")
        {
            AddPaymentInput();
            quit = false;
        }
        else if (option == "3")
        {
            SearchPaymentByPaymentIdInput();
            quit = false;
        }
        else if (option == "4")
        {
            SearchPaymentByReservIdInput();
            quit = false;
        }
        else if (option == "5")
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

    public void RemovePaymentInput()
    {
        Console.WriteLine("\n******* Remove a payment ********\n");
        Console.WriteLine("Payment Id to be removed: ");
        if (int.TryParse(Console.ReadLine(), out int rPaymentId))
        {
            paymentManager.RemovePaymentById(rPaymentId);
            Console.WriteLine("Payment has been removed!");
        }
        else
        {
            Console.WriteLine("Input prayment ID number!");
        }
    }

    public void SearchPaymentByPaymentIdInput()
    {
        Console.WriteLine("\n******* Search a payment by Id ********\n");
        Console.WriteLine("Searching Payment ID: ");
        if (int.TryParse(Console.ReadLine(), out int searchPaymentId))
        {
            try
            {
                if (paymentManager.SearchPaymentByPaymentId(searchPaymentId) != null)
                {
                    Console.WriteLine(paymentManager.SearchPaymentByPaymentId(searchPaymentId));
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

    public bool ReceiptOptionInput(bool quit)
    {
        Console.Clear();
        Console.WriteLine("********* Receipt option ********* ");
        Console.WriteLine("Do you want a receipt? Y/N");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.WriteLine("\n*********** Receipt ********\n");
            DateTime now = DateTime.Now;
            List<Receipt> receipts = new();
            int reservId = TryGetInt("Enter Reservation Id: ");
            Console.WriteLine("*********** Reservation Infor ****************");
            Console.WriteLine(reservationManager.SearchReservationById(reservId));
            Console.WriteLine("*********** Payment Infor ********");
            Receipt receipt = new(now);
            Console.WriteLine(receipt);
            if (paymentManager.SearchPaymentByReservId(reservId).Count != 0)
            {
                foreach (var item in paymentManager.SearchPaymentByReservId(reservId))
                {
                    Console.WriteLine(item);
                }
                
            }

            receipts.Add(receipt);
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

    public void SearchPaymentByReservIdInput()
    {
        Console.WriteLine("\n******* Search a payment by Reservation Id ********\n");
        Console.WriteLine("Reservation ID: ");
        if (int.TryParse(Console.ReadLine(), out int searchPaymentId))
        {
            try
            {
                if (paymentManager.SearchPaymentByReservId(searchPaymentId) != null)
                {
                    Console.WriteLine(paymentManager.SearchPaymentByReservId(searchPaymentId));
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

    public double GetDouble(string message)
    {
        int input = 0;
        while (input < 3)
        {
            Console.WriteLine(message);
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
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

    public int TryGetInt(string prompt)
    {
        int input = 0;
        while (input < 3)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            else
            {
                if (input < 2)
                {
                    Console.WriteLine("Enter a correct number,try again");
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

    public string GetString(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    public void NoTryMessage()
    {
        Console.Write("\nNO more try. Bye!");
    }

    public void LoginWrongMessage()
    {
        Console.Write("\nLoggin unsucced, try again!");
    }

    public bool QuitMessage()
    {
        bool quit;
        Console.WriteLine("You have chosen to quit the program");
        quit = true;
        return quit;
    }



}

