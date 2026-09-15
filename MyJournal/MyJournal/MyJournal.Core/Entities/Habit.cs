using System;
using System.Collections.Generic;

namespace MyJournal.Core.Entities
{
    public class Habit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Frequency { get; set; }
        public string? DaysOfWeek { get; set; } // simple csv or bitmask later
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<HabitLog> Logs { get; set; } = new List<HabitLog>();
    }
}
