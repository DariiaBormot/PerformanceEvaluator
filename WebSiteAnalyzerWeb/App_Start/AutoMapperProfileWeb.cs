using AutoMapper;
using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteAnalyzerWeb.Models;

namespace WebSiteAnalyzerWeb.App_Start
{
    public class AutoMapperProfileWeb : Profile
    {
        public AutoMapperProfileWeb()
        {
            CreateMap<PageBL, WebPageViewModel>().ReverseMap();
            CreateMap<SiteBL, WebSiteViewModel>().ReverseMap();
            CreateMap<HistoryBL, HistoryViewModel>().ReverseMap();
        }

    }
}