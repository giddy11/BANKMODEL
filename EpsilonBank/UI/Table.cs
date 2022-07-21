using EpsilonBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.UI
{
    public static class Table
    {
        public static void PrintAccountDetailsTable(Customer customer)
        {
            CreateAccountDetailsTableHeader();
            int count = customer.Accounts.Count;
            for (int i = 0; i < count; i++)
            {
                AddTableElement(customer.Accounts[i].AccountName, customer.Accounts[i].AccountNumber, customer.Accounts[i].AccountType, customer.Accounts[i].AccountBalance);
            }
            Console.WriteLine(".................................................................................................");
        }
        public static void CreateAccountDetailsTableHeader()
        {
            Console.WriteLine("|...............................................................................................|");
            Console.WriteLine($"|{"FULL NAME",20}|{"ACCOUNT NUMBER  ",15}|{"ACCOUNT TYPE",15}|{"AMOUNT BAL",15}|");
            Console.WriteLine(".................................................................................................\n");
        }


        public static void PrintaccountHistoryTable(List<AccountHistory> accountHistoryList)
        {
            CreateAccountHistoryTableHeader();
            int count = accountHistoryList.Count;
            for (int i = 0; i < count; i++)
            {
                AddAccountHistoryTableElement(accountHistoryList[i].TransactionDate, accountHistoryList[i].Description, accountHistoryList[i].AmountTransacted, accountHistoryList[i].BalanceAfterTransaction, accountHistoryList[i].DestinationAccountNumber);
            }
        }


        private static void AddTableElement(string fullName, string accountNumber, AccountType accountType, decimal accountBalance )
        {
            Console.WriteLine($"|{fullName,-20}|{accountNumber,-15}|{accountType,-15}|{accountBalance,-15}|");
        }

        public static void CreateAccountHistoryTableHeader()
        {
            Console.WriteLine("|...............................................................................................|");
            Console.WriteLine($"|{"TRANSACTION DATE",20}|{"dESCRIPTION  ",15}|{"AMOUNT TRANSACTED",15}|{"BAL AFTER TRANSACTION",15}|{"DESTINATION ACCOUNT",15}|");
            Console.WriteLine(".................................................................................................\n");
        }

        private static void AddAccountHistoryTableElement(DateTime date, string description, decimal amountTransacted, decimal balanceAfterTransaction, string destinationAccountNumber)
        {
            Console.WriteLine($"|{date, -20}|{description,-15}|{amountTransacted,-15}|{balanceAfterTransaction,-15}|{destinationAccountNumber}|");
        }
    }
}
