#region HomeWork01
//10 elemanlı rastgele değerlerden oluşan bir tam sayı dizisi içinde, dizinin her bir elemanının yalnızca bir önceki ve bir sonraki elemanı ile kıyaslandığı bir algoritma yazın. Bu algoritma, yalnızca kendinden önceki sayı ve kendinden sonraki sayı büyük olan elemanları bulmalı ve bunları ekrana yazdırmalıdır.
// Random rnd = new Random();
// int[] dizi = new int[10];

// for (var i = 0; i < dizi.Length; i++)
// {
//     dizi[i] = rnd.Next(1,101);
// }
// Console.WriteLine("Dizi Elemanları: ");
// Console.WriteLine(string.Join(" ", dizi));

// Console.WriteLine("\nÖnceki ve sonraki elemandan büyük olan sayılar:");
// for (int i = 1; i < dizi.Length - 1; i++)
// {
//     if (dizi[i] > dizi[i - 1] && dizi[i] > dizi[i + 1])
//     {
//         Console.WriteLine($"dizi[{i}] = {dizi[i]}");
//     }
// }
#endregion

#region HomeWork02
//Klavyeden girilen 10 sayıyı bir diziye atayın. Bu sayılardan çift olanları for döngüsü kullanarak ayrı bir diziye aktarın. Ardından bu çift sayı dizisini küçükten büyüğe sıralayın.

// int[] sayilar = new int[10];
// int[] ciftSayilar;
// int ciftSayac=0;

// Console.WriteLine("Lütfen 10 adet tam sayı giriniz: ");
// for (var i = 0; i < 10; i++)
// {
//     Console.Write($"Sayi {i+1}: ");
//     sayilar[i] = int.Parse(Console.ReadLine()!);
// }
// foreach (var sayi in sayilar)
// {
//     if(sayi %2==0)
//     {
//         ciftSayac++;
//     }
// }

// ciftSayilar = new int[ciftSayac];
// int index=0;
// for (var i = 0; i < 10; i++)
// {
//     if(sayilar[i] % 2 ==0)
//     {
//         ciftSayilar[index] = sayilar[i];
//         index++;
//     }
// }

// Array.Sort(ciftSayilar);
// Console.WriteLine("\nGirilen çift sayılar (küçükten büyüğe sıralı: ");
// foreach (var cift in ciftSayilar)
// {
//     Console.WriteLine(cift + " ");
// }
#endregion

#region HomeWork03
//10 elemanlı rastgele değerlerden oluşan bir dizideki tüm pozitif sayıları ve negatif sayıları ayrı dizilere ayıran ve her iki diziyi de ekrana yazdıran bir program yazın. İşlemi gerçekleştirmek için while döngüsü kullanın.

// Random rnd = new Random();
// int[] sayilar = new int[10];
// int[] pozitifSayilar = new int[10];
// int[] negatifSayilar = new int[10];
// int pozitifIndex = 0, negatifIndex = 0;
// for (var i = 0; i < sayilar.Length; i++)
// {
//     sayilar[i] = rnd.Next(-100,101);
// }
// Console.WriteLine("Dizi Elemanları: ");
// Console.WriteLine(string.Join(" , ", sayilar));

// int index =0;
// while (index<sayilar.Length)
// {
//     if(sayilar[index] >=0)
//     {
//         pozitifSayilar[pozitifIndex] = sayilar[index];
//         pozitifIndex++;
//     }
//     else
//     {
//         negatifSayilar[negatifIndex] = sayilar[index];
//         negatifIndex++;
//     }
//     index++;
// }

// Console.WriteLine("\nPozitif Sayılar:");
// for (int i = 0; i < pozitifIndex; i++)
// {
//     Console.Write(pozitifSayilar[i] + " ");
// }
// Console.WriteLine("\nNegatif Sayılar:");
// for (int i = 0; i < negatifIndex; i++)
// {
//     Console.Write(negatifSayilar[i] + " ");
// }

#endregion

#region HomeWork04
//100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde tekrar eden elemanları bulan bir program yazın. Diziyi tararken, elemanların hangi pozisyonlarda(kaçıncı indexte) tekrarlandığını ekrana yazdırın. Bu işlemi hem for hem de foreach döngüleri ile gerçekleştirin.

