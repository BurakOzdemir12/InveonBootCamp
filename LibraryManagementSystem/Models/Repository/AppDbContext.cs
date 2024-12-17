using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        :IdentityDbContext<AppUser,AppRole,Guid>(options)
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFeature>().HasKey(e => e.UserId);

            builder.Entity<UserFeature>().HasOne(e => e.AppUser)
            .WithOne(e => e.UserFeature)
            .HasForeignKey<UserFeature>(e => e.UserId);
        }


    }
}
