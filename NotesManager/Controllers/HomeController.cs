using Microsoft.AspNetCore.Mvc;
using NotesManager.Data;
using Microsoft.EntityFrameworkCore;
using NotesManager.Models;
using System.Diagnostics;

namespace NotesManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? id, bool create = false)
        {
            var notes = _context.Notes.OrderByDescending(n => n.CreatedAd).ToList();

            NotesManager.Models.Note? selectedNote = null;
            if (create)
            {
                selectedNote = new NotesManager.Models.Note();
            }
            else if (id.HasValue)
            {
                selectedNote = notes.FirstOrDefault(n => n.Id == id.Value);
            }
            ViewBag.SelectedNote = selectedNote;
            return View(notes);
        }

        public async Task<IActionResult> CreateEditNoteForm(Note model)
        {
            if (string.IsNullOrWhiteSpace(model.Content))
                model.Content = "";

            if (model.Id == 0)
            {
                model.CreatedAd = DateTime.UtcNow;
                _context.Notes.Add(model);
            }
            else
            {
                var existingNote = await _context.Notes.FindAsync(model.Id);
                if (existingNote == null)
                    return NotFound();

                existingNote.Title = model.Title;
                existingNote.Content = model.Content;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = model.Id });

            //return RedirectToAction("Index");
            //return Redirect("/Home/Index?id=" + model.Id);
        }

        public async Task<IActionResult> DeleteNote(int? id)
        {
            if (id == null) return NotFound();

            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            var nextNote = await _context.Notes
            .OrderByDescending(n => n.Id)
            .FirstOrDefaultAsync(n => n.Id < id);

            //if (nextNote != null)
            //    return Redirect("/Home/Index?id=" + nextNote.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
