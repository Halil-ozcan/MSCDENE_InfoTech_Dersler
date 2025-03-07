using System;

namespace Odev01_Araba_Simulasyon;

public class Car
{
    public Car(string marka, string model)
    {
        Marka = marka;
        Model = model;
        Hiz = 0;
        YakitSeviyesi = 100;
    }

    public string  Marka { get; set; }
    public string  Model { get; set; }
    public int  Hiz { get; set; }
    public int  YakitSeviyesi { get; set; }

    public void Hizlan(int arttir)
    {
        if(YakitSeviyesi>0)
        {
            Hiz+=arttir;
            YakitTuket(arttir);

        }
        else
        {
            Console.WriteLine($"{Marka} {Model} aracının yakitti bittiği için hızlanamıyor.");
        }
    }

    public void Yavasla(int azalt)
    {
        Hiz = Math.Max(0, Hiz - azalt);
    }

    private void YakitTuket(int miktar)
    {
        YakitSeviyesi = Math.Max(0, YakitSeviyesi - miktar);
        if(YakitSeviyesi == 0)
        {
            Console.WriteLine($"{Marka} {Model} aracının yakıtı bitmiştir.");
        }
    }

    public void EkranaYazdirma()
    {
        Console.WriteLine($"{Marka} {Model} araci=> HIZ:{Hiz} km/h, Yakıt: {YakitSeviyesi}%");
    }




}
