// // Bu çalışmada C# içerisinde sayılarla ilgili işlemlerden bazılarını konuşuyor olacağız.
// int a = 15;
// int b = 2;
// int result;

// result = a + b;
// result = a - b;
// result = a * b;
// result = a / b;
// result = a % b;

// // Console.WriteLine($"a değişkenin ilk değeri : {a}");
// // result = a++; // Önce atama işlemi yapılır. sonra a'nın değerini bir arttır demek. Dolayısıyla bu satır sonrasında result'ın içinde 15, ama a'nın içinde 16 vardır.
// // Console.WriteLine($"resukt değişkenin  değeri : {result}");
// // Console.WriteLine($"a değişkenin son değeri : {a}");

// Console.WriteLine($"a ilk deger: {a++}");
// result = a * 2;
// Console.WriteLine($"result: {result}");
// Console.WriteLine($"result: {++result}"); 
// Console.WriteLine($"result: {result - a}");

// // ++ operatörü eger bir değişkenin sonuna yazılırsa önce değişken işleme sokulur, Değeri 1 Arttırılır. Önüne yazılırsa önce değişkenin değeri 1 Arttırılır, sonra işleme sokulur.
// //sonuna : degisken_adi++;
// //önüne : ++degisken_adi;


// int number1 = 10;
// int number2 = 20;
// Console.WriteLine(number1--);
// Console.WriteLine(--number1);
// //cebimdekiPara = cebimdekiPara + arkadasımdanAldıgımPara;
// number1+=5; //  number1 = number1 +5;
// number1-=5; // number1 = number1 - 5;
// number1*=5; // number1 = number1 * 5;
// number1/=5; // number1 = number1 / 5;
// number1++;  // number1 = number1 + 1;


// int a = -5;
// int result;
// result = Math.Abs(a);//mutlak değerini alır
// result = (int)Math.Pow(a, 2); // karesini alır double tipinde olduğu için ekstra int'e dönüştürdüm. 
// double result2 = Math.Sqrt(a); //karekök alınır. // buda yine double türünde olduğu için double değişken atayarak yaptım.
// double result3 = Math.Pow(a, 1d/3d); // burda küp kökünü almak istedğimizde bu şekilde kullanabiliriz. 
// Console.WriteLine(result);

// double d1 = Math.Round(7.4); // matematiksel olarak yuvarlama yapar.
// d1 = Math.Floor(7.1); // her zaman tabana yuvarlama yapar. => 7
// d1 = Math.Ceiling(7.1); // bu da her zaman tavana(Üstte) yuvarlama yapar. => 8
// Console.WriteLine(d1);

Random rnd  = new Random(); // Rastgele sayı üretmek için kullanılır.
Console.WriteLine(rnd.Next());
Console.WriteLine(rnd.Next(10)); // 0 dahil, 10 hariç
Console.WriteLine(rnd.Next(1,11)); // 1 dahil, 11 hariç
