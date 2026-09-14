using Microsoft.EntityFrameworkCore;
using MyJournal.Core.Entities;

namespace MyJournal.Infrastructure.Data
{
    public class MyJournalDbContext : DbContext
    {
        public MyJournalDbContext(DbContextOptions<MyJournalDbContext> options) : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; } = null!;
        public DbSet<HabitLog> HabitLogs { get; set; } = null!;
        public DbSet<TaskItem> Tasks { get; set; } = null!;
        public DbSet<JournalEntry> JournalEntries { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habit>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.Logs).WithOne().HasForeignKey("HabitId");
            });

            modelBuilder.Entity<HabitLog>(b =>
            {
                b.HasKey(x => x.Id);
            });
        }
    }
}
