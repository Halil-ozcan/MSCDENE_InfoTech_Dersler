using System;

namespace Project01_EFCore_Intro.Models;

public class NoteTag
{
    public int NoteId { get; set; }
    public Note? Note { get; set; } 
    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}


// Tag modeli oluşturduk ve bu tagde çoka çok ilişki olacağı için NoteTag ile yardımcı bir tablo oluştutarak çoka çok bir ilişki oluşturduk.
// Yani bir notun birden fazala etiketi olacak ve bir etikette birden fazla not olacak şekilde ayarladık. çoka çok ilişkide direk note tablosundan çekemeyeceğimiz için yardımcı bir NoteTag modeli oluşturup çoka çok ilşiki yapmış olduk.