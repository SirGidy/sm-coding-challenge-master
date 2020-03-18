using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services
{
    public interface IPassingService
    {
        Task<Passing> FindByIdAsync(int id);
        Task<IEnumerable<Passing>> ListAsync();
        Task<PassingResource> SaveAsync(Passing passing);
    }
}