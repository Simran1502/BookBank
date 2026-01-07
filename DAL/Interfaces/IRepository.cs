using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        bool AddBook(BookDetail book);
        List<BookDetail> ViewAllBooks();
        bool RemoveBook(int bookId);
    }
}
