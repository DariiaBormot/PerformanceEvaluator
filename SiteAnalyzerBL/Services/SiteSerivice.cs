using AutoMapper;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Services
{
    public class SiteSerivice : ISiteSerivice
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        private readonly IPageRepository _pageRepository;
        public SiteSerivice(ISiteRepository siteRepository, IMapper mapper, IPageRepository pageRepository)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
            _pageRepository = pageRepository;
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

        public void Update(SiteBL site)
        {
            var siteToUpdate = _mapper.Map<Site>(site);
            _siteRepository.Update(siteToUpdate);

        }

        public SiteBL SaveSite(IEnumerable<PageBL> pages, SiteBL siteModel)
        {
            var site = Create(siteModel);

            foreach (var page in pages)
            {
                if (page != null)
                {
                    page.SiteId = site.Id;
                    var pageToCreate = _mapper.Map<Page>(page);
                    _pageRepository.Create(pageToCreate);
                }
            }

            site.MaxResponseTime = _pageRepository.GetFastestResponceTime(site.Id);

            site.MinResponseTime = _pageRepository.GetSlowestResponceTime(site.Id);

            var siteToUpdate = _mapper.Map<Site>(site);

            _siteRepository.Update(siteToUpdate);

            var siteWithLinks = _siteRepository.GetById(siteToUpdate.Id);

            var siteToReturn = _mapper.Map<SiteBL>(siteWithLinks);

            return siteToReturn;
        }

    }
}
