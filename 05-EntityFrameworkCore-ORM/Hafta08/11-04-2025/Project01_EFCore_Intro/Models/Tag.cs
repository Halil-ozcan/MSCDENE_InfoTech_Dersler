using System;

namespace Project01_EFCore_Intro.Models;

public class Tag
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public List<NoteTag> NoteTags { get; set; } = [];
}
