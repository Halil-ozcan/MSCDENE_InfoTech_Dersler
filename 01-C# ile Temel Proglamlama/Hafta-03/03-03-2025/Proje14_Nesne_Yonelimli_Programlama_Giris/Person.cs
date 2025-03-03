using System;

namespace Proje14_Nesne_Yonelimli_Programlama_Giris;

public class Person
{
    public string? FirstName { get; set; } // ? beni uyarma demek anlamına geliyor.
    public string LastName { get; set; } = string.Empty!; // ikinci kullanım yöntemide bu.
    public int Age { get; set; }
}
