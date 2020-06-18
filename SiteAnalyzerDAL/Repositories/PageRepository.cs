using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System;
using System.Collections.Generic;
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


    }
}
