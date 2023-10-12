using Core.Domains;

namespace WebApi.Dtos
{
    public class StudentDTO
    {
        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }
    }
}
