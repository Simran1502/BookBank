using BookBank.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookBank.Controllers
{
    public class BookController : Controller
    {
        public readonly IRepository _repo;
        public BookController(IRepository repo)
        {
            _repo = repo;
            
        }

        // GET: View all books
        public ActionResult ViewAllBooks()
        {
            var books = _repo.ViewAllBooks()
                .Select(b => new Book
                {
                    Id = b.Id,
                    BookName = b.BookName,
                    Genre = b.Genre,
                    AvailabilityStatus = b.AvailabilityStatus
                }).ToList();

            return View(books);
        }

        // GET: Add Book
        public ActionResult AddBook()
        {
            return View();
        }

        // POST: Add Book
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                BookDetail bd = new BookDetail
                {
                    BookName = book.BookName,
                    Genre = book.Genre,
                    AvailabilityStatus = book.AvailabilityStatus
                };

                _repo.AddBook(bd);
                return RedirectToAction("ViewAllBooks");
            }
            return View(book);
        }

        // GET: Remove Book (Loads delete page)
        public IActionResult RemoveBook(int bookId)
        {
            var book = _repo.ViewAllBooks()
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null)
                return NotFound();

            var model = new Book
            {
                Id = book.Id,
                BookName = book.BookName,
                Genre = book.Genre,
                AvailabilityStatus = book.AvailabilityStatus
            };

            return View(model);
        }

        // POST: Remove Book (ACTUAL DELETE)
        [HttpPost]
        public IActionResult RemoveBook(Book book)
        {
            _repo.RemoveBook(book.Id);
            return RedirectToAction("ViewAllBooks");
        }
    }
}
