using System;

namespace Proje17_Inheritance.Sample2;

public class Manager  : Employee
{
    public decimal Bonus { get; set; }

    public void ConductMeet()
    {
        Console.WriteLine($"{FirstName} {LastName} adlı yönetici toplantıyı yönetti.");
    }
}
