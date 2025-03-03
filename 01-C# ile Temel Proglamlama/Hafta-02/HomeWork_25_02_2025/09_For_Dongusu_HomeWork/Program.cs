#region HomeWork01
//Kullanıcıdan pozitif bir tam sayı girmesini isteyin. 1'den bu sayıya kadar olan tüm tam sayıların toplamını bulan ve sonucu ekrana yazdıran bir program yazın. Örneğin, kullanıcı 5 girdiğinde, program 1+2+3+4+5 toplamını hesaplayıp sonucu göstermelidir.

// int sayi, toplam = 0;

// Console.WriteLine("Lütfen pozitif bir tam sayi gitiniz: ");
// sayi = int.Parse(Console.ReadLine()!);

// if(sayi<=0)
// {

//     Console.WriteLine("Lütfen Pozitif bir tam sayi giriniz: ");
// }
// else
// {
//     for (var i = 0; i <= sayi; i++)
//     {
//         toplam +=i;
//     }

//     Console.WriteLine($"1'den {sayi} sayısına kadar sayıların toplamı: {toplam}");
// }

#endregion

#region HomeWork02
//Kullanıcıdan bir pozitif tam sayı isteyin. Bu sayı ile 1'den bu sayıya kadar olan sayıların küplerini hesaplayın. Her bir sayının küpünü ayrı satırlarda ekrana yazdırın. Örneğin, kullanıcı 3 girdiğinde, 1^3, 2^3 ve 3^3 sonuçlarını görmelidir. Not: Pow kullanmayın.

// Console.Write("Pozitif bir tam sayı girin: ");
// int sayi = int.Parse(Console.ReadLine());

// if (sayi < 1)
// {
//     Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
//     return;
// }

// for (int i = 1; i <= sayi; i++)
// {
//     int kup = i * i * i;
//     Console.WriteLine($"{i}^3 = {kup}");
// }

#endregion

#region HomeWork03
//Kullanıcıdan bir pozitif tam sayı alın. Bu sayının tüm tam bölenlerini bulan ve ekrana yazdıran bir program yazın. Bir tam bölen, bir sayıyı tam bölen herhangi bir tam sayıdır. Örneğin, 12 sayısı için tam bölenler 1, 2, 3, 4, 6 ve 12'dir.
//  int sayi;

// Console.Write("Lütfen pozitif bir tam sayı giriniz: ");
// sayi = Convert.ToInt32(Console.ReadLine());

// if (sayi <= 0)
// {
//     Console.WriteLine("Lütfen pozitif bir tam sayı giriniz!");
// }
// else
// {
//     Console.Write($"Tam bölenler: ");       
    
//     for (int i = 1; i <= sayi; i++)
//     {
//         if (sayi % i == 0)
//         {
//             Console.Write(i + " ");
//         }
//     }
// }
#endregion

#region HomeWork04
//Kullanıcıdan bir pozitif tam sayı alın. Bu sayı kadar satırda, her satırda bir önceki satırdan bir fazla olacak şekilde yıldız (*) karakteri ile bir desen çizin. 

// Console.Write("Pozitif bir tam sayı girin: ");
// int sayi = int.Parse(Console.ReadLine());

//     if (sayi < 1)
//     {
//         Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
//         return;
//     }

//     for (int i = 1; i <= sayi; i++)
//     {
//         for (int j = 1; j <= i; j++)
//         {
//             Console.Write("*");
//         }
//             Console.WriteLine();
//     }
#endregion

#region HomeWork05
//1’den 100’e kadar olan tüm asal sayıları bulan ve ekrana yazdıran bir program yazın. Asal sayılar yalnızca 1 ve kendisi ile bölünebilen pozitif tam sayılardır.
// Console.WriteLine("1'den 100'e kadar olan asal sayılar:");

// for (int sayi = 2; sayi <= 100; sayi++) 
// {
//     bool asal = true; 

// for (int i = 2; i * i <= sayi; i++) 
// {
//     if (sayi % i == 0) 
//     {
//         asal = false;
//         break; 
//     }
// }

// if (asal)
// {
//     Console.Write(sayi + " ");
//     }
// }
#endregion

#region HomeWork06
// Kullanıcıdan 10'dan büyük bir pozitif tam sayı girmesini isteyin. 1’den bu sayıya kadar olan tüm sayıların karelerini hesaplayın ve her sayının karesini ekrana yazdırın. Örneğin, kullanıcı 12 girdiğinde, 1^2, 2^2, …, 12^2 sonuçlarını ekranda görmelidir.
//  int sayi;

