using ContactApp5.Models;
using ContactApp5.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp5.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return View(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> SaveContact(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await _contactService.SaveContactAsync(contact);
            return RedirectToAction("Success");
        }
        return View("Index", await _contactService.GetAllContactsAsync());
    }

    [HttpGet]
    public IActionResult Success()
    {
        return View();
    }
}