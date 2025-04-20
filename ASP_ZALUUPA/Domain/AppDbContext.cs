using ASP_ZALUUPA.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_ZALUUPA.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string AdminName = "admin";
            string roleAdminId = Guid.NewGuid().ToString();
            string userAdminId = Guid.NewGuid().ToString();

            // добавляем роль администратора сайта
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = AdminName,
                NormalizedName = AdminName.ToUpper(),
            });

            // добавляем нового IdentityUser в качестве администратора сайта
            //builder.Entity<IdentityUser>().HasData(new IdentityUser()
            //{
            //    Id = userAdminId,
            //    UserName = AdminName,
            //    NormalizedUserName = AdminName.ToUpper(),
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "admin@admin.com",
            //    EmailConfirmed = true,
            //    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), AdminName),
            //    SecurityStamp = string.Empty,
            //    PhoneNumberConfirmed = true
            //});

            // Создаем заранее пользователя с нужными данными
            var adminUser = new IdentityUser
            {
                Id = userAdminId,
                UserName = AdminName,
                NormalizedUserName = AdminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PhoneNumberConfirmed = true
            };

            // Хешируем пароль именно для этого пользователя
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, AdminName);

            // Добавляем пользователя
            builder.Entity<IdentityUser>().HasData(adminUser);


            // определяем админа в соответствующую роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId,
            });
        }
    }
}
