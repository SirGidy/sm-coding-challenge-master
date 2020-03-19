using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services
{
    public class ReceivingService : IReceivingService
    {
        private readonly IReceivingRepository  _receivingRepository ;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ReceivingService(IReceivingRepository  receivingRepository,  IUnitOfWork unitOfWork,IPlayerRepository playerRepository)
        {
            _receivingRepository = receivingRepository;
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Receiving>> ListAsync()
        {
           return await _receivingRepository.ListAsync();
        }
        public async Task<Receiving> FindByIdAsync(int id)
        {
            try
            {
                return await _receivingRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }
        public async Task<IEnumerable<Receiving>> GetReceivingsByPlayerIdAsync(string PlayerId)
        {
            try
            {
                return await _receivingRepository.GetReceivingsByPlayerIdAsync(PlayerId);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }
        public async Task<Receiving> GetLatestReceivingByPlayerIdAsync(string PlayerId)
        {
            try
            {
                return await _receivingRepository.GetLatestReceivingByPlayerIdAsync(PlayerId);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<ReceivingResource> SaveAsync(Receiving receiving )
        {
         
            return new ReceivingResource();
        }
    }
}