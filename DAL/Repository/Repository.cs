using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        public readonly BookDbContext _context;

        public Repository(BookDbContext context)
        {
            _context = context;
        }
        public bool AddBook(BookDetail book)
        {
            try
            {
                _context.BookDetails.Add(book);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BookDetail> ViewAllBooks()
        {
            return _context.BookDetails.ToList();
        }

        public bool RemoveBook(int bookId)
        {
            try
            {
                var book = _context.BookDetails.Find(bookId);
                if (book != null)
                {
                    _context.BookDetails.Remove(book);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
