using System;

namespace Proje17_Inheritance.Sample2;

public class Developer : Employee
{
    public string? ProgrammingLanguage { get; set; }
    public override void Work()
    {
        Console.WriteLine($"{FirstName} {LastName} adlı developer {ProgrammingLanguage} kullanarak kod yazıyor!");
    }
}
