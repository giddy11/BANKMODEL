using EpsilonBank.Models;
using EpsilonBank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.UI
{
    public static class BankOperations
    {
        public static void OpenDashBoard(Customer customer)
        {
            //Console.Clear();
            Console.WriteLine("@**************************************************************************@");
            Console.WriteLine("Welcome to Epsilon Bank! Giving platinum experiences one customer at a time");
            Console.WriteLine($"Distinguished {customer.FullName}\n What would you like to do?");
            Console.WriteLine("****************************************************************************");
            Console.WriteLine(@"1: Create another account
2: Deposit money
3: withdraw money
4: Transfer money
5: Get balance
6: Get account details
7: Get statement of account
8: Log out");
            Console.WriteLine("@**************************************************************************@");
            Console.WriteLine("Enter your desired option");
            var _option = Console.ReadLine();
            string error;
            while (!Validator.ValidateNumber(_option, out error) || (float.Parse(_option) < 1 || float.Parse(_option) > 8))
            {
                Console.WriteLine("Enter your desired option");
                _option = Console.ReadLine();
            }

            float option = float.Parse(_option);
            if (option == 1)
            {
                CreateAnotherAccount(customer);
                OpenDashBoard(customer);
            }
            else if (option == 2)
            {
                Console.WriteLine("How much do you want to deposit");
                var _amoount = Console.ReadLine();
                while (!Validator.ValidateMoney(_amoount,out error))
                {
                    Console.WriteLine("How much do you want to deposit");
                   _amoount = Console.ReadLine();
                }
                decimal amount = decimal.Parse(_amoount);
                int accountOption = ChooseAccount(customer);
                DepositMoney(customer.Accounts[accountOption-1], amount);
                OpenDashBoard(customer);
            }
            else if(option == 3)
            {
                Console.WriteLine("How much do you want to Withdraw");
                var _amoount = Console.ReadLine();
                while (!Validator.ValidateMoney(_amoount, out error))
                {
                    Console.WriteLine("How much do you want to withdraw");
                    _amoount = Console.ReadLine();
                }
                decimal amount = decimal.Parse(_amoount);
                int accountOption = ChooseAccount(customer);
                WithdrawMoney(customer.Accounts[accountOption-1], amount);
                OpenDashBoard(customer);
            }
            else if(option == 4)
            {
                Console.WriteLine("How much do you want to transfer");
                var _amoount = Console.ReadLine();
                while (!Validator.ValidateMoney(_amoount, out error))
                {
                    Console.WriteLine("How much do you want to transfer");
                    _amoount = Console.ReadLine();
                }
                decimal amount = decimal.Parse(_amoount);
                int accountOption = ChooseAccount(customer);
                Console.WriteLine("Enter the account number you want to transfer to: ");
                string accountNumber = Console.ReadLine();
                Account destinationAccount = UserCreator.GetAccount(UserCreator.customerBase, accountNumber);
                if (!destinationAccount.AccountName.Equals("First"))
                {
                    TransferMoney(customer.Accounts[accountOption - 1], destinationAccount, amount);
                }
                else
                {
                    Console.WriteLine("You have entered in invalid accountNumber ");
                }

                OpenDashBoard(customer);
            }
            else if(option == 5)
            {
                int accountOption = ChooseAccount(customer);
                GetBalance(customer.Accounts[accountOption - 1]);
                OpenDashBoard(customer);
            }
            else if (option == 6)
            {
                GetAccountDetails(customer);
                OpenDashBoard(customer);
            }
            else if (option == 7)
            {
                int accountOption = ChooseAccount(customer);
                List<AccountHistory> history = customer.Accounts[accountOption - 1].AccountHistory;
                GetStatementOfAccount(history);
                OpenDashBoard(customer);

            }
            else
            {
                Home.HomePage();
            }
        }

        public static void CreateAnotherAccount(Customer customer)
        {
            UserCreator.CreateAccount(customer);
        }
        public static void DepositMoney(Account account, decimal amount)
        {
            account.DepositCash(amount);
        }

        public static void WithdrawMoney(Account account, decimal amount)
        {
            account.WithdrawCash(amount);
        }
        public static void TransferMoney(Account senderAccount, Account receiverAccount, decimal amount)
        {
            senderAccount.TransferCash(amount, receiverAccount);
        }

        public static void GetBalance(Account account)
        {
            Console.WriteLine($"Your account balance is {account.AccountBalance}");
        }

        public static int ChooseAccount(Customer customer)
        {
            Console.WriteLine("Which of your accounts do you want to use for this transaction?\n Choose number curresponding to the account");
            int count = customer.Accounts.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}: {customer.Accounts[i].AccountType} {customer.Accounts[i].AccountNumber} {customer.Accounts[i].AccountBalance}");
            }

            Console.WriteLine("Enter your chosen option");
            var _accountOption = Console.ReadLine();
            string _accountOptionError;
            while (!Validator.ValidateNumber(_accountOption, out _accountOptionError) || (int.Parse(_accountOption) < 1 || int.Parse(_accountOption) > 8))
            {
                Console.WriteLine("Enter your desired option");
                _accountOption = Console.ReadLine();
            }

            return  int.Parse(_accountOption);
        }

        public static void GetAccountDetails(Customer customer)
        {
            Table.PrintAccountDetailsTable(customer);
        }

        public static void GetStatementOfAccount(List<AccountHistory> accountHistories)
        {
            Table.PrintaccountHistoryTable(accountHistories);
        }
    }
    
}
