﻿using bookApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApiProject.Services
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string bookIsbn);
        bool BookExists(int bookId);
        bool BookExists(string bookIsbn);

        bool IsDuplicateIsbn(int bookId, string bookIsbn);

        decimal GetBookRating(int bookId);

    }
}
