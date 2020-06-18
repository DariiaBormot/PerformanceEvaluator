using AutoMapper;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;

namespace SiteAnalyzerBL.Services
{
    public class SiteSerivice : ISiteSerivice
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        public SiteSerivice(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public SiteBL Create(SiteBL site)
        {
            var siteToCreate = _mapper.Map<Site>(site);
            var siteDAL = _siteRepository.Create(siteToCreate);
            var siteBL = _mapper.Map<SiteBL>(siteDAL);
            return siteBL;
        }

        public SiteBL GetSiteByUrl(string url)
        {
            var siteDAL = _siteRepository.GetSiteByUrl(url);
            var siteBL = _mapper.Map<SiteBL>(siteDAL);
            return siteBL;
        }
    }
}
