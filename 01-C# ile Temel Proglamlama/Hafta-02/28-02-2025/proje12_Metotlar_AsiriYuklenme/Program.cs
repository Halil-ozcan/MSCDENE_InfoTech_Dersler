namespace proje12_Metotlar_AsiriYuklenme;

class Program
{
    static int Sum(int number1, int number2) // Aşağıdaki metot imzasindaki parantez içindeki parametreler farklılaştırarak değiştirebilir(overloading) işlemi diye geçer. ve bu işlemde metot adları aynı kalır.
    {
        int result = number1 + number2;
        return result;
    }   
      static double Sum(double number1, double number2)
    {
        double result = number1 + number2;
        return result;
    } 
    static int Sum(int number1, int number2, int number3)
    {
        int result = number1 + number2 + number3;
        return result;
    }

    static int GetLength(string text1, string text2)
    {
        int text1Length = text1.Length;
        int text2Length = text2.Length;
        int Length = text1Length + text2Length;
        return Length;
    }

    static bool IsContain(string text, string findText)
    {
        bool result = text.Contains(findText, StringComparison.CurrentCultureIgnoreCase); // küçük büyük harf duyarlılığı yapmadan arama yapar.Yani Sistemi Türkçeye Çevirir.
        return result;
    }
    static void Main(string[] args)
    {

        int result1 = Sum(5,4);
        int result2 = Sum(5,4,9);
        double result3 = Sum(4.4, 3.5);


        // Console.WriteLine(Sum(5,90));
        // int result = Sum(60,70) + Sum(100,99) + 400;
        // Console.WriteLine(result);

        // string name  ="Bekir";
        // string city = "İstanbul";
        // int length = GetLength(name, city);
        // Console.WriteLine(length);
        // Console.WriteLine(GetLength("Halil", "Özcan"));

        // bool hasB = IsContain(city, "b");
        // if(hasB == true)
        // {
        //     Console.WriteLine("var");
        // }
        // else
        // {
        //     Console.WriteLine("Yok");
        // }
    }

}
