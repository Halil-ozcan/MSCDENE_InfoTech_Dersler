using OOP_HomeWork.HomeWork01;
using OOP_HomeWork.HomeWork02;
using OOP_HomeWork.HomeWork03;

namespace OOP_HomeWork;

class Program
{
    static void Main(string[] args)
    {
       #region HomeWork01
    //     Random rand = new Random();
    //     Car[] cars = new Car[]
    //     {
    //         new Car("BMW", "M3", 50),
    //         new Car("Audi", "A4", 45),
    //         new Car("Mercedes", "C-Class", 60)
    //     };
        
    //     bool raceOn = true;
    //     while (raceOn)
    //     {
    //         raceOn = false;
    //         foreach (var car in cars)
    //         {
    //             if (!car.IsOutOfFuel())
    //             {
    //                 int action = rand.Next(0, 2);
    //                 if (action == 0) car.Accelerate();
    //                 else car.Brake();
    //                 raceOn = true;
    //             }
    //         }
    //         Console.WriteLine("----------------------");
    //     }
        
    //     Car winner = null;
    //     foreach (var car in cars)
    //     {
    //         if (winner == null || car.Speed > winner.Speed)
    //             winner = car;
    //     }
        
    //     Console.WriteLine($"Kazanan: {winner.Brand} {winner.Model} ({winner.Speed} km/h)!");
       #endregion

        #region HomeWork02balances

        //     BankAccount[] accounts = new BankAccount[]
        //     {
        //         new BankAccount("Ali Yılmaz", "1001", 1500.50m),
        //         new BankAccount("Ayşe Demir", "1002", 2500.75m),
        //         new BankAccount("Mehmet Kaya", "1003", 3500.00m),

        //     };

        // accounts[0].Deposit(500);
        // accounts[1].WithDraw(1000);
        // accounts[2].Deposit(750);
        // accounts[0].WithDraw(2000);
        // accounts[1].Deposit(300);
        // accounts[2].WithDraw(500);

        // Console.WriteLine("\nTüm hesapların güncel durumu:");
        // foreach (var account in accounts)
        // {
        //     account.ShowBalance();
        // }

        #endregion

        #region HomeWork03
           Animal[] animals = new Animal[]
           {
            new Lion("Simba"),
            new Monkey("Charlie"),
            new Elephant("Dumbo"),
            new Dog("Karabaş"),
            new Cat("Boncuk"),

           };

           foreach (var animal in animals)
           {
            animal.MakeSound();
           }
        #endregion
    }

}
