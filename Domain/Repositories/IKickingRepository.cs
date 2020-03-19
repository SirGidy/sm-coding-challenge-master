using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IKickingRepository
    {
        Task<IEnumerable<Kicking>> ListAsync();
        Task AddAsync(Kicking kick);
        Task<Kicking> FindByIdAsync(int id);
        Task<IEnumerable<Kicking>> GetKickingsByPlayerIdAsync(string PlayerId);
        void Update(Kicking kick);
        void Remove(Kicking kick);

    }
}