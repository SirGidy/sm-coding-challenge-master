using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class ReceivingRepository : BaseRepository,IReceivingRepository
    {
        public ReceivingRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Receiving>> ListAsync()
        {
           return await _context.Receivings.ToListAsync();
        }
        public async Task AddAsync(Receiving receiving)
        {
            await _context.Receivings.AddAsync(receiving);
        }

        public async Task<Receiving> FindByIdAsync(int id)
        {
            return await _context.Receivings.FindAsync(id);
        }

        public void Update(Receiving receiving)
        {
            _context.Receivings.Update(receiving);
        }

        public void Remove(Receiving receiving)
        {
            _context.Receivings.Remove(receiving);
        }
    }
}