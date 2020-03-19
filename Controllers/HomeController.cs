using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Services.DataProvider;

namespace sm_coding_challenge.Controllers
{
    public class HomeController : Controller
    {

        //private IDataProvider _dataProvider;
        private readonly IPlayerService _playerService;
        public HomeController(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        /// <summary>
        /// This method is used to fetch details of a player.</summary>
        /// <param name="id"> Id of player. </param>
        /// <returns>  </returns>
        /// <response code="200">Returns if the operation was successful.</response>
        /// <response code="400">Returns if parameter is not valid.</response>            
        /// <response code="404">Returns if player with Id does not exist.</response>
        /// <remarks>
        ///</remarks>
        [ProducesResponseType(200, Type = typeof(PlayerDetailsResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Player(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("Kindly specify player id");
            }
            var playerdetails = await _playerService.GetPlayer(id);

            if ( ! playerdetails.Success )
            {
                return  NotFound(playerdetails);
            }

            return Ok(playerdetails);
                 
        }

        [HttpGet]
        /// <summary>
        /// This method is used to fetch details of players specified in id list.</summary>
        /// <param name="ids"> list of player Ids </param>
        /// <returns>  </returns>
        /// <response code="200">Returns if the operation was successful.</response>
        /// <response code="400">Returns if parameter is not valid.</response>            
        /// <response code="404">Returns if no id in the list returns result.</response>
        /// <remarks>
        ///</remarks>
        [ProducesResponseType(200, Type = typeof(IList<PlayerDetailsResponse>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Players(string ids)
        {
            if(string.IsNullOrEmpty(ids))
            {
                return BadRequest("Kindly specify player id");
            }
            var idList = ids.Split(',').ToList();
            var playerdetails = await _playerService.GetPlayers(idList);
            if ( playerdetails == null)
            {
                return  NotFound();
            }

            return Ok(playerdetails);
            
        }

        [HttpGet]
        /// <summary>
        /// This method is used to fetch the latest details of players specified in id list.</summary>
        /// <param name="ids"> list of player Ids </param>
        /// <returns>  </returns>
        /// <response code="200">Returns if the operation was successful.</response>
        /// <response code="400">Returns if parameter is not valid.</response>            
        /// <response code="404">Returns if no id in the list returns result.</response>
        /// <remarks>
        ///</remarks>
        [ProducesResponseType(200, Type = typeof(IList<PlayerDetailsResponse>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult>  LatestPlayers(string ids)
        {
            if(string.IsNullOrEmpty(ids))
            {
                return BadRequest("Kindly specify player id");
            }
            var idList = ids.Split(',').ToList();
            var playerdetails = await _playerService.GetLatestPlayers(idList);
            if ( playerdetails == null)
            {
                return  NotFound();
            }

            return Ok(playerdetails);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
