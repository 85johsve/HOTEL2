using Dapper;
using MySqlConnector;
internal class Program
{





    private static void Main(string[] args)
    {
        Menu menu = new();
        MenuChoiceUser choice = menu.MenuChoiceUserEnumSwitch();
        bool quit = false;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (choice)
            {
                case MenuChoiceUser.Employee:

                    menu.GetEmployeeLogIn();
                    if (menu.employeeIsLoggedIn)
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
                    menu.AddCustomerInput();
                    menu.GetCustomerLogIn();
                    if (menu.customerIsLoggedIn)
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
                    menu.GetCustomerLogIn();
                    if (menu.customerIsLoggedIn)
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
                    menu.GetManagerLogIn();
                    if (menu.managerIsLoggedIn)
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
                    quit = menu.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;

            }
        }
    }

}





