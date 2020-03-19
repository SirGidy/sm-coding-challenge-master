using System.Threading.Tasks;
using sm_coding_challenge.Persistence.Context;
using sm_coding_challenge.Domain.Repositories;
using EFCore.BulkExtensions;

namespace sm_coding_challenge.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}