using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Interfaces
{
    public interface ISiteSerivice
    {
        SiteBL GetSiteByUrl(string url);
        SiteBL Create(SiteBL site);
    }
}
