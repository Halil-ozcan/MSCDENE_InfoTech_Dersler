#region HomeWork01
// Kullanıcıdan pozitif tam sayılar girmesini isteyin. Kullanıcı sıfır girdiğinde, program sona erer ve girilen tüm sayıların toplamını ekrana yazdırır. Her sayının toplanmasından sonra kullanıcıya yeni bir sayı girmesi istenir. Program sadece sıfır girildiğinde sona ermelidir.

// int sayi;
// int toplam=0;
// do
// {
//     Console.Write("Lütfen Pozitif bir tam sayi giriniz: ");
//     sayi = int.Parse(Console.ReadLine()!);
//     toplam +=sayi;
//     Console.WriteLine($"Toplam: {toplam}");
// } while (sayi!=0);

#endregion

#region HomeWork02
//Kullanıcıdan bir metin alın. Bu metindeki tüm harfleri büyük harfe çeviren bir program yazın. Sadece harf karakterleri büyük harfe çevrilmeli, diğer karakterler (noktalama işaretleri vb.) olduğu gibi kalmalıdır. Örneğin, "Merhaba Dünya!" metni "MERHABA DÜNYA!" olarak ekrana yazdırılmalıdır.
// Console.WriteLine("Lütfen Bir Metin Giriniz: ");
// string metin = Console.ReadLine()!;
// string result = "";
// int i =0;
// while (i<metin.Length)
// {
//    char c = metin[i];
//    if(char.IsLetter(c))
//         result+=char.ToUpper(c);
//     else
//         result +=c;
    
//     i++;
// } 
//  Console.WriteLine("Büyük harfe çevrilmiş metin: " + result);

#endregion

#region HomeWork03
//Kullanıcıdan sürekli pozitif tam sayılar alın. Kullanıcı negatif bir sayı girdiğinde, program sona erer ve bu sayılardan her birinin karesini ekrana yazdırır. Örneğin, 4, 5, -1 girildiğinde, program 16 ve 25'i gösterir, ardından sonlanır.

// int sayi;
// int result;
// do
// {
//     Console.Write("Lütfen pozitif bir sayi giriniz: ");
//     sayi = int.Parse(Console.ReadLine()!);
//     result = sayi * sayi;
//     Console.WriteLine($"{sayi} * {sayi} = {result}");
// } while (sayi>=0);
#endregion

#region HomeWork04
//Kullanıcıdan bir sayı alın ve bu sayının rakamlarının toplamını while döngüsü ile hesaplayın. Sonucu ekrana yazdırın. Örneğin, 245 sayısı girildiğinde, program 2+4+5 işlemini yaparak sonucu ekranda göstermelidir.
// Console.Write("Bir sayi Giriniz: ");
// int resultNumber;
// int number = resultNumber = int.Parse(Console.ReadLine()!);
// int total=0;
// while (number>0)
// {
//     total+= number % 10;
//     number /=10;
// }

// Console.WriteLine($"{resultNumber} sayisinin Basamaklarının Toplamı: {total}");

#endregion

#region HomeWork05
//Kullanıcıdan alınan pozitif bir tam sayıyı tersine çeviren bir program yazın. Örneğin, kullanıcı 1234 girdiyse, program 4321 olarak ekrana yazdırmalıdır.
// int sayi, tersSayi = 0;
// Console.Write("Lütfen pozitif bir tam sayı giriniz: ");
// sayi = Convert.ToInt32(Console.ReadLine());
// if (sayi <= 0)
// {
//     Console.WriteLine("Lütfen pozitif bir tam sayı giriniz!");
// }
// else
// {
//     while (sayi > 0)
//     {
//         int sonBasamak = sayi % 10; // Son basamağı al
//         tersSayi = tersSayi * 10 + sonBasamak; // Yeni ters sayıyı oluştur
//         sayi /= 10; // Son basamağı at
//     }
//     Console.WriteLine("Ters çevrilmiş sayı: " + tersSayi);
// }
#endregion

#region HomeWork06
//Kullanıcıdan bir metin alın ve bu metni tersten yazarak ekrana yazdırın. Örneğin, "Merhaba" girdisi "abahreM" olarak yazdırılmalıdır.
// Console.Write("Lütfen bir metin giriniz: ");
// string metin = Console.ReadLine()!;
        
// string tersMetin = "";
// int i = metin.Length - 1; // Son karakterin index'i
// while (i >= 0)
// {
//     tersMetin += metin[i];
//     i--;
// }
// Console.WriteLine("Ters çevrilmiş metin: " + tersMetin);

