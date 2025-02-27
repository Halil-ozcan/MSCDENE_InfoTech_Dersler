#region HomeWork01
// Kullanıcıdan alınan bir sayının pozitif, negatif veya sıfır olduğunu kontrol eden bir program yazın.

// Console.Write("Lütfen Bir Sayi Giriniz: ");
// int sayi = int.Parse(Console.ReadLine()!);

// if(sayi>0)
// {
//     Console.WriteLine($"{sayi} Sayisi Pozitif");
// }
// else if(sayi<0)
// {
//     Console.WriteLine($"{sayi} Sayisi negatif");
// }
// else
// {
//     Console.WriteLine($"{sayi} Sayisi Sıfır");
// }
#endregion

#region HomeWork02
// Kullanıcıdan alınan üç sayıyı büyükten küçüğe sıralayan bir program yazın.
// Console.Write("Lütfen Birinci Sayi Giriniz: ");
// int sayi1 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen İkinci Sayi Giriniz: ");
// int sayi2 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen Üçüncü Sayi Giriniz: ");
// int sayi3 = int.Parse(Console.ReadLine()!);

// if(sayi1>=sayi2 && sayi2>=sayi3)
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi1}, sonra {sayi2}, en son {sayi3}");
// }
// else if(sayi2>=sayi1 && sayi1>=sayi3)
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi2}, sonra {sayi1}, en son {sayi3}");
// }
// else if(sayi3>=sayi1 && sayi1>=sayi2)
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi3}, sonra {sayi1}, en son {sayi2}");
// }
// else if(sayi2>=sayi3 && sayi3>=sayi1)
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi2}, sonra {sayi3}, en son {sayi1}");
// }
// else if(sayi1>=sayi3 && sayi3>=sayi2)
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi1}, sonra {sayi3}, en son {sayi2}");
// }
// else
// {
//     Console.WriteLine($"En büyük Sayimiz {sayi3}, sonra {sayi2}, en son {sayi1}");
// }
#endregion

#region HomeWork03
//Kullanıcıdan alınan bir karakterin sesli harf olup olmadığını kontrol eden bir program yazın. (Veya (||) operatörünü araştırınız.)
// Console.Write("Bir Karakter Girin: ");
// char karakter = char.ToLower(Console.ReadKey().KeyChar);
// Console.WriteLine();

// if(karakter == 'a' || karakter == 'e' || karakter == 'ı' || karakter == 'i' || karakter == 'o' || karakter == 'ö' || karakter == 'u' || karakter == 'ü')
// {
//    Console.WriteLine($"'{karakter}' bir sesli harftir.");
// }
// else
// {
//     Console.WriteLine($"'{karakter}' bir sessiz harftir.");
// }
#endregion

#region HomeWork04
//Kullanıcıdan alınan bir yılın artık yıl olup olmadığını kontrol eden bir program yazın.

// Console.Write("Bir Yil Girin: ");
// int yil = int.Parse(Console.ReadLine()!);

// if((yil % 400 == 0) || (yil % 4 == 0 && yil % 100 !=0))
// {
//     Console.WriteLine($"{yil} bir artik yildir.");
// }
// else
// {
//       Console.WriteLine($"{yil} bir artik yil değildir.");
// }   
#endregion

#region HomeWork05
//Kullanıcıdan alınan üç sayının bir üçgen oluşturup oluşturamayacağını kontrol eden bir program yazın. (Geometride üçgen teorisini araştırınız.)

// Console.Write("Lütfen Üçgen oluşturmak için birinci kenarı giriniz: ");
// int kenar1 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen Üçgen oluşturmak için ikinci kenarı giriniz: ");
// int kenar2 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen Üçgen oluşturmak için üçüncü kenarı giriniz: ");
// int kenar3 = int.Parse(Console.ReadLine()!);

// if((kenar1 + kenar2>kenar3) || (kenar1 + kenar3>kenar2) || (kenar2 + kenar3>kenar1))
// {
//     Console.WriteLine($"Kenarlar: {kenar1}, {kenar2}, {kenar3} bu kenarlarla üçgen oluşturulabilir.");
// }
// else
// {
//     Console.WriteLine($"Kenarlar: {kenar1}, {kenar2}, {kenar3} bu kenarlarla üçgen oluşturulamaz.");
// }
#endregion

