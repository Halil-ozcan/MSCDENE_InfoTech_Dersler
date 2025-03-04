#region Market Fis Hesaplayıcı

// Metot
// static void HesaplaVeGoster(string[] urunler, int[] fiyatlar, int urunSayisi)
// {
//     double toplamTutar=0;
//     Console.WriteLine("\nAlişveriş Fişiniz: ");
//     Console.WriteLine("---------------------");
//     for (var i = 0; i < urunSayisi; i++)
//     {
//         Console.WriteLine($"{urunler[i]}: {fiyatlar[i]}");
//         toplamTutar+=fiyatlar[i];
//     }
//     Console.WriteLine("------------------------");

//     if(toplamTutar>500)
//     {
//         double indirim = toplamTutar * 0.10;
//         toplamTutar -=indirim;
//         Console.WriteLine("Büyük alişveriş yaptınız! %10 indirim kazandınız.");
//         Console.WriteLine($"İndirim: -{indirim:C}");
//     }

//     Console.WriteLine($"Toplam Ödenecek Tutar: {toplamTutar:C}");
// }

// string[] urunler = new string[100];
// int[] fiyatlar = new int[100];
// int urunSayisi=0;

// Console.WriteLine("Market Fiş Hesaplayıcıya Hoşgeldiniz: ");
// while (true)
// {
//     Console.Write("Ürün Adını Giriniz(Fişi tamamlamak için 'tamam' yazın):");
//     string urun = Console.ReadLine()!;
    
//     if(urun.ToLower() == "tamam")
//         break;

//     Console.Write("Ürün Fiyatını Giriniz: ");
//     if(int.TryParse(Console.ReadLine(), out int fiyat))
//     {
//         urunler[urunSayisi] = urun;
//         fiyatlar[urunSayisi] = fiyat;
//         urunSayisi++;
//     }
//     else
//     {
//         Console.WriteLine("Geçerli bir fiyat giriniz: ");
//     } 

//     HesaplaVeGoster(urunler, fiyatlar, urunSayisi);         
// }


#endregion

#region Hava Durumu Öneri Asistanı
Random rnd = new Random();
string[] havaDurumlari = {"Güneşli", "Yağmurlu", "Karlı", "Sisli", "Rüzgarlı", "Bulutlu"};
while (true)
{
    Console.Write("Bir Şehir Giriniz: ");
    string sehir = Console.ReadLine()!;
    string havaDurumu = havaDurumlari[rnd.Next(havaDurumlari.Length)];
    string kiyafetOnerisi = KiyafetOner(havaDurumu);

    Console.WriteLine($"{sehir} için hava durumu: {havaDurumu}");
    Console.WriteLine($"Önerilen kıyafet: {kiyafetOnerisi}\n");
                
    Console.Write("Başka bir şehir için hava durumu görmek ister misiniz? (evet/hayır): ");
    string devamMi = Console.ReadLine()!.ToLower();
                
    if (devamMi != "evet")
    {
        Console.WriteLine("Programdan çıkılıyor...");
        break;
    }

}

// Metot

static string KiyafetOner(string havaDurumu)
{
    switch (havaDurumu)
    {
        case "Güneşli":
            return "Tişört ve şort giyebilirsiniz. Güneş gözlüğü almayı unutmayın!";
        case "Yağmurlu":
            return "Yağmurluk ve su geçirmez bot giyin. Şemsiyenizi yanınıza alın!";
        case "Karlı":
            return "Kalın mont, atkı ve eldiven giyin. Soğuk havaya dikkat edin!";
        case "Sisli":
            return "Hafif bir ceket yeterli olabilir, ancak dikkatli olun!";
        case "Rüzgarlı":
            return "Rüzgarlık veya hafif mont giymeniz önerilir.";
        case "Bulutlu":
            return "Mevsime uygun kıyafet giyin, hava serin olabilir.";
        default:
            return "Mevsime uygun kıyafet seçin.";
        }
}

#endregion


