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
        void Update(Receiving receiving);
        void Remove(Receiving receiving);

    }
}