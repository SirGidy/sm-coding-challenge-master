using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> ListAsync();
        Task AddAsync(Player player);
        Task<Player> FindByIdAsync(int id);
        Task<Player> GetPlayerByIdAsync(string PlayerId);
        void Update(Player player);
        void Remove(Player player);

    }
}