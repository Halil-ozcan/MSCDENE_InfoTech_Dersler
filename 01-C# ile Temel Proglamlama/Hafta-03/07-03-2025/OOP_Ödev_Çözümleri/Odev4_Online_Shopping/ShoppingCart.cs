using System;

namespace Odev4_Online_Shopping;

public class ShoppingCart
{
    public ShoppingCart()
    {
       Items = new Product[0];
       Count = 0;
    }

    private Product[] Items { get; set; }
    public int Count { get; set; }

    public void AddToCard(Product product)
    {
        // Dizinin boyutunu bir arttırma 
        ResizeArray(Count + 1);
        Items[Count++] = product;
        Console.WriteLine($"{product.Name} sepete eklendi!");
        Console.WriteLine();
    }

    public void RemoveProduct(string productName)
    {
        // Bize ismi gönderilen Product'ın Items dizisi içinde kaçıncı indexte olduğunu bulacaz.
        int index=-1;
        for (int i = 0; i < Count; i++)
        {
            if(Items[i].Name.ToLower() == productName.ToLower())
            {
                index = i;
                break;
            }
        }
        if(index!=-1)
        {
            for (int i = index; i < Count-1; i++)
            {
                Items[i] = Items[i+1];
            }
            ResizeArray(Count-1);
            Count--;
            Console.WriteLine($"{productName} adlı ürün Sepetten Çıkarıldı.");
        }
        else
        {
            Console.WriteLine($"{productName} sepette bulunamadı.");
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
        Console.WriteLine("----------");
        foreach (Product ıtem in Items)
        {
            Console.WriteLine($"{ıtem.Name} - {ıtem.Price} TL");
        }
        Console.WriteLine($"Toplam Tutar: {CalculateTotal()} TL");
    }

    private void ResizeArray(int newSize)
    {
        Product[] tempMewArray = new Product[newSize];
        for (int i = 0; i < Math.Min(Count, newSize); i++)
        {
            tempMewArray[i] = Items[i];
        }
        Items = tempMewArray;
    }

}
