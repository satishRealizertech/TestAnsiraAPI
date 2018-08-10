using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;

namespace BPA.API.Controllers
{
    [RoutePrefix("api/PageType")]
    public class PageTypeController : ApiController
    {
        IPageTypeRepository _repository;
        public PageTypeController(IPageTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetPageTypes")]
        public HttpResponseMessage GetPageTypes()
        {
            var result = _repository.GetPageType();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreatePageType")]
        public HttpResponseMessage CreatePageType(PageTypes pageTypeData)
        {
            var result = _repository.CreatePageType(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("UpdatePageType")]
        public HttpResponseMessage UpdatePageType(PageTypes pageTypeData)
        {
            var result = _repository.UpdatePageType(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("DeletePageType")]
        public HttpResponseMessage DeletePageType(PageTypes pageTypeData)
        {
            var result = _repository.DeletePageType(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetBackbonePage")]
        public HttpResponseMessage GetBackbonePage()
        {
            var result = _repository.GetBackbonePageType();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateBackbonePage")]
        public HttpResponseMessage CreateBackbonePage(BackbonePageType pageTypeData)
        {
            var result = _repository.CreateBackbonePage(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("UpdateBackbonePage")]
        public HttpResponseMessage UpdateBackbonePage(BackbonePageType pageTypeData)
        {
            var result = _repository.UpdateBackbonePage(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("DeleteBackbonePage")]
        public HttpResponseMessage DeleteBackbonePage(BackbonePageType pageTypeData)
        {
            var result = _repository.DeleteBackbonePage(pageTypeData);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
