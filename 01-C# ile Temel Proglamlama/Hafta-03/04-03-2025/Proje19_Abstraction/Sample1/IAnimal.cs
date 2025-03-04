using System;

namespace Proje19_Abstraction.Sample1
{
    public interface IAnimal // Interfaceler public metotlar barındırır.
    {
        void MakeSound();
        void Run();
        void Eat();
        void Jump();
        void Fly();
    }
}
