using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class DownloadTrackerRepository : BaseRepository,IDownloadTrackerRepository
    {
        public DownloadTrackerRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<DownloadTracker>> ListAsync()
        {
           return await _context.DownloadTrackers.ToListAsync();
        }
        public async Task AddAsync(DownloadTracker downloadTracker)
        {
            await _context.DownloadTrackers.AddAsync(downloadTracker);
        }

        public async Task<DownloadTracker> FindByIdAsync(int id)
        {
            return await _context.DownloadTrackers.FindAsync(id);
        }

        public void Update(DownloadTracker downloadTracker)
        {
            _context.DownloadTrackers.Update(downloadTracker);
        }

        public void Remove(DownloadTracker downloadTracker)
        {
            _context.DownloadTrackers.Remove(downloadTracker);
        }
    }
}