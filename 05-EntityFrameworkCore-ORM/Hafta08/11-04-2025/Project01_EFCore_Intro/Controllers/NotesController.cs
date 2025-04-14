using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project01_EFCore_Intro.DTOs;
using Project01_EFCore_Intro.Models;
using Project01_EFCore_Intro.Services.Abstract;

namespace Project01_EFCore_Intro.Controllers
{
    [Route("notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _noteService.GetNotes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _noteService.GetNote(id);
            return result is null ? NotFound("Aradığınız Not Bulunammadı!") : Ok(result);
        }
        [HttpPost]
        public IActionResult Create(NoteDTO noteDTO)
        {
            var result = _noteService.CreateNote(noteDTO);
            return Ok(result);            
        }
        [HttpDelete("{id}")]
        private IActionResult Delete(int id)
        {
            var result = _noteService.DeleteNote(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        private IActionResult Update(int id, NoteDTO noteDTO)
        {
            var result = _noteService.UpdateNote(id, noteDTO);
            return Ok(result);
        }


    }
}
