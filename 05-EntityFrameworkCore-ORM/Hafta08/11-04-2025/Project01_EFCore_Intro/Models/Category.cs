using System;
using System.Text.Json.Serialization;

namespace Project01_EFCore_Intro.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public List<Note>? Notes { get; set; }=[];
}
