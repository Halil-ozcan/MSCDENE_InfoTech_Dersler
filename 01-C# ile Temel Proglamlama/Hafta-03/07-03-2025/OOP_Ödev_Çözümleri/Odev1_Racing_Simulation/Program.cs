namespace Odev1_Racing_Simulation;

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = [
            new Car("Toyata","Corolla"),
            new Car("Honda","Civic"),
            new Car("Woksvagen","Transporter"),
        ];

        Random rnd = new Random();
        bool raceFinished=false;
      while(!raceFinished)
      {
        foreach (Car car in cars)
        {
            if(car.FuelLevel>0)
            {
                //Hızlandır
                car.Accelerate(rnd.Next(5,20));
                car.Brake(rnd.Next(0,5));
            }
            car.DisplayStatus();
        }
        Console.WriteLine("----------------------------");
        bool temp=true;
        foreach (Car car in cars)
        {
            if(car.FuelLevel!=0)
            {
                temp = false;
            }
        }
        raceFinished=temp;
      }
      Console.WriteLine();
      //Kazananı Belirle
      Car winnerCar=cars[0];
      for (var i = 0; i < cars.Length; i++)
      {
        if(cars[i].Speed>winnerCar.Speed)
        {
            winnerCar=cars[i];
        }
      }
      Console.WriteLine($"Yarışı kazanan Araç:\n {winnerCar.Brand} {winnerCar.Model} \n Hız: {winnerCar.Speed}");
    }
        
}
