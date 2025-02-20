long sayi = 500000000000;

int donusum = (int) sayi;


Console.WriteLine($"Long değeri: {sayi}");
Console.WriteLine($"Int değeri: {donusum}");

// Long değişkeni 64bit veri tutuyor. Int değişkeni ise 32bite kadar yer tutabiliyor. Int dönüşümü yapıldığında veri kaybına neden oluyor. Bu yüzden int çıktısı int değişkenin 32 bitine kadar olan değeri alır(1783793664) gerisi veri kaybına neden olur.