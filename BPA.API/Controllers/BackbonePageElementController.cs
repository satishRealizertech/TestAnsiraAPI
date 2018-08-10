using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BPA.API.Controllers
{
    [RoutePrefix("api/BackbonePageElement")]
    public class BackbonePageElementController : ApiController
    {
        IBackbonePageElementRepository _repository;
        public BackbonePageElementController(IBackbonePageElementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetBackbonePageElementData")]
        public HttpResponseMessage GetBackbonePageElementData()
        {
            var result = _repository.GetBackbonePageElementList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateBackbonePageElementData")]
        public bool CreateBackbonePageElementData(BackbonePageElement create)
        {
            var result = _repository.CreateBackbonePageElement(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateBackbonePageElementData")]
        public bool UpdateBackbonePageElementData(BackbonePageElement update)
        {
            var result = _repository.UpdateBackbonePageElement(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteBackbonePageElementData")]
        public bool DeleteBackbonePageElementData(BackbonePageElement delete)
        {
            var result = _repository.DeleteBackbonePageElement(delete);
            return result;
        }
    }
}
