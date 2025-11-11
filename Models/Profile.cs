using Microsoft.AspNetCore.Identity;

namespace Opiskelijaportaali.Models
{
    //Profiili
    public class Profile : IdentityUser
    {
        public int Id { get; set; }                   // Primary key
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Bdate { get; set; }
        public string? Phone { get; set; }
    }
}
