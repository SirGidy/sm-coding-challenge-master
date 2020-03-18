using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Services.DataProvider
{
    public interface IDataProvider
    {
        Player GetPlayerById(string id);
    }
}
