using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        Database newDatabase = new Database();
        var database = new Database();

        Console.WriteLine("Employee Press [1]\nCustomer Press [2]");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            Employee();
        }
        else if (answer == "2")
        {
            Customer();
        }
    }
    static void Employee()
    {
        Console.Clear();

        int employeeID = GetID();

        if (employeeID != 1 || employeeID != 2 || employeeID != 3) //Hämta från databasen
        {
            Console.WriteLine("ID not recognized! Try again");
        }

        if (employeeID == 1 || employeeID == 2 || employeeID == 3) //Hämta från databasen
        {
            foreach (string c in Enum.GetNames(typeof(MenuChoiceStaff)))
                Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceStaff), Enum.Parse(typeof(MenuChoiceStaff), c), "d"));

            Console.WriteLine("Select one of the options:");
            int input = int.Parse(Console.ReadLine());
            MenuChoiceStaff choice = (MenuChoiceStaff)input;

            switch (choice)
            {
                case MenuChoiceStaff.ShowRoom:
                    Console.WriteLine("Show available rooms");//RoomManager.ShowAvailableRoom();  //Behöver ändra dessa till anrop
                    break;

                case MenuChoiceStaff.CheckIn:
                    Console.WriteLine("Check in/Check out");
                    break;

                case MenuChoiceStaff.AddRoom:
                    Console.WriteLine("Add/Remove Rooms");
                    break;

                case MenuChoiceStaff.Receipt:
                    Console.WriteLine("Print Receipt");
                    break;

                case MenuChoiceStaff.Quit:
                    Console.WriteLine("Quit");
                    break;

                default:
                    break;
            }
        }
        else
            Console.WriteLine("No ID identified!");

    }

    static void Customer()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));
        GetCustomerInput();

    }

    private static void GetCustomerInput()
    {
        Console.WriteLine("Select one of the options:");
        int CustomerInput = int.Parse(Console.ReadLine());
        MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)CustomerInput;


        switch (CustomerChoice)
        {
            case MenuChoiceCustomer.ViewRoom:
                Console.WriteLine("View Available Rooms");
                break;

            case MenuChoiceCustomer.ViewReviews:
                Console.WriteLine("View Reviews");
                break;

            case MenuChoiceCustomer.BookRoom:
                Console.WriteLine("Book Room");
                break;

            case MenuChoiceCustomer.WriteReview:
                Console.WriteLine("Write Review");
                break;

            case MenuChoiceCustomer.Quit:
                Console.WriteLine("Quit");
                break;


            default:
                break;
        }
    }

    private static int GetID()
    {
        Console.WriteLine("Please enter your ID: "); //For-loop i<3?
        int employeeID = int.Parse(Console.ReadLine());
        return employeeID;
    }
    // static void Login()
    // {
    //     for (int i = 1; i < 3; i++)
    //     {
    //     Console.WriteLine("Please enter your employee ID: "); //For-loop i<3?
    //     string employeeID = Console.ReadLine();

    //     if (employeeID != "1" || employeeID != "2" || employeeID !="3") //Hämta från databasen
    //     {
    //         Console.WriteLine("ID not recognized! Try again");   
    //     }
    //     }
    // }
}