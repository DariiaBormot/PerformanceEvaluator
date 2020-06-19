using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace SiteAnalyzerDAL.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly SiteContext _context;
        public SiteRepository()
        {
            _context = new SiteContext();
        }

        public Site GetSiteByUrl(string url)
        {
            var site = _context.Sites.Include(x => x.Pages).FirstOrDefault(x => x.Url == url);
            site.Pages = site.Pages.OrderBy(x => x.ResponseTime).ToList();
            return site;
        }

        public Site Create(Site site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
            return site;
        }

        public Site GetById(int id)
        {
           var site = _context.Sites.Include(x => x.Pages).FirstOrDefault(x => x.Id == id);
            return site;
        }

        public void Update(Site site)
        {
            var siteToUpdate = _context.Sites.FirstOrDefault(x => x.Id == site.Id);

            siteToUpdate.MaxResponseTime = site.MaxResponseTime;
            siteToUpdate.MinResponseTime = site.MinResponseTime;
            siteToUpdate.Url = site.Url;

            _context.SaveChanges();
        }

    }
}
