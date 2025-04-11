using ASP_ZALUUPA.infrastructure;

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

            // подключаем функционал контроллеров
            builder.Services.AddControllersWithViews();

            // собираем конфигурацию
            WebApplication app = builder.Build();

            // подключаем использование стачиных файлов (css, js, любых)
            app.UseStaticFiles();

            // подключаем систему маршрутизации
            app.UseRouting();

            // регистрируем нужные нам маршруты

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            //app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}"
            //);



            await app.RunAsync();
        }
    }
}
