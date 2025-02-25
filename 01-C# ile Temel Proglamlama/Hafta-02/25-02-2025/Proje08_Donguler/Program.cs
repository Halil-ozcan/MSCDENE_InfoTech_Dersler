// for(int sayac=1; sayac<=5; sayac++)
// {
//     Console.WriteLine("Merhaba");   
// }

// for(int i=10; i>0; i--)
// {
//     Console.WriteLine(i);
// }

// int total=0;// Birden ona kadar olan sayıların toplamını yaptık.
// for(int i=1; i<=10; i++)
// {
//    //total = total + i;
//    total+=i; // ikinci yazımı
// } 
// Console.WriteLine(total);

// string name="Ali";
// while(name=="Ali")
// {
//     Console.Write("Adınızız Giriniz: ");
//     name = Console.ReadLine()!;
//     Console.WriteLine($"Adınız: {name}");
// }

// string name = "";
// do
// {
//     Console.Write("Adınızız Giriniz: ");
//     name = Console.ReadLine()!;
//     Console.WriteLine($"Adınız: {name}");
// }while(name == "Ali")

// do-while sadece while dan farkı şu sadece while de yukardaki örnekteki gibi name ismine Ali yazmasaydık döngüye girilmiyor. fakat do-while yazdığımızda en az bir kerede olsa gir demek anlamına geldiği için şart olmadan döngüye giriyor ve while ile şartı belirttiğimizde şart sağlanmazsa döngüden çıkar ve biter.


// Kullanıcının gireceği aralıktaki sayılar arasından çift sayıları ekrana yazdırın.

// Console.Write("Alt Sınırı Giriniz: ");
// int limit1 = int.Parse(Console.ReadLine()!);

// Console.Write("Üst Sınırı Giriniz: ");
// int limit2 = int.Parse(Console.ReadLine()!);


// if(limit1<limit2)
// {
//     for(int i=limit1; i<=limit2; i++)
// {
//     if(i % 2 == 0)
//     {
//         Console.WriteLine(i);
//     }
    
// }
// }
// else if(limit1>limit2)
// {
//    for(int i=limit1; i>=limit2; i--)
// {
//     if(i % 2 == 0)
//     {
//         Console.WriteLine(i);
//     }
    
// }
// }
// else
// {
//     Console.WriteLine("Lütfen eşit sayi Girmeyin!");
// }


// Kullanıcının gireceği sayının faktöriyelini hesaplayıp ekrana yazdıralım.

Console.Write("Faktöriyelini almak istediğiniz sayiyi giriniz: ");
int number = int.Parse(Console.ReadLine()!);
int facktorial =1;
for(int i=number; i>1; i--)
{
    //facktorial = facktorial * i;
    facktorial*=i;
}
Console.WriteLine($"{number}!= {facktorial}");