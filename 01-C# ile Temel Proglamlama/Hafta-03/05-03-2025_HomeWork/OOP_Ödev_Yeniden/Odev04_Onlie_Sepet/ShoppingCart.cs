using System;

namespace Odev04_Onlie_Sepet;

public class ShoppingCart
{
    public ShoppingCart(List<Product> ıtems)
    {
        Items = ıtems ?? new List<Product>();
        Count = 0;
    }

    private List<Product> Items { get; set; }
   private int Count { get; set; }

   public void SepeteEkle(List<Product> products, string name)
   {
        Items.AddRange(products);
        Count+=products.Count;
        Console.WriteLine($"{name} adlı ürün eklendi");  
   }

   public void SepettenCikar(string productName)
   {
       int removedCount = Items.RemoveAll(p=>p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
       if(removedCount > 0)
       {
            Count-= removedCount;
            Console.WriteLine($"{productName} adlı ürün Silindi");
       }
       else
       {
            Console.WriteLine($"{productName} adlı ürün sepette bulunamadı");
       }
   }

   public decimal CalculateTotal()
   {
        decimal total=0;
        for (int i = 0; i < Count; i++)
        {
            total+=Items[i].Price;
        }
        return total;
   }
   public void DisplayShoppingCart()
    {
        Console.WriteLine("SEPETİNİZ");
        Console.WriteLine("---------");
        foreach (Product nextItem in Items)
        {
            Console.WriteLine($"{nextItem.Name} - {nextItem.Price} TL");
        }
        Console.WriteLine($"Toplam Tutar: {CalculateTotal()} TL");
    }

}
