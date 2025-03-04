using System;

namespace Proje16_Encapsulation;

public class BankAccount
{
    public string? FirstName { get; set; }
    private decimal balance;

    public decimal Balance
    {
        get
        {
            return balance;
        }
    }

    public void Withdraw(decimal amount) // Para Çekme
    {
        if(amount>0 && amount<=balance)
        {
            //balance = balance - amount;
            balance-=amount;
            
        }
    }
    public void Deposit(decimal amount) // Para Yatırma
    {
        if(amount>0)
        {
            balance+=amount;
        }
    }
}
