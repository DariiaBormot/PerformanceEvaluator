using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly SiteContext _context;
        public PageRepository()
        {
            _context = new SiteContext();
        }

        public IEnumerable<Page> GetPages()
        {
            return _context.Pages.ToList();
        }

        public void Create(Page page)
        {
            _context.Pages.Add(page);
             _context.SaveChanges();
        }

        public Page Update(Page page) 
        {
            _context.Entry(page).State = EntityState.Modified;
            _context.SaveChanges();
            return page;
        }

        public int GetSlowestResponceTime(int siteId)
        {
            var result = _context.Pages.Where(x => x.SiteId == siteId)
                                 .Min(x => x.ResponseTime);
            return result;
        }

        public int GetFastestResponceTime(int siteId) 
        {
            var result = _context.Pages.Where(x => x.SiteId == siteId)
                                 .Max(x => x.ResponseTime);
            return result;
        }


    }
}
