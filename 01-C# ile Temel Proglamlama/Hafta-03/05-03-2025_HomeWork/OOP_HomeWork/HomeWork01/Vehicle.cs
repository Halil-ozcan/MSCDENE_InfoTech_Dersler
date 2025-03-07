using System;

namespace OOP_HomeWork.HomeWork01;

public class Vehicle
{
    private string brand;
    private string model;
    private int speed;
    private double fuelLevel;

    protected Vehicle(string brand, string model, double fuelLevel)
    {
        this.brand = brand;
        this.model = model;
        this.speed = 0;
        this.fuelLevel = fuelLevel;
    }

    public string? Brand { get{return brand;}}
    public string? Model { get{return model;}}
    public int Speed { get{return speed;}}
    public double FuelLevel { get{return fuelLevel;}}

    public virtual void Accelerate()
    {
        if(fuelLevel > 0)
        {
            speed +=10;
            ConsumeFuel(2);
            
        }

    }
    public virtual void Brake()
    {
        if(speed > 0)
        {
            speed -=5;
        }

    }

    public void ConsumeFuel(double amount)
    {
        fuelLevel -=amount;
        if(fuelLevel<0) fuelLevel=0;
    }

    public bool IsOutOfFuel()
    {
        return fuelLevel <= 0;
    }


}
