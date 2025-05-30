using BookormaApplication.Context;
using BookormaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookormaApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Book/Index or /
        [HttpGet]
        public IActionResult Index(string searchTerm = null)
        {
            ViewBag.NewBook = new Book();

            var books = string.IsNullOrWhiteSpace(searchTerm)
                ? _context.books.ToList()
                : _context.books
                         .Where(b => b.Title.Contains(searchTerm))
                         .ToList();

            return View(books);
        }

        // POST: /Book/Add
        [HttpPost]
        public IActionResult Add(Book NewBook)
        {
            if (ModelState.IsValid)
            {
                _context.books.Add(NewBook);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: /Book/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.books.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
