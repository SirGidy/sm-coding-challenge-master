using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IDownloadTrackerService
    {
        Task<DownloadTracker> FindByIdAsync(int id);
        Task<IEnumerable<DownloadTracker>> ListAsync();
        Task<DownloadTrackerResponse> SaveAsync(DownloadTracker downloadTracker);
    }
}