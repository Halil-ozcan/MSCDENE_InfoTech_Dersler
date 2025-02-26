#region HomeWork01
//Kullanıcıdan alınan bir tarihin haftanın hangi günü olduğunu bulan bir program yazın.
// Console.Write("Lütfen bir tarih giriniz: ");
// DateTime date = Convert.ToDateTime(Console.ReadLine());
// Console.WriteLine(date.DayOfWeek);
#endregion
#region HomeWork02
//Şu anki tarih ve saati ekrana yazdıran bir program yazın.
// Console.WriteLine(DateTime.Now);
#endregion

#region HomeWork03
//Kullanıcıdan alınan bir tarihe belirli bir gün sayısı ekleyerek yeni tarihi bulan bir program yazın.
// Console.Write("Lütfen bir tarih giriniz: ");
// DateTime date = Convert.ToDateTime(Console.ReadLine());
// Console.WriteLine($"Eski Tarih: {date}, ve eklenen gün ile yeni tarih: {date.AddDays(4)}");
#endregion

#region HomeWork04
//İki tarih arasındaki gün farkını hesaplayan bir program yazın.
// Console.WriteLine("Lütfen birinci tarihi giriniz: ");
// DateTime date1 = Convert.ToDateTime(Console.ReadLine());

// Console.WriteLine("Lütfen ikinci tarihi giriniz: ");
// DateTime date2 = Convert.ToDateTime(Console.ReadLine());

// TimeSpan fark = date1 - date2;
// int gunFarki = Math.Abs(fark.Days); 
// Console.WriteLine($"İki tarih arasındaki gün farkı: {gunFarki} gün");

#endregion

#region HomeWork05
// //Kullanıcıdan alınan bir tarihin yılın kaçıncı günü olduğunu hesaplayan bir program yazın.
// Console.Write("Lütfen bir tarih giriniz: ");
// DateTime date = Convert.ToDateTime(Console.ReadLine());
// int gun = date.DayOfYear;
// Console.WriteLine(gun);
#endregion

#region HomeWork06
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

#region HomeWork08
//Şu anki tarihin ay adını tam olarak yazdıran bir program yazın

// DateTime bugun = DateTime.Now;
// string ayAdi = bugun.ToString("MMMM");
// Console.WriteLine($"Bugünün Ayi: {ayAdi}");
#endregion

#region HomeWork09
//Kullanıcıdan alınan bir tarihin, başka bir kullanıcıdan alınan tarihten önce mi, sonra mı yoksa aynı mı olduğunu kontrol eden bir program yazın.
// Console.Write("İlk tarihi girin: ");
//  DateTime tarih1 = Convert.ToDateTime(Console.ReadLine());

// Console.Write("ikinci tarihi girin: ");
//  DateTime tarih2 = Convert.ToDateTime(Console.ReadLine());

//     if (tarih1 < tarih2)
//     {
//         Console.WriteLine("İlk tarih, ikinci tarihten önce.");
//     }
//     else if (tarih1 > tarih2)
//     {
//         Console.WriteLine("İlk tarih, ikinci tarihten sonra.");
//     }
//     else
//     {
//         Console.WriteLine("Her iki tarih aynı.");
//     }   
#endregion

#region HomeWork10
//Kullanıcıdan alınan bir saati, 12 saat formatından 24 saat formatına (veya tam tersi) çeviren bir program yazın.

#endregion