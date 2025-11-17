using System;

namespace LibraryManagementSystemAPI.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
