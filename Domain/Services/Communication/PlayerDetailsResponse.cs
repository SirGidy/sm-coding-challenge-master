using System.Collections.Generic;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services.Communication
{
    public class PlayerDetailsResponse : BaseResponse<PlayerResource>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="filelocation">Saved location.</param>
        /// <returns>Response.</returns>
        public PlayerDetailsResponse(PlayerResource resource) : base(resource)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PlayerDetailsResponse(string message) : base(message)
        { }
    }
}