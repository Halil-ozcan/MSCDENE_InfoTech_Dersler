#region HomeWork01
// Kullanıcıdan alınan bir sayıya göre (1-7 arası) haftanın gününü yazdıran bir program yazın.
// Console.WriteLine("Lütfen Bir sayi Giriniz: ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 1: 
//         Console.WriteLine("Pazartesi");
//         break;
//     case 2: 
//         Console.WriteLine("Salı");
//         break;
//     case 3: 
//         Console.WriteLine("Çarşamba");
//         break;
//      case 4: 
//         Console.WriteLine("Perşembe");
//         break;
//      case 5: 
//         Console.WriteLine("Cuma");
//         break;
//      case 6: 
//         Console.WriteLine("Cumartesi");
//         break;
//      case 7: 
//         Console.WriteLine("Pazar");
//         break;

// }
#endregion

#region HomeWork02
//Kullanıcıdan alınan bir sayıya göre (1-12 arası) ayın adını yazdıran bir program yazın.

// Console.WriteLine("Lütfen Bir sayi Giriniz(1-12): ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 1: 
//         Console.WriteLine("Ocak");
//         break;
//     case 2: 
//         Console.WriteLine("Şubat");
//         break;
//     case 3: 
//         Console.WriteLine("Mart");
//         break;
//      case 4: 
//         Console.WriteLine("Nisan");
//         break;
//      case 5: 
//         Console.WriteLine("Mayıs");
//         break;
//      case 6: 
//         Console.WriteLine("Haziran");
//         break;
//      case 7: 
//         Console.WriteLine("Temmuz");
//         break;
//     case 8: 
//         Console.WriteLine("Ağustos");
//         break;
//     case 9: 
//         Console.WriteLine("Eylül");
//         break;
//     case 10: 
//         Console.WriteLine("Ekim");
//         break;
//     case 11: 
//         Console.WriteLine("Kasım");
//         break;
//     case 12: 
//         Console.WriteLine("Aralık");
//         break;
// }
#endregion

#region HomeWork03
//  Kullanıcıdan alınan iki sayı ve bir işlem (+, -, *, /) için basit bir hesap makinesi yapın (switch kullanarak).

// Console.WriteLine("Lütfen Bir Sayi Giriniz: ");
// int sayi1 = int.Parse(Console.ReadLine()!);

// Console.WriteLine("Lütfen İknici Sayi Giriniz: ");
// int sayi2 = int.Parse(Console.ReadLine()!);

// Console.WriteLine("Hangi İşlemi Yapmak İstiyorsunuz(+, -, *, /): ");
// char op = Convert.ToChar(Console.ReadLine()!);
// int result=0;

// switch(op)
// {
//     case '+':
//         Console.WriteLine($"{sayi1} {op} {sayi2} = {result = sayi1 +  sayi2}");
//         break;
//     case '-':
//         Console.WriteLine($"{sayi1} {op} {sayi2} = {result = sayi1 - sayi2}");
//         break;
//     case '*':
//         Console.WriteLine($"{sayi1} {op} {sayi2} = {result = sayi1 * sayi2}");
//         break;
//     case '/':
//         Console.WriteLine($"{sayi1} {op} {sayi2} = {result = sayi1 / sayi2}");
//         break;
//     default:
//         Console.WriteLine(" Geçersiz İşlem");
//         break;
// }


#endregion

#region HomeWork04
//Kullanıcıdan alınan bir harfe göre sesli veya sessiz harf olduğunu belirleyen bir program yazın.
// Console.Write("Lütfen Bir Harf Giriniz: ");
// char harf = Convert.ToChar(Console.ReadLine()!.ToLower());

// switch(harf)
// {
//     case 'a':
//     case 'e':
//     case 'i':
//     case 'ı':
//     case 'o':
//     case 'ö':
//     case 'u':
//     case 'ü':
//         Console.WriteLine($"{harf} harfi sesli bir harftir.");
//         break;
//     default:
//         Console.WriteLine($"{harf} Harfi sessiz bir harftir.");
//         break;
// }

#endregion

#region HomeWork05
//Kullanıcıdan alınan bir sayıya göre (1-4 arası) mevsim adını yazdıran bir program yazın.
// Console.WriteLine("Lütfen bir sayi giriniz(1-4): ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 1: 
//         Console.WriteLine("ilkBahar");
//         break;
//     case 2: 
//         Console.WriteLine("Yaz");
//         break;
//     case 3: 
//         Console.WriteLine("Sonbahar");
//         break;
//     case 4: 
//         Console.WriteLine("Kış");
//         break;
// }
#endregion

