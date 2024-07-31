using Microsoft.AspNetCore.Identity;

namespace BrainDumpApi_2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }


    }
}
