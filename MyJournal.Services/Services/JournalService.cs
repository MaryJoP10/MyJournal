using Microsoft.EntityFrameworkCore;
using MyJournal.Core.Entities;
using MyJournal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyJournal.Services.Services
{
    public class JournalService : IJournalService
    {
        private readonly MyJournalDbContext _db;

        public JournalService(MyJournalDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(JournalEntry entry)
        {
            _db.JournalEntries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _db.JournalEntries.FindAsync(id);
            if (e != null)
            {
                _db.JournalEntries.Remove(e);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JournalEntry>> GetAllAsync()
        {
            return await _db.JournalEntries.ToListAsync();
        }

        public async Task<JournalEntry?> GetByIdAsync(Guid id)
        {
            return await _db.JournalEntries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(JournalEntry entry)
        {
            _db.JournalEntries.Update(entry);
            await _db.SaveChangesAsync();
        }
    }
}
