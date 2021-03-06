using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IReceivingService
    {
        Task<Receiving> FindByIdAsync(int id);
        Task<IEnumerable<Receiving>> ListAsync();
        Task<IEnumerable<Receiving>> GetReceivingsByPlayerIdAsync(string PlayerId);
        Task<Receiving> GetLatestReceivingByPlayerIdAsync(string PlayerId);
        Task<ReceivingResource> SaveAsync(Receiving receiving );
    }
}