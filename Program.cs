internal class Program
{
    private static void Main(string[] args)
    {
        foreach ( string c in Enum.GetNames(typeof (MenuChoiceStaff )) )
        Console.WriteLine( "{0,-11}= {1}", c, Enum.Format( typeof (MenuChoiceStaff ) , Enum.Parse(typeof (MenuChoiceStaff ) , c), "d"));

        Console.WriteLine("Select one of the options:");
        int input =int.Parse(Console.ReadLine ());
        MenuChoiceStaff choice=(MenuChoiceStaff )input ;


        switch (choice)
        {
            case MenuChoiceStaff.ShowRoom:
            Console.WriteLine ("Show Available Rooms");  //Behöver ändra dessa till anrop
            break;

            case MenuChoiceStaff.CheckIn:
            Console.WriteLine ("Check in/Check out");
            break;

            case MenuChoiceStaff.AddRoom:
            Console.WriteLine ("Add/Remove Rooms");
            break;

            case MenuChoiceStaff.Receipt:
            Console.WriteLine ("Print Receipt");
            break;

            case MenuChoiceStaff.Quit:
            Console.WriteLine ("Quit");
            break;


            default:
            break;

        }
        
        foreach ( string c in Enum.GetNames(typeof (MenuChoiceCustomer )) )
        Console.WriteLine( "{0,-11}= {1}", c, Enum.Format( typeof (MenuChoiceCustomer ) , Enum.Parse(typeof (MenuChoiceCustomer ) , c), "d"));

        Console.WriteLine("Select one of the options:");
        int CustomerInput =int.Parse(Console.ReadLine ());
        MenuChoiceCustomer CustomerChoice=(MenuChoiceCustomer )CustomerInput;


        switch (CustomerChoice)
        {
            case MenuChoiceCustomer.ViewRoom:
            Console.WriteLine ("View Available Rooms");
            break;

            case MenuChoiceCustomer.ViewReviews:
            Console.WriteLine ("View Reviews");
            break;

            case MenuChoiceCustomer.BookRoom:
            Console.WriteLine ("Book Room");
            break;

            case MenuChoiceCustomer.WriteReview:
            Console.WriteLine ("Write Review");
            break;

            case MenuChoiceCustomer.Quit:
            Console.WriteLine ("Quit");
            break;


            default:
            break;
        }

    }
}