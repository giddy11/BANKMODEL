using EpsilonBank.Models;
using EpsilonBank.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.Utilities
{
    public static class UserCreator
    {
        public static List< Customer> customerBase = new List< Customer >();
        public static void CreateUser()
        {
            string error;
            Console.Write("Enter your firstName: ");
            string firstName = Console.ReadLine();
            while (!Validator.ValidateName(firstName, out error))
            {
                Console.WriteLine(error);
                Console.WriteLine($"{error}\nre-enter name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Enter your lastName: ");
            string lastName = Console.ReadLine();
            while (!Validator.ValidateName(lastName, out error))
            {
                Console.WriteLine($"{error}\nre-enter name: ");
                lastName = Console.ReadLine();
            }

            Console.Write("Enter your age: ");
            var _age = Console.ReadLine();
            while (!Validator.ValidateAge(_age, out error))
            {
                Console.WriteLine($"{error}\nre-enter name");
                _age = Console.ReadLine();
            }
            float age = float.Parse(_age);

            Console.Write("Enter your phone number(+2348162814855) : ");
            string phoneNumber = Console.ReadLine();
            while (!Validator.ValidatePhoneNumber(phoneNumber, out error))
            {
                Console.WriteLine($"{error}\nre-enter phone number: ");
                phoneNumber = Console.ReadLine();
            }

            Console.Write("Enter your email address (user@xyz.com) : ");
            string email = Console.ReadLine();
            while (!Validator.ValidateEmail(email, out error))
            {
                Console.WriteLine($"{error}\nre-enter email: ");
                email = Console.ReadLine();
            }
            Console.WriteLine("Enter your password (Password should be minimum 6 characters that include alphanumeric and at least one special characters (@, #, $, %, ^, &, !)): ");
            string password = Console.ReadLine();
            while (!Validator.ValidatePassword(password, out error))
            {
                Console.WriteLine($"{error}\nre-enter password: ");
                password = Console.ReadLine();
            }

            Address houseAddress = CreateAddress();

            Customer currentCustomer = new Customer(firstName, lastName, age, email, houseAddress, phoneNumber, password);
            Console.Clear();
            customerBase.Add(currentCustomer);
            CreateAccount(currentCustomer);
            BankOperations.OpenDashBoard(currentCustomer);
        }

        public static Address CreateAddress()
        {
            string error;
            Console.Write("Enter your street : ");
            string street = Console.ReadLine();

            Console.Write("Enter your city: ");
            string city = Console.ReadLine();
            while (!Validator.ValidateName(city, out error))
            {
                Console.WriteLine(error);
                Console.WriteLine($"{error}\nre-enter city: ");
                city = Console.ReadLine();
            }

            Console.Write("Enter your state: ");
            string state = Console.ReadLine();
            while (!Validator.ValidateName(state, out error))
            {
                Console.WriteLine(error);
                Console.WriteLine($"{error}\nre-enter state: ");
                state = Console.ReadLine();
            }

            Console.Write("Enter your country: ");
            string country = Console.ReadLine();
            while (!Validator.ValidateName(country, out error))
            {
                Console.WriteLine(error);
                Console.WriteLine($"{error}\nre-enter country: ");
                state = Console.ReadLine();
            }

            return new Address(street,city, state, country);
        }

        public static void CreateAccount(Customer customer)
        {
            Console.WriteLine(@"What kind of account do you want to create?
1: Savings
2: Current");
            Console.WriteLine("Enter your prefered option");
            var _option = Console.ReadLine();
            string error;
            while (!Validator.ValidateNumber(_option, out error) || (float.Parse(_option) < 1 || float.Parse(_option) > 2))
            {
                Console.WriteLine("Enter your desired option");
                _option = Console.ReadLine();
            }

            float option = float.Parse(_option);
            AccountType accountType = option == 1 ? AccountType.Savings : AccountType.Current;

            Account customerAccount = new Account(customer.FullName, accountType);

            customer.Accounts.Add(customerAccount);

            Console.WriteLine($"Your account has been created and your account name is {customer.FullName} and your account number is {customer.Accounts.Last().AccountNumber}");
        }

        public static Account GetAccount(List<Customer> customerBase, string accountNumber)
        {
            int count = customerBase.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < customerBase[i].Accounts.Count; j++)
                {
                    if (customerBase[i].Accounts[j].AccountNumber.Equals(accountNumber))
                    {
                        return customerBase[i].Accounts[j];
                    }
                }
            }
            return new Account();
        }
    }
}
