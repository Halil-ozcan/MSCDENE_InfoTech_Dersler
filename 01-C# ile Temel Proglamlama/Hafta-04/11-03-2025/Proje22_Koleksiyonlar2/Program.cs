namespace Proje22_Koleksiyonlar2;

class Program
{
    static void Main(string[] args)
    {
        #region List
            /*
            1) List<T> List<int> List<string> : Dinamik boyutlu dizilerdir. T tipinde veriler tutar. bu yapıya Generic yapılar deriz. 
            2) IList<T>'i implemente eder.
        */

        // List<int> ages = new List<int>();
        // ages.Add(25);
        // ages.Add(40); // Add, en sona eleman ekler.
        // ages.AddRange([4,66,3,4,2,23,45]); // Birden fazla eleman eklersek addrange kullanılır.
        // List<int> newAges=[5,33,56,74];
        // ages.AddRange(newAges); // ikinci kullanım yöntemi bu şekilde.
        // Console.WriteLine(string.Join(",",ages));
        // ages.Insert(0,600); // index e göre ekleme yapar.
        // ages.Remove(4); // sayıya göre siler.
        // ages.RemoveAt(5); // index e göre silme işlemi yapar.
        // ages.RemoveRange(3,2); // 3.indexten itibaren 2 tane eleman sil demek.
        // Console.WriteLine(string.Join("\n",ages));
        // Console.WriteLine($"Eleman Sayısı: {ages.Count}");
        // if(ages.Contains(4)) // ages listesinde 4 sayısı var mı diye bakar.
        // {
        //     Console.WriteLine("4 değeri ages adlı listede yer almaktadır");
        // }
        // else
        // {
        //     Console.WriteLine("sayı yok");
        // }
        // ages.Sort();
        // ages.Reverse();
        // Console.WriteLine(string.Join("\n",ages));
        #endregion

        #region LinkedList
            // LinkedList<int> ages = new LinkedList<int>();
            // ages.AddFirst(5); // Listenin en başına ekler.
            // ages.AddFirst(20);
            // ages.AddLast(50); // Listenin en sonuna ekler.
            // LinkedListNode<int> newItem = new LinkedListNode<int>(67);
            // ages.AddLast(newItem);
            // ages.AddLast(40);
            // ages.AddFirst(35);
            // ages.AddAfter(newItem, 88);
            // ages.AddBefore(newItem, 38);
            // ages.Remove(5);
            // ages.RemoveFirst();// baştaki elemanı siler
            // ages.RemoveLast();
            // Console.WriteLine(string.Join("\n",ages)); // sondaki elemanı siler.
        #endregion


        #region HashSet
            /*
                içinde benzersiz(uniqe) değereler tutacak şekilde tasarlanmış bir collectiondır.
            */
            // HashSet<int> numbers = [];
            // numbers.Add(40);
            // numbers.Add(50);
            // numbers.Add(45);
            // numbers.Add(40);

            // Console.WriteLine(string.Join("\n",numbers));
            // List<string> cities = [
            //     "İstanbul",
            //     "Ankara",
            //     "İzmir",
            //     "İstanbul",
            //     "Ankara",
            //     "İzmir",
            //     "İstanbul",
            //     "Ankara",
            //     "İzmir",
            //     "İstanbul",
            //     "Ankara",
            //     "İzmir",
            // ];

            // Console.WriteLine("Şehirlerin Tam Listesi(List)");
            // Console.WriteLine(string.Join("\n",cities));

            // // List<string> uniqueCities = 

            // HashSet<string> citiesHashSet = new HashSet<string>(cities); // tekrar edenleri teke düşürür
            // Console.WriteLine("Şehir Listesi(HashSet)");
            // Console.WriteLine(string.Join("\n", citiesHashSet));


            HashSet<int> dataSet1 = new HashSet<int>{1,2,3,4,5};
            HashSet<int> dataSet2 = new HashSet<int>{4,5,6,7,8};

            // Console.WriteLine("Birleşim");
            // dataSet1.UnionWith(dataSet2);

            // Console.WriteLine(string.Join(",",dataSet1));

            // Console.WriteLine("Kesişim");
            // dataSet1.IntersectWith(dataSet2);
            // Console.WriteLine(string.Join(",",dataSet1));

            Console.WriteLine("dataSet1 in dataSet2 den farkı: ");
            dataSet1.ExceptWith(dataSet2);

            Console.WriteLine(string.Join(",",dataSet1));
        #endregion


        
    }
}
