using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Services;
using Notes.Services.Interfaces;

namespace NotesMVC.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IService<Notes.Domain.Contact> _services;

        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger, IService<Notes.Domain.Contact> services)
        {
            _logger = logger;
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Notes.Domain.Contact contact)
        {
            if (ModelState.IsValid)
            {
                _services.Add(contact);
                TempData["SuccessMessage"] = "Контакт успешно добавлен!";
                return RedirectToAction("Create"); // Перезагрузка страницы
            }

            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contact = _services.Get(id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = $"Контакт с ID {id} не найден!";
                return RedirectToAction("Delete");
            }

            _services.Remove(id);
            TempData["SuccessMessage"] = $"Контакт с ID {id} успешно удален!";
            return RedirectToAction("Delete");
        }


        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int Id, Notes.Domain.Contact contact)
        {
            var updatingContact = _services.Get(Id);

            if (updatingContact == null)
            {
                TempData["ErrorMessage"] = $"Контакт с ID {Id} не найден!";
                return RedirectToAction("Update");
            }

            _services.Update(Id, contact);
            TempData["SuccessMessage"] = $"Контакт с ID {Id} успешно изменен!";
            return RedirectToAction("Update");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(bool showContacts)
        {

            var all = _services.GetAll();

            if(all == null)
            {
                TempData["ErrorMessage"] = $"Нет данных в базе";
                return View();
            }

            return View(all);

        }

        [HttpGet]
        public IActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetById(int Id)
        {
            var result = _services.Get(Id);

            if( result == null)
            {
                TempData["ErrorMessage"] = $"Нет данных с Id:{Id}";
                return View();
            }

            return View(result);
        }
    }
}
