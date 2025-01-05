using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Services;
using Notes.Services.Interfaces;

namespace NotesMVC.Controllers
{
    public class NotesController : Controller
    {
        private readonly IService<Notes.Domain.Note> _services;

        private readonly ILogger<ContactsController> _logger;

        public NotesController(ILogger<ContactsController> logger, IService<Notes.Domain.Note> services)
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
        public IActionResult Create(Notes.Domain.Note note)
        {
            if (ModelState.IsValid)
            {
                _services.Add(note);
                TempData["SuccessMessage"] = "Контакт успешно добавлен!";
                return RedirectToAction("Create"); // Перезагрузка страницы
            }

            return View(note);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var note = _services.Get(id);
            if (note == null)
            {
                TempData["ErrorMessage"] = $"Заметка с ID {id} не найдена!";
                return RedirectToAction("Delete");
            }

            _services.Remove(id);
            TempData["SuccessMessage"] = $"Заметка с ID {id} успешно удалена!";
            return RedirectToAction("Delete");
        }


        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int Id, Notes.Domain.Note note)
        {
            var updatingNote = _services.Get(Id);

            if (updatingNote == null)
            {
                TempData["ErrorMessage"] = $"Контакт с ID {Id} не найден!";
                return RedirectToAction("Update");
            }

            _services.Update(Id, note);
            TempData["SuccessMessage"] = $"заметка с ID {Id} успешна изменена!";
            return RedirectToAction("Update");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(bool showNotes)
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

            if (result == null)
            {
                TempData["ErrorMessage"] = $"Нет данных с Id:{Id}";
                return View();
            }

            return View(result);
        }
    }
}
