using Microsoft.AspNet.Identity;
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
            SeedAdmin(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "83e062a5-5e67-4916-b0ec-d0f864e5fcee",
                    Name = "Admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp = "1"

                }
                );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1f92139d-cc02-4c90-b288-91507390b938",
                    Name = "Manager",
                    NormalizedName = "Manager",
                    ConcurrencyStamp = "1"

                }
                );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "59853763-43e1-4d55-91fa-574cc71fc077",
                    Name = "Customer",
                    NormalizedName = "Customer",
                    ConcurrencyStamp = "1"

                }
                );
        }


        private void SeedAdmin(ModelBuilder builder)
        {
            PasswordHasher<CustomUserModel> hasher = new PasswordHasher<CustomUserModel>();
            CustomUserModel user = new CustomUserModel();
            user.Id = "a4384d86-474c-4af6-aa0c-d472d9152c07";
            user.UserName = "admin@admin.com";
            user.NormalizedUserName = "admin@admin.com".ToUpper();
            user.NormalizedEmail = "admin@admin.com".ToUpper();
            user.Email = "admin@admin.com";
            user.LockoutEnabled = false;
            user.FName = "Admin";
            user.SName = "Admin";
            user.ConcurrencyStamp = "1";
            var password = hasher.HashPassword(user, "Admin123!");


            user.PasswordHash = password;

            builder.Entity<CustomUserModel>().HasData(user);

        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "83e062a5-5e67-4916-b0ec-d0f864e5fcee",
                    UserId = "a4384d86-474c-4af6-aa0c-d472d9152c07"
                });

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "1f92139d-cc02-4c90-b288-91507390b938",
                    UserId = "a4384d86-474c-4af6-aa0c-d472d9152c07"
                });

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "59853763-43e1-4d55-91fa-574cc71fc077",
                    UserId = "a4384d86-474c-4af6-aa0c-d472d9152c07"
                });

        }
    }
}
