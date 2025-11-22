using System;

namespace LibraryManagementSystemAPI.Dtos
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
