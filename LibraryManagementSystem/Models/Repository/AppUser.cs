using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models.Repository
{
    public enum UserType:byte
    {
        Normal=1,
        Admin=2
    }

    public class AppUser:IdentityUser<Guid>
    {
        public string? City { get; set; }

        public UserType UserType { get; set; }

        public UserFeature? UserFeature { get; set; }
    }
}
