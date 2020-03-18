using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IDownloadTrackerRepository
    {
        Task<IEnumerable<DownloadTracker>> ListAsync();
        Task AddAsync(DownloadTracker tracker);
        Task<DownloadTracker> FindByIdAsync(int id);
        void Update(DownloadTracker tracker);
        void Remove(DownloadTracker tracker);

    }
}