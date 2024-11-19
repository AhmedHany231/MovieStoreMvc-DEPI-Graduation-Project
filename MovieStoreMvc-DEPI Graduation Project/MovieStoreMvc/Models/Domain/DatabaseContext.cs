using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreMvc.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options) { }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
        //        Name = "AdminsRole",
        //        NormalizedName = "ADMINSROLE"
        //    },
        //    new IdentityRole
        //    {
        //        Id = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
        //        Name = "UsersRole",
        //        NormalizedName = "USERSROLE"
        //    });

        //    var hasher = new PasswordHasher<IdentityUser>();

        //    builder.Entity<IdentityUser>().HasData(new IdentityUser
        //    {
        //        Id = "62fe5285-fd68-4711-ae93-673787f4ac66",
        //        UserName = "Admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "admin@admin.com",
        //        NormalizedEmail = "admin@admin.com".ToUpper(),
        //        PasswordHash = hasher.HashPassword(null, "123"),
        //        EmailConfirmed = true
        //    },
        //    new IdentityUser
        //    {
        //        Id = "62fe5285-fd68-4711-ae93-673787f4a111",
        //        UserName = "user",
        //        NormalizedUserName = "USER",
        //        Email = "user@user.com",
        //        NormalizedEmail = "user@user.com".ToUpper(),
        //        PasswordHash = hasher.HashPassword(null, "123"),
        //        EmailConfirmed = true
        //    });

        //    builder.Entity<IdentityUserRole<string>>().HasData(
        //    new IdentityUserRole<string>
        //    {
        //        RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
        //        UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
        //    }, new IdentityUserRole<string>
        //    {
        //        RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
        //        UserId = "62fe5285-fd68-4711-ae93-673787f4a111"
        //    }, new IdentityUserRole<string>
        //    {
        //        RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
        //        UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
        //    });

        //}

        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Movie> Movie { get; set; }
    }
}
