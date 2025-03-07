using System;

namespace Odev4_BankAccount;

public class BankAccount
{
    public BankAccount(string owner, string accountNumber)
    {
        Owner = owner;
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public string Owner { get; private set; }
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if(amount>0)
        {
            Balance=+amount;
            Console.WriteLine($"{Owner} ({AccountNumber}) hesabına {amount} TL yatırıldı. Yeni bakiye: {Balance} TL");
        }
        else
        {
            Console.WriteLine("Geçersiz para yatırma işlemi");
        }
    }

    public void WithDraw(decimal amount)
    {
        if(amount>0 && amount<=Balance)
        {
            Balance-=amount;
            Console.WriteLine($"{Owner} ({AccountNumber}) hesabına {amount} TL Çekildi. Yeni bakiye: {Balance} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz Bakiye");
        }
    }

    public void ShowBalance()
    {
         Console.WriteLine($"{Owner} ({AccountNumber}) hesabının güncel bakiyesi: {Balance} TL ");
    }

}
