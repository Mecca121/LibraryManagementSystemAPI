using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Author : BaseEntity
    {
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }

        public DateTime DateOfBirth { get; set; }   

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
