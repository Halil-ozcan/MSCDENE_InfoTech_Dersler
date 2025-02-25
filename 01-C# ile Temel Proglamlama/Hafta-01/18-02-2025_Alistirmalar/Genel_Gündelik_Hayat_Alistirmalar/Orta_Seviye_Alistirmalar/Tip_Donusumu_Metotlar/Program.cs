#region KelimeSayacı
    // Console.Write("Lütfen Bir Cümle Yazınız: ");
    // string cumle = Console.ReadLine()!;
    // int kelimeSayisi = cumle.Split(" ").Length;
    // Console.WriteLine($"Kelime Sayisi: {kelimeSayisi}");
#endregion

#region TelefonNumarasıFormatlama
    Console.Write("Lütfen 10 haneli bir telefon numarası giriniz: ");
    string telefonNumarasi = Console.ReadLine()!;

        string alanKodu = telefonNumarasi.Substring(0, 3); 
        string ilkBolum = telefonNumarasi.Substring(3, 3); 
        string ikinciBolum = telefonNumarasi.Substring(6, 2); 
        string ucuncuBolum = telefonNumarasi.Substring(8, 2);

        string formatlanmisNumara = $"({alanKodu}) {ilkBolum}-{ikinciBolum}-{ucuncuBolum}";

        
        Console.WriteLine($"Formatlanmış telefon numarası: {formatlanmisNumara}");
#endregion

