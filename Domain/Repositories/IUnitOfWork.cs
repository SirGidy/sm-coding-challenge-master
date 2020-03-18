using System.Threading.Tasks;

namespace sm_coding_challenge.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}