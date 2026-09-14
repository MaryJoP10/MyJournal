using System;

namespace MyJournal.Core.Entities
{
    public class JournalEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Content { get; set; } = string.Empty;
        public string? Mood { get; set; }
        public string? Tags { get; set; }
    }
}
