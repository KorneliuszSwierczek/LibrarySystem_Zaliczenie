using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Add()
        {
            return View(new Book());
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return View(book);
        }

        public IActionResult Edit(int id)
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
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);

                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.PublicationYear = book.PublicationYear;
                    existingBook.Description = book.Description;
                    existingBook.Categories = book.Categories;

                    _context.SaveChanges();

                    return RedirectToAction("List");
                }
            }

            return View(book);
        }

        public IActionResult Delete(int id)
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
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
