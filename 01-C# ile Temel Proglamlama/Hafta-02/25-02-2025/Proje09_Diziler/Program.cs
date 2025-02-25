
// int[] ages = new int[8]; // C Sharp Dizi tanımlarken eleman sayısına ihtiyaç duyar ve bunu belirtmeyi zorunlu kılar.

// ages[0] = 21;
// ages[1] = 32;
// ages[2] = 21;
// ages[3] = 32;
// ages[4] = 23;
// ages[5] = 20;
// ages[6] = 22;
// ages[7] = 18;

// Console.WriteLine(ages[4]);
// Console.WriteLine(ages);// burda sadece tipini verir.

// int totalAges=0;
// for(int i = 0; i<ages.Length;i++)
// {
//     Console.WriteLine(ages[i]);
//     totalAges+=ages[i];
// }
// int result = totalAges / 8;
// Console.WriteLine($"Yaş Ortalamasi: {result}");

// Dizi Tanımlama 2.YOL


// Ödev: ilk olarak 5 elemanlı bir dizi tanımlamış olayım. ilerleyen satırlarda dizinin eleman sayısını değiştirmek(arttırmak) için ne yapabiliriz.? ipucuc: Arryay.Resize() araştır.

int[] studentNumber = [34,33,11,55,76,87,45];
bool isThere = studentNumber.Contains(11); // değeri var yada yok olup olmadığına bakar true ya da false döndürür.
Console.WriteLine(isThere);


// int index = Array.IndexOf(studentNumber, 4544545454); // burda ise varsa index numarasını verir yoksa -1 döndürür.
// if(index==-1)
// {
//     Console.WriteLine("İlgili deger dizide bulunamadı");
// }
// else
// {
//     Console.WriteLine($"ilgili değer dizinin {index}. sırasında yer aliyor");
// }



// Console.WriteLine("Dizinin Orjinal Hali"); 
// for(int i=0; i<studentsNumber.Length;i++)
// {
//     Console.WriteLine(studentsNumber[i]);
// }

// Array.Sort(studentsNumber);

// Console.WriteLine("Dizinin Artan Sıralı Hali");
// for(int i=0; i<studentsNumber.Length;i++)
// {
//     Console.WriteLine(studentsNumber[i]);
// }

// Array.Reverse(studentsNumber);
// Console.WriteLine("Dizinin Azalan Sıralı Hali");
// for(int i=0; i<studentsNumber.Length;i++)
// {
//     Console.WriteLine(studentsNumber[i]);
// }