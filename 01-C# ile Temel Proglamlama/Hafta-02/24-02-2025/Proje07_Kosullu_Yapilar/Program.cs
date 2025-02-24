/*
    5 + 6 = ? // Aritmetiksel İşlem
    5 > 6 = ? // Mantıksal İşlem
*/
#region if

    /*
        if(koşul)
        {
            koşul doğru(true) olduğunda çalışması istenilen kodları yazıyoruz.
        }
    */

    // int number1 = 10;
    // int limit = 5;

    // if(number1 > limit)
    // {
    //     Console.WriteLine("Limiti Aştınız");
    // }
    

#endregion

#region ifelse
    /*
        if(kosul)
        {
            koşul doğruysa çalışacak kodlar
        }
        else
        {
            koşul yanlışsa çalışacak kodlar.
        }
    */
    //    int number1 = 5;
    //     int limit = 5;

    // if(number1 > limit)
    // {
    //     Console.WriteLine("Limiti Aştınız");
    // }
    // else{
    //     Console.WriteLine("Limiti Aşmadınız");
    // }
#endregion

#region ifelseif
/*
    if(kosul)
    {
        Koşul1 doğruysa çalışacak kodlar
    }
    else if(koşul2)
    {
        Koşul2 doğruysa çalışacak kodlar
    }
    else if(koşul3)
    {
        koşul3 doğruysa çalışacak kodlar
    }
    else
    {
        Bütün koşullar yanlışsa çalışacak kodlar
    }
*/    

    //     int number1 = 5;
    //     int limit = 5;

    // if(number1 > limit)
    // {
    //     Console.WriteLine("Limiti Aştınız");
    // }
    // else if(number1 == limit)
    // {
    //     Console.WriteLine("Limit Sınırındasınız");
    // }
    // else{
    //     Console.WriteLine("Limiti Aşmadınız");
    // }
#endregion

#region switchCase
    /*
        switch(degisken)
        {
            case deger1:
                degiskenin degeri deger1 (deger = deger1) ise çalışacak kodlar;
                break; 
            case deger2:
                degiskenin degeri deger2 (deger = deger2) ise çalışacak kodlar;
                break; 
            case deger3:
                degiskenin degeri deger3 (deger = deger3) ise çalışacak kodlar;
                break; 
            default:
                degiskenin değeri deger1, deger2 yada deger3 eşit değilse(hiç bir koşula uyguj değilse)buradaki kodlar çalışacak.
        }
    */

    // int a = 10;
    // switch(a)
    // {
    //     case 1:
    //         Console.WriteLine("Bir");
    //         break;
    //     case 5:
    //         Console.WriteLine("Beş");
    //         break;
    //     case 10:
    //         Console.WriteLine("On");
    //         break;
    //     default:
    //         Console.WriteLine("Bu sayıyı tanımıyorum.");
    //         break;
    // }
#endregion

#region ternary
    /*
        degisken = kosul ? koşul true ise değışkene aktarılacak değer : koşul false ise değişkene aktarılacak deger.

        // 2. Yol Kullanım şekli
        degisken = kosul 
                        ? koşul true ise değışkene aktarılacak değer 
                        : koşul false ise değişkene aktarılacak deger.
    */

    int number1 = 10;
    int limit = 5;

    string message = number1>limit 
                            ? "Limiti Aştınız" 
                            : "Limiti Aşmadınız";

    Console.WriteLine(message);
// Ödev : Ternary if yapısını if-else-if benzeri şekilde kullanabilir miyiz? Araştırınız
#endregion