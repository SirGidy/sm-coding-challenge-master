using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Services;
using sm_coding_challenge.Services.DataProvider;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace sm_coding_challenge.Controllers
{
    public class HomeController : Controller
    {

        private  readonly IDataProvider _dataProvider;
        private readonly IPlayerService _playerService;
        private readonly IResponseCacheService _cache;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
    
        public HomeController(IOptions<AppSettings> appSettings,ILogger<HomeController> logger,IPlayerService playerService,IDataProvider dataProvider, IResponseCacheService cache)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            _cache = cache;
            _logger = logger;
            _appSettings = appSettings;
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
        /// <response code="304">Returns  if player have not been modifed since last fetch and retrieved from cache</response>
        /// <remarks>
        ///</remarks>
        [ProducesResponseType(200, Type = typeof(PlayerDetailsResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(304)]
        public async Task<IActionResult> Player(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Kindly specify player id");
                }

                PlayerDetailsResponse playerDetails =  await _cache.GetCachedObject<PlayerDetailsResponse>($"player-{id}");

                // If we have no cached details, then get the details from the database
                if (playerDetails == null)
                {
                    playerDetails = await _playerService.GetPlayer(id);
                }


                if (!playerDetails.Success)
                {
                    return NotFound(playerDetails);
                }
                //bool isModified =  await _cache.SetCachedObject($"player-{id}", playerDetails,TimeSpan.FromSeconds(600));
                bool isModified =  await _cache.SetCachedObject($"player-{id}", playerDetails,TimeSpan.FromSeconds( Convert.ToDouble(_appSettings.Value.TimeSpan)));
                if (isModified)
                {
                    return Ok(playerDetails);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotModified);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Error processing request{ex}" );
                return StatusCode(502);
            }




                 
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

       [HttpGet]
        /// <summary>
        /// This method is used to fetch details of players from Third-party API.</summary>
        /// <param name="id"> Id of player. </param>
        /// <returns>  </returns>
        /// <response code="200">Returns if the operation was successful.</response>
        /// <response code="400">Returns if parameter is not valid.</response>            
        /// <response code="404">Returns if url is invalid</response>
        /// <remarks>
        ///</remarks>
        [ProducesResponseType(200, Type = typeof(DownloadTrackerResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FetchDetails(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("Kindly specify url");
            }


            var fetchresult = await _dataProvider.FetchDetails(id);
            if (!fetchresult.Success)
            {
                return NotFound();
            }

            return Ok(fetchresult);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
