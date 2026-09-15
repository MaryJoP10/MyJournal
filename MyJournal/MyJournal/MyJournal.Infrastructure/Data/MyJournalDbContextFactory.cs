using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyJournal.Infrastructure.Data
{
    public class MyJournalDbContextFactory
        : IDesignTimeDbContextFactory<MyJournalDbContext>
    {
        public MyJournalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<MyJournalDbContext>();

            var databasePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "MyJournal",
                "myjournal.db");

            var directory = Path.GetDirectoryName(databasePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            optionsBuilder.UseSqlite($"Data Source={databasePath}");

            return new MyJournalDbContext(optionsBuilder.Options);
        }
    }
}