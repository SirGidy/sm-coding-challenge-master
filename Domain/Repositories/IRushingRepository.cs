using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IRushingRepository
    {
        Task<IEnumerable<Rushing>> ListAsync();
        Task AddAsync(Rushing rushing);
        Task<Rushing> FindByIdAsync(int id);
        Task<IEnumerable<Rushing>> GetRushingsByPlayerIdAsync(string PlayerId);
        Task<Rushing> GetLatestRushingByPlayerIdAsync(string PlayerId);
        void Update(Rushing rushing);
        void Remove(Rushing rushing);

    }
}