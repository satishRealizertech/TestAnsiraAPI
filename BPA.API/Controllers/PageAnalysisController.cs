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
       
        [HttpPost]
        [Route("PageAnalysisPageElement")]
        public HttpResponseMessage PageAnalysisPageElement(PageAnalysisRequest request)
        {
            var result = PageAnalysisOperations.ExecutePageAnalysis(request);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
