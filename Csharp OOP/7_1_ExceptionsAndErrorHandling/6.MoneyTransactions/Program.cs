using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = InputData();

            RunEngine(accounts);
        }

        static Dictionary<int, double> InputData()
        {
            List<string> input = Console.ReadLine().Split(",").ToList();
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach ((int account, double balance) in from string item in input
                                                      let tokens = item.Split("-")
                                                      let account = int.Parse(tokens[0])
                                                      let balance = double.Parse(tokens[1])
                                                      select (account, balance))
            {
                accounts.Add(account, balance);
            }

            return accounts;
        }

        static void RunEngine(Dictionary<int, double> accounts)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string action = tokens[0];
                    int accountID = int.Parse(tokens[1]);
                    double balance = double.Parse(tokens[2]);

                    switch (action)
                    {
                        case "Deposit":
                            GetDeposit(accounts, accountID, balance);
                            break;
                        case "Withdraw":
                            GetWithdraw(accounts, accountID, balance);
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {

                    Console.WriteLine("Enter another command");

                }

                command = Console.ReadLine();
            }
        }

        private static void GetDeposit(Dictionary<int, double> accounts, int accountID, double balance)
        {
            ValidateID(accountID, accounts);
            accounts[accountID] += balance;
            Console.WriteLine($"Account {accountID} has new balance: {accounts[accountID]:f2}");
        }

        private static void GetWithdraw(Dictionary<int, double> accounts, int accountID, double balance)
        {
            ValidateID(accountID, accounts);
            ValidateBalance(balance, accountID, accounts);
            accounts[accountID] -= balance;
            Console.WriteLine($"Account {accountID} has new balance: {accounts[accountID]:f2}");
        }

        static bool ValidateID(int accountID, Dictionary<int, double> accounts)
        {
            if (!accounts.ContainsKey(accountID))
            {
                throw new ArgumentException("Invalid account!");

            }

            return true;
        }

        static bool ValidateBalance(double balance, int accountID, Dictionary<int, double> accounts)
        {
            if (accounts[accountID] < balance)
            {
                throw new ArgumentException("Insufficient balance!");
            }

            return true;
        }
    }
}


