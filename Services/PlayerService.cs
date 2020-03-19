using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKickingService _kickingService;
        private readonly IRushingService _rushingService;
        private readonly IPassingService _passingService;
        private readonly IReceivingService _receivingService;
        
        public PlayerService(IUnitOfWork unitOfWork,IPlayerRepository playerRepository, IKickingService kickingService, IRushingService rushingService , IPassingService passingService,IReceivingService receivingService)
        {
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
            _kickingService = kickingService;
            _rushingService = rushingService;
            _passingService = passingService;
            _receivingService = receivingService;
            

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
                    // Fetch all players kickins and map object returned to Resource.
                    var kickings =  await _kickingService.GetKickingsByPlayerIdAsync(PlayerId);
                    if(kickings != null)
                    {
                        // fix mapping
                        //var kickingresource =  Mapper.Map<IEnumerable<KickingResource>, IEnumerable<Kicking>>(kickings);
                        resource.kicking =   kickings;
                    }

                    // Fetch all players rushing.
                    var rushings =  await _rushingService.GetRushingsByPlayerIdAsync(PlayerId);
                    if(rushings != null)
                    {
                        resource.rushing = rushings;
                    }
                    //Fetch all player passing.
                    var passings =  await _passingService.GetPassingsByPlayerIdAsync(PlayerId);
                    if(passings != null)
                    {
                        resource.passing = passings;
                    }
                    //Fetch all player receivings.
                    var receivings =  await _receivingService.GetReceivingsByPlayerIdAsync(PlayerId);
                    if(receivings != null)
                    {
                        resource.receiving = receivings;
                    }


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
                            // fix mapping
                            //var kickingresource =  Mapper.Map<IEnumerable<KickingResource>, IEnumerable<Kicking>>(kickings);
                            resource.kicking = kickings;
                        }

                        // Fetch all players rushing.
                        var rushings = await _rushingService.GetRushingsByPlayerIdAsync(PlayerId);
                        if (rushings != null)
                        {
                            resource.rushing = rushings;
                        }
                        //Fetch all player passing.
                        var passings = await _passingService.GetPassingsByPlayerIdAsync(PlayerId);
                        if (passings != null)
                        {
                            resource.passing = passings;
                        }
                        //Fetch all player receivings.
                        var receivings = await _receivingService.GetReceivingsByPlayerIdAsync(PlayerId);
                        if (receivings != null)
                        {
                            resource.receiving = receivings;
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
                            RushingResource rushingresource = new RushingResource();

                            rushingresource.Name = playerdetails.Name;
                            rushingresource.PlayerId = PlayerId;
                            rushingresource.Position = playerdetails.Position;
                            rushingresource.Att = rushing.Att;
                            rushingresource.EntryId = rushing.EntryId;
                            rushingresource.Fum = rushing.Fum;
                            rushingresource.Tds = rushing.Tds;
                            rushingresource.Yds = rushing.Yds;

                            rushingResources.Add(rushingresource);
                        }
                       
                        //Fetch all player receivings.
                        var receiving = await _receivingService.GetLatestReceivingByPlayerIdAsync(PlayerId);
                        if (receiving != null)
                        {
                            ReceivingResource receivingResource = new ReceivingResource();
                            receivingResource.EntryId = receiving.EntryId;
                            receivingResource.Name = playerdetails.Name;
                            receivingResource.PlayerId = PlayerId;
                            receivingResource.Position = playerdetails.Position;
                            receivingResource.Rec = receiving.Rec;
                            receivingResource.Tds = receiving.Tds;
                            receivingResource.Yds = receiving.Yds;

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