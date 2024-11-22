using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace perdidog.Data
{
    public class ApplicationDbContextAuth : IdentityDbContext
    {
        public ApplicationDbContextAuth(DbContextOptions<ApplicationDbContextAuth> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var guestRoleId = "4c72bee0 - c489 - 4c3b - bdd4 - 308f86a04c13";
            var userRoleId = "7a94e01f-52a5-4f9b-a4e5-f424da93b6fd";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = guestRoleId,
                    ConcurrencyStamp = guestRoleId,
                    Name = "Guest",
                    NormalizedName = "Guest".ToUpper(),
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                },
            };


            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
