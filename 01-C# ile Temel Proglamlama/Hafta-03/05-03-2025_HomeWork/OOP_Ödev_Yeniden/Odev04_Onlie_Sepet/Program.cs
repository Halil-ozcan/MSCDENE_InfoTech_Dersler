namespace Odev04_Onlie_Sepet;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Iphone 13 Pro Max", 45000);
        Product product2 = new Product("MackBook Air M2", 52000);
        Product product3 = new Product("Lenova XYZ47", 36000);

        ShoppingCart cart = new ShoppingCart(new List<Product>());

        cart.SepeteEkle(new List<Product> {product1},name:"Iphone 13 Pro Max");
        cart.SepeteEkle(new List<Product> {product2},name: "MackBook Air M2");
        cart.SepeteEkle(new List<Product> {product3}, name: "Lenova XYZ47");

        cart.DisplayShoppingCart();

        cart.SepettenCikar("Lenova XYZ47");

        Console.WriteLine("\nGüncel Sepet:");
        cart.DisplayShoppingCart();
    }
}
