using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Interfaces
{
    public interface IRequestService
    {
        IEnumerable<PageBL> MeasureResponseTime(IEnumerable<PageBL> pages);
    }
}
