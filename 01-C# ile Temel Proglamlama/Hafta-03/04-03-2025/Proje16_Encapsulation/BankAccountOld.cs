using System;

namespace Proje16_Encapsulation;

public class BankAccountOld
{
    private decimal balance; //bakiye
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
    public decimal GetBalance() // Miktarı Gösterme
    {
        return balance;
    }
}
