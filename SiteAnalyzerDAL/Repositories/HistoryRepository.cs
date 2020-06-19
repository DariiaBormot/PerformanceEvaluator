using SiteAnalyzerDAL.Entities;
using SiteAnalyzerDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly SiteContext _context;
        public HistoryRepository()
        {
            _context = new SiteContext();
        }

        public void Create(History history)
        {
            _context.Histories.Add(history);
            _context.SaveChanges();
        }

        public IEnumerable<History> GetHistory(string url)
        {
            var history = _context.Histories.Where(x => x.SiteURL == url).ToList();
            return history;
        }
    }
}
