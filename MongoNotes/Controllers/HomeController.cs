using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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