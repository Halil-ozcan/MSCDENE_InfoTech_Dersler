using System;

namespace Project08_LINQ.Models;

public class Product:BaseClass
{
    public string? Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }

}
