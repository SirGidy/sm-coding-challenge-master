using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class RushingRepository : BaseRepository,IRushingRepository
    {
        public RushingRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Rushing>> ListAsync()
        {
           return await _context.Rushings.ToListAsync();
        }
        public async Task AddAsync(Rushing rushing)
        {
            await _context.Rushings.AddAsync(rushing);
        }

        public async Task<Rushing> FindByIdAsync(int id)
        {
            return await _context.Rushings.FindAsync(id);
        }
        public async Task<IEnumerable<Rushing>> GetRushingsByPlayerIdAsync(string PlayerId)
        {
            return await _context.Rushings.Where(p => p.PlayerId == PlayerId).ToListAsync();
        }
        public async Task<Rushing> GetLatestRushingByPlayerIdAsync(string PlayerId)
        {
            return await _context.Rushings.LastOrDefaultAsync(p => p.PlayerId == PlayerId);
        }

        public void Update(Rushing rushing)
        {
            _context.Rushings.Update(rushing);
        }

        public void Remove(Rushing rushing)
        {
            _context.Rushings.Remove(rushing);
        }
    }
}