using System;
using System.Collections.Generic;

class Account
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Summani noto'g'ri kiritdingiz.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Summani noto'g'ri kiritdingiz.");
        if (amount > Balance) throw new InvalidOperationException("Balans yetarli emas.");
        Balance -= amount;
    }

    public decimal GetBalance() => Balance;
}

class Customer
{
    public string Name { get; private set; }
    public Account CustomerAccount { get; private set; }

    public Customer(string name, Account account)
    {
        Name = name;
        CustomerAccount = account;
    }
}

class Bank
{
    private List<Customer> customers = new List<Customer>();

    public Customer OpenAccount(string name, string accountNumber, decimal initialBalance)
    {
        Account newAccount = new Account(accountNumber, initialBalance);
        Customer newCustomer = new Customer(name, newAccount);
        customers.Add(newCustomer);
        return newCustomer;
    }

    public void CloseAccount(string accountNumber)
    {
        Customer customer = customers.Find(c => c.CustomerAccount.AccountNumber == accountNumber);
        if (customer == null) throw new InvalidOperationException("Hisob topilmadi.");
        customers.Remove(customer);
    }

    public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
    {
        Account fromAccount = customers.Find(c => c.CustomerAccount.AccountNumber == fromAccountNumber)?.CustomerAccount;
        Account toAccount = customers.Find(c => c.CustomerAccount.AccountNumber == toAccountNumber)?.CustomerAccount;

        if (fromAccount == null || toAccount == null) throw new InvalidOperationException("Hisob topilmadi.");

        fromAccount.Withdraw(amount);
        toAccount.Deposit(amount);
    }

    public void DisplayBalances()
    {
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Name} hisob raqami: {customer.CustomerAccount.AccountNumber}, Balans: {customer.CustomerAccount.GetBalance()} so'm.");
        }
    }
}

class BankApp
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        var customer1 = bank.OpenAccount("Ali", "12345", 100000);
        var customer2 = bank.OpenAccount("Vali", "67890", 200000);

        Console.WriteLine("Boshlang'ich balanslar:");
        bank.DisplayBalances();

        bank.Transfer("12345", "67890", 50000);

        Console.WriteLine("\nTranzaktsiyadan keyingi balanslar:");
        bank.DisplayBalances();

        bank.CloseAccount("12345");
        Console.WriteLine("\nAli hisobini yopgandan keyingi balanslar:");
        bank.DisplayBalances();
    }
}

