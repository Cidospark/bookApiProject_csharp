using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Models;

namespace bookApiProject.Services
{
    public class BookRepository : IBookRepository
    {
        private BookDBContext _bookContext;

        public BookRepository(BookDBContext bookContext)
        {
            _bookContext = bookContext;
        }

        public bool BookExists(int bookId)
        {
            return _bookContext.Books.Any(b => b.Id == bookId);
        }

        public bool BookExists(string bookIsbn)
        {
            return _bookContext.Books.Any(b => b.Isbn == bookIsbn);
        }

        public Book GetBook(int bookId)
        {
            return _bookContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Book GetBook(string bookIsbn)
        {
            return _bookContext.Books.Where(b => b.Isbn == bookIsbn).FirstOrDefault();
        }

        public decimal GetBookRating(int bookId)
        {
            return _bookContext.Reviews.Where(b => b.Book.Id == bookId)
                .Select(r => r.Rating).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _bookContext.Books.OrderBy(b => b.Id).ToList();
        }

        public bool IsDuplicateIsbn(int bookId, string bookIsbn)
        {
            throw new NotImplementedException();
        }
    }
}