#endregion

#region HomeWork07
//Kullanıcıdan bir pozitif tam sayı ve bir üst sınır değeri alın. İlk sayı üst sınırdan küçük olduğu sürece, sayıyı iki katına çıkararak yeniden kontrol edin. Bu işlem sayı üst sınırı geçene kadar devam etmelidir. Sonucu her aşamada ekrana yazdırın.
// Console.Write("Lütfen bir pozitif tam sayı giriniz: ");
// int sayi = Convert.ToInt32(Console.ReadLine());
// Console.Write("Lütfen bir üst sınır giriniz: ");
// int ustSinir = Convert.ToInt32(Console.ReadLine());
// if (sayi <= 0 || ustSinir <= 0)
// {
//     Console.WriteLine("Lütfen pozitif tam sayılar giriniz!");
// }
// else
// {
//     while (sayi <= ustSinir)
//     {
//         Console.WriteLine("Sayı: " + sayi);
//         sayi *= 2; // Sayıyı iki katına çıkar
//     }

//     Console.WriteLine("Son değer üst sınırı geçti!");
// }
#endregion

#region HomeWork08
//Kullanıcıdan pozitif tam sayılar girmesini isteyin. Kullanıcı 100’den büyük bir sayı girdiğinde program sona erer. Kaç tane sayı girildiğini, girilen sayıların toplamını ve girilen sayıların ortalamasını ekrana yazdırın.


// int sayi;
// int sayiAdedi=0;
// int result=0;
// int ortalama = 0;
// do
// {
//     Console.WriteLine("Lütfen bir tam sayi giriniz: ");
//     sayi = int.Parse(Console.ReadLine()!);
//     result += sayi;
//     sayiAdedi++;
//     ortalama = result / sayiAdedi;
//     Console.WriteLine($"{result} / {sayiAdedi} =>{ortalama}");
// } while (sayi<100);
#endregion

#region HomeWork09
//Kullanıcıdan pozitif bir tam sayı girmesini isteyin. Bu sayıya kadar olan her sayı için, sayının asal olup olmadığını kontrol edin ve sonucu ekrana yazdırın. Örneğin, 5 girildiğinde, program 1-Asal değil 2-Asal 3-Asal 4-Asal değil 5-Asal şeklinde çıktı vermelidir.
//  Console.Write("Pozitif bir tam sayı giriniz: ");
//  int n = Convert.ToInt32(Console.ReadLine());
// if (n <= 0)
// {
//     Console.WriteLine("Lütfen pozitif bir tam sayı giriniz!");
//     return;
// }
// int sayi = 1;

//     while (sayi <= n)
//     {
//         bool asal = true;

//         if (sayi < 2)
//         {
//             asal = false;
//         }
//         else
//         {
//             int bolen = 2;
//         while (bolen * bolen <= sayi)
//         {
//             if (sayi % bolen == 0)
//             {
//                 asal = false;
//                 break;
//             }
//             bolen++;
//         }
//         }

//         if (asal)
//             Console.WriteLine($"{sayi} - Asal");
//         else
//             Console.WriteLine($"{sayi} - Asal değil");

//         sayi++;
//     }
#endregion

#region HomeWork10
//Kullanıcıdan pozitif iki tam sayı girmesini isteyin. İlk sayı ile ikinci sayı arasındaki tüm sayıların çarpımını hesaplayan bir program yazın. Sonucu ekrana yazdırın. Örneğin, kullanıcı 4 ve 7 girdiyse, program 456*7=840 çıktısını ekrana yazdırmalıdır.
Console.Write("Birinci sayıyı giriniz: ");
int sayi1 = Convert.ToInt32(Console.ReadLine());

Console.Write("İkinci sayıyı giriniz: ");
int sayi2 = Convert.ToInt32(Console.ReadLine());

if (sayi1 <= 0 || sayi2 <= 0)
{
    Console.WriteLine("Lütfen pozitif iki tam sayı giriniz!");
    return;
}

int baslangic = Math.Min(sayi1, sayi2);
int bitis = Math.Max(sayi1, sayi2);

long carpim = 1;
int sayac = baslangic;

while (sayac <= bitis)
{
    carpim *= sayac;
    sayac++;
}
Console.Write($"Çarpım: ");

sayac = baslangic;
while (sayac <= bitis)
{
    Console.Write(sayac);
    if (sayac < bitis)
        Console.Write(" * ");
        sayac++;
}

 Console.WriteLine($" = {carpim}");
#endregion