using System;
using Project01_EFCore_Intro.Models;

namespace Project01_EFCore_Intro.DTOs;

public class NoteDTO
{
     public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public List<string> TagNames { get; set; } =[];

}
