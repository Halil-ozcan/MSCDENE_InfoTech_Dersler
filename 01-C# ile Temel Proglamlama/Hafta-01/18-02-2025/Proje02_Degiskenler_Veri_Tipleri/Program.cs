
/*
// Açıklama Satırı

   Değişken İsimlendirme Kuralları
   * Degisken isminin içerisinde - (alt tire) haric özel karakterler olamaz.

   * Degisken isiminin ilk karakteri rakam olamaz.
   * C#' ın ayrılmış kelimeleri(reserved words) değişken ismi olarak kullanılmaz.

   (Best Practices(Yaygın Kullanımlar))

   * Türkçe Karakter Kullanmamak.

   * camelCase adlandırma yöntemini kullanmak.

   (Öneri!)

   *Türkçe değişken ismi kullanmamaya çalışın.


*/

//  byte studentPoint = 59; // 1byte(8bit) kadar ramde yer ayırmış oldu.

// 1- Sayısal Tipler
// sbyte b = -5; // signed(işaretli) 
// byte a = 5; // unsigned(işaretsiz);
// short g = -32767;
// ushort h = 64536;
// int c = -255656556;
// uint d = 430000000;
// long e = -850000000000;
// ulong f = 8500000000000;

// Console.WriteLine("long tipinin boyutu: " + sizeof(long) + " byte");
// Console.WriteLine("Long tipinin minimum değeri:" + long.MinValue);
// Console.WriteLine("Long tipinin maxiumum değeri:" + long.MaxValue);

// 2- Kayan Noktalı Sayılar

float b = 9.32f; // 4 byte
double a = 5.589; // 8byte
decimal c = 56.4m; // 16byte