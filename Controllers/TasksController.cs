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

    public IActionResult Index()
    {
        var tasks = _repo.GetAll();
        return View(tasks);
    }
}