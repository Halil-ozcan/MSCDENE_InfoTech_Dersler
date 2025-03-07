namespace Odev3_Zoo_Managment;

class Program
{
    static void Main(string[] args)
    {
        Animal[] animals = [
            new Lion("Aslan","Simba"),
            new Elephant("Fil","Criys"),
            new Monkey("Maymun","Dombo"),
            new Lion("Aslan","Cumba"),
            new Elephant("Fil", "Jetty"),
        ];
        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}
