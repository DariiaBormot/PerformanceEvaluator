using AutoMapper;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using SiteAnalyzerDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;
        public PageService(IPageRepository pageRepository, IMapper mapper)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
        }

        public void Create(PageBL page)
        {
            var pageToCreate = _mapper.Map<Page>(page);
            _pageRepository.Create(pageToCreate);
        }

        public IEnumerable<PageBL> GetPages()
        {
            var pagesDAL = _pageRepository.GetPages();
            var pagesBL = _mapper.Map<IEnumerable<PageBL>>(pagesDAL);
            return pagesBL;
        }

        public void SavePagesToDB(IEnumerable<PageBL> pages, int siteId) 
        {
            foreach (var page in pages)
            {
                if (page != null)
                {
                    page.SiteId = siteId;
                    var pageToCreate = _mapper.Map<Page>(page);
                    _pageRepository.Create(pageToCreate);
                }
            }
        }
    }
}
