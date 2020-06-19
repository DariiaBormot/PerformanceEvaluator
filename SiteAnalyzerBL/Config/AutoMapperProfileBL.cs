using AutoMapper;
using SiteAnalyzerBL.Models;
using SiteAnalyzerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Config
{
    public class AutoMapperProfileBL : Profile
    {
        public AutoMapperProfileBL()
        {
            CreateMap<Page, PageBL>().ReverseMap();
            CreateMap<Site, SiteBL>().ReverseMap();
            CreateMap<History, HistoryBL>().ReverseMap();
        }
    }
}
