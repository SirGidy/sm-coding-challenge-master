using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services
{
    public class RushingService : IRushingService
    {
        private readonly IRushingRepository  _rushingRepository ;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RushingService(IRushingRepository  rushingRepository,  IUnitOfWork unitOfWork,IPlayerRepository playerRepository)
        {
            _rushingRepository= rushingRepository;
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Rushing>> ListAsync()
        {
           return await _rushingRepository.ListAsync();
        }
        public async Task<Rushing> FindByIdAsync(int id)
        {
            try
            {
                return await _rushingRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<RushingResource> SaveAsync(Rushing rushing )
        {
         
            return new RushingResource();
        }
    }
}