using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemAPI.Repository.Interfaces;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Dtos;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreRepository.GetAllGenres()
                .Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    CreatedOn = g.CreatedOn,
                    IsDeleted = g.IsDeleted
                });
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(Guid id)
        {
            var genre = _genreRepository.GetGenreById(id);
            if (genre == null) return NotFound();

            var dto = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                CreatedOn = genre.CreatedOn,
                IsDeleted = genre.IsDeleted
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreDto dto)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
            _genreRepository.AddGenre(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(Guid id, [FromBody] GenreDto dto)
        {
            var genre = _genreRepository.GetGenreById(id);
            if (genre == null) return NotFound();

            genre.Name = dto.Name;
            genre.Description = dto.Description;
            genre.IsDeleted = dto.IsDeleted;

            _genreRepository.UpdateGenre(genre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(Guid id)
        {
            _genreRepository.DeleteGenre(id);
            return NoContent();
        }
    }
}
