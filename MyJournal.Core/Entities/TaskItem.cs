using System;

namespace MyJournal.Core.Entities
{
    public enum TaskState { Pending, InProgress, Completed, Postponed, Cancelled }

    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public TaskState State { get; set; } = TaskState.Pending;
    }
}
