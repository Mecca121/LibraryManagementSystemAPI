using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string? Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(13, MinimumLength = 10)]
        public string? ISBN { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int PublicationYear { get; set; } 

        public Guid AuthorId { get; set; }
        [Required]
        public Author? Author { get; set; }

        public Guid GenreId { get; set; }          
        public Genre? Genre { get; set; }
    }
}
