using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IKickingService _kickingService;
        private readonly IRushingService _rushingService;
        private readonly IPassingService _passingService;
        private readonly IReceivingService _receivingService;
        private readonly ILogger<PlayerService> _logger;
        private readonly IMapper _mapper;
        
        public PlayerService( IMapper mapper,ILogger<PlayerService> logger,IPlayerRepository playerRepository, IKickingService kickingService, IRushingService rushingService , IPassingService passingService,IReceivingService receivingService)
        {
            _playerRepository = playerRepository;
            _kickingService = kickingService;
            _rushingService = rushingService;
            _passingService = passingService;
            _receivingService = receivingService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
           return await _playerRepository.ListAsync();
        }
 
        public async Task<PlayerDetailsResponse> GetPlayer(string PlayerId)
        { 
            PlayerResource resource = new PlayerResource();
            try{
                
                if (string.IsNullOrEmpty(PlayerId))
                {
                    return new PlayerDetailsResponse("Kindly specify player id");

                }

                var playerdetails = await _playerRepository.GetPlayerByIdAsync(PlayerId);
                if(playerdetails == null)
                {
                    return new PlayerDetailsResponse("Kindly specify valid player id");
                }
                else
                {
                    resource.Name = playerdetails.Name;
                    resource.PlayerId = PlayerId;
                    resource.Position = playerdetails.Position;
                    // Fetch all players kickings and map object returned to Resource.
                    var kickings =  await _kickingService.GetKickingsByPlayerIdAsync(PlayerId);
                    if(kickings != null)
                    {
                        var kickingresource =  _mapper.Map<IEnumerable<Kicking>,IEnumerable<KickingResource>>(kickings);
                        resource.kicking =   kickingresource;
                    }

                    // Fetch all players rushing.
                    var rushings =  await _rushingService.GetRushingsByPlayerIdAsync(PlayerId);
                    if(rushings != null)
                    {
                        var rushingresource =  _mapper.Map<IEnumerable<Rushing>,IEnumerable<RushingResource>>(rushings);
                        resource.rushing = rushingresource;
                    }
                    //Fetch all player passing.
                    var passings =  await _passingService.GetPassingsByPlayerIdAsync(PlayerId);
                    if(passings != null)
                    {
                        var passingresource =  _mapper.Map<IEnumerable<Passing>,IEnumerable<PassingResource>>(passings);
                        resource.passing = passingresource;
                    }
                    //Fetch all player receivings.
                    var receivings =  await _receivingService.GetReceivingsByPlayerIdAsync(PlayerId);
                    if(receivings != null)
                    {
                        var receivingresource =  _mapper.Map<IEnumerable<Receiving>,IEnumerable<ReceivingResource>>(receivings);
                        resource.receiving = receivingresource;
                    }

                    _logger.LogInformation("Player {@resource} retrieved", resource);


                }

        

            }
            catch(Exception ex)
            {

            }
           
           return new PlayerDetailsResponse(resource);
        }

        public async Task<IList<PlayerDetailsResponse>> GetPlayers(List<string> PlayerIds)
        { 
             var response =  new List<PlayerDetailsResponse>();
            
            try{
                foreach (var PlayerId in PlayerIds)
                {
                    PlayerResource resource = new PlayerResource();
                    if (string.IsNullOrEmpty(PlayerId))
                    {
                       response.Add(new PlayerDetailsResponse("Kindly specify player id"));

                    }

                    var playerdetails = await _playerRepository.GetPlayerByIdAsync(PlayerId);
                    if (playerdetails == null)
                    {
                        response.Add( new PlayerDetailsResponse($"Kindly specify valid player id : {PlayerId}"));
                    }
                    else
                    {
                        resource.Name = playerdetails.Name;
                        resource.PlayerId = PlayerId;
                        resource.Position = playerdetails.Position;
                        // Fetch all players kickins and map object returned to Resource.
                        var kickings = await _kickingService.GetKickingsByPlayerIdAsync(PlayerId);
                        if (kickings != null)
                        {
                            var kickingresource = _mapper.Map<IEnumerable<Kicking>, IEnumerable<KickingResource>>(kickings);
                            resource.kicking = kickingresource;
                            
                        }
                        
                        // Fetch all players rushing.
                        var rushings = await _rushingService.GetRushingsByPlayerIdAsync(PlayerId);
                        if (rushings != null)
                        {
                            var rushingresource = _mapper.Map<IEnumerable<Rushing>, IEnumerable<RushingResource>>(rushings);
                            resource.rushing = rushingresource;
                        }
                        //Fetch all player passing.
                        var passings = await _passingService.GetPassingsByPlayerIdAsync(PlayerId);
                        if (passings != null)
                        {
                            var passingresource = _mapper.Map<IEnumerable<Passing>, IEnumerable<PassingResource>>(passings);
                            resource.passing = passingresource;
                        }
                        //Fetch all player receivings.
                        var receivings = await _receivingService.GetReceivingsByPlayerIdAsync(PlayerId);
                        if (receivings != null)
                        {
                            var receivingresource = _mapper.Map<IEnumerable<Receiving>, IEnumerable<ReceivingResource>>(receivings);
                            resource.receiving = receivingresource;
                        }


                        response.Add(new PlayerDetailsResponse(resource));

                    }

                }
                

        

            }
            catch(Exception ex)
            {

            }
           
           return response;
        }
        
        // This method fetches the latest data about a player on the database
        public async Task<LatestPlayerResponse> GetLatestPlayers(List<string> PlayerIds)
        {
            
            var rushingResources = new List<RushingResource>();
            var receivingResources = new List<ReceivingResource>();
            try{
                foreach (var PlayerId in PlayerIds)
                {
                    
                    if (string.IsNullOrEmpty(PlayerId))
                    {
                       continue;

                    }

                    var playerdetails = await _playerRepository.GetPlayerByIdAsync(PlayerId);
                    if (playerdetails == null)
                    {
                        continue;
                    }
                    else
                    {

                        // Fetch latest player rushing.
                        var rushing = await _rushingService.GetLatestRushingByPlayerIdAsync(PlayerId);
                        if (rushing != null)
                        {
                            RushingResource rushingresource =  _mapper.Map<Rushing,RushingResource>(rushing);//  new RushingResource();

                            rushingresource.Name = playerdetails.Name;
                            //rushingresource.PlayerId = PlayerId;
                            rushingresource.Position = playerdetails.Position;
                            // rushingresource.Att = rushing.Att;
                            // rushingresource.EntryId = rushing.EntryId;
                            // rushingresource.Fum = rushing.Fum;
                            // rushingresource.Tds = rushing.Tds;
                            // rushingresource.Yds = rushing.Yds;

                            rushingResources.Add(rushingresource);
                        }
                       
                        //Fetch all player receivings.
                        var receiving = await _receivingService.GetLatestReceivingByPlayerIdAsync(PlayerId);
                        if (receiving != null)
                        {
                            ReceivingResource receivingResource = _mapper.Map<Receiving,ReceivingResource>(receiving);//new ReceivingResource();
                            // receivingResource.EntryId = receiving.EntryId;
                            receivingResource.Name = playerdetails.Name;
                            // receivingResource.PlayerId = PlayerId;
                            receivingResource.Position = playerdetails.Position;
                            // receivingResource.Rec = receiving.Rec;
                            // receivingResource.Tds = receiving.Tds;
                            // receivingResource.Yds = receiving.Yds;

                            receivingResources.Add(receivingResource);
                            

                        }
                        

                    }

                }
            }
            catch(Exception ex)
            {

            }

            if(receivingResources.Count > 0 || rushingResources.Count > 0)
            {
                return new LatestPlayerResponse( receivingResources, rushingResources);

            }
            else
            {
                return new LatestPlayerResponse("Could not fetch latest players");
            }
           
        }
        public async Task<Player> FindByIdAsync(int id)
        {
            try
            {
                return await _playerRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<PlayerResource> SaveAsync(Player player  )
        {
         
            return new PlayerResource();
        }
    }
}