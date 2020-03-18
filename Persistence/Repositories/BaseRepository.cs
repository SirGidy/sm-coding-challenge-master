using sm_coding_challenge.Persistence.Context;

namespace sm_coding_challenge.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    } 
}