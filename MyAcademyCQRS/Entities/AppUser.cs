using Microsoft.AspNetCore.Identity;

namespace MyAcademyCQRS.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public IList<Order> Orders { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Cart Cart { get; set; }
    }
}
