#region AdYasBilgisi
    
// KOLAY SEVİYE AD YAŞ BİLGİSİ

Console.Write("Merhaba Adinizi Giriniz: ");
string FullName = Console.ReadLine()!;

Console.Write("Merhaba Yasinizi Giriniz: ");
int age = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Merhaba {FullName}, sen {age} yasindasin.");

#endregion

#region DildortgenAlanveCevreBulma

    //KOLAY SEVİYE DildortgenAlanveCevreBulma

    Console.Write("Kisa Kenar Uzunluğu Giriniz: ");
    double kisaKenar = Convert.ToDouble(Console.ReadLine());  

    Console.Write("Uzun Kenar Uzunluğu Giriniz: ");
    double uzunKenar = Convert.ToDouble(Console.ReadLine());

    double alan = kisaKenar * uzunKenar;
    double cevre = (kisaKenar + uzunKenar) * 2;

    Console.WriteLine($"Girilen dikdörtgenin alani: {alan}, ve çevresi: {cevre}");

    
#endregion

#region Dereceyi Fahrenheit'a Cevirme

    // KOLAY SEVİYE - Dereceyi Fahrenheit'a Cevirme,

    Console.Write("Lütfen derce olarak bir sicaklik değeri giriniz: ");
    double sicaklik = Convert.ToDouble(Console.ReadLine());

    double fahrenheit = sicaklik *1.8 + 32;
    
    Console.WriteLine($"Santigrate Derece Cinsinden Girilen {sicaklik} C'nin,  Fahreneit karsılığı : {fahrenheit}");
#endregion