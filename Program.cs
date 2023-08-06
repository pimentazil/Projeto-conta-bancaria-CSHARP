using System;
using System.Globalization;
using contaBancaria.Entities.Exceptions;
using contaBancaria.Entitites;

public class ProcessFile

{
    public static void Main()
    {
        Console.WriteLine("Enter account data");
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Holder: ");
        string nome = Console.ReadLine();
        Console.Write("Saldo na conta: ");
        double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Limite para saque: ");
        double withDrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        Account account = new Account(number, nome, balance, withDrawLimit);

        Console.WriteLine();
        Console.Write("Enter amount for withdraw: ");
        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        try
        {
            account.WithDraw(amount);
            Console.WriteLine("New balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
        }
        catch (DomainException e)
        {
            Console.WriteLine("Withdraw error: " + e.Message);
        }

    }
}