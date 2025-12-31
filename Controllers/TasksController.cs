using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers;

public class TasksController : Controller
{
    private readonly TaskRepository _repo;

    public TasksController(TaskRepository repo)
    {
        _repo = repo;
    }

    //GET /Tasks
    public IActionResult Index()
    {
        var tasks = _repo.GetAll();
        return View(tasks);
    }
    
    //POST /Tasks/Add
    [HttpPost]
    public IActionResult Add(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
            _repo.Add(title);
                
        return RedirectToAction(nameof(Index));
    }
    
    //POST /Tasks/ToggleDone
    [HttpPost]
    public IActionResult ToggleDone(int id)
    {
        _repo.ToggleDone(id);
        return RedirectToAction(nameof(Index));
    }
    
    //POST /Tasks/Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}