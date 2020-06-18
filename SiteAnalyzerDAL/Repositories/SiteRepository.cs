using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System.Linq;
using System.Data.Entity;


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
            return _context.Sites.Include(x => x.Pages).FirstOrDefault(x => x.Url == url);
        }

        public Site Create(Site site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
            return site;
        }

    }
}
