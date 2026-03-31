using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Accounts
    {
        public int AccountNumber;
        public string CustomerName;
        public string AccountType;
        public double Balance;
        public Accounts(int AccounNumber, String CustomerName, String AccountType)
        {
            this.AccountNumber = AccounNumber;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            Balance = 6000;

        }
        public void credit(double amount)
        {
            Balance += amount;

        }
        public void debit(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;

            }
            else
            {
                Console.WriteLine("Insufficient balance.");

            }
        }

        public virtual void showData()
        {
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Customer Name: " + CustomerName);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance: " + Balance);
        }
    }
    public class Transaction : Accounts
    {
        public char TransactionType;
        public double Amount;
        public Transaction(int accountNumber, string customerName, string accountType)
                    : base(accountNumber, customerName, accountType)
        {
        }

        public void TransactionProcessing()
        {

            if (TransactionType == 'w' || TransactionType == 'W')
            {
                debit(Amount);
            }
            else if (TransactionType == 'D' || TransactionType == 'd')
            {
                credit(Amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }

        public override void showData()
        {
            base.showData();
            Console.WriteLine("Transaction Type: " + TransactionType);
            Console.WriteLine("Amount: " + Amount);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction transaction = new Transaction(12345, "John Doe", "Savings");
            transaction.TransactionType = 'D';
            transaction.Amount = 500.0;
            transaction.TransactionProcessing();
            transaction.showData();

        }

    }
}
