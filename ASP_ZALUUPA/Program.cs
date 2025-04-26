using ASP_ZALUUPA.Domain;
using ASP_ZALUUPA.Domain.Repositories.Abstract;
using ASP_ZALUUPA.Domain.Repositories.EntityFramework;
using ASP_ZALUUPA.infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace ASP_ZALUUPA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // подключаем в конфигурацию файл appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // оборачиваем секцию Project в объектную форму для удобства
            IConfiguration configuration = configBuild.Build();
            AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

            // подключаем контекст БД
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(appConfig.Database.ConnectionString)
                // на момент создания приложения в данной версии EF был баг, хотя ошибки нет, поэтому подавляем предупреждения
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

            builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
            builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
            builder.Services.AddTransient<DataManager>();

            // настраиваем Identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // настраиваем Auth Cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });

            // подключаем функционал контроллеров
            builder.Services.AddControllersWithViews();

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            // собираем конфигурацию
            WebApplication app = builder.Build();

            // используем логирование
            app.UseSerilogRequestLogging();

            // обработка исключений
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // подключаем использование стачиных файлов (css, js, любых)
            app.UseStaticFiles();

            // подключаем систему маршрутизации
            app.UseRouting();

            // подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // регистрируем нужные нам маршруты

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");



            await app.RunAsync();
        }
    }
}
