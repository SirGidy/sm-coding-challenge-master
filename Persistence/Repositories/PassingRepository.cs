using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class PassingRepository : BaseRepository,IPassingRepository
    {
        public PassingRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Passing>> ListAsync()
        {
           return await _context.Passings.ToListAsync();
        }
        public async Task AddAsync(Passing passing)
        {
            await _context.Passings.AddAsync(passing);
        }

        public async Task<Passing> FindByIdAsync(int id)
        {
            return await _context.Passings.FindAsync(id);
        }

        public void Update(Passing passing)
        {
            _context.Passings.Update(passing);
        }

        public void Remove(Passing passing)
        {
            _context.Passings.Remove(passing);
        }
    }
}