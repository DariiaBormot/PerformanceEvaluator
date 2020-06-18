using System.Web.Mvc;
using SiteAnalyzerBL.Interfaces;
using WebSiteAnalyzerWeb.Models;
using AutoMapper;
using SiteAnalyzerBL.Models;
using Antlr.Runtime.Misc;
using System.Linq;

namespace WebSiteAnalyzerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrawlerService _crawlerService;
        private readonly ISitemapService _sitemapService;
        private readonly ISiteSerivice _siteSerivice;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;
        public HomeController(ICrawlerService crawlerService, 
            ISitemapService sitemapService, IRequestService requestService, 
            ISiteSerivice siteService, IMapper mapper, IPageService pageService)
        {
            _crawlerService = crawlerService;
            _sitemapService = sitemapService;
            _siteSerivice = siteService;
            _requestService = requestService;
            _mapper = mapper;
            _pageService = pageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(WebSiteViewModel model)
        {
            var linkds = _crawlerService.GetPageLinks(model.Url);

            var sitemap = _sitemapService.GetPages(linkds, model.Url);

            var measuredPaged = _requestService.MeasureResponseTime(sitemap);

            var siteModel = _mapper.Map<SiteBL>(model);

            var site = _siteSerivice.Create(siteModel);

            _pageService.SavePagesToDB(measuredPaged, site.Id);

            var orderedResponces = measuredPaged.OrderByDescending(x => x.MinResponseTime);

            site.Pages = orderedResponces;

            //var siteBL = _siteSerivice.GetSiteByUrl(siteModel.Url);

            //var sitePL = _mapper.Map<WebSiteViewModel>(siteBL);


            return View(site);
        }

        [HttpGet]
        public ActionResult GetHistory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetHistory(string url)
        {
            var history = _siteSerivice.GetSiteByUrl(url);

            var historyPL = _mapper.Map<WebSiteViewModel>(history);

            return View(historyPL);
        }

    }
}