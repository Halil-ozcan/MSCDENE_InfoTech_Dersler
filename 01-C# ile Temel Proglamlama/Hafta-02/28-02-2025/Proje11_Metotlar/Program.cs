namespace Proje11_Metotlar;

class Program
{
    /*
        Metot, belirli bir işlevi olan kodları barındıran kod parçacığıdır.
        
        Metotdun_Geri_Dönüş_Tipi MetotAdi()
        {
            Bu metotta yerine getirilecek işlevlerin kodları...

            eğer metot geriye bir değer döndürmeyecekse void keywordu  yazılır.

            Geriye bir değer dödüreceksek döndüreceği değerin tipi yazılır: int, string, double vb.

            Eğer metot geriye değer döndürüyorsa, metodun içinde mutlaka "return" keywordü kullanılarak geriye değer döndürme operasyonu yapılmalıdır.
        }
    */
    static void SelamVer() // void metotdu geriye herhangibir değer döndürmezler.
    {
        Console.WriteLine("Merhaba");
    }

    static string SelamVer2()
    {
        string selam = "Merhaba";
        return selam;
    }

    static void SelamVer3(string name)
    {
        Console.WriteLine($"Merhaba {name}");
    }
   
   static void SelamVer4(bool zaman, string name)
   {
        if(zaman==true) // Günaydın denmek isteniyorsa
        {
            Console.WriteLine($"Günaydın {name}");
        }
        else
        {
            Console.WriteLine($"iyi geceler {name}");
        }
   }

    static void Topla(int sayi1, int sayi2, int? sayi3=null)
    {
        int? toplam = sayi3!=null
                             ? sayi1 + sayi2 + sayi3
                             : sayi1 + sayi2;
        string sonuc = sayi3!=null 
                            ?  $"{sayi1} + {sayi2} + {sayi3} = {toplam}"
                            : $"{sayi1} + {sayi2} = {toplam}";
        Console.WriteLine(sonuc);
    }
    
    static void DiziyiToplaVeEkranaYaz(int[] sayilar)
    {
        int toplam = 0;
        for (int i = 0; i < sayilar.Length; i++)
        {
            toplam+=sayilar[i];
        }
        Console.WriteLine($"{String.Join("+",sayilar)} = {toplam}"); //String.join() metodu ile Dizi elemanlarını yan yana artı ile yazdırıp = ile de sonuca atama yapar.
    }

    static void DisplayMaxAndMinLengthString(string[] values)
    {
        string maxResult=values[0];
        int maxLength = values[0].Length;

        string minResult = values[0];
        int minLength = values[0].Length;

        for (var i = 0; i < values.Length; i++)
        {
            if(values[i].Length>maxLength)
            {
                maxResult = values[i];
                maxLength = values[i].Length;
            }
            if(values[i].Length<minLength)
            {
                minResult = values[i];
                minLength = values[i].Length;
            }
        }
        Console.WriteLine($"En uzun Karakter Sayısı: {maxResult}, ve uzunluğu {maxLength}");
        Console.WriteLine($"En kısa Karakter Sayısı: {minResult}, ve uzunluğu {minLength}");
    }

    static void SelamVer5(string name, bool cinsiyet=true) // cinsiyet true ise kadın false ise erkek 
    {
        string displayMessage = 
            cinsiyet ==true 
                ? $"Merhaba {name} Hanım" 
                : $"Merhaba {name} Bey";
        Console.WriteLine(displayMessage);
    }

    static void Main(string[] args)
    {

        SelamVer5("Sibel", true);
        SelamVer5("Halil", false);

        // string[] persons = ["İrem","Ender","Halil","Ahmet","Berke","İsmail"];
        // string[] cities = ["İstanbul","Ankara","İzmir","Van","AfyonKarahisar"];
        // string[] products = ["Yemek Takımı","Kahve Fincanı Seti","MacBook Air M2","Karton Bardak"];
        // DisplayMaxAndMinLengthString(persons);
        // DisplayMaxAndMinLengthString(cities);
        // DisplayMaxAndMinLengthString(products);


        // int[] ornekDizi = [10,40,50,100,300];
        // DiziyiToplaVeEkranaYaz(ornekDizi);
        // DiziyiToplaVeEkranaYaz([10,20,50,30,60,90,]); // dizi tanımlama 2.yol
        // Topla(5,10,100);
        // Topla(5,10);
        // Tüm Kodlar Buraya Yazılır.
        // SelamVer();// Metot Çağırma Yöntemi.
        // Console.WriteLine(SelamVer2());
        // SelamVer3("Halil");
        // SelamVer4(true, "Halil");
    }

}
