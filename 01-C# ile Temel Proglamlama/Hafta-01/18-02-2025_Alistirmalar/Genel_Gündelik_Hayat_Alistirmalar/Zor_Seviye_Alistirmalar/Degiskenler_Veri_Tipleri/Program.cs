#region Manav Kasa Programı
    // ZOR SEVİYE - Manav Kasa Programı 

    // Console.Write("Lütfen alacağınız meyvenin adını giriniz :");
    // string meyveAdi = Console.ReadLine()!;

    // Console.Write("Lütfen alacağınız meyvenin kg giriniz :");
    // int kg = int.Parse(Console.ReadLine()!);

    // Console.Write("Lütfen alacağınız meyvenin kg Fiyatini giriniz :");
    // int fiyat = int.Parse(Console.ReadLine()!);

    // int result = kg * fiyat;

    // Console.WriteLine($"{meyveAdi} {kg} kg * {fiyat} TL/kg  Toplam Tutar => {result} TL'dir.");

#endregion

#region ATM Simülasyonu
    // ZOR SEVİYE - ATM Simülasyonu
    int bakiye = 5000;

    Console.WriteLine("Seçim Yapınız(1/2): ");
    int secim = int.Parse(Console.ReadLine()!);

    switch(secim)
    {
        case 1:
        
            Console.WriteLine("Lütfen Yatıracağınız parayı giriniz: ");
            int paraYatirma = int.Parse(Console.ReadLine()!);
            bakiye += paraYatirma;
            Console.WriteLine($"Güncel bakiyeniz: {bakiye}");
            break;
        case 2:
            Console.WriteLine("Lütfen Çekeceğiniz parayı giriniz: ");
            int paraCekme = int.Parse(Console.ReadLine()!);
            bakiye -= paraCekme;
            Console.WriteLine($"Güncel Bakiyeniz: {bakiye}");
            break;

        default:
            Console.WriteLine("Hatalı seçim yaptınız!");
            break;
    

    } 
#endregion
