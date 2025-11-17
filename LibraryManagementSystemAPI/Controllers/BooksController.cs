using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemAPI.Repository.Interfaces;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Dtos;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks()
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublicationYear = b.PublicationYear,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId,
                    CreatedOn = b.CreatedOn,
                    IsDeleted = b.IsDeleted
                });
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) return NotFound();

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                CreatedOn = book.CreatedOn,
                IsDeleted = book.IsDeleted
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto dto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            _bookRepository.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] BookDto dto)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.ISBN = dto.ISBN;
            book.PublicationYear = dto.PublicationYear;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;
            book.IsDeleted = dto.IsDeleted;

            _bookRepository.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
