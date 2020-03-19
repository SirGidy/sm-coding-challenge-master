using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Domain.Repositories;
using sm_coding_challenge.Domain.Services;
using sm_coding_challenge.Domain.Services.Communication;
using sm_coding_challenge.Persistence.Context;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Services.DataProvider
{
    public class DataProviderImpl : IDataProvider
    {

        private readonly IOptions<AppSettings> _appSettings;
        private readonly IPlayerRepository _playerRepository;
         private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IDownloadTrackerService _downloadTrackerService;
        public DataProviderImpl(IOptions<AppSettings> appSettings,IDownloadTrackerService downloadTrackerService,IMapper mapper, AppDbContext context , IPlayerRepository playerRepository)
        {
            
            _playerRepository = playerRepository;
           _downloadTrackerService = downloadTrackerService;
            _appSettings = appSettings;
            _mapper = mapper;
            _context = context;
            
        }

        
        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);
        // This methos=d calls the third-party APIs to ingest data. It is assumed that this end point will be called 
        // at periodic intervals for example weekly by a scheduled job. We use the EFCore.BulkExtensions to perform
        // bulk insert into database, Bulk Insert works only with a relational database. 
        // Method shall be updated to check for existence and store new palyers and also update details stored in database alreacy.
        public async Task<DownloadTrackerResponse> FetchDetails(string id)
        {
            
            try
            {

                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = Timeout;
                    var response = client.GetAsync(_appSettings.Value.JSonURL.ToString()).Result;
                    var stringData = response.Content.ReadAsStringAsync().Result;
                    var dataResponse = JsonConvert.DeserializeObject<DataResponseModel>(stringData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    
                    List<Rushing> rushings = new List<Rushing>();

                    foreach (var player in dataResponse.Rushing)
                    {
                        var rush =   _mapper.Map<RushingResource, Rushing>(player);
                        rushings.Add(rush);

                      
                    }
                    _context.BulkInsert(rushings);

                    List<Passing> passings = new List<Passing>();

                    foreach (var player in dataResponse.Passing)
                    {
                        var passing =   _mapper.Map<PassingResource, Passing>(player);
                        passings.Add(passing);
                    }
                    _context.BulkInsert(passings);

                    List<Receiving> receivings = new List<Receiving>();
                    foreach (var player in dataResponse.Receiving)
                    {
                        var receiving =   _mapper.Map<ReceivingResource, Receiving>(player);
                        receivings.Add(receiving);
                    }
                    _context.BulkInsert(receivings);

                    List<Kicking> kickings = new List<Kicking>();

                    foreach (var player in dataResponse.Kicking)
                    {
                        var Kicking =   _mapper.Map<KickingResource, Kicking>(player);
                        kickings.Add(Kicking);
                    }

                   _context.BulkInsert(kickings);


                   DownloadTracker tracker = new DownloadTracker();
                   tracker.CompetitionName = dataResponse.CompetitionName;
                   tracker.PollingInterval = 0;
                   tracker.SeasonId =  dataResponse.SeasonId;
                   tracker.SportsName = dataResponse.SportName;
                   tracker.TimeStamp = DateTime.Now;
                   tracker.Week =   dataResponse.Week != null ? Convert.ToInt32(dataResponse.Week):0;

                   var result = await _downloadTrackerService.SaveAsync(tracker);
                   return result;
                    
                 
                }
            }
            catch(Exception ex)
            {
                //log error
                return new DownloadTrackerResponse("Error saving document details");
            }

    

        }

        // public async Task<DownloadTrackerResource> GetPlayer(string id)
        // {
        //     var handler = new HttpClientHandler()
        //     {
        //         AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        //     };
        //     using (var client = new HttpClient(handler))
        //     {
        //         client.Timeout = Timeout;
        //         var response = client.GetAsync("https://gist.githubusercontent.com/RichardD012/a81e0d1730555bc0d8856d1be980c803/raw/3fe73fafadf7e5b699f056e55396282ff45a124b/basic.json").Result;
        //         var stringData = response.Content.ReadAsStringAsync().Result;
        //         var dataResponse = JsonConvert.DeserializeObject<DataResponseModel>(stringData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        //         foreach(var player in dataResponse.Rushing)
        //         {
        //             if(player.Id.Equals(id))
        //             {
        //                 return player;
        //             }
        //         }
        //         foreach(var player in dataResponse.Passing)
        //         {
        //             if(player.Id.Equals(id))
        //             {
        //                 return player;
        //             }
        //         }
        //         foreach(var player in dataResponse.Receiving)
        //         {
        //             if(player.Id.Equals(id))
        //             {
        //                 return player;
        //             }
        //         }
        //         foreach(var player in dataResponse.Receiving)
        //         {
        //             if(player.Id.Equals(id))
        //             {
        //                 return player;
        //             }
        //         }
        //         foreach(var player in dataResponse.Kicking)
        //         {
        //             if(player.Id.Equals(id))
        //             {
        //                 return player;
        //             }
        //         }
        //     }
        //     return null;
        // }
    }
}
