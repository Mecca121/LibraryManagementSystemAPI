using System;
using System.Collections.Generic;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre? GetGenreById(Guid id);
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Guid id);
    }
}
