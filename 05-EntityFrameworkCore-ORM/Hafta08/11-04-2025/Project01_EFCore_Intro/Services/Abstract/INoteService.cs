using System;
using Project01_EFCore_Intro.DTOs;
using Project01_EFCore_Intro.Models;

namespace Project01_EFCore_Intro.Services.Abstract;

public interface INoteService
{
    List<NoteDTO> GetNotes();
    NoteDTO GetNote(int id);
    NoteDTO CreateNote(NoteDTO noteDTO);
    bool UpdateNote(int id, NoteDTO noteDTO);
    bool DeleteNote(int id);
}
