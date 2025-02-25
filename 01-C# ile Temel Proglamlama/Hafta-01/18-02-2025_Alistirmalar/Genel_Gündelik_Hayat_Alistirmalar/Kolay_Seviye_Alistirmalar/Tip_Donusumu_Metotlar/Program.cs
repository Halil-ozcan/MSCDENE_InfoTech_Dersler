#region YasHesaplama
    // Console.WriteLine("Lütfen dogum yılınızı giriniz: ");
    // string year = Console.ReadLine()!;
    // int age = Convert.ToInt32(year);
    // DateTime today = DateTime.Today;
    // int newToday = today.Year;
    // int result = newToday -  age;
    // Console.WriteLine($"Bugünkü yasınız: {result}");
#endregion

#region İkiSayıyıToplama
    // Console.Write("Lütfen Birinci Sayiyi Giriniz: ");
    // string number1 = Console.ReadLine()!;

    // Console.Write("Lütfen İkinci Sayiyi Giriniz: ");
    // string number2 = Console.ReadLine()!;

    // int toplam = int.Parse(number1) + int.Parse(number2);
    // Console.WriteLine($"{number1} + {number2} = {toplam}");
#endregion

#region MetniBüyük/KüçükHarfeÇevirme
    Console.WriteLine("Lütfen Bir Cümle Yazınız: ");
    string cumle = Console.ReadLine()!.ToUpper();
    Console.WriteLine(cumle);
    Console.WriteLine(cumle.ToLower());
#endregion