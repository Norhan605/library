public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllersWithViews();
        var app=builder.Build();
        app.MapControllerRoute("default","{controller=Book}/{action=GetBooks}");
        app.UseStaticFiles();
        app.Run();

        return 0;
    }
}
