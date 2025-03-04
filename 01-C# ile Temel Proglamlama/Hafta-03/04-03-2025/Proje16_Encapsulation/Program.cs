namespace Proje16_Encapsulation;

class Program
{
    static void Main(string[] args)
    {


        BankAccount bankAccount = new BankAccount();
        bankAccount.Deposit(30000);
        Console.WriteLine($"Hesabın açılış bakiyesi: {bankAccount.Balance}");
        //bankAccount.Balance = 5454; // bu hata veriyor çünkü set işlemi yapılmadı sadece get işleimi yapıldı yanı salt okunur halde. 
        bankAccount.FirstName = "dfksdlkfd";


        // BankAccountOld bankAccount1 = new BankAccountOld();
        // bankAccount1.Deposit(100000);
        // Console.WriteLine($"Heabın Açılış Bakiyesi: { bankAccount1.GetBalance()}");
        // bankAccount1.Deposit(25000);
        // Console.WriteLine($"Hesabın Şu anki Bakiyesi: {bankAccount1.GetBalance()}");
        // bankAccount1.Withdraw(75000);
        // Console.WriteLine($"Hesabın Şu anki Bakiyesi: {bankAccount1.GetBalance()}");
    }
}