#region Homework06
// Kullanıcıdan alınan bir notun aşağıdaki tabloya göre harf karşılığını veren bir program yazın.
// Console.Write("Lütfen notunuzu girin (Yeterli için 'YE', Yetersiz için 'YS', Devamsız için 'DS' yazabilirsiniz): ");
// string girdi = Console.ReadLine()!.ToUpper().Trim();
// string harfNotu;

// if (girdi == "YE")
//     harfNotu = "Yeterli (YE)";
// else if (girdi == "YS")
//     harfNotu = "Yetersiz (YS)";
// else if (girdi == "DS")
//     harfNotu = "Devamsız (DS)";
// else
// {
            
//     if (int.TryParse(girdi, out int not))
//     {
//         if (not >= 90 && not <= 100)
//             harfNotu = "AA";
//         else if (not >= 85)
//             harfNotu = "BA";
//         else if (not >= 80)
//             harfNotu = "BB";
//         else if (not >= 70)
//             harfNotu = "CB";
//         else if (not >= 60)
//             harfNotu = "CC";
//         else if (not >= 55)
//             harfNotu = "DC";
//         else if (not >= 50)
//             harfNotu = "DD";
//         else if (not >= 40)
//             harfNotu = "FD";
//         else if (not >= 0)
//             harfNotu = "FF";
//         else
//         {
//             Console.WriteLine("Geçersiz not girdiniz!");
//            return;
//         }
//         }
//         else
//         {
//             Console.WriteLine("Geçersiz giriş yaptınız!");
//             return;    
//         }
// }
// Console.WriteLine($"Harf notunuz: {harfNotu}");


#endregion

#region HomeWork07
// Kullanıcıdan alınan üç sayıdan en büyüğünü bulan bir program yazın.
//  Console.Write("Birinci Sayiyi Giriniz: ");
//  int sayi1 = int.Parse(Console.ReadLine()!);

//  Console.Write("İknici Sayiyi Giriniz: ");
//  int sayi2 = int.Parse(Console.ReadLine()!);

//  Console.Write("Üçüncü Sayiyi Giriniz: ");
//  int sayi3 = int.Parse(Console.ReadLine()!);

//  int enBuyuk;

// if(sayi1>=sayi2 && sayi1>=sayi3)
// {
//     Console.WriteLine($"En Büyük sayi: {enBuyuk = sayi1}");
// }
// else if(sayi2>sayi1 && sayi2>sayi3)
// {
//     Console.WriteLine($"En Büyük Sayi: {enBuyuk =sayi2}");
// }
// else
// {
//     Console.WriteLine($"En Büyük Sayi: {enBuyuk = sayi3}");
// }
    
#endregion

#region HomeWork09
//Kullanıcıdan alınan iki sayı ve bir işlem (+, -, *, /) için basit bir hesap makinesi yapın.

// Console.Write(" bir işlem (+, -, *, /) seçiniz: ");
// string islem = Console.ReadLine()!;
// Console.Write("Birinci Sayiyi Giriniz: ");
// int sayi1 = int.Parse(Console.ReadLine()!);

// Console.Write("İkinci Sayiyi Giriniz: ");
// int sayi2 = int.Parse(Console.ReadLine()!);


// if(islem == "+")
// {
//     Console.WriteLine($"Toplam Sonucu: {sayi1 + sayi2}");
// }
// else if(islem == "-")
// {
//     Console.WriteLine($"Fark Sonucu: {sayi1 - sayi2}");
// }
// else if(islem == "*")
// {
//     Console.WriteLine($"Çarpım Sonucu: {sayi1 * sayi2}");
// }
// else if(islem == "/")
// {
//     Console.WriteLine($"Bölüm Sonucu: {sayi1 / sayi2}");
// }
// else
// {
//     Console.WriteLine("Yanlış Secim Yaptınız");
// }
#endregion

#region HomeWork10
//Kullanıcıdan alınan bir sayının asal olup olmadığını kontrol eden bir program yazın.
Console.Write("Bir Sayi Girin: ");
int sayi = int.Parse(Console.ReadLine()!);

bool asalMi = true;

if(sayi<2)
{
    asalMi = false;
}
else
{
    for(int i=2; i<=Math.Sqrt(sayi); i++)
    {
        if(sayi % i == 0)
        {
            asalMi = false;
            break;
        }
    }

    if(asalMi)
    {
        Console.WriteLine($"{sayi} bir asal sayidir.");
    }
    else
    {
        Console.WriteLine($"{sayi} bir asal sayi değildir.");
    }
}
#endregion