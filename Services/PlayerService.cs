using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public PlayerService(IUnitOfWork unitOfWork,IPlayerRepository playerRepository)
        {
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Player>> ListAsync()
        {
           return await _playerRepository.ListAsync();
        }
        public async Task<PlayerDetailsResponse> GetPlayer(string PlayerId)
        {
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
                    PlayerResource resource = new PlayerResource();
                    resource.Name = playerdetails.Name;
                    resource.PlayerId = PlayerId;
                    resource.Position = playerdetails.Position;
                    resource.kicking =
                    PlayerDetailsResponse result = new PlayerDetailsResponse();


                }

        

            }
            catch(Exception ex)
            {

            }
           
           return await _playerRepository.ListAsync();
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