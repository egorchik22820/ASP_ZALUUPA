using ASP_ZALUUPA.infrastructure;

namespace ASP_ZALUUPA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // ���������� � ������������ ���� appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // ����������� ������ Project � ��������� ����� ��� ��������
            IConfiguration configuration = configBuild.Build();
            AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

            // ���������� ���������� ������������
            builder.Services.AddControllersWithViews();

            // �������� ������������
            WebApplication app = builder.Build();

            // ���������� ������������� �������� ������ (css, js, �����)
            app.UseStaticFiles();

            // ���������� ������� �������������
            app.UseRouting();

            // ������������ ������ ��� ��������

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
