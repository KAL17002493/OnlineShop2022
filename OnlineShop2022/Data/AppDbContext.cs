using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Models;

namespace OnlineShop2022.Data
{
    public class AppDbContext : IdentityDbContext<CustomUserModel>
    {
        public DbSet<ProductModel> Products { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        //Creates a user and roles when the database is generated
        public DbSet<OnlineShop2022.Models.CategoryModel> CategoryModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedAdmin(builder);
            this.SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity <IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "83e062a5-5e67-4916-b0ec-d0f864e5fcee",
                    Name = "Admin"
                });
        }
        private void SeedAdmin(ModelBuilder builder)
        {
            CustomUserModel user = new CustomUserModel();
            user.Id = "a4384d86-474c-4af6-aa0c-d472d9152c07";
            user.UserName = "Admin";
            user.Email = "admin@admin.com";
            user.LockoutEnabled = false;
            user.FName = "Admin";
            user.SName = "Admin";

            PasswordHasher hasher = new PasswordHasher();
            var password = hasher.HashPassword("Admin123!");
            user.PasswordHash = password;

            builder.Entity<CustomUserModel>().HasData(user);

        }
    }
}
