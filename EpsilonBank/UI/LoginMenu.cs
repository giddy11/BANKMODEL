using EpsilonBank.Models;
using EpsilonBank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.UI
{
    public static class LoginMenu
    {
        public static void SignIn()
        {
            Console.WriteLine("Welcome to your sign in page");
            Console.WriteLine("Enter your email(test@decagon.dev): ");
            string email = Console.ReadLine();
            Console.WriteLine("enter your password: ");
            string password = Console.ReadLine();

            int count = UserCreator.customerBase.Count;
            Customer customer = new(); 
            for (int i = 0; i < count; i++)
            {
                if (UserCreator.customerBase[i].EmailAddress.Equals(email) && UserCreator.customerBase[i].Password.Equals(password))
                {
                    customer = UserCreator.customerBase[i];
                }
            }
            if (customer.Accounts.Count != 0)
            {
                BankOperations.OpenDashBoard(customer);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid email or password!\nTry Signing up or enter a valid email and password");
                Home.HomePage();
            }
            
        }
        public static void SignUp()
        {
            Console.WriteLine("Welcome to sign up page");
            UserCreator.CreateUser();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
