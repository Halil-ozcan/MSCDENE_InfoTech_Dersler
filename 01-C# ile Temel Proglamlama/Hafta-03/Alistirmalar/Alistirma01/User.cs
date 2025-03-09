using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Alistirma01;

public class User
{
    public User(string name, int age, double weight, double height)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        Steps = 0;//Adım Sayısı
        CaloriesBurned = 0; // Yakılan Kalori
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public int Steps { get; set; }//Adım Sayısı
    public double CaloriesBurned { get; set; }//Adım Sayısı

   public void AddSteps(int StepsCount=1)
   {
        Steps+=StepsCount;
        CaloriesBurned += StepsCount * BurnCalories();
            

       
   }

   private double BurnCalories()
   {
        if(Weight<=70) return 0.04; // Hafif Tempolu koşu
        else if(Weight<90) return 0.05; // normal Tempolu koşu
        else return 0.08;   //Tam Tempolu Koşu
   }

   public void ShowProgress()
   {
        Console.WriteLine($"{Name} adlı kullanıcının Bilgileri:\n  Age: {Age}, Kilo:{Weight}, Boy{Height},\n Fitness Bilgileri:\n adım Sayısı:{Steps}, Yakılan Kalori:{CaloriesBurned:N2}");
   }




}
