using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MyJournal.Infrastructure.Data;
using MyJournal.Services.Services;
using MyJournal.Services.Seed;
using Microsoft.Maui.Storage;
using System.IO;

namespace MyJournal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // Register DbContext and application services
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "myjournal.db");
            builder.Services.AddDbContext<MyJournalDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<IHabitService, HabitService>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<IJournalService, JournalService>();
            builder.Services.AddSingleton<MyJournal.Services.Theming.IThemeService, MyJournal.Services.Theming.ThemeService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Seed demo data if appropriate (basic, safe for startup)
            try
            {
                using var scope = app.Services.CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<MyJournalDbContext>();

                db.Database.Migrate();

                DemoDataSeeder.SeedAsync(db).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(
                    $"ERROR inicializando la base de datos: {ex}");
#endif

                throw;
            }

            return app;
        }
    }
}
