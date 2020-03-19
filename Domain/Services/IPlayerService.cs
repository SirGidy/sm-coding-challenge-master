using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IPlayerService
    {
        Task<Player> FindByIdAsync(int id);
        Task<IEnumerable<Player>> ListAsync();
        Task<PlayerResource> SaveAsync(Player player);
        Task<PlayerDetailsResponse> GetPlayer(string PlayerId);
        Task<IList<PlayerDetailsResponse>> GetPlayers(List<string> PlayerIds);
        Task<LatestPlayerResponse> GetLatestPlayers(List<string> PlayerIds);
        

    }
}