using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IRushingService
    {
        Task<Rushing> FindByIdAsync(int id);
        Task<IEnumerable<Rushing>> ListAsync();
        Task<IEnumerable<Rushing>> GetRushingsByPlayerIdAsync(string PlayerId);
        Task<Rushing> GetLatestRushingByPlayerIdAsync(string PlayerId);
        Task<RushingResource> SaveAsync(Rushing rushing);
    }
}