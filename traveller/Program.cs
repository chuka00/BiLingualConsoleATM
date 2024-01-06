/*using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our Travel Agency!");

        string[] destinations = { "Lagos", "Abuja", "Port Harcourt" };
        int[] costs = { 500, 400, 450 };

        while (true)
        {
            Console.WriteLine("Please select a destination:");
            for (int i = 0; i < destinations.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {destinations[i]}");
            }

            if (int.TryParse(Console.ReadLine(), out int destination) && destination >= 1 && destination <= destinations.Length)
            {
                Console.WriteLine($"You selected {destinations[destination - 1]}.");
                Console.WriteLine("Please select a travel package:");
                Console.WriteLine("1. Basic (includes flight only)");
                Console.WriteLine("2. Standard (includes flight and hotel)");
                Console.WriteLine("3. Premium (includes flight, hotel, and car rental)");

                if (int.TryParse(Console.ReadLine(), out int package) && package >= 1 && package <= 3)
                {
                    int totalCost = costs[destination - 1];
                    switch (package)
                    {
                        case 2:
                            totalCost += 200; // additional cost for hotel
                            break;
                        case 3:
                            totalCost += 500; // additional cost for hotel and car rental
                            break;
                    }
                    Console.WriteLine($"The total cost is ${totalCost}.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please select a valid travel package.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please select a valid destination.");
            }
        }
    }
}
*/

using System;
using System.Collections.Generic;

public class Account
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public Account(string name, decimal initialBalance)
    {
        Name = name;
        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"You have withdrawn {amount}. Your new balance is {Balance}.");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"You have deposited {amount}. Your new balance is {Balance}.");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Your balance is {Balance}.");
    }
}

public class Program
{
    static Dictionary<string, Account> accounts = new Dictionary<string, Account>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our ATM!");
        Console.WriteLine("Please select a language:");
        Console.WriteLine("1. English");
        Console.WriteLine("2. French");
        Console.WriteLine("3. Spanish");

        int language = Convert.ToInt32(Console.ReadLine());

        switch (language)
        {
            case 1:
                Console.WriteLine("You selected English.");
                break;
            case 2:
                Console.WriteLine("Vous avez sélectionné le français.");
                break;
            case 3:
                Console.WriteLine("Has seleccionado español.");
                break;
            default:
                Console.WriteLine("Invalid selection. Please select a valid language.");
                break;
        }

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Check balance");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Deposit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    CheckBalance();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    Deposit();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter initial deposit:");
        decimal initialDeposit = Convert.ToDecimal(Console.ReadLine());
        var account = new Account(name, initialDeposit);
        accounts[name] = account;
        Console.WriteLine($"Account created for {name} with initial deposit of {initialDeposit}.");
    }

    static void CheckBalance()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        if (accounts.ContainsKey(name))
        {
            accounts[name].CheckBalance();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void Withdraw()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter amount to withdraw:");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        if (accounts.ContainsKey(name))
        {
            accounts[name].Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void Deposit()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter amount to deposit:");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        if (accounts.ContainsKey(name))
        {
            accounts[name].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
}
