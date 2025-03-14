namespace Proje21_Koleksiyonlar;
/*
    C Sharp da veri yönetimi için farklı ihtiyaçlara göre hazırlanmış ve içinde birden fazla veriyi tutabilme becerisine sahip yapılara Collections(Koleksiyonlar) diyoruz.
    Veriyi içinde tutmak, Yönetmek gibi temel bir amaca sahiptir.

    C Sharp koleksiyonların Implemente Ettiği Yapıları:
    1)IEnumerable
    2)ICollection
    3)IList
    4)IQueryable
*/
class Program
{
    static void Main(string[] args)
    {
       
        #region IEnumerable
         /*
            Özellikler:
            1) Koleksiyonlar üzerinden gezinti yapmak(iteration) amacıyla kullanılır.
            2)Verilerin sadece okunabileceği durumlarda kullanılır.
            3)Veri ekleme, Silme yada değiştirme gibi işlemlere izin vermez.
            4)Index'e sahip değildir.
            5)Özellikle Foreach ile kullanılır.
            6)Verileri belleğe almadan işlem yapar, bu da ciddi bir performans kazandırır.
        */ 
            // List<string> names = ["Halil","Hakan","Mert"];
            // IEnumerable<string> students = names;
            // //students.Add(); IEnumerable da ekleme ve silme işlemleri olmaz.
            // names.Add("Cengiz");
            // foreach (string name in students)
            // {
            //     Console.WriteLine(name);
            // }
            

        #endregion

        #region ICollection
        /*
            Özellikleri:
            - IEnumerable'ı implemente ettiği için bu da iterasyon yapma becerisine sahiptir.
            - Veri ekleme, silme gibi operasyonları destekler.
        */ 

        // ICollection<string> names = new List<string>(){"Bestegül","Halil","Sena","Berke"};
        // names.Add("İrem");
        // names.Remove("Bestegül");
        // Console.WriteLine(string.Join("\n",names));
            
        #endregion

        #region IList
            /*
                Özellikleri:
                -ICollection'dan implemente edildi için hem iterasyon hem de ekleme/silme gibi işlemleri destekler.
                -İndex özelliğini kullanmamızı sağlar. 
            */

            // List<string> names = ["Ahsen","Canan","Buray","Kemal"];
            // IEnumerable<string> namesIEnumerable = names;
            // ICollection<string> namesICollection = names;
            // IList<string> namesList = names;

            // // Iterasyon(Gezinti yapmak)
            // // foreach (string nextItem in namesIEnumerable)
            // // {
            // //     Console.WriteLine(nextItem);
            // // }

            // // foreach (string nextItem in namesICollection)
            // // {
            // //     Console.WriteLine(nextItem);
            // // }

            // // foreach (string nextItem in namesList)
            // // {
            // //     Console.WriteLine(nextItem);
            // // }

            // // Veri ekleme/silme/İndexleme vb.
            // //namesIEnumerable.Add Bu İŞLEME İZİN VERMEZ.
            // //Console.WriteLine(namesIEnumerable[2]) BU İŞLEME İZİN VERMEZ.
            // foreach (string nextItem in namesIEnumerable)
            // {
            //     Console.WriteLine(nextItem);
            // }

            // namesICollection.Add("Selen");
            // namesICollection.Remove("Canan");
            // //Console.WriteLine(namesICollection[1]); BU İŞLEME İZİN VERMEZ!
            // foreach (string nextItem in namesICollection)
            // {
            //     Console.WriteLine(nextItem);
            // }

            // namesList.Add("Hakan");
            // namesList.Remove("Selen");
            // Console.WriteLine(namesList[2]);
            // foreach (string nextItem in namesList)
            // {
            //     Console.WriteLine(nextItem);
            // }

            
        #endregion

        #region IQueryable
            /*
                Özellikler:
                - Özellikle LINQ ve EF Core gibi ORM araçlarıyla kullanılmak üzere veri tabanı operasyonları için tasarlanmıştır.
            */
        #endregion

    }

    
}




