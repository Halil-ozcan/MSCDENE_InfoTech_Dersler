// Örtük(Implicit) Dönüşüm
// int a = 45;
// byte b = 56;
// long c = 466;

// int myInt = 123;
// long myLong = myInt;
// byte myByte = myInt; 

// Açık(Explicit) Dönüşüm

//A) Cast Etme
// double myDouble = 123.45;
// int myInt = (int)myDouble; 
// long myLong = 5346L;
// int newInt = (int)myLong;
// byte newByte = (byte)myLong;


// B) Boxing ve UnBoxing
//Değer Tiplerini, referans tiplerine ya da referans tiplerinini, değer tiplerine dönüştürme işlemidir.

// int myInt = 123;
// object boxedMyInt = myInt; // Boxing işlemi.

// object boxedMyInt = 123;
// int myInt = (int)boxedMyInt; // UnBoxing işlemi


// C) Convert Komutları
// string numberString = "134";
// int convertedInt =Convert.ToInt32(numberString); //123

// bool isActive = true;
// Console.WriteLine(isActive);
// string isActiveString = Convert.ToString(isActive);
// Console.WriteLine(isActiveString.Length);

// int myInt = 5435;
// string myString = myInt.ToString();// stringe dönüştürme işlemi yapar toString ifadesi.
// bool myBool = true;
// string myBoolString = myBool.ToString();

// D) Parse Komutu(Tek amacı string ifadeleri sayısal değerlere dönüştürür.)
// string age = "50";
// byte byteAge = byte.Parse(age);
// Console.WriteLine(byteAge * 3);

string rate = "0,5,5";
double rateDouble = double.Parse(rate);
Console.WriteLine(rateDouble);

//İlerleyen derslerde böyle hata olasılıklarını tespit edebilmek için TryParse kullanacağız.


