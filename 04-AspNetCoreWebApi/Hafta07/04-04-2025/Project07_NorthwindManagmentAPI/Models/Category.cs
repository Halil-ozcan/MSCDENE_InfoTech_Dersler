using System;
using System.ComponentModel.DataAnnotations;

namespace Project07_NorthwindManagmentAPI.Models;

public class Category
{
    public int CategoryID { get; set;}
    [Required]
    public string? CategoryName { get; set;}
    [Required]
    public string? Description { get; set; }
}
