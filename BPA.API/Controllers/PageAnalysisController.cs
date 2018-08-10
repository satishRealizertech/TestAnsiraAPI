using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BPAClassLibrary.Interface;
using BPA.Services;
using BPA.Core.Domain;
using BPAClassLibrary.Model;

namespace BPA.API.Controllers
{
    [RoutePrefix("api/PageAnalysis")]
    public class PageAnalysisController : ApiController
    {
        [HttpGet]
        [Route("GetAllDealersList")]
        public HttpResponseMessage GetAllDealersList()
        {
            var dealer = PageAnalysisOperations.GetAllDealers();
            return Request.CreateResponse(HttpStatusCode.OK, dealer);
        }
        [HttpGet]
        [Route("GetPageTypesList")]
        public HttpResponseMessage GetPageTypesList()
        {
            var pageType = PageAnalysisOperations.GetPageTypes();
            return Request.CreateResponse(HttpStatusCode.OK, pageType);
        }

        [HttpPost]
        [Route("PageAnalysisPageElement")]
        public HttpResponseMessage PageAnalysisPageElement(PageAnalysisRequestModel request)
        {
            var result = PageAnalysisOperations.ProcessPageAnalysisPageElement(request.dealer, request.PageId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
