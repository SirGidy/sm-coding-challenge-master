using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class KickingRepository : BaseRepository,IKickingRepository
    {
        public KickingRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Kicking>> ListAsync()
        {
           return await _context.Kickings.ToListAsync();
        }
        public async Task AddAsync(Kicking kicking)
        {
            await _context.Kickings.AddAsync(kicking);
        }

        public async Task<Kicking> FindByIdAsync(int id)
        {
            return await _context.Kickings.FindAsync(id);
        }
        public Task<Kicking> GetPlayerKickingByIdAsync(string PlayerId)
        {
            return await _context.Players..FirstOrDefaultAsync(p => p.PlayerId == PlayerId);
        }

        public void Update(Kicking kicking)
        {
            _context.Kickings.Update(kicking);
        }

        public void Remove(Kicking kicking)
        {
            _context.Kickings.Remove(kicking);
        }
    }
}