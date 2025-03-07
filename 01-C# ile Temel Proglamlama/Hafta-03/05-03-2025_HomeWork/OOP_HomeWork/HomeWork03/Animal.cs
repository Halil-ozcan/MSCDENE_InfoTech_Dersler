using System;

namespace OOP_HomeWork.HomeWork03;

public class Animal
{
  private string? species;
  private string? name;
  private string? sound;

    public Animal(string? species, string? name, string? sound)
    {
        Species = species;
        Name = name;
        Sound = sound;
    }

    public string? Species { get; }
  public string? Name { get;}
  public string? Sound { get;}

  public virtual void MakeSound()
  {
    Console.WriteLine($"{Name} ({Species}) sesi Çıkarıyor: {Sound}");
  }



}
