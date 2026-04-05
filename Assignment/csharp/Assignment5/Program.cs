
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment5
{
    
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }
        public class BankAccount
        {
            private decimal balance;

            
            public BankAccount(decimal initialBalance)
            {
                if (initialBalance < 0)
                {
                    throw new ArgumentException("Initial balance cannot be negative");
                }

                balance = initialBalance;
            }

            
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be greater than zero");
                }

                balance += amount;
            }

           
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be greater than zero");
                }

                if (amount > balance)
                {
                    throw new InsufficientBalanceException(
                        "Insufficient balance. Available balance: " + balance
                    );
                }

                balance -= amount;
            }

           
            public decimal GetBalance()
            {
                return balance;
            }
    }
        class Program
        {
            static void Main()
            {
                try
                {
                    Console.Write("Enter initial balance: ");
                    decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

                    BankAccount account = new BankAccount(initialBalance);

                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.Write("Enter your choice (1 or 2): ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter deposit amount: ");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            account.Deposit(depositAmount);
                            Console.WriteLine("Deposit successful.");
                            break;

                        case 2:
                            Console.Write("Enter withdrawal amount: ");
                            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Withdrawal successful.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            return;
                    }

                    Console.WriteLine("Current balance: " + account.GetBalance());
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Custom Exception: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Input Error: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter numeric values.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Transaction completed.");
                }
            }
        }
    }