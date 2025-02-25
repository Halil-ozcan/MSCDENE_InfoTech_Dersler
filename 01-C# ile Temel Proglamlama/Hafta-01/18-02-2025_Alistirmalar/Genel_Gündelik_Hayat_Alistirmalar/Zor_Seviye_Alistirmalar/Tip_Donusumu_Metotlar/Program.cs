#region Metinden Rakamları Çekme
    // Console.Write("Lütfen Bir Adres Giriniz: ");
    // string cumle = Console.ReadLine()!;

    // string sadeceRakamlar = new string(cumle.Where(char.IsDigit).ToArray());

    // Console.WriteLine($"Sadece Rakamlar: {sadeceRakamlar}");
#endregion

#region KullanıcıAdiOlusturucu
    Console.WriteLine("Lütfen adınızı girin:");
    string ad = Console.ReadLine()!;

    Console.WriteLine("Lütfen soyadınızı girin:");
    string soyad = Console.ReadLine()!;

    ad = char.ToUpper(ad[0]) + ad.Substring(1).ToLower();
    soyad = char.ToUpper(soyad[0]) + soyad.Substring(1).ToLower();

    Random rnd = new Random();
    int rastgeleSayilar = rnd.Next(100,1000);

    string kullaniciAdi = ad + soyad + rastgeleSayilar.ToString();

    Console.WriteLine($"Oluşturulan Kullanıcı Adı: {kullaniciAdi}");
#endregion