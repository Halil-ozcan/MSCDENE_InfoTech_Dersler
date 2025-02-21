
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

// float b = 9.32f; // 4 byte - Hassasiyet 7 basamak - Not: Yuvarlama işlemlerinde zaman zaman çok küçük de olsa hatalar yapar.
// double a = 5.589; // 8byte - Hassasiyet 15-16 basamak -  Not: Yuvarlama işlemlerinde zaman zaman çok küçük de olsa(floata göre daha az ihtimal vardır.) hatalar yapar.
// decimal c = 56.4m; // 16byte - Hassasiyet 28-29 basamak - Not: yuvarlama hataları neredeyse yok denecek kadar minimize edilmiştir.

// System.Single=> bizim için float demek.
// System.Double=> bizim için double demek
// System.Decimal=> bizim için decimal demek.
// float f = 1.0f / 3.0f;
// double d = 1.0 / 3.0;
// decimal m = 1.0m / 3.0m;

// Console.WriteLine(f);
// Console.WriteLine(d);
// Console.WriteLine(m);

// 3- Diğer Tipler

// bool isActive = true; // 1byte - true/false
// bool isDiscounted = false;
// char letter ='g' ; // 2byte - Unicode karakter


// ***********************************************

// Buraya kadar gördüğümüz tipler C#  programlama dilinde VALUE TYPES(değişken tipler) olarak adlandırılır.

// ************************************************


// İşte buradan itibaren kullandığımız tiplerde REFERENCE TYPES(Referans Tipler)diyoruz.

// String tipteki firstName değişkenin Stack'teki değeri "Halil Özcan" Heap'teki bir String bölgeye yazılmıştır. firstName içinde ise bu bölgenin referansı(adresi) yer almaktadır.
// string firstName = "Halil Özcan";

// // Object kapladığı alan 16 byte REFERENCE TYPES
// object object1 = 56; 
// object object2 = "Selam";
// object object3 = true;


// Çalışmalar

// int, byte, bool, string tiplerinde 4 adet değişken tanımlayarak içlerine örnek veriler ekleyiniz.

// int age = 45;
// byte studentPoint = 60;
// bool isSucceeded = true;
// string fullName = "Halil Özcan";

// iki tane int tipinde değişken tanımlayalım. Ve sonra bunlara değer atayalım. Sonra bunların toplamını, farkını, çarpımını, bölümünü ve mod işlemini ekrana yazdıralım.

// int number1 = 50;
// int number2 = 7;
// double divideResult = (double) number1 / number2;

// Console.WriteLine("Toplam :" +( number1 + number2));
// Console.WriteLine("Fark :" +( number1 - number2));
// Console.WriteLine("Çarpım :" +( number1 * number2));
// Console.WriteLine("Bölüm :" +divideResult);
// Console.WriteLine("Mod :" +( number1 % number2));

// String(Metin) Birleştirme

// string word1 = "Bugün";
// string word2 = "Hava";
// string word3 = "çok";
// string word4= "Soğuk.";

// string sentense = word1 + " " + word2 + " " + word3 + " " + word4;

// Console.WriteLine(sentense);

// int veri tipinin bellekteki boyutu en küçük değeri ve en büuük değerini ekrana şu formatta yazdıralım.
// int veri tipinin bellekteki boyutu 4byte, en küçük değeri -21221122byte ve en büyük değeri +2122222 olarak belirlenmiştir.

//1- Metin Birleştirme Yöntemi ile(+)
// string result = "int veri tipinin bellekteki boyutu " + sizeof(int) + " byte, en küçük değeri " + int.MinValue + " ve en büyü değeri +" + int.MaxValue + " olarak belirlenmiştir.";
// Console.WriteLine(result);

//2- Concat komutu ile
// string result = String.Concat("int veri tipinin bellekteki boyutu ", sizeof(int), " byte, en küçük değeri ", int.MinValue, "ve en büyü değeri +", int.MaxValue, " olarak belirlenmiştir.");

// Console.WriteLine(result);

//3- Format komutu ile
// string result = String.Format("int veri tipinin bellekteki boyutu {0} byte, en küçük değeri {1} ve en büyük değeri +{2} olarak belirlenmiştir.", sizeof(int), int.MinValue,int.MaxValue);

// Console.WriteLine(result);

//4- String Interpolation(Interpolasyon) En çok Kullanılan Yöntemdir.
string result = $"int veri tipinin bellekteki boyutu {sizeof(int)} byte, en küçük değeri {int.MinValue} ve en büyük değeri +{int.MaxValue} olarak belirlenmiştir.";
Console.WriteLine(result);



