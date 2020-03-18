using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class PlayerRepository : BaseRepository,IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
           return await _context.Players.ToListAsync();
        }
        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
        }

        public async Task<Player> FindByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }
        public async Task<Player> GetPlayerByIdAsync(string PlayerId )
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == PlayerId);
          
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);
        }

        public void Remove(Player player)
        {
            _context.Players.Remove(player);
        }
    }
}