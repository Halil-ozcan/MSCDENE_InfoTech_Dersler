using System;
using System.Text.Json.Serialization;

namespace Project01_EFCore_Intro.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CategoryId { get; set; } // 12-13 satırları bire-çok ilşiki kurmak için kullanılır.yani bir categoryde birden çok not olabilir.
    public Category? Category { get; set; } // navigation property(foreign key bire çok ilişki oluşturur.)
    
     public List<NoteTag>? NoteTags { get; set; }=[];
}
