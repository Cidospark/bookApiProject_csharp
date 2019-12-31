using bookApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Services
{
    interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string isbn);
        bool BookExists(int bookId);
        bool BookExists(string isbn);

        bool IsDuplicate(int bookId);

        double GetBookRating(int bookId);

    }
}
