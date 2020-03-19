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
    public class DownloadTrackerService : IDownloadTrackerService
    {
        private readonly IDownloadTrackerRepository  _downloadTrackerRepository ;
        private readonly IUnitOfWork _unitOfWork;
        
        public DownloadTrackerService(IDownloadTrackerRepository  downloadTrackerRepository,  IUnitOfWork unitOfWork)
        {
            _downloadTrackerRepository = downloadTrackerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DownloadTracker>> ListAsync()
        {
           return await _downloadTrackerRepository.ListAsync();
        }
        public async Task<DownloadTracker> FindByIdAsync(int id)
        {
            try
            {
                return await _downloadTrackerRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<DownloadTrackerResponse> SaveAsync(DownloadTracker downloadTracker )
        {
            var result = new DownloadTrackerResource();
            try
            {
                await _downloadTrackerRepository.AddAsync(downloadTracker);
                await _unitOfWork.CompleteAsync();
                

                return new DownloadTrackerResponse(downloadTracker) ;
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DownloadTrackerResponse($"Error saving document {downloadTracker.CompetitionName}");
            }

             
        }
    }
}