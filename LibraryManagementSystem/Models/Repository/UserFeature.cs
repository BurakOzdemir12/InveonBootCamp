namespace LibraryManagementSystem.Models.Repository
{
    public class UserFeature
    {
        public  Guid UserId { get; set; }
        public int Age { get; set; } = default!;
        public string Gender { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
    }
}
