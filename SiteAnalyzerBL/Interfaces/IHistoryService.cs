using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Interfaces
{
    public interface IHistoryService
    {
        IEnumerable<HistoryBL> GetHistory(string url);
        void CreateHistory(SiteBL site);
    }
}
