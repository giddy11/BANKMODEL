namespace EpsilonBank.Models
{
    public class AccountHistory
    {
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal AmountTransacted { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public string DestinationAccountNumber { get; set; }

        public AccountHistory(string description, decimal amountTransacted, decimal balanceAfterTransaction, string destinationAccountNumber)
        {
            Description = description;
            AmountTransacted = amountTransacted;
            BalanceAfterTransaction = balanceAfterTransaction;
            DestinationAccountNumber = destinationAccountNumber;
            TransactionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Date: {TransactionDate} Description: {Description} Amount Transacted {AmountTransacted} Destination Account: {DestinationAccountNumber} Balance: {BalanceAfterTransaction}";
        }
    }
}
