using System;

namespace Odev05_Not_Hesaplama;

public class Student : Person
{
    public Student(string name) : base(name)
    {
        Grades = new List<int>();
    }
    public List<int> Grades { get; set; }

    public void AddGrades(int grade)
    {
        Grades.Add(grade);
        Console.WriteLine($"{Name} adlı öğrenciye {grade} notu eklendi.");
    }

    public double CalculateAverage()
    {
        if(Grades.Count==0) return 0;
        return Grades.Average();
        
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Name} adlı öğrencinin not ortalaması: {CalculateAverage():N2}");
    }
}