#region HomeWork06
//  Kullanıcıdan alınan bir nota göre (A, B, C, D, F) geçme veya kalma durumunu belirleyen bir program yazın.
// Console.WriteLine("Lütfen Bir Not Giriniz(0-100): ");
// int not = int.Parse(Console.ReadLine()!);
// switch(not)
// {
//     case 100:
//     case 95:
//     case 90:
//         Console.WriteLine($"{not} notunuzun harf karşılığı => A");
//         break;
//     case 85:
//     case 80:
//     case 75:
//     case 70:
//         Console.WriteLine($"{not} notunuzun harf karşılığı => B");
//         break;
//     case 65:
//     case 60:
//     case 55:
//         Console.WriteLine($"{not} notunuzun harf karşılığı => C");
//         break;
//     case 50:
//     case 45:
//         Console.WriteLine($"{not} notunuzun harf karşılığı => D");
//         break;
//     case 40:
//     case 35:
//     case 30:
//     case 25:
//     case 20:
//     case 15:
//     case 10:
//     case 5:
//     case 0:
//         Console.WriteLine($"{not} notunuzun harf karşılığı => F");
//         break;
//     default:
//         Console.WriteLine("Geçersiz İşlem");
//         break;
    
// }
#endregion

#region HomeWork07
// Kullanıcıdan alınan bir sayıya göre (1-5 arası) Türk para biriminin adını yazdıran bir program yazın (1 Kr, 5 Kr, 10 Kr, 25 Kr, 50 Kr).
// Console.WriteLine("Lütfen Bir Sayi Giriniz(1-5): ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 1:
//         Console.WriteLine($"{sayi} Kr");
//         break;
//     case 2:
//         Console.WriteLine($"{sayi} Kr");
//         break;
//     case 3:
//         Console.WriteLine($"{sayi} Kr");
//         break;
//     case 4:
//         Console.WriteLine($"{sayi} Kr");
//         break;
//     case 5:
//         Console.WriteLine($"{sayi} Kr");
//         break;
//     default:
//         Console.WriteLine("Geçersiz İşlem");
//         break;    
// }

#endregion

#region HomeWork08
//Kullanıcıdan alınan bir sayıya göre (0-6 arası) bir geometrik şeklin adını yazdıran bir program yazın (0: Nokta, 1: Çizgi, 2: Açı, 3: Üçgen, 4: Kare, 5: Beşgen, 6: Altıgen).

// Console.WriteLine("Lütfen Bir Sayi Giriniz(0-6): ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 0:
//         Console.WriteLine($"{sayi}: Nokta");
//         break;
//     case 1:
//         Console.WriteLine($"{sayi}: Çizgi");
//         break;
//     case 2:
//         Console.WriteLine($"{sayi}: Açı");
//         break;
//     case 3:
//         Console.WriteLine($"{sayi}: Üçgen");
//         break;
//     case 4:
//         Console.WriteLine($"{sayi}: Dörtgen");
//         break;
//     case 5:
//         Console.WriteLine($"{sayi}: Beşgen");
//         break;
//     case 6:
//         Console.WriteLine($"{sayi}: Altıgen");
//         break;
//     default:
//         Console.WriteLine("Geçersiz İşlem");
//         break;    
// }

    
#endregion

#region HomeWork09
//Kullanıcıdan alınan bir sayıya göre (1-5 arası) Türkçe sayı sıfatını yazdıran bir program yazın (1: Birinci, 2: İkinci, vb.).

// Console.WriteLine("Lütfen Bir Sayi Giriniz(1-5): ");
// int sayi = int.Parse(Console.ReadLine()!);

// switch(sayi)
// {
//     case 1:
//         Console.WriteLine($"{sayi}: Birinci");
//         break;
//     case 2:
//         Console.WriteLine($"{sayi}: İkinci");
//         break;
//     case 3:
//         Console.WriteLine($"{sayi}: Üçüncü");
//         break;
//     case 4:
//         Console.WriteLine($"{sayi}: Dördüncü");
//         break;
//     case 5:
//         Console.WriteLine($"{sayi}: Beşinci");
//         break;
//     default:
//         Console.WriteLine("Geçersiz İşlem");
//         break;    
// }
#endregion

#region HomeWork10
//Kullanıcıdan alınan bir karaktere göre (+, -, *, /, %) matematiksel işlemin adını yazdıran bir program yazın.

Console.WriteLine("Lütfen Bir Karakter Giriniz(+, -, *, /, %): ");
char Karakter = Convert.ToChar(Console.ReadLine()!);

switch(Karakter)
{
    case '+':
        Console.WriteLine($"{Karakter} Toplama işlemi");
        break;
    case '-':
        Console.WriteLine($"{Karakter} Çıkarma İşlemi");
        break;
    case '*':
        Console.WriteLine($"{Karakter} Çarpma İşlemi");
        break;
    case '/':
        Console.WriteLine($"{Karakter} Bölme İşlemi");
        break;
    case '%':
        Console.WriteLine($"{Karakter} Mod Alma İşlemi");
        break;
    default:
        Console.WriteLine("Geçersiz İşlem");
        break;    
}
    
#endregion