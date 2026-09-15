using Microsoft.EntityFrameworkCore;
using MyJournal.Core.Entities;
using MyJournal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyJournal.Services.Services
{
    public class HabitService : IHabitService
    {
        private readonly MyJournalDbContext _db;

        public HabitService(MyJournalDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Habit habit)
        {
            _db.Habits.Add(habit);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var h = await _db.Habits.FindAsync(id);
            if (h != null)
            {
                _db.Habits.Remove(h);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Habit>> GetAllAsync()
        {
            return await _db.Habits.Include(x => x.Logs).ToListAsync();
        }

        public async Task<Habit?> GetByIdAsync(Guid id)
        {
            return await _db.Habits.Include(x => x.Logs).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Habit habit)
        {
            _db.Habits.Update(habit);
            await _db.SaveChangesAsync();
        }
    }
}
