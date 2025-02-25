#region HomeWork01
//Kullanıcıdan alınan bir ondalıklı sayıyı en yakın tam sayıya yuvarlayan bir program yazın.

// Console.Write("Lütfen ondalıklı bir sayi giriniz: ");
// double sayi = Convert.ToDouble(Console.ReadLine());
// int yuvarlatilmisSayi = (int)Math.Round(sayi);
// Console.WriteLine($"ondalıklı sayinin yuvarlatılmıs hali: {yuvarlatilmisSayi}");
#endregion

#region HomeWork02
//Kullanıcıdan alınan iki sayıdan hangisinin daha büyük olduğunu bulan bir program yazın.

// Console.Write("Lütfen birinci sayiyi giriniz: ");
// int sayi1 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen ikinci sayiyi giriniz: ");
// int sayi2 = int.Parse(Console.ReadLine()!);

// if(sayi1>sayi2)
// {
//     Console.WriteLine($"Büyük olan Sayi: {sayi1}");
// }
// else
// {
//     Console.WriteLine($"Büyük olan Sayi: {sayi2}");
// }
#endregion

#region HomeWork03
//Kullanıcıdan alınan bir sayının mutlak değerini hesaplayan bir program yazın.,

// Console.Write("Lütfen bir sayi giriniz: ");
// int sayi = int.Parse(Console.ReadLine()!);
// int mutlakDeger = Math.Abs(sayi);
// Console.WriteLine($"Mutlak değeri döndürülen sayi: {mutlakDeger}");
#endregion

#region HomeWork04
// Kullanıcıdan alınan bir sayının karekökünü hesaplayan bir program yazın.

// Console.Write("Lütfen bir sayi giriniz: ");
// int sayi = int.Parse(Console.ReadLine()!);

// double karekok = Math.Sqrt(sayi);

// Console.WriteLine($"Karekök alınan sayi: {karekok}");
#endregion

#region HomeWork05
//Kullanıcıdan alınan iki sayı için üs alma işlemi yapan bir program yazın (örneğin, 2^3).

// Console.Write("Lütfen üst alınacak sayiyi giriniz: ");
// int ustSayi = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen dereceyi(üssü) giriniz: ");
// int derece = int.Parse(Console.ReadLine()!);

// double result = Math.Pow(ustSayi, derece);

// Console.WriteLine($"üs alma işelminin sonucu: {result}");
#endregion

#region HomeWork06
//Kullanıcıdan alınan bir sayının trigonometrik sinüs değerini hesaplayan bir program yazın.
// Console.Write("Bir açı değeri girin (derece cinsinden): ");
// double derece = Convert.ToDouble(Console.ReadLine());
// double radyan = derece * (Math.PI / 180);
// double sinDegeri = Math.Sin(radyan);
// Console.WriteLine($"Sin({derece}) = {sinDegeri}");
#endregion

#region HomeWork07
//Kullanıcıdan alınan bir açının (derece cinsinden) radyan cinsinden değerini hesaplayan bir program yazın.
// Console.Write("Bir açı değeri girin (derece cinsinden): ");
// double derece = Convert.ToDouble(Console.ReadLine());
// double radyan = derece * (Math.PI / 180);
// Console.WriteLine($"Sin({derece}) = {radyan}");
#endregion

#region HomeWork08
//Kullanıcıdan alınan bir sayının logaritmasını (doğal logaritma) hesaplayan bir program yazın.
// Console.Write("Logaritması hesaplanacak sayıyı girin: ");
// double sayi = Convert.ToDouble(Console.ReadLine());
// double logDegeri = Math.Log(sayi);
// Console.WriteLine($"ln{sayi} = {logDegeri}");
#endregion

#region HomeWork09
//Kullanıcıdan alınan iki sayı arasındaki küçük olanı bulan bir program yazın.
// Console.Write("Lütfen birinci sayiyi giriniz: ");
// int sayi1 = int.Parse(Console.ReadLine()!);

// Console.Write("Lütfen İkinci sayiyi giriniz: ");
// int sayi2 = int.Parse(Console.ReadLine()!);

// if(sayi1<sayi2)
// {
//     Console.WriteLine($"Küçük olan sayi: {sayi1}");
// }
// else
// {
//     Console.WriteLine($"küçük olan sayi: {sayi2}");
// }

#endregion

#region HomeWork10
//  Kullanıcıdan alınan bir ondalıklı sayıyı, yine kullanıcıdan alınan ondalık basamak sayısına göre yuvarlayan bir program yazın.
Console.Write("Ondaliki bir sayi giriniz: ");
double sayi = Convert.ToDouble(Console.ReadLine());

Console.Write("Yuvarlamak istediğiniz ondalık basamak sayısını giriniz: ");
int basamak = int.Parse(Console.ReadLine()!);

double yuvarlatilmisSayi = Math.Round(sayi, basamak);

Console.WriteLine($"Yuvarlatılmıs sayi: {yuvarlatilmisSayi}");
#endregion