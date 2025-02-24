#region ZamliMaasHesaplama
    // ORTA SEVİYE - ZamliMaasHesaplama
    
    Console.Write("Merhaba Lütfen Maas Bilginizi Giriniz: ");
    double maas = Convert.ToDouble(Console.ReadLine());

    Console.Write("Lütfen Zam oranını Giriniz: ");
    double zam = Convert.ToDouble(Console.ReadLine());

    int zamHesaplama = (int)(maas * zam)/100;

    Console.WriteLine($"Çalışan Elemanın zam öncesi Maası: {maas}, yapılan zam: %{zam} ve net alınan Maas: {maas + zamHesaplama} TL olarak Güncellenmiştir.");
#endregion

#region UcegeninHipotenusunuBulma
    // ORTA SEVİYE - UcegeninHipotenusunuBulma

    Console.Write("Üçgenin birinci dik kenarını giriniz: ");
    double kenar1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Üçgenin ikinci dik kenarını giriniz: ");
    double kenar2 = Convert.ToDouble(Console.ReadLine());

    double result = Math.Sqrt(Math.Pow(kenar1,2) + Math.Pow(kenar2,2));

    Console.WriteLine($"İki dik kenarı Girilen Üçgenin hipotenüsü: {result}");
#endregion

#region TaksimetreUcreti
    // ORTA SEVİYE - TaksimetreUcreti

    Console.WriteLine("Merhaba Taksimetre uygulamasına Hoş Geldiniz Açılış Ücreti : 20 TL dir");
    Console.Write("Lütfen Gitmek İstediğiniz Mesafeyi Giriniz(km): ");
    int mesafe = int.Parse(Console.ReadLine()!);
    int acilisUcreti = 20;
    double ucret = mesafe * 10 + acilisUcreti;

    Console.WriteLine($"Toplam Gidilen Yol: {mesafe}km, km başına alınan ücret: {10} TL ve açılış ucreti: {acilisUcreti} TL olarak hesaplandığında toplam tutar: {ucret} TL olarak hesaplandi."); 
#endregion

#region Vücut Kitle İndeksi (BMI) Hesaplama:
    // ORTA SEVİYE - Vücut Kitle İndeksi (BMI) Hesaplama:

    Console.Write("Lütfen boyunuzu Giriniz(m): ");
    double boy = Convert.ToDouble(Console.ReadLine());

    Console.Write("Lütfen kilonuzu Giriniz(kg): ");
    double kilo = Convert.ToDouble(Console.ReadLine());

    double BMI = kilo /(kilo * boy);

    Console.WriteLine($"Ekrana Girilen Boy: {boy} metre ve Kilo: {kilo} kg BMI değeri: {BMI} olarak hesaplanmıştır.");
#endregion