// Random rnd = new Random();
// int[] sayilar = new int[100];
// for (int i = 0; i < sayilar.Length; i++)
// {
//     sayilar[i] = rnd.Next(0, 51);
// }

// Console.WriteLine("Dizi Elemanları:");
// Console.WriteLine(string.Join(" ", sayilar));
// Dictionary<int, List<int>> tekrarEdenler = new Dictionary<int, List<int>>();
// for (int i = 0; i < sayilar.Length; i++)
// {
//     for (int j = i + 1; j < sayilar.Length; j++)
//     {
//         if (sayilar[i] == sayilar[j])
//         {
//             if (!tekrarEdenler.ContainsKey(sayilar[i]))
//             {
//                 tekrarEdenler[sayilar[i]] = new List<int> { i };
//             }
//             if (!tekrarEdenler[sayilar[i]].Contains(j))
//             {
//                 tekrarEdenler[sayilar[i]].Add(j);
//             }
//         }
//     }
//  }

// Console.WriteLine("\nTekrar Eden Elemanlar ve Indexleri:");
// foreach (var eleman in tekrarEdenler)
// {
//     Console.WriteLine($"Sayı {eleman.Key} -> Indexler: {string.Join(", ", eleman.Value)}");
// }
#endregion

#region HomeWork05
//Klavyeden girilen bir sayının, 100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde olup olmadığını kontrol eden bir algoritma yazın. Eğer sayı dizide varsa, sayının dizideki yerini ve tekrar sayısını ekrana yazdırın.
// Random rand = new Random();
// int[] dizi = new int[100];
// int i = 0;
// while (i < dizi.Length)
// {
//     dizi[i] = rand.Next(1, 101);
//     i++;
// }
// Console.Write("Bir sayı giriniz: ");
// int arananSayi = Convert.ToInt32(Console.ReadLine());
// int tekrarSayisi = 0;
// string indeksler = "";
// i = 0;
// while (i < dizi.Length)
// {
//     if (dizi[i] == arananSayi)
//     {
//         tekrarSayisi++;
//         indeksler += i + " ";
//     }
//         i++;
// }

// if (tekrarSayisi > 0)
// {
//     Console.WriteLine($"Girilen {arananSayi} sayısı dizide {tekrarSayisi} kez bulundu.");
//     Console.WriteLine($"İndeksler: {indeksler}");
// }
// else
// {
//     Console.WriteLine($"Girilen {arananSayi} sayısı dizide bulunamadı.");
// }
#endregion

#region HomeWork06
//100 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde en büyük ve en küçük sayıyı bulan programı yazın.
// Random rand = new Random();
// int[] dizi = new int[100];
// for (int i = 0; i < dizi.Length; i++)
// {
//     dizi[i] = rand.Next(1, 101);
// }

//     int enKucuk = dizi[0];
//     int enBuyuk = dizi[0];

// for (int i = 1; i < dizi.Length; i++)
// {
//     if (dizi[i] < enKucuk)
//         enKucuk = dizi[i];

//     if (dizi[i] > enBuyuk)
//         enBuyuk = dizi[i];
// }

// Console.WriteLine("Dizi Elemanları: ");
// foreach (int sayi in dizi)
// {
//     Console.Write(sayi + " ");
// }

// Console.WriteLine("\n\nEn Küçük Sayı: " + enKucuk);
// Console.WriteLine("En Büyük Sayı: " + enBuyuk);
#endregion

