using MyJournal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyJournal.Services.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(Guid id);
    }
}
