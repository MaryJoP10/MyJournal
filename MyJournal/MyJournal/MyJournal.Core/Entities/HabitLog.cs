using System;

namespace MyJournal.Core.Entities
{
    public class HabitLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid HabitId { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public string? Notes { get; set; }
    }
}
