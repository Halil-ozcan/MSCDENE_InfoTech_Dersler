using System;
using System.ComponentModel.DataAnnotations;

namespace Project07_NorthwindManagmentAPI.Models;

public class Product
{
    public int ProductID { get; set; }
    [Required(ErrorMessage = "Ürün Adı zorunludur!")]
    public string? ProductName { get; set; }
    [Required(ErrorMessage ="CategoryID bilgisi zorunludur.")]
    public int? CategoryID { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
}

