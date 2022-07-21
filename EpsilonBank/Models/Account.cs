using EpsilonBank.Utilities;

namespace EpsilonBank.Models
{
    public class Account
    {
        public Account()
        {
            AccountName = "First";
        }
        public Account(string accountName, AccountType accountType)
        {
            AccountName = accountName;
            AccountType = accountType;
            AccountHistory = new List<AccountHistory>();
            AccountNumber = AccountNumberGenerator.GenerateAccountNumber();
        }

        public string AccountName { get; set; }
        public string AccountNumber { get;  private set; }
        public AccountType AccountType { get; private set; }
        public decimal AccountBalance { get; private set; }
        public List<AccountHistory> AccountHistory { get; private set; }//tight coupling spotted


        //form a class with this methods and call it Account Services
        public void DepositCash(decimal amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
                AccountHistory.Add(
                    new AccountHistory("Deposit", amount, AccountBalance, AccountNumber)
                    );
                Console.WriteLine($"Deposit successful\n{AccountHistory.Last().ToString()}");
            }
            else
            {
                Console.WriteLine("enter a valid amount");
            }
        }

        public void WithdrawCash(decimal amount)
        {
            if (amount > 0)
            {
                if (AccountType.GetType().Equals(AccountType.Current))
                {
                    if (AccountBalance >= amount)
                    {
                        AccountBalance -= amount;

                        Console.WriteLine($"Withdrawal successful\n{AccountHistory.Last().ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
                else
                {
                    if (AccountBalance - amount >= 1000)
                    {
                        AccountBalance -= amount;
                        AccountHistory.Add(
                        new AccountHistory("Withdrawal", amount, AccountBalance, AccountNumber)
                    );
                        Console.WriteLine($"Withdrawal successful\n{AccountHistory.Last().ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter a valid amount");
            }
        }

        public void TransferCash(decimal amount, Account account)
        {
            if (amount > 0)
            {
                if (AccountType.GetType().Equals(AccountType.Current))
                {
                    if (AccountBalance >= amount)
                    {
                        AccountBalance -= amount;
                        AccountHistory.Add(
                        new AccountHistory("Transfer", amount, AccountBalance, AccountNumber)
                    );
                        account.AccountBalance += amount;
                        account.AccountHistory.Add(new AccountHistory($"Transfer from {AccountName}", amount, account.AccountBalance, account.AccountNumber));
                        Console.WriteLine($"Transfer successful\n{AccountHistory.Last().ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
                else
                {
                    if (AccountBalance - amount >= 1000)
                    {
                        AccountBalance -= amount;
                        AccountHistory.Add(
                        new AccountHistory("Transfer", amount, AccountBalance, AccountNumber)
                    );
                        account.AccountBalance += amount;
                        account.AccountHistory.Add(new AccountHistory($"Transfer from {AccountName}", amount, account.AccountBalance, account.AccountNumber));
                        Console.WriteLine($"Transfer successful\n{AccountHistory.Last().ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter a valid amount");
            }
        }
    }
}
