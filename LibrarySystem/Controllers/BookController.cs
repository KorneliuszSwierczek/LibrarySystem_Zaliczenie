using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LibrarySystem.Models;
using LibrarySystem.Data;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly LibrarySystemContext _context;

        public BookController(LibrarySystemContext context)
        {
            _context = context;
        }

        [Authorize] // Tylko zalogowani użytkownicy mają dostęp
        public ActionResult List()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public ActionResult Add()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                ViewBag.ErrorMessage = "Książka nie została znaleziona.";
                return View("Error");
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return View(book);
        }

        public ActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                ViewBag.ErrorMessage = "Książka nie została znaleziona.";
                return View("Error");
            }

            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
