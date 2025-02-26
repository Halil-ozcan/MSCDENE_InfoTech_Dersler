#region HomeWork01
// İki saat arasındaki farkı gösteren bir TimeSpan oluşturun ve ekrana yazdırın.

// Console.Write("İlk saati  girin: ");
// DateTime saat1 = Convert.ToDateTime(Console.ReadLine());

// Console.Write("İkinci saati  girin: ");
//  DateTime saat2 = Convert.ToDateTime(Console.ReadLine());
//  TimeSpan fark = saat2 - saat1; 
//  Console.WriteLine($"İki saat arasındaki fark: {fark.Hours} saat {fark.Minutes} dakika.");
#endregion

#region HomeWork02
//3 gün, 5 saat ve 30 dakikalık bir süreyi temsil eden bir TimeSpan oluşturun ve ekrana yazdırın.

// TimeSpan timeSpan = new TimeSpan(3, 5, 30);
// Console.WriteLine("TimeSpan: " + timeSpan);
// Console.WriteLine($"Gün: {timeSpan.Days}, Saat: {timeSpan.Hours}, Dakika: {timeSpan.Minutes}");
#endregion

#region HomeWork03
//Bir haftayı temsil eden bir TimeSpan oluşturun ve toplam saat sayısını ekrana yazdırın.
// TimeSpan timeSpan = TimeSpan.FromDays(7);
// double totalHours = timeSpan.TotalHours;

// Console.WriteLine($"Bir hafta, toplam {totalHours} saat eder.");

#endregion

#region HomeWork04
//10000 dakikalık bir TimeSpan oluşturun ve bu sürenin kaç gün, saat ve dakika olduğunu ekrana yazdırın.
    // TimeSpan timeSpan = TimeSpan.FromMinutes(10000);
    // int days = timeSpan.Days;
    // int hours = timeSpan.Hours;
    // int minutes = timeSpan.Minutes;
    // Console.WriteLine($"{10000} dakikalık süre, {days} gün, {hours} saat ve {minutes} dakika eder.");
#endregion

#region HomeWork05
//İki tarih arasındaki farkı TimeSpan olarak hesaplayıp ekrana yazdırın.
    DateTime date1 = new DateTime(2025, 2, 1);
    DateTime date2 = new DateTime(2025, 2, 28); 
    TimeSpan fark = date2 - date1;
    Console.WriteLine($"İki tarih arasındaki fark: {fark.Days} gün, {fark.Hours} saat, {fark.Minutes} dakika.");
    
#endregion