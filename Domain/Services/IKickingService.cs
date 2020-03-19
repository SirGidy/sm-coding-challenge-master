using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IKickingService
    {
        Task<Kicking> FindByIdAsync(int id);
        Task<IEnumerable<Kicking>> GetKickingsByPlayerIdAsync(string PlayerId);
        Task<IEnumerable<Kicking>> ListAsync();
        Task<KickingResource> SaveAsync(Kicking kicking);
    }
}