#region Not Hesaplama
    
    int not = 80;
    
    if(not>=90)
    {
        Console.WriteLine("A");
    }
    else if(not>=80)
    {
        Console.WriteLine("B");
    }
    else if(not>=70)
    {
        Console.WriteLine("C");
    }
    else if(not>=60)
    {
        Console.WriteLine("D");
    }
      else if(not>=50)
    {
        Console.WriteLine("E");
    }
    else
    {
        Console.WriteLine("F");
    }


#endregion

#region Hesap Makinesi
    // Console.Write("Birinci Sayiyi Giriniz: ");
    // int number1 = int.Parse(Console.ReadLine()!); // Kullanıcıdan değer almamızı sağlar. Girilen değeri her zaman string olarak kabul eder. Sonuna koyulan ! işareti sen beni uyarma ben farkındayım demek anlamına geliyor(null olma durumuna karşılık olarak bunu yaptık);

    // Console.Write("İkinci Sayiyi Giriniz: ");
    // int number2 = int.Parse(Console.ReadLine()!);
    
    // Console.Write("Hangi işlemi yapacaksınız?(+,-,/,*): ");
    // char op = Convert.ToChar(Console.ReadLine()!);
    // int result=0;
    // switch(op)
    // {
    //     case '+':
    //         result = number1 + number2;
    //         break;
    //      case '-':
    //         result = number1 - number2;
    //         break;
    //     case '/':
    //         result = number1 / number2;
    //         break;
    //      case '*':
    //         result = number1 * number2;
    //         break;
    //     default:
    //         Console.WriteLine("Geçersiz İşlem");
    //         break;
    // }
    // if(op == '+' || op =='-' || op =='/' || op== '*')
    // {
    //     Console.WriteLine($"{number1} {op} {number2} = {result}");
    // }

    // // Ödev Bu kodu Switch yerine if kullanarak yazınız.
#endregion

#region Mevsim Tespit Etme
    // Kullanıcıdan bir ay numarası girmesini isteyin Girilen ay numarasına göre o ayı hangi mevsime ait olduğunu ekrana yazdırın.
    // örnek:
    // Girilen ay no: 5 Sonuç İlkbahar
    // Girilen ay no: 1 Kış

    // İf İle Çözüm
    // Console.Write("Lütfen Ay Numarası Giriniz(1-12): ");
    // int monthNumber = int.Parse(Console.ReadLine()!);

    // if(monthNumber == 12 || monthNumber ==1 ||monthNumber==2)
    // {
    //     Console.WriteLine("Kış");
    // }
    // else if(monthNumber>=3 && monthNumber<=5)
    // {
    //     Console.WriteLine("ilkbahar");
    // }
    // else if(monthNumber>=6 && monthNumber<=8)
    // {
    //     Console.WriteLine("Yaz");
    // }
    // else if(monthNumber>=9 && monthNumber<=11)
    // {
    //     Console.WriteLine("Sonbahar");
    // }
    // else
    // {
    //     Console.WriteLine("Böyle bir ay numarası bulunamadı...");
    // }

    // Switch ile Çözüm
    // Console.Write("Lütfen Ay Numarası Giriniz(1-12): ");
    // int monthNumber = int.Parse(Console.ReadLine()!);
    Console.Write("Lütfen Tarih  Giriniz(dd.mm.yyyy ): ");
    DateTime date = DateTime.Parse(Console.ReadLine()!);
    switch(date.Month)
    {
        case 12:
        case 1:
        case 2:
            Console.WriteLine("Kış");
            break;
        case 3:
        case 4:
        case 5:
            Console.WriteLine("İlkbahar");
            break;
        case 6:
        case 7:
        case 8:
            Console.WriteLine("Yaz");
            break;
        case 9:
        case 10:
        case 11:
            Console.WriteLine("Sonbahar");
            break;
        default:
            Console.WriteLine("Böyle bir ay numarası bulunamadı.");
            break;
    }
#endregion

