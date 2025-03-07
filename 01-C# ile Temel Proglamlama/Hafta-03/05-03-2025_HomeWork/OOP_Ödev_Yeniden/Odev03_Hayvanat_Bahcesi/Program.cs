namespace Odev03_Hayvanat_Bahcesi;

class Program
{
    static void Main(string[] args)
    {
       Animal[] animals = [
        new Lion("Aslan","Simba","ROOOOARRRR"),
        new Elephant("Fil","Dumbo","TRUMPETTT"),
        new Monkey("Maymun","Chris","OO-OO-AA-AA"),
        new Lion("Aslan","Daron","ROOOOARRRR"),
        new Monkey("Maymun","Kambo","OO-OO-AA-AA"),
       ];

       foreach (Animal animal in animals)
       {
            animal.MakeSound();
       }
    }

   
}
