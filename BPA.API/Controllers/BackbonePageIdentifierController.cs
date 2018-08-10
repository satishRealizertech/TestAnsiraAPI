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
    [RoutePrefix("api/BackbonePageIdentifier")]
    public class BackbonePageIdentifierController : ApiController
    {
        IBackbonePageIdentifierRepository _repository;
        public BackbonePageIdentifierController(IBackbonePageIdentifierRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetBackbonePageIdentifierData")]
        public HttpResponseMessage GetBackbonePageIdentifierData()
        {
            var result = _repository.GetBackbonePageIdentifierList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateBackbonePageIdentifierData")]
        public bool CreateBackbonePageIdentifierData(BackbonePageIdentifier create)
        {
            var result = _repository.CreateBackbonePageIdentifier(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateBackbonePageIdentifierData")]
        public bool UpdateBackbonePageIdentifierData(BackbonePageIdentifier update)
        {
            var result = _repository.UpdateBackbonePageIdentifier(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteBackbonePageIdentifierData")]
        public bool DeleteBackbonePageIdentifierData(BackbonePageIdentifier delete)
        {
            var result = _repository.DeleteBackbonePageIdentifier(delete);
            return result;
        }
    }
}
