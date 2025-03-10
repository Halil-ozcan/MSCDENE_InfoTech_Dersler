namespace Proje21_Koleksiyonlar;
/*
    C Sharp da veri yönetimi için farklı ihtiyaçlara göre hazırlanmış ve içinde birden fazla veriyi tutabilme becerisine sahip yapılara Collections(Koleksiyonlar) diyoruz.
    Veriyi içinde tutmak, Yönetmek gibi temel bir amaca sahiptir.

    C Sharp koleksiyon Yapıları:
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
            List<string> names = ["Halil","Hakan","Mert"];
            IEnumerable<string> students = names;
            //students.Add(); IEnumerable da ekleme ve silme işlemleri olmaz.
            names.Add("Cengiz");
            foreach (string name in students)
            {
                Console.WriteLine(name);
            }

        #endregion
    }
}
