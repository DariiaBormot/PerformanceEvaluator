﻿using SiteAnalyzerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Interfaces
{
    public interface ISiteRepository
    {
        Site GetSiteByUrl(string url);
        Site Create(Site site);
        void Update(Site site);
        Site GetById(int id);
    }
}
