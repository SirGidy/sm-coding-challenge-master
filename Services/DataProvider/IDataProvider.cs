using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services.DataProvider
{
    public interface IDataProvider
    {
        //Player GetPlayerById(string id);
        Task<DownloadTrackerResponse> FetchDetails(string id);
    }
}