#region HomeWork07
//50 elemanlı rastgele değerlerden oluşan bir tam sayı dizisindeki tüm çift sayıları toplayan ve bu toplamı ekrana yazdıran bir program yazın. foreach döngüsü kullanarak bu işlemi gerçekleştirin.
// Random rand = new Random();
// int[] dizi = new int[50];
// int toplam = 0;
// for (int i = 0; i < dizi.Length; i++)
// {
//     dizi[i] = rand.Next(1, 101);
// }
// foreach (int sayi in dizi)
// {
//     if (sayi % 2 == 0)
//     {
//         toplam += sayi;
//     }
// }
// Console.WriteLine("Dizi Elemanları:");
// foreach (int sayi in dizi)
// {
//     Console.Write(sayi + " ");
// }
// Console.WriteLine("\n\nÇift Sayıların Toplamı: " + toplam);
#endregion
#region HomeWork08
//Klavyeden girilen bir sayıyı, 10 elemanlı rastgele değerlerden oluşan bir tam sayı dizisinde aratın. Eğer sayı dizide yoksa, diziyi sıralayın ve sayıyı dizinin doğru(olması gereken sıra) yerine ekleyin. Ekledikten sonra yeni diziyi ekrana yazdırın.
#endregion
#region HomeWork09
//Verilen bir dizinin yalnızca pozitif sayılarını ters çeviren bir algoritma yazın. Diziyi tararken, sadece pozitif sayıların yerini değiştirmelisiniz, diğer elemanlar aynı kalmalı.
// int[] dizi = { 5, -3, 7, 0, 2, -1, 4, 8, -6, 3 };
// Console.WriteLine("Orijinal Dizi:");
// foreach (int sayi in dizi)
// {
//     Console.Write(sayi + " ");
// }
// Console.WriteLine();
// int sol = 0, sag = dizi.Length - 1;
// while (sol < sag)
// {
//     if (dizi[sol] > 0 && dizi[sag] > 0)
//     {
//         int temp = dizi[sol];
//         dizi[sol] = dizi[sag];
//         dizi[sag] = temp;

//         sol++;
//         sag--;
//     }
//     else
//     {
//         if (dizi[sol] <= 0)
//             sol++;
//         if (dizi[sag] <= 0)
//             sag--;
//         }
// }
// Console.WriteLine("\nPozitif Sayılar Tersine Çevrildi:");
// foreach (int sayi in dizi)
// {
//     Console.Write(sayi + " ");
// }
#endregion
#region HomeWork10
//10 elemanlı bir dizi oluşturun ve bu dizinin elemanlarını bir başka diziye ters sırada kopyalayın. İlk dizideki sıralama değişmeyecek, sadece ikinci dizideki sıralama ters olacak.
// int[] dizi1 = new int[10];
// Console.WriteLine("10 elemanlı bir dizi girin:");
// for (int i = 0; i < dizi1.Length; i++)
// {
//     Console.Write($"Dizi1 elemanı {i + 1}: ");
//     dizi1[i] = Convert.ToInt32(Console.ReadLine());
// }
// int[] dizi2 = new int[10];
// int j = 0;
// for (int i = dizi1.Length - 1; i >= 0; i--)
// {
//     dizi2[j] = dizi1[i];
//     j++;
// }
// Console.WriteLine("\nİlk Dizi (Dizi1):");
// foreach (int sayi in dizi1)
// {
//     Console.Write(sayi + " ");
// }
// Console.WriteLine("\nTers Sıralanmış Dizi (Dizi2):");
// foreach (int sayi in dizi2)
// {
//     Console.Write(sayi + " ");
// }
#endregion
#region HomeWork11
//Klavyeden girilen bir cümlenin kelimelerini bir diziye aktarın. while döngüsü ile bu kelimeleri tersten ekrana yazdırın.
// Console.Write("Bir cümle giriniz: ");
// string cumle = Console.ReadLine();
// string[] kelimeler = cumle.Split(' ');
// int i = kelimeler.Length - 1;
// Console.WriteLine("\nCümledeki kelimeler tersten:");
// while (i >= 0)
// {
//     Console.WriteLine(kelimeler[i]);
//     i--; 
// }
#endregion
#region HomeWork12
//Bir dizideki tek sayıları toplayan ve bu toplamın çift mi, tek mi olduğunu kontrol eden bir program yazın. Toplamla birlikte eğer toplam tek ise, "Toplam tek sayı" mesajı, çift ise "Toplam çift sayı" mesajı ekrana yazdırılmalı.
int[] dizi = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int toplam = 0;
foreach (int sayi in dizi)
{
    if (sayi % 2 != 0)
    {
        toplam += sayi;
    }
}

Console.WriteLine($"Toplam: {toplam}");
if (toplam % 2 == 0)
{
    Console.WriteLine("Toplam çift sayı");
}
else
{
    Console.WriteLine("Toplam tek sayı");
}
#endregion