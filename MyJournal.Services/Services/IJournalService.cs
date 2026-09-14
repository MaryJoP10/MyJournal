using MyJournal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyJournal.Services.Services
{
    public interface IJournalService
    {
        Task<IEnumerable<JournalEntry>> GetAllAsync();
        Task<JournalEntry?> GetByIdAsync(Guid id);
        Task AddAsync(JournalEntry entry);
        Task UpdateAsync(JournalEntry entry);
        Task DeleteAsync(Guid id);
    }
}
