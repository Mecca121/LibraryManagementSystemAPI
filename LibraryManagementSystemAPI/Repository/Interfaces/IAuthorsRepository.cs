using System;
using System.Collections.Generic;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author? GetAuthorById(Guid id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Guid id);
    }
}
