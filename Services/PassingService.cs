using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services
{
    public class PassingService : IPassingService
    {
        private readonly IPassingRepository  _passingRepository ;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PassingService(IPassingRepository  passingRepository,  IUnitOfWork unitOfWork,IPlayerRepository playerRepository)
        {
            _passingRepository = passingRepository;
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Passing>> ListAsync()
        {
           return await _passingRepository.ListAsync();
        }
        public async Task<Passing> FindByIdAsync(int id)
        {
            try
            {
                return await _passingRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<PassingResource> SaveAsync(Passing passing )
        {
         
            return new PassingResource();
        }
    }
}