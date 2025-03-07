namespace Odev02_Banka_Hesap;

class Program
{
    static void Main(string[] args)
    {
        BankAccount[] bankAccounts = [
            new BankAccount("Halil Özcan", "12301",1500.250m),
            new BankAccount("Hakan Gür", "12302",3000.125m),
            new BankAccount("Cansu Dalkılıç", "12303",1200.452m),
        ];

        bankAccounts[0].ParaYatir(3500);
        bankAccounts[0].ParaCek(5000);
        bankAccounts[0].BakiyeGoster();

        bankAccounts[1].ParaYatir(3500);
        bankAccounts[1].ParaCek(5000);
        bankAccounts[1].BakiyeGoster();

        bankAccounts[2].ParaYatir(3500);
        bankAccounts[2].ParaCek(5000);
        bankAccounts[2].BakiyeGoster();
    }
}
