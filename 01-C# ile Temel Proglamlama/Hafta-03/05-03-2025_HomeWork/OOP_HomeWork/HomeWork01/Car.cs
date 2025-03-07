using System;

namespace OOP_HomeWork.HomeWork01;

public class Car : Vehicle
{
    public Car(string brand, string model, double fuelLevel) : base(brand, model, fuelLevel){}

    public override void Accelerate()
    {
        if(!IsOutOfFuel())
        {
            base.Accelerate();
            Console.WriteLine($"{Brand} {Model} hızlandı, şu anki hızı: {Speed} km/h, yakıt seviyesi: {FuelLevel}%");
        }
        else
        {
            Console.WriteLine($"{Brand} {Model} yakıtsız kaldı ve durdu!");
        }
    }

    public override void Brake()
    {
        base.Brake();  
        Console.WriteLine($"{Brand} {Model} yavaşladı, şu anki hızı: {Speed} km/h");
    }

}
