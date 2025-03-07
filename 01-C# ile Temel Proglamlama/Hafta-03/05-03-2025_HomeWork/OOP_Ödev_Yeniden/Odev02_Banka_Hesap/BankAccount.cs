using System;

namespace Odev02_Banka_Hesap;

public class BankAccount
{
    public BankAccount(string malSahibi, string hesapNumarasi, decimal ilkBakiye)
    {
        MalSahibi = malSahibi;
        HesapNumarasi = hesapNumarasi;
        Bakiye = ilkBakiye;
        
    }

    public string  MalSahibi{ get; private set; }
    public string  HesapNumarasi{ get; private set; }
    public decimal  Bakiye{ get; private set; }

    public void ParaYatir(decimal miktar)
    {
        if(miktar>0)
        {
            Bakiye+=miktar;
            Console.WriteLine($"{MalSahibi} adlı hesaba {miktar:C2} yatırıldı");
        }
        else
        {
            Console.WriteLine("Para yatırma işlemi yapılmadı.");
        }
    }

    public void ParaCek(decimal miktar)
    {
        if(miktar>0 && miktar<=Bakiye)
        {
            Bakiye-=miktar;
            Console.WriteLine($"{MalSahibi} adlı hesaptan {miktar:C2} çekildi");
        }
        else
        {
            Console.WriteLine("Yetersiz Bakiye veya geçersiz miktar.");
        }
    }

    public void BakiyeGoster()
    {
        Console.WriteLine($"{MalSahibi}, adlı hesabın bakiyesi: {Bakiye:C2}");
    }
}
