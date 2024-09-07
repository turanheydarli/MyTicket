using Microsoft.AspNetCore.Mvc;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class CustomerController : Controller
{
    private readonly IRepository<Customer, AppDbContext> _repository;

    public CustomerController(IRepository<Customer, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var customers = _repository.GetList();

        return View(customers);
    }

    public IActionResult Create()
    {
        return View(new CustomerViewModel());
    }

    [HttpPost]
    public IActionResult Create(CustomerViewModel model)
    {
        _repository.Add(model.Customer);
        
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var customer = _repository.Get(m => m.Id == id);
        if (customer == null)
        {
            return NotFound();
        }

        CustomerViewModel viewModel = new()
        {
            Customer = customer
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(CustomerViewModel model)
    {
        _repository.Update(model.Customer);
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var movie = _repository.Get(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        CustomerViewModel viewModel = new()
        {
            Customer = movie
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