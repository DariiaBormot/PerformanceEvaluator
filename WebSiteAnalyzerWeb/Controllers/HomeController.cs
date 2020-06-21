using System.Web.Mvc;
using SiteAnalyzerBL.Interfaces;
using WebSiteAnalyzerWeb.Models;
using AutoMapper;
using SiteAnalyzerBL.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSiteAnalyzerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrawlerService _crawlerService;
        private readonly ISitemapService _sitemapService;
        private readonly ISiteSerivice _siteSerivice;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly IHistoryService _historyService;

        public HomeController(ICrawlerService crawlerService,
            ISitemapService sitemapService, IRequestService requestService,
            ISiteSerivice siteService, IMapper mapper, IHistoryService historyService)
        {
            _crawlerService = crawlerService;
            _sitemapService = sitemapService;
            _siteSerivice = siteService;
            _requestService = requestService;
            _mapper = mapper;
            _historyService = historyService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(WebSiteViewModel model)
        {
            var links = _crawlerService.GetPageLinks(model.Url);

            var sitemap = _sitemapService.GetPages(links, model.Url);

            var measuredPages = _requestService.MeasureResponseTime(sitemap);

            var siteModelBL = _mapper.Map<SiteBL>(model);

            var site = _siteSerivice.SaveSiteAndPages(measuredPages, siteModelBL);

            _historyService.CreateHistory(site);

            var sitePL = _mapper.Map<WebSiteViewModel>(site);

            //Chart

            var pagesList = site.Pages;

            var speedsDistinct = pagesList.Select(x => x.ResponseTime).Distinct();

            var countTime = new List<int>();

            foreach (var item in speedsDistinct)
            {
                countTime.Add(pagesList.Count(x => x.ResponseTime == item));
            }

            ViewBag.Speeds = speedsDistinct.ToList();
            ViewBag.Repart = countTime;

            return View(sitePL); 
        }


        [HttpGet]
        public ActionResult History(string url)
        {
            var history = _historyService.GetHistory(url);

            var historyPL = _mapper.Map<IEnumerable<HistoryViewModel>>(history);

            return View(historyPL);
        }


    }
}