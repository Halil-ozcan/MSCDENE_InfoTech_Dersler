using System;
using Microsoft.EntityFrameworkCore;
using Project01_EFCore_Intro.Data;
using Project01_EFCore_Intro.DTOs;
using Project01_EFCore_Intro.Models;
using Project01_EFCore_Intro.Services.Abstract;

namespace Project01_EFCore_Intro.Services.Concrete;

public class NoteService : INoteService
{
    private readonly AppDbContext _appDbContext;
    public NoteService(AppDbContext appDbContext) // DI-Dependency Injection
    {
        _appDbContext = appDbContext;
    }
    public NoteDTO CreateNote(Note note)
    {
        throw new NotImplementedException();
    }

    public bool DeleteNote(int id)
    {
        
        throw new NotImplementedException();
    }

    public NoteDTO GetNote(int id)
    {
    // Note note = _appDbContext.Notes.Where(x=>x.Id==id).FirstOrDefault()!;
    // Note note = _appDbContext.Notes.FirstOrDefault(x=>x.Id==id)!;// ikinci kullanım yöntemi where kullanmadan yapabiliriz
    //Note note = _appDbContext.Notes.Find(id)!;//Primary key kolonunda arama yapcaksak find metoduyla yapabiliyoruz.
    Note note = _appDbContext
        .Notes
        .Where(x=>x.Id==id)
        .Include(X=>X.Category)
        .FirstOrDefault()!;
    NoteDTO noteDTO = new NoteDTO{
        Id = note.Id,
        Title = note.Title,
        Content = note.Content,
        CategoryName = note.Category!.Name!
    };
       return noteDTO;
       
    }

    public List<NoteDTO> GetNotes()
    {
        List<Note> notes = _appDbContext
            .Notes
            .Include(x=>x.Category)
            .ToList();
        List<NoteDTO> noteDTOs = notes
            .Select(note=>new NoteDTO{
                Id=note.Id,
                Title = note.Title,
                Content = note.Content,
                CategoryName = note.Category!.Name!
            }).ToList();
        return noteDTOs;
    }

    public bool UpdateNote(int id, Note note)
    {
        throw new NotImplementedException();
    }
}
