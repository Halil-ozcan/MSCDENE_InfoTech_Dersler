using System;

namespace OOP_HomeWork.HomeWork02;

public class BankAccount
{
    private string? owner; // Mal Sahibi
    private string? accountNumber; // Hesap Numarası
    private decimal balance; // bakiye

    public BankAccount(string? owner, string accountNumber, decimal initialBalance)
    {
        this.owner = owner;
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }

    public string? Owner { get{return owner;}}
    public string? AccountNumber { get{return accountNumber;}}
    public decimal Balance { get{return balance;}}

    public void Deposit(decimal amount)
    {
        if(amount>0)
        {
            balance+=amount;
            Console.WriteLine($"{owner} ({accountNumber}) hesabına {amount:C} yatırıldı. Yeni bakiye: {balance:C}");
        }
        else
        {
            Console.WriteLine("Geçersiz para yatırma işlemi.");
        }
    }

    public void WithDraw(decimal amount)
    {
        if(amount>0 && amount<=balance)
        {
            balance-=amount;
            Console.WriteLine($"{owner} ({accountNumber}) hesabından {amount:C} çekildi. Yeni bakiye: {balance:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye veya geçersiz tutar.");
        }

    }

    public void ShowBalance()
    {
        Console.WriteLine($"{owner} ({accountNumber}) hesabının güncel bakiyesi: {balance:C}");
    }

}
