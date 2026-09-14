using MyJournal.Infrastructure.Data;
using MyJournal.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyJournal.Services.Seed
{
    public static class DemoDataSeeder
    {
        public static async Task SeedAsync(MyJournalDbContext db)
        {
            if (db.Habits.Any()) return;

            var habit = new Habit
            {
                Title = "Beber agua",
                Description = "Tomar 8 vasos de agua",
                Frequency = "Daily"
            };

            db.Habits.Add(habit);

            db.JournalEntries.Add(new JournalEntry
            {
                Content = "Bienvenida al diario!",
                Date = DateTime.UtcNow
            });

            await db.SaveChangesAsync();
        }
    }
}
