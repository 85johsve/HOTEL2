using Dapper;
using MySqlConnector;
internal class Program
{

    private static void Main(string[] args)
    {
        Menu menu = new();
        UserInput userInput = new();
        MenuChoiceUser choice = menu.MenuChoiceUserEnumSwitch();
        bool quit = false;
        int employeeId;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (choice)
            {
                case MenuChoiceUser.Employee:

                    userInput.GetEmployeeLogIn();
                    if (userInput.employeeIsLoggedIn)
                    {
                        menu.GetEmployeeMenu();
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.NewCustomer:
                    userInput.AddCustomerInput();
                    userInput.GetCustomerLogIn();
                    if (userInput.customerIsLoggedIn)
                    {
                        menu.GetCustomerMenu();
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.CustomerLogIn:
                    userInput.GetCustomerLogIn();
                    if (userInput.customerIsLoggedIn)
                    {
                        menu.GetCustomerMenu();
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.Manager:
                    userInput.GetManagerLogIn();
                    if (userInput.managerIsLoggedIn)
                    {
                        menu.GetManagerMenu();
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.Quit:
                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;

            }
        }
    }

}





