using System.Collections.Generic;
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