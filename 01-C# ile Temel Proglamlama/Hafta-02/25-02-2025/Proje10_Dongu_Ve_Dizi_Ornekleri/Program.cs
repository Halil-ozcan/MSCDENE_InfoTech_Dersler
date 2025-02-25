// int[] numbers = [40,30,10,20,30,50,80];
// // Dizideki sayıların toplamını, ortalamasını, en büyük değerini, en küçük değerini tespit edip ekrana yazdıralım.

// int count = numbers.Length;
// int total=0;
// int avg =0;
// int max =numbers[0];
// int min = numbers[0];

// int currentValue;
// for (int i = 0; i < count; i++)
// {
//     currentValue = numbers[i];
//     total +=currentValue; // toplamı hesaplama
//     if(currentValue<min)
//     {
//         min = currentValue;
//     }
//     if(currentValue>max)
//     {
//         max = currentValue;
//     }
// }
// avg =total/count;
// Console.WriteLine("İstatistikler");
// Console.WriteLine("--------------");
// Console.Write("Sayılar: ");
// Console.WriteLine(string.Join(", ", numbers));
// Console.WriteLine();
// Console.WriteLine($"Toplam: {total}");
// Console.WriteLine($"Ortalama: {avg}");
// Console.WriteLine($"en Büyük: {max}");
// Console.WriteLine($"En Küçük: {min}");


// Kullanıcı pozitif bir sayi girene kadar, sayi almaya devam eden; pozitif sayi girince sona eren bir program yazalım.

// int input;
// do
// {
//     Console.Write("Çıkmak için pozitif bir sayi giriniz: ");
//     input = int.Parse(Console.ReadLine()!);
// } while (input<0);
// Console.Write("Döngü Sona erdi...");

// Kullanıcıdan kullanııc adı ve parola bilgilerini alan ve geçerli kullanıcı adı ve parola iklisini girene kadar bu bilgileri tekrar tekrar isteyen kodu yazınız. Eğer kullanıcı doğru bilgieri girerse Giriş başarılı yazsın.

// string userName = "admin";
// string password = "1234";

// string inputUserName;
// string inputPassword;
// bool status;
// do
// {
//         Console.Write("Kullanıcı Adı: ");
//         inputUserName =Console.ReadLine();

//         Console.Write("Parola: ");
//         inputPassword =Console.ReadLine();
        
//         status = inputUserName!=userName || inputPassword!=password;
//         Console.WriteLine(status ? "Hatali kullanici adı yada parola" : "Giriş başarılı!");

// } while (status);

// Console.WriteLine("Program sona erdi...");




// string userName = "admin";
// string password = "1234";

// string inputUserName;
// string inputPassword;
// bool status;
// string response;
// do
// {
//     Console.Write("Kullanıcı Adı: ");
//     inputUserName =Console.ReadLine();

//     Console.Write("Parola: ");
//     inputPassword =Console.ReadLine();

//     status = inputUserName==userName && inputPassword==password;
//     if(status)
//     {
//         Console.WriteLine("İşlem Başarıyla Tamamlandı.");

//     }
//     else
//     {
//         Console.WriteLine("İşlem Başarısız oldu!");
//     }
//     do
//     {
//         Console.Write("Yeniden denemek ister misiniz?(E/H)");
//         response = Console.ReadLine()!;
//     } while (response!="E" && response!="H");
// } while (response == "E");

// Console.WriteLine("Program Sona Erdi...");





// int[] numbers = [20,30,6,40,23,44,55,66,77,123];
// // numbers dizisindeki ilk elemandan başlayarak tek sayıyla karşılana kadar olan sayıların toplamını bulduralım...

// int total=0;
// int i=0;

// while (numbers[i] %2 ==0)
// {
//     total+=numbers[i];
//     i++;
// }
// Console.WriteLine(i>0 ? $"{i} adet sayının toplamı: {total}" : "Toplanacak çift sayı bulunamadı.");



// Girilen Sayının basamaklarını toplayan bir kod yazınız. 482 çıktı: 14
Console.Write("Bir sayi Giriniz: ");
int resultNumber;
int number = resultNumber = int.Parse(Console.ReadLine()!);
int total=0;
while (number>0)
{
    total+= number % 10;
    number /=10;
}

Console.WriteLine($"{resultNumber} sayisinin Basamaklarının Toplamı: {total}");




//Diziyi yanyana aralarına virgül koyarak for ile yazdırmanın yolu..
// for (int i = 0; i < count; i++)
// {
//     Console.Write(numbers[i]);
//     if(i<count-1)
//     {
//         Console.Write(",");
//     }
// }