namespace Odev01_Araba_Simulasyon;

class Program
{
    static void Main(string[] args)
    {
        Car[] cars =[
            new Car("Toyota", "Corolla"),
            new Car("Volkswagen", "Transporter"),
            new Car("Ford", "Mustang"),
        ];

        Random rnd = new Random();
        bool yarisBittiMi = false;

        while(!yarisBittiMi)
        {
            foreach (Car car in cars)
            {
                if(car.YakitSeviyesi>0)
                {
                    car.Hizlan(rnd.Next(5,40));
                    car.Yavasla(rnd.Next(0,5));
                }
                car.EkranaYazdirma();
            }
            bool temp = true;
            foreach (Car car in cars)
            {
                if(car.YakitSeviyesi!=0)
                {
                    temp=false;
                }
            }
            yarisBittiMi = temp;
        }

        Car kazananAraba = cars[0];
        for (int i = 0; i < cars.Length; i++)
        {
            if(cars[i].Hiz>kazananAraba.Hiz)
            {
                kazananAraba = cars[i];
            }
        }
        Console.WriteLine($"Yarışı Kazanan Araç: {kazananAraba.Marka} {kazananAraba.Model}\n Hız:{kazananAraba.Hiz}");

    }
}
