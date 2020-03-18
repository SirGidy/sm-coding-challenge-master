using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IPassingRepository
    {
        Task<IEnumerable<Passing>> ListAsync();
        Task AddAsync(Passing pass);
        Task<Passing> FindByIdAsync(int id);
        void Update(Passing pass);
        void Remove(Passing pass);

    }
}