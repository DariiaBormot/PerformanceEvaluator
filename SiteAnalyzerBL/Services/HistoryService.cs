using AutoMapper;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _historyRepository = historyRepository;
        }

        public void CreateHistory(SiteBL site) 
        {
            var history = new HistoryBL
            {
                Date = DateTime.Now,
                MaxResponseTime = site.MaxResponseTime,
                MinResponseTime = site.MinResponseTime,
                SiteId = site.Id,
                SiteURL = site.Url
            };

            var historyToCreate = _mapper.Map<History>(history);
            _historyRepository.Create(historyToCreate);
        }

        public IEnumerable<HistoryBL> GetHistory(string url)
        {
            var historiesDAL = _historyRepository.GetHistory(url);
            var historiesBL = _mapper.Map<IEnumerable<HistoryBL>>(historiesDAL);
            return historiesBL;
        }
    }
}
