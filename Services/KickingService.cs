using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services
{
    public class KickingService : IKickingService
    {
        private readonly IKickingRepository _kickingRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public KickingService(IKickingRepository kickingRepository,  IUnitOfWork unitOfWork,IPlayerRepository playerRepository)
        {
            _kickingRepository = kickingRepository;
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Kicking>> ListAsync()
        {
           return await _kickingRepository.ListAsync();
        }
        public async Task<Kicking> FindByIdAsync(int id)
        {
            try
            {
                return await _kickingRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
               //log error
                return null;


            }

        }

        public async Task<KickingResource> SaveAsync(Kicking kicking )
        {
            // try
            // {
            //     var existingplayer = await _playerRepository.FindByIdAsync(kicking.PlayerId);

            //     if (existingplayer == null)
            //         return new ProductResponse("player not found.");
            //     await _kickingRepository.AddAsync(kicking);
            //     await _unitOfWork.CompleteAsync();

            //     return new KickingResource() ProductResponse(product);
            // }
            // catch (Exception ex)
            // {
            //     // Do some logging stuff
            //     return new ProductResponse($"An error occurred when saving the product: {ex.Message}");
            // }
            return new KickingResource();
        }

        

        

  
    }
}