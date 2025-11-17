using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemAPI.Repository.Interfaces;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Dtos;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors()
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Bio = a.Bio,
                    DateOfBirth = a.DateOfBirth,
                    CreatedOn = a.CreatedOn,
                    IsDeleted = a.IsDeleted
                });
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) return NotFound();

            var dto = new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Bio = author.Bio,
                DateOfBirth = author.DateOfBirth,
                CreatedOn = author.CreatedOn,
                IsDeleted = author.IsDeleted
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDto dto)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Bio = dto.Bio,
                DateOfBirth = dto.DateOfBirth,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            _authorRepository.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] AuthorDto dto)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) return NotFound();

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.Bio = dto.Bio;
            author.DateOfBirth = dto.DateOfBirth;
            author.IsDeleted = dto.IsDeleted;

            _authorRepository.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
