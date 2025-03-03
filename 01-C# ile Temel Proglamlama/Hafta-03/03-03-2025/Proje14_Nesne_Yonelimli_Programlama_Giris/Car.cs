using System;

namespace Proje14_Nesne_Yonelimli_Programlama_Giris;

public class Car
{
    // Bu property yazım formatında field'lar implict bir şekilde c sharp tarafından çalışma zamanında eklenir.
    public string  Brand { get; set; } // Kısa bir şekilde tanımlanmış hali budur. yüzde 90 bu şekilde kullanılır.
    public string Model { get; set; }
    public int MaxSpeed { get; set; }
    
}
