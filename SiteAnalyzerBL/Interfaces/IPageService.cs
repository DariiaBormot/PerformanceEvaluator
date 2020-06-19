using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Interfaces
{
    public interface IPageService
    {
        IEnumerable<PageBL> GetPages();
        void Create(PageBL page);
        int GetFastestResponceTime(int siteId);
        int GetSlowestResponceTime(int siteId); 
    }
}
