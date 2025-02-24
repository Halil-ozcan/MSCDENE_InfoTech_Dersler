// DateTime  date1 = new DateTime(1919,5,19,18,15,10);
// Console.WriteLine(date1);

// DateTime today = DateTime.Today; // burda bugünün tarihini verir
// DateTime now = DateTime.Now; // bugünü tarihini ve saatini birlikte verir.
// DateTime utcNow = DateTime.UtcNow;
// Console.WriteLine(today);
// Console.WriteLine(now);
// Console.WriteLine(utcNow);
// Console.WriteLine(today.ToShortDateString()); // gün ay yıl formatında yazılır. 24.02.2025 olarak yazılır.
// Console.WriteLine(today.ToLongDateString()); // gün ay yıl formatında yazılır. 24 Şubat 2025 Pazartesi olarak yazılır.
// Console.WriteLine(now.ToShortTimeString()); // 11:27 olarak gösterir. saniye göstermez.
// Console.WriteLine(now.ToLongTimeString()); // 11:27:40 olarak gösterir. saniye gösterir.

// DateTime dateOfBirth = new DateTime(2001,10,02);
// Console.WriteLine(dateOfBirth.ToLongDateString());
// Console.WriteLine($"Yıl : {dateOfBirth.Year}");
// Console.WriteLine($"Ay : {dateOfBirth.Month}");
// Console.WriteLine($"Gün : {dateOfBirth.Day}");

// DateTime today = DateTime.Today;
// int todayYear = today.Year;
// int birthYear = dateOfBirth.Year;
// int result = todayYear - birthYear;
// Console.WriteLine(result);
// Console.WriteLine(dateOfBirth.DayOfWeek);// Haftanın Günü

// TimeSpan tarihler arasındaki süreyi verir bize.
// TimeSpan timeSpan = today.Subtract(dateOfBirth);// şu ana kadar yaşadığımız gün sayısını verir.
// Console.WriteLine(timeSpan);
// Console.WriteLine(timeSpan.Days); // sadece gün verir.
// Console.WriteLine(timeSpan.TotalHours); // toplam saati verir.

// DateTime orderDate = DateTime.Today;
// DateTime orderDate = new DateTime(2025,02,27); // tarihlere göre uyarlama yaparak otomatik şekilde ayarlar. yani şubat 28 çektiği için 30 şubat demek yerine marın 2'sine atıyor.
// Console.WriteLine($"{orderDate.ToShortDateString()} tarihli siparişiniz, en geç {orderDate.AddDays(3)} tarihinde teslim edilecektir.");


// Bir sonraki yılın yılbaşı tarihini ekrana yazdıralım.
// 1.YOL
// int year = DateTime.Today.Year + 1;
// DateTime newYearDate = new DateTime(year,1,1);
// Console.WriteLine(newYearDate);

// 2.YOL
DateTime firstDate = new DateTime(DateTime.Now.Year,1,1);
Console.WriteLine(firstDate.AddYears(1));