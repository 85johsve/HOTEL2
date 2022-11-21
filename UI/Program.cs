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
        int customerId;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (choice)
            {
                case MenuChoiceUser.Employee:

                    employeeId = userInput.GetEmployeeLogIn();
                    if (userInput.employeeIsLoggedIn)
                    {
                        menu.GetEmployeeMenu(employeeId);
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.NewCustomer:
                    userInput.AddCustomerInput();
                    customerId = userInput.GetCustomerLogIn();
                    if (userInput.customerIsLoggedIn)
                    {
                        menu.GetCustomerMenu(customerId);
                        break;
                    }
                    else
                    {
                        menu.MenuChoiceUserEnumSwitch();
                    }
                    break;

                case MenuChoiceUser.CustomerLogIn:
                    customerId = userInput.GetCustomerLogIn();
                    if (userInput.customerIsLoggedIn)
                    {
                        menu.GetCustomerMenu(customerId);
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





