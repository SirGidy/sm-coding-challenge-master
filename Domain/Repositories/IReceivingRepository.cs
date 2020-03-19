using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IReceivingRepository
    {
        Task<IEnumerable<Receiving>> ListAsync();
        Task AddAsync(Receiving receiving);
        Task<Receiving> FindByIdAsync(int id);
        Task<IEnumerable<Receiving>> GetReceivingsByPlayerIdAsync(string PlayerId);
        Task<Receiving> GetLatestReceivingByPlayerIdAsync(string PlayerId);
        // Task<IEnumerable<Receiving>> GetReceivingsByPlayerIdsAsync(IList<string> PlayerId);
        void Update(Receiving receiving);
        void Remove(Receiving receiving);

    }
}