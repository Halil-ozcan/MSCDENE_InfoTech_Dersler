#region HomeWork01
// Kullanıcıdan alınan bir cümledeki kelime sayısını bulan bir program yazın. (Split metodunu araştırınız.)
    // Console.Write("Lütfen Bir Cümle Giriniz: ");
    // string cumle = Console.ReadLine()!;
    // int KelimeSayisi = cumle.Split().Length;
    // Console.WriteLine($"Girilen Cümlenin Kelime Sayisi: {KelimeSayisi}");
#endregion

#region HomeWork02
//2. Kullanıcıdan alınan bir metni tüm harfleri büyük olacak şekilde ve tüm harfleri küçük olacak şekilde alt alta tek bir Console.Write ile ekrana yazdıran bir program yazın.

    // Console.Write("Lütfen birinci metini giriniz: ");
    // string metin1 = Console.ReadLine()!;

    // Console.Write("Lütfen ikinci metini giriniz: ");
    // string metin2 = Console.ReadLine()!;

    // Console.Write($"Tüm harleri Büyük olan Metinler:\n{metin1.ToUpper()}\n{metin2.ToUpper()}\n Tüm Harfleri Küçük olan Metinler:\n{metin1.ToLower()}\n{metin2.ToLower()}");
#endregion

#region HomeWork03
//Kullanıcıdan alınan bir cümlede belirli bir kelimenin kaç kez geçtiğini bulan bir program yazın. (Split metodunu araştırınız.)


    // Console.Write("Lütfen Bir Cümle Giriniz: ");
    // string cumle = Console.ReadLine()!;

    // Console.Write("Aranacak Kelimeyi Giriniz: ");
    // string kelime = Console.ReadLine()!;

    // string[] kelimeler = cumle.Split(' ');// Split boşluk karakterlerine göre kelimeleri böler.

    // int sayac=0;
    // for (int i = 0; i < kelimeler.Length; i++)
    // {
    //     if(kelimeler[i] == kelime)
    //     {
    //         sayac++;
    //     }
    // }
    // Console.WriteLine($"{kelime} Kelimesi Cümlede {sayac} kez geçti.");
#endregion

#region  HomeWork04
//Kullanıcıdan alınan bir cümlenin başındaki ve sonundaki boşlukları kaldıran bir program yazın. (Trim metotlarını araştırınız.)

    // Console.Write("Lütfen Baştan ve Sondan Boşluk bırakarak Cümle Giriniz: ");
    // string cumle = Console.ReadLine()!;

    // Console.WriteLine($"Baştan ve Sondan Boşluk bırakılan cümlenin son hali: {cumle.Trim()}");
#endregion

#region HomeWork05
    Console.Write("Lütfen bir metin giriniz: ");
    string metin = Console.ReadLine()!;

    Console.Write("Lütfen aranacak metini giriniz: ");
    string aranacakMetin = Console.ReadLine()!;

    int index = metin.IndexOf(aranacakMetin);

    if(index !=-1) // -1 dememizin sebebi indexof bulamayınca -1 değeri döndürdüğü için
    {
        Console.WriteLine($"aranan metin, ana metin içinde {index}. indexte bulundu.");
    }
    else
    {
        Console.WriteLine("Aranan metin ana metinde bulunamadı!");
    }
#endregion