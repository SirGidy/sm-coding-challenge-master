using System.Collections.Generic;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services.Communication
{
    public class DownloadTrackerResponse : BaseResponse<DownloadTracker>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="filelocation">Saved location.</param>
        /// <returns>Response.</returns>
        public DownloadTrackerResponse(DownloadTracker resource) : base(resource)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DownloadTrackerResponse(string message) : base(message)
        { }
    }
}