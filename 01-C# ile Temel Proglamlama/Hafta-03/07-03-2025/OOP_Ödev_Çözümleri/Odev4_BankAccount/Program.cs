namespace Odev4_BankAccount;

class Program
{
    static void Main(string[] args)
    {
       BankAccount[] bankAccounts =[
        new BankAccount("Halil Özcan","256314"),
        new BankAccount("Ali Yılmaz","569636"),
        new BankAccount("Hakan Gür","456921"),
       ];

       bankAccounts[0].Deposit(500);
       bankAccounts[1].Deposit(2500);
       bankAccounts[2].Deposit(5000);

       bankAccounts[0].WithDraw(200);
       bankAccounts[1].WithDraw(500);
       bankAccounts[2].WithDraw(400);

       bankAccounts[0].ShowBalance();
       bankAccounts[1].ShowBalance();
       bankAccounts[2].ShowBalance();


       
    }
}
