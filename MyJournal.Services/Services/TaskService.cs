using Microsoft.EntityFrameworkCore;
using MyJournal.Core.Entities;
using MyJournal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyJournal.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly MyJournalDbContext _db;

        public TaskService(MyJournalDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TaskItem task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t != null)
            {
                _db.Tasks.Remove(t);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
