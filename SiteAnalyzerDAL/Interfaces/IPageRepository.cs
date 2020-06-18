using SiteAnalyzerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Interfaces
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetPages();
        void Create(Page page);
    }
}
