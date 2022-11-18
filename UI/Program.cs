﻿using Dapper;
using MySqlConnector;
internal class Program
{





    private static void Main(string[] args)
    {
        Menu menu = new();
        UserInput userInput = new();
        MenuChoiceUser choice = menu.MenuChoiceUserEnumSwitch();
        bool quit = false;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (choice)
            {
                case MenuChoiceUser.Employee:

                    userInput.GetEmployeeLogIn();
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
                    userInput.AddCustomerInput();
                    userInput.GetCustomerLogIn();
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
                    userInput.GetCustomerLogIn();
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
                    userInput.GetManagerLogIn();
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
                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;

            }
        }
    }

}





