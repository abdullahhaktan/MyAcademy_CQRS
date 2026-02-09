using System.ComponentModel.DataAnnotations;

namespace MyAcademyCQRS.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
