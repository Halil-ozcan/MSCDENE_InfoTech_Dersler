namespace Odev4_Online_Shopping;

class Program
{
    static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart();
        Console.Clear();
        Console.WriteLine("Online Shopping App");
        Console.WriteLine("-------------------");
        Console.WriteLine();
        cart.AddToCard(new Product("Iphone13", 57000));
        cart.AddToCard(new Product("MackBook Air M2", 59000));
        cart.AddToCard(new Product("MackBook Air M3", 65000));
        cart.AddToCard(new Product("MackBook Air M4", 72000));
        cart.AddToCard(new Product("Lenova XYZ67", 80000));
        cart.DisplayShoppingCart();

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Silme işlemleri yapılıyor");
        // cart.RemoveProduct("kol saati");
        cart.RemoveProduct("MackBook Air M3");
        cart.RemoveProduct("MackBook Air M4");
        cart.DisplayShoppingCart();

    }
}
