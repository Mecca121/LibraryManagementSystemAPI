using System;
using System.Collections.Generic;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book? GetBookById(Guid id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}
