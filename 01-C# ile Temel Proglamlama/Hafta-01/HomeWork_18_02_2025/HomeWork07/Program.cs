int sayi = 1000000;

byte sayiDonusumu = (byte)sayi;


Console.WriteLine($"Int değeri: {sayi}");
Console.WriteLine($"Byte değeri: {sayiDonusumu}");

// Byte değeri 0-255 arasında değer aldığı için 1000000 değeri byte ın alacağı değerden büyük olduğu için Taşma(Overflow) meydana gelir. Yani Özet olarak 1000000 sayısını 256 bölüp kalanı 64 sayısını bulmuş oluruz ve ekrana 1000000 birinci çıktı 64 ikinci çıktı olarak gösterilir.