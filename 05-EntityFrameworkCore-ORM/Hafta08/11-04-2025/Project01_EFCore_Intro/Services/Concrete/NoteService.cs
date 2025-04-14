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
    public NoteDTO CreateNote(NoteDTO noteDTO)
    {
        Note note = new ()
        {
            Title=noteDTO.Title,
            CategoryId =noteDTO.CategoryId,
            Content = noteDTO.Content, 
        };
        _appDbContext.Notes.Add(note);//contex'e ekler
        var result = _appDbContext.SaveChanges();// contexteki tüm değişiklikleri db'ye kaydeder.
        var CreateNote=GetNote(noteDTO.Id);
        NoteDTO CreatedNoteDto = new ()
        {
            Id = note.Id,
            Title=note.Title,
            Content=note.Content,
            CategoryId=note.CategoryId,
            CategoryName = CreateNote.CategoryName
        };
        return CreatedNoteDto;

    }

    public bool DeleteNote(int id)
    {
        var deletedNoteDto = GetNote(id);
        if(deletedNoteDto is null)
        {
            return false;
        }
         Note deletedNote = new ()
        {
            Title=deletedNoteDto.Title,
            CategoryId =deletedNoteDto.CategoryId,
            Content = deletedNoteDto.Content, 
        };
        _appDbContext.Remove(deletedNote);
        var result = _appDbContext.SaveChanges();
        if(result<1)
        {
            return false;
        }
        return true;
    }

    public NoteDTO GetNote(int id)
    {
    // Note note = _appDbContext.Notes.Where(x=>x.Id==id).FirstOrDefault()!;
    // Note note = _appDbContext.Notes.FirstOrDefault(x=>x.Id==id)!;// ikinci kullanım yöntemi where kullanmadan yapabiliriz
    //Note note = _appDbContext.Notes.Find(id)!;//Primary key kolonunda arama yapcaksak find metoduyla yapabiliyoruz.
    Note note = _appDbContext
        .Notes
        .AsNoTracking()//db contexte çektiğimiz id li notu izleme diyoruz.
        .Where(x=>x.Id==id)
        .Include(X=>X.Category)
        .FirstOrDefault()!;
    NoteDTO noteDTO = new NoteDTO{
        Id = note.Id,
        Title = note.Title,
        Content = note.Content,
        CategoryName = note.Category!.Name!,
        CategoryId = note.CategoryId
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
                CategoryName = note.Category!.Name!,
                CategoryId = note.CategoryId
            }).ToList();
        return noteDTOs;
    }

    public bool UpdateNote(int id, NoteDTO noteDTO)
    {
        if(noteDTO.Id!=id)
        {
            return false;
        }
        var existingNote = GetNote(id);
        existingNote.Title=noteDTO.Title;
        existingNote.Content=noteDTO.Content;
        existingNote.CategoryId=noteDTO.CategoryId;

        Note updatedNote = new ()
        {
            Id=existingNote.Id,
            Content=existingNote.Content,
            CategoryId=existingNote.CategoryId,
            UpdatedAt = DateTime.UtcNow,
        };
        _appDbContext.Notes.Update(updatedNote);
        var result = _appDbContext.SaveChanges();
        return result>0;
    }
}
