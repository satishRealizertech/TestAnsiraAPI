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
    [RoutePrefix("api/Backbone")]
    public class BackboneController : ApiController
    {
        IBackboneRepository _repository;
        public BackboneController(IBackboneRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetBackboneData")]
        public HttpResponseMessage GetBackboneData()
        {
            var result = _repository.GetBackboneList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateBackboneData")]
        public bool CreateBackboneData(Backbone create)
        {
            var result = _repository.CreateBackbone(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateBackboneData")]
        public bool UpdateBackboneData(Backbone update)
        {
            var result = _repository.UpdateBackbone(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteBackboneData")]
        public bool DeleteBackboneData(Backbone delete)
        {
            var result = _repository.DeleteBackbone(delete);
            return result;
        }



        [HttpGet]
        [Route("GetBackbone")]
        public HttpResponseMessage GetBackbone()
        {
            var result = _repository.GetBackboneList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetBackboneIdentifier")]
        public HttpResponseMessage GetBackboneIdentifier()
        {
            var result = _repository.GetIdentifiersList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateBackboneIdentifier")]
        public HttpResponseMessage CreateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            var result = _repository.CreateBackboneIdentifier(backboneIdentifier);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        [Route("UpdateBackboneIdentifier")]
        public HttpResponseMessage UpdateBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            var result = _repository.UpdateBackboneIdentifier(backboneIdentifier);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpPost]
        [Route("DeleteBackboneIdentifier")]
        public HttpResponseMessage DeleteBackboneIdentifier(BackboneIdentifier backboneIdentifier)
        {
            var result = _repository.DeleteBackboneIdentifier(backboneIdentifier);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