// do
// {
//     Console.Write("10'dan büyük bir pozitif tam sayı girin: ");
//     sayi = int.Parse(Console.ReadLine());

//     if (sayi <= 10)
//     {
//         Console.WriteLine("Lütfen 10'dan büyük bir sayı girin.");
//     }

// } while (sayi <= 10);

// Console.WriteLine($"1'den {sayi}'e kadar olan sayıların kareleri:");

//     for (int i = 1; i <= sayi; i++)
//     {
//         int kare = i * i; 
//         Console.WriteLine($"{i}^2 = {kare}");
//     }
#endregion

#region HomeWork07
//Kullanıcıdan bir pozitif tam sayı alın. Bu sayıya kadar olan çift sayıların toplamını hesaplayın ve sonucu ekrana yazdırın. Örneğin, kullanıcı 10 girerse, program 2+4+6+8+10 toplamını hesaplayıp sonucu göstermelidir.
// int sayi, toplam = 0;

// do
// {
//     Console.Write("Pozitif bir tam sayı girin: ");
//     sayi = int.Parse(Console.ReadLine());

//     if (sayi <= 0)
//     {
//         Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
//     }

// } while (sayi <= 0);

//     for (int i = 2; i <= sayi; i += 2)
//     {
//         toplam += i;
//     }

//     Console.WriteLine($"1'den {sayi}'e kadar olan çift sayıların toplamı: {toplam}");
#endregion

#region HomeWork08
//Kullanıcıdan bir pozitif tam sayı alın. Bu sayıdan başlayarak geriye doğru sayarak 1’e kadar olan tüm sayıların karesini hesaplayın ve her sayının karesini ayrı satırlarda ekrana yazdırın.
// int sayi;
// do
// {
//     Console.Write("Pozitif bir tam sayı girin: ");
//     sayi = int.Parse(Console.ReadLine());

//     if (sayi <= 0)
//     {
//         Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
//     }

// } while (sayi <= 0);

// Console.WriteLine($"{sayi}’den 1’e kadar olan sayıların kareleri:");

//     for (int i = sayi; i >= 1; i--)
//     {
//         int kare = i * i; // Pow kullanmadan kare hesaplama
//         Console.WriteLine($"{i}^2 = {kare}");
//     }
#endregion

#region HomeWork09
//Kullanıcıdan bir pozitif tam sayı alın. Bu sayının asal olup olmadığını kontrol eden bir program yazın. Eğer sayı asal ise ekrana "Asal Sayıdır" değilse "Asal Sayı Değildir" yazdırın.
// int sayi;
// bool asal = true;
// do
// {
//     Console.Write("Pozitif bir tam sayı girin: ");
//     sayi = int.Parse(Console.ReadLine());

//     if (sayi <= 0)
//     {
//         Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
//     }

// } while (sayi <= 0);

//     if (sayi == 1)
//     {
//         asal = false;
//     }
//     else
//     {
//         for (int i = 2; i * i <= sayi; i++)
//         {
//             if (sayi % i == 0)
//             {
//                 asal = false;
//                 break; 
//             }
//         }
//     }

//     if (asal)
//         Console.WriteLine($"{sayi} Asal Sayıdır.");
//     else
//         Console.WriteLine($"{sayi} Asal Sayı Değildir.");
#endregion

#region HomeWork10
//Kullanıcıdan iki pozitif tam sayı alın. İlk sayıdan başlayarak ikinci sayıya kadar olan sayıların çarpımını hesaplayan bir program yazın. Sonucu ekrana yazdırın. Örneğin, 3 ve 6 girildiğinde, 345*6 çarpımı hesaplanmalı ve ekranda gösterilmelidir.
int sayi;
Console.Write("Lütfen pozitif bir tam sayı giriniz: ");
sayi = Convert.ToInt32(Console.ReadLine());
if (sayi <= 0)
{
    Console.WriteLine("Lütfen pozitif bir tam sayı giriniz!");
}
else
{
    Console.Write($"Tam bölenler: ");

    for (int i = 1; i <= sayi; i++)
    {
        if (sayi % i == 0)
        {
            Console.Write(i + " ");
        }
    }
}
#endregion