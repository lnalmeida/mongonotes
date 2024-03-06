using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoNotes.Models;
using MongoNotes.ModelViews;
using MongoNotes.Repositories;

namespace MongoNotes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _notesRepository;

    public HomeController(ILogger<HomeController> logger, IRepository notesRepository)
    {
        _logger = logger;
        _notesRepository = notesRepository;
    }

    public async Task<IActionResult> Index()
    {
        var notes = await _notesRepository.FindAll();
        return View(notes);
    }

    public async Task<IActionResult> Details(string id)
    {
        var note = await _notesRepository.FindOne(id);
        if (note != null)
        {
            return View(note);
        }
        return null;
    }

    public IActionResult Create()
    {
        ViewData["btnLabel"] = "Criar nota";
        return View("Form");
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NoteViewModel note)
    {
        await _notesRepository.CreateNote(note);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        ViewData["btnLabel"] = "Salvar";
        var note = await _notesRepository.FindOne(id);
        if (note == null) return NotFound();
        return View("Form", note);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(string id, NoteViewModel note)
    {
        await _notesRepository.EditNote(id, note);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(string id)
    {
        await _notesRepository.DeleteNote(id);
        return RedirectToAction(nameof(Index));
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