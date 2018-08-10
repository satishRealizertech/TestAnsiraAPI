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
    [RoutePrefix("api/BackbonePageElementIdentifier")]
    public class BackbonePageElementIdentifierController : ApiController
    {
            IBackbonePageElementIdentifierRepository _repository;
            public BackbonePageElementIdentifierController(IBackbonePageElementIdentifierRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            [Route("GetBackbonePageElementIdentifier")]
            public HttpResponseMessage GetBackbonePageElementIdentifier()
            {
                var result = _repository.GetBackbonePageElementIdentifierList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        [HttpPost]
        [Route("CreateBackbonePageElementIdentifier")]
        public bool CreateBackbonePageElementIdentifier(BackbonePageElementIdentifier create)
        {
            var result = _repository.CreateBackbonePageElementIdentifier(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateBackbonePageElementIdentifier")]
        public bool UpdateBackbonePageElementIdentifier(BackbonePageElementIdentifier update)
        {
            var result = _repository.UpdateBackbonePageElementIdentifier(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteBackbonePageElementIdentifier")]
        public bool DeleteBackbonePageElementIdentifier(BackbonePageElementIdentifier delete)
        {
            var result = _repository.DeleteBackbonePageElementIdentifier(delete);
            return result;
        }


    }
    }
    

