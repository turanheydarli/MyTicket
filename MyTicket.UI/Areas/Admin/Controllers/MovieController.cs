using Microsoft.AspNetCore.Mvc;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class MovieController : Controller
{
    private readonly IRepository<Movie, AppDbContext> _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MovieController(IRepository<Movie, AppDbContext> repository, IWebHostEnvironment webHostEnvironment)
    {
        _repository = repository;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var movies = _repository.GetList();

        return View(movies);
    }

    public IActionResult Create()
    {
        return View(new MovieViewModel());
    }

    [HttpPost]
    public IActionResult Create(MovieViewModel model)
    {
        if (model.ThumbnailFile != null)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ThumbnailFile.FileName)}";
            string rootDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            string fullPath = Path.Combine(rootDirectory, fileName);

            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                model.ThumbnailFile.CopyTo(fs);
            }

            model.Movie.ThumbnailUrl = Path.Combine("uploads", fileName);
        }

        _repository.Add(model.Movie);
        
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var movie = _repository.Get(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        MovieViewModel viewModel = new()
        {
            Movie = movie
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(MovieViewModel model)
    {
        _repository.Update(model.Movie);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var movie = _repository.Get(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        MovieViewModel viewModel = new()
        {
            Movie = movie
        };

        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _repository.Get(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        _repository.Delete(movie);
        return RedirectToAction("Index");
    }
